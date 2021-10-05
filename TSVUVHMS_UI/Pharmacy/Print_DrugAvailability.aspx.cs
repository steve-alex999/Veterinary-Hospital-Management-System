using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Net.Mime;
using System.Text;
using System.IO;
using System.Drawing;
using System.Data;
using Microsoft.Reporting.WebForms;
using VHMS_BL;

public partial class Pharmacy_Print_DrugAvailability : System.Web.UI.Page
{
    
    PharmacyBAL ojPhar = new PharmacyBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    private int m_currentPageIndex;
    private IList<Stream> m_streams;
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try{
            getReport();
            }


            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }
    }

    public void getReport()
    {
        try
        {
            ddt = ojPhar.getDrugsAvailBAL(Session["UniqueInstId"].ToString(), Session["DrugCodeList"].ToString(), ConnKey);
            LocalReport report = (LocalReport)Session["Rpt"];
            //LocalReport report = new LocalReport();
            //report.DataSources.Clear();
            //report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DrugAvailability.rdlc");
            //report.DataSources.Add(
            //   new ReportDataSource("DS_RptDrugAvailability", ddt));
            //report.Refresh();
            Export(report);


            Print();
        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }

    private void Print()
    {
      //  const string printerName = "Microsoft Office Document Image Writer";

        if (m_streams == null || m_streams.Count == 0)
            return;
        Stream[] s = m_streams.ToArray();
        byte[] b = ReadFully(s[0]);

        Response.Clear();

        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "inline; filename=Report.pdf");
        Response.ContentType = "application/pdf";
        Response.Buffer = true;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.BinaryWrite(b);
        Response.Flush();
        //Response.End();
    }

    public static byte[] ReadFully(Stream input)
    {
        byte[] buffer = new byte[16 * 1024];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
            return ms.ToArray();
        }
    }



    private void PrintPage(object sender, PrintPageEventArgs ev)
    {
        Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
        ev.Graphics.DrawImage(pageImage, 0, 0);

        m_currentPageIndex++;
        ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
    }
    private void Export(LocalReport report)
    {
        string deviceInfo =
          @"<DeviceInfo>
                <OutputFormat>PDF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.25in</MarginTop>
                <MarginLeft>0.25in</MarginLeft>
                <MarginRight>0.25in</MarginRight>
                <MarginBottom>0.25in</MarginBottom>
            </DeviceInfo>";
        Warning[] warnings;

        m_streams = new List<Stream>();
        report.Render("PDF", deviceInfo, CreateStream,
             out warnings);

        foreach (Stream stream in m_streams)
        {
            stream.Position = 0;

        }




    }

    private Stream CreateStream(string name, string fileNameExtension,
       Encoding encoding,
           string mimeType, bool willSeek)
    {
        MemoryStream stream = new MemoryStream();
        m_streams.Add(stream);
        return stream;
    }
    public void Dispose()
    {
        if (m_streams != null)
        {
            foreach (Stream stream in m_streams)
                stream.Close();
            m_streams = null;
        }
    }
}