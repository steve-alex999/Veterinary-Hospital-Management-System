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




public partial class Patient : System.Web.UI.Page
{
    string ConnKey;
    InstutionBAL ObjIns = new InstutionBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["RegNo"].ToString() == null || Session["VisitDate"].ToString() == null)
            Response.Redirect("~/Error.aspx");
        //Htpp Referer Check
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
            /*GENERATE CaseSheet*/
            getReport();
        }
    }
    protected void getReport()
    {
        try
        {

            //RptCasesheet.LocalReport.DataSources.Clear();
            //// Set a DataSource to the report  
            //// First Parameter - Report DataSet Name  
            //// Second Parameter - DataSource Object i.e DataTable  
            //RptCasesheet.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ObjIns.RptCaseSheetBAL(Session["RegNo"].ToString(), Session["VisitDate"].ToString(), ConnKey)));
            //// OR Set Report Path  
            //RptCasesheet.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Casesheet.rdlc");
            //// Refresh and Display Report  
            //RptCasesheet.LocalReport.Refresh();
            RptCasesheet.LocalReport.DataSources.Clear();
           RptCasesheet.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", ObjIns.RptCaseSheetBAL(Session["RegNo"].ToString(), Session["VisitDate"].ToString(), ConnKey)));

           //working in Server
           string imagePath = new Uri(Server.MapPath("~/img/" + Session["statecd"].ToString().Trim() + ".png")).AbsoluteUri;
           //working in local
           //  string imagePath = GetFullRootUrl() + "/vhms/img/" + Session["statecd"].ToString().Trim() + ".png";

                
                RptCasesheet.LocalReport.EnableExternalImages = true;
                RptCasesheet.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Casesheet.rdlc");

                RptCasesheet.LocalReport.SetParameters(new ReportParameter("imagepath", imagePath));
                RptCasesheet.LocalReport.SetParameters(new ReportParameter("StateName", Session["statename"].ToString()));
                // Refresh and Display Report  
                RptCasesheet.LocalReport.Refresh();
          
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    public string GetFullRootUrl()
    {
        HttpRequest request = HttpContext.Current.Request;
        //string url = ConfigurationManager.AppSettings["VirtualDirectory"].ToString();
        int index = request.Url.AbsoluteUri.IndexOf(request.Url.AbsolutePath);
        return request.Url.AbsoluteUri.Substring(0, index);
    }
    protected void btnImgprint_Click(object sender, ImageClickEventArgs e)
    {

        string url = "Print_CaseSheet.aspx";
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.open('");
        sb.Append(url);
        sb.Append("','_blank');");
        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(),
                     "script", sb.ToString());
    }
}