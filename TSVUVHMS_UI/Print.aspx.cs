using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVUVHMS_BL;
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
using System.Reflection;


public partial class Print : System.Web.UI.Page
{
    InstutionBAL ObjIns = new InstutionBAL();
    ReportBAL ObjRptBL = new ReportBAL();
    PharmacyBAL objPhar = new PharmacyBAL();
    DiagBAL objDiag = new DiagBAL();
    private IList<Stream> m_streams;
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["RegNo"].ToString() == null || Session["VisitDate"].ToString() == null)
        if (Session["ReportName"].ToString() == null )
            Response.Redirect("~/Error.aspx");
        //Htpp Referer Check
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                /*CALL REPORT FUNCTION*/
                PrintAllReports(Session["ReportName"].ToString());
            }
            catch (Exception ex)
            {
              
            }
        }
    }

    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    private void PrintAllReports(string ReportName)
    {
        try
        {
            LocalReport Report = new LocalReport();
            Report.DataSources.Clear();
            // Set a DataSource to the report  
            // First Parameter - Report DataSet Name  
            // Second Parameter - DataSource Object i.e DataTable  
            if (ReportName == "PtRegStats")
            {
                DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;


                Report.DataSources.Add(new ReportDataSource("DS_VisitCount", ObjIns.FetchPaitentVisitCountBAL(Session["UniqueInstId"].ToString(), FromDt, ToDt, ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_PaitentVistCount.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "PtRegAbstract")
            {
                DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;


                Report.DataSources.Add(new ReportDataSource("Ds_Rpt_Visit_ReVisit_Abstract", ObjIns.FetchPaitentVisitCount_AbstractBAL(Session["UniqueInstId"].ToString(), FromDt.ToString("yyyy"), FromDt.ToString("MM"), ToDt.ToString("yyyy"), ToDt.ToString("MM"), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_PaitentVistCount_Abstract.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "FeeCollected")
            {
                DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

                Report.DataSources.Add(new ReportDataSource("DS_RptFeeCollected", ObjIns.FetchFeecollectedBAL(Session["UniqueInstId"].ToString(), FromDt, ToDt, ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/FeeCollectedRpt.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "DailyStocksIssued")
            {
                DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                Report.DataSources.Add(new ReportDataSource("Ds_Rpt_Ph_DailyStocksIssued", ObjRptBL.Rpt_Ph_DailyStocksIssuedBAL(FromDt, ToDt, Session["DistCode"].ToString(), Session["InsId"].ToString(), Session["DrugCode"].ToString(), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Ph_DailyStocksIssued.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "Abstract_StocksIssued")
            {
                DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                Report.DataSources.Add(new ReportDataSource("Ds_Rpt_StocksIssued_Abstract", ObjRptBL.Rpt_Ph_StocksIssued_AbstractBAL(FromDt.ToString("yyyy"), FromDt.ToString("MM"), ToDt.ToString("yyyy"), ToDt.ToString("MM"), Session["DistCode"].ToString(), Session["InsId"].ToString(), Session["DrugCode"].ToString(), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Ph_StocksIssued_Abstract.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "DailyStocksRcvd")
            {
                DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                Report.DataSources.Add(new ReportDataSource("Ds_Rpt_Ph_DailyStocksRcvd", ObjRptBL.Rpt_Ph_DailyStocksRcvdBAL(FromDt, ToDt, Session["DistCode"].ToString(), Session["InsId"].ToString(), Session["DrugCode"].ToString(), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Ph_DailyStocksRcvd.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "DrugsAvailability")
            {
                Report.DataSources.Add(new ReportDataSource("DS_RptDrugAvailability", objPhar.getDrugsAvailBAL1(Session["UniqueInstId"].ToString(), Session["DrugCodeList"].ToString(), Session["Sort"].ToString(), Session["Order"].ToString(), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DrugAvailability.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "DrugsIssuedByRegNo")
            {
                DateTime Dt = DateTime.Parse(Session["SelDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                Report.DataSources.Add(new ReportDataSource("Ds_Rpt_Ph_DrugsIssuedByRegNo", ObjRptBL.Rpt_Ph_DrugsIssuedByRegNoBAL(Dt, Session["InsId"].ToString(), Session["RegNo"].ToString(), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Ph_DrugsIssuedByRegNo.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "DA_PatientVisits")
            {
                DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

                Report.DataSources.Add(new ReportDataSource("Ds_Rpt_DA_PatientVisits", ObjRptBL.FetchDA_PaitentVisitsBAL(Session["UniqueInstId"].ToString(), FromDt, ToDt, Convert.ToInt16(Session["StartTime"].ToString()), Convert.ToInt16(Session["EndTime"].ToString()), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Analysis_PaitentVisits.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "DiagTestBill")
            {
                DateTime TestDate = DateTime.Parse(Session["TestDate"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                Report.DataSources.Add(new ReportDataSource("DS_RptDiagTest", objDiag.GetTestRepotBAL(Session["RegNo"].ToString(), Session["UniqueInstId"].ToString(), TestDate, ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DiagTest.rdlc");
                //Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "DiagFeeCollected")
            {
                DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

                Report.DataSources.Add(new ReportDataSource("DS_Rpt_DiagTestFeeCollected", objDiag.FetchFeecollectedBAL(Session["UniqueInstId"].ToString(), FromDt, ToDt, ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/DiagFeeCollectedRpt.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "PatientDtlsstatistics")
            {

                if (Session["ATypeCd"].ToString() == "ALL")
                {
                    DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                    DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                    Report.DataSources.Add(new ReportDataSource("DataSet1", ObjIns.GetAnimalReportBAL(Session["UniqueInstId"].ToString(), Session["AnimalTypeCode"].ToString(), FromDt, ToDt, ConnKey)));
                    // OR Set Report Path  
                    Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_TotalPaitentCount.rdlc");
                    // Refresh and Display Report  
                    Report.Refresh();
                }
                else if (Session["ATypeCd"].ToString() == "R")
                {
                    ReportParameter rp = new ReportParameter("AnimalTypeCode", Session["AnimalTypeCode"].ToString());
                    ReportParameter rp1 = new ReportParameter("Status", Session["Status"].ToString());
                    DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                    DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

                    Report.DataSources.Add(new ReportDataSource("Ds_PatientDtls", ObjIns.GetAtypeRptBAL(Session["UniqueInstId"].ToString(), Session["AnimalTypeCode"].ToString(), Session["Status"].ToString(), FromDt, ToDt, ConnKey)));
                    // OR Set Report Path  
                    Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_AnimalTypeWiseDtls.rdlc");
                    Report.SetParameters(new ReportParameter[] { rp });
                    Report.SetParameters(new ReportParameter[] { rp1 });
                    // Refresh and Display Report  
                    Report.Refresh();
                }
                else if (Session["ATypeCd"].ToString() == "T")
                {
                    ReportParameter rp = new ReportParameter("AnimalTypeCode", Session["AnimalTypeCode"].ToString());
                    ReportParameter rp1 = new ReportParameter("Status", Session["Status"].ToString());
                    DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                    DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

                    Report.DataSources.Add(new ReportDataSource("Ds_PatientDtls", ObjIns.GetAtypeALL1BAL(Session["UniqueInstId"].ToString(), FromDt, ToDt, ConnKey)));
                    // OR Set Report Path  
                    Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_AnimalTypeWiseDtls.rdlc");
                    Report.SetParameters(new ReportParameter[] { rp });
                    Report.SetParameters(new ReportParameter[] { rp1 });
                    // Refresh and Display Report  
                    Report.Refresh();

                }
            }
            else if (ReportName == "DBTotInstitutions")
            {
                Report.DataSources.Add(new ReportDataSource("DS_Rpt_DB_TotInstitutions", ObjRptBL.FetchDB_TotInstutionsBAL(Session["StateCd"].ToString(), Session["UniqueInstId"].ToString(), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DB_TotInstitutions.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "DBTotRegistrations")
            {
                Report.DataSources.Add(new ReportDataSource("DS_Rpt_DB_TotRegistrations", ObjRptBL.FetchDB_TotRegistrationsBAL(Session["StateCd"].ToString(), Session["UniqueInstId"].ToString(), Session["RegType"].ToString(), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DB_TotRegistrations.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "DBTotDrugIssued")
            {
                Report.DataSources.Add(new ReportDataSource("DS_Rpt_DB_TotDrugIssued", ObjRptBL.FetchDB_TotDrugIssuedBAL(Session["statecd"].ToString(),Session["UniqueInstId"].ToString(), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DB_TotDrugsIssued.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "PatientHistory")
            {
                Report.DataSources.Add(new ReportDataSource("Ds_Rpt_PatientHistory", ObjRptBL.GetPatientHistoryDtlsBAL(Session["UniqueInstId"].ToString(), Session["RegNo"].ToString(), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_PatientHistory.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "Diag_MnthlyAbs")
            {
                Report.DataSources.Add(new ReportDataSource("Ds_Rpt_Diag_MonthlyAbstract", ObjRptBL.FetchDiag_MnthlyAbstractBAL(Session["UniqueInstId"].ToString(), Session["FromYr"].ToString(), Session["FromMnth"].ToString(), Session["ToYr"].ToString(), Session["ToMnth"].ToString(), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Diag_MonthlyAbstarct.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "FeedbackAnalysis")
            {
                DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                Report.DataSources.Add(new ReportDataSource("Ds_Rpt_FeedbackAnalysis", ObjRptBL.FetchFeedbackAnalysisBAL(Session["UniqueInstId"].ToString(),FromDt ,ToDt , ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_FeedbackAnalysis.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "SchemeWsDrugsIssued")
            {
                DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

                Report.DataSources.Add(new ReportDataSource("DS_Rpt_PH_HospWs_ShcemeWs_DrugsIssued", ObjRptBL.GetSchemeWsDrugsIssuedBAL(Session["UniqueInstId"].ToString(), FromDt, ToDt, ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_PH_HospWs_ShcemeWs_DrugsIssued.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            else if (ReportName == "Ben_Dst_SchemeWsDrugsIssued_AadharCatCnt")
            {
                DateTime FromDt = DateTime.Parse(Session["FromDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DateTime ToDt = DateTime.Parse(Session["ToDt"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

                Report.DataSources.Add(new ReportDataSource("DS_Rpt_SchemeWs_Aadhar_CatCnt", ObjRptBL.GetBenCnt_Dst_Ins_SchemeWsDrugsIssuedBAL("ALL",Session["SelDtCode"].ToString(), FromDt, ToDt,Session["WithAadhar"].ToString(), ConnKey)));
                // OR Set Report Path  
                Report.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_SchemeWs_Aadhar_CatCnt_.rdlc");
                // Refresh and Display Report  
                Report.Refresh();
            }
            Export(Report);
            PrintReport();
        }
        catch (Exception ex)
        {
          
        }
    }

    private void PrintReport()
    {

        

        // string printerName = "Microsoft Print to PDF";

        if (m_streams == null || m_streams.Count == 0)
            return;
        Stream[] s = m_streams.ToArray();
        byte[] b = ReadFully(s[0]);

        WebClient we = new WebClient();

        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "inline; filename=" + "Print" + ".pdf");
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

    private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
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