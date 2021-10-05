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

public partial class Rpt_Diag_Test : System.Web.UI.Page
{
    
    PharmacyBAL ojPhar = new PharmacyBAL();
    DiagBAL objDiag = new DiagBAL();
    InstutionBAL objIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    string ConnKey;

    protected void Page_Load(object sender, EventArgs e)
    {
      
        string UserName = Session["UsrName"].ToString();
        //Htpp Referer Check
        if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
        {
            Response.Redirect("~/Error.aspx");
        }
        else
        {
            string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            int len = http_hos.Length;
            if (http_ref.IndexOf(http_hos, 0) < 0)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "4")
        {
            Response.Redirect("~/Error.aspx");
        }
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        if (Session["TestDate"].ToString() == null)
            Response.Redirect("~/Error.aspx");

        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
            lblUsrName.Text = Session["UsrName"].ToString();
            try{
            getReport();
            GetInsNameBAL();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }

        }
    }
    public void GetInsNameBAL()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objIns.GetInsNameBAL(Session["UniqueInstId"].ToString(), Session["UsrName"].ToString(), ConnKey);
            lblInsName.Text = dt.Rows[0]["InstitutionName"].ToString();
        }
        catch (Exception ex)
        {

            Response.Redirect("~/Error.aspx");
        }
    }
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    public void getReport()
    {
       try{ 
        Rpt_Diagtest.LocalReport.DataSources.Clear();
        // Set a DataSource to the report  
        // First Parameter - Report DataSet Name  
        // Second Parameter - DataSource Object i.e DataTable  
        DateTime TestDate = DateTime.Parse(Session["TestDate"].ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        ddt = objDiag.GetTestRepotBAL(Session["RegNo"].ToString(), Session["UniqueInstId"].ToString(), TestDate, ConnKey);
      
        if (ddt.Rows.Count > 0)
        {
            Rpt_Diagtest.LocalReport.DataSources.Add(new ReportDataSource("DS_RptDiagTest", ddt));
            // OR Set Report Path  
            Rpt_Diagtest.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DiagTest.rdlc");
            // Refresh and Display Report  
            Rpt_Diagtest.LocalReport.Refresh();
            //btnImgprint.Visible = true;
            Rpt_Diagtest.Visible = true;
            lblNoRecordFound.Visible = false;
            lblNoRecordFound.Visible = false;
            btnImgprint.Visible = true;
        }
        else
        {
            lblNoRecordFound.Visible = true;
            Rpt_Diagtest.Visible = false;
            lblNoRecordFound.Text = "No Record Found!!";
            btnImgprint.Visible = false;
            //btnImgprint.Visible = false;
        }
       }
       catch (Exception ex)
       {
           Response.Redirect("~/Error.aspx");
       }

    }


    protected void btnImgprint_Click(object sender, ImageClickEventArgs e)
    {
        Session["ReportName"] = "DiagTestBill";
        string Regno = Session["RegNo"].ToString();
        string url = "../Print.aspx";
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