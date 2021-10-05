using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;
using Microsoft.Reporting.WebForms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Net.Mime;
using System.Text;
using System.IO;
using System.Drawing;
using System.Net;

public partial class Institution_Print_CaseSheet : System.Web.UI.Page
{
    InstutionBAL ObjIns = new InstutionBAL();
    private IList<Stream> m_streams;
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RegNo"].ToString() == null || Session["VisitDate"].ToString() == null)
            Response.Redirect("~/Error.aspx");
        //Htpp Referer Check
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {

            /*GENERATE CaseSheet*/
           
            PrintReport();
        }
    }


    private void PrintReport()
    {
        try
        {
            LocalReport RptCasesheet = new LocalReport();
            RptCasesheet.DataSources.Clear();
            // Set a DataSource to the report  
            // First Parameter - Report DataSet Name  
            // Second Parameter - DataSource Object i.e DataTable  
            RptCasesheet.DataSources.Add(new ReportDataSource("DataSet1", ObjIns.RptCaseSheetBAL(Session["RegNo"].ToString(), Session["VisitDate"].ToString(), ConnKey)));
            // OR Set Report Path  
            RptCasesheet.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Casesheet.rdlc");
            // Refresh and Display Report  
            RptCasesheet.Refresh();


            Export(RptCasesheet);


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



        // string printerName = "Microsoft Print to PDF";

        if (m_streams == null || m_streams.Count == 0)
            return;
        Stream[] s = m_streams.ToArray();
        byte[] b = ReadFully(s[0]);

        WebClient we = new WebClient();
       
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "inline; filename=" + Session["RegNo"].ToString() + ".pdf");
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

    public static string StreamToString(Stream stream)
    {
        stream.Position = 0;
        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        {
            return reader.ReadToEnd();
        }
    }


    //private void PrintPage(object sender, PrintPageEventArgs ev)
    //{
    //    string strout = StreamToString(m_streams[m_currentPageIndex]);
    //    //Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
    //    //ev.Graphics.DrawImage(pageImage, 0, 0);
    //    System.Drawing.Font printFont = new System.Drawing.Font
    //    ("Arial", 35, System.Drawing.FontStyle.Regular);

    //    // Draw the content.
    //    ev.Graphics.DrawString(strout, printFont,
    //        System.Drawing.Brushes.Black, 10, 10);
    //    m_currentPageIndex++;
    //    ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
    //}
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

    private Stream CreateStream(string name, string fileNameExtension,       Encoding encoding,           string mimeType, bool willSeek)
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