using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVUVHMS_BL;
using System.Data;
using System.Web.Security;
using System.Text;
using Microsoft.Reporting.WebForms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Net.Mime;
using System.Text;
using System.IO;
using System.Drawing;
using System.Net;

public partial class Rpt_DB_TotInstitutions : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    ReportBAL objRptBL = new ReportBAL();
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {

        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            try
            {
               
                if (Session["UniqueInstId"].ToString() == null)
                    Response.Redirect("~/Error.aspx");

              
                getReport();

            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");

            }
        }
    }
    protected void getReport()
    {
        try
        {
            RptDBTotIns.LocalReport.DataSources.Clear();


            DataTable dt = objRptBL.FetchDB_TotDrugIssuedBAL(Session["statecd"].ToString(),Session["UniqueInstId"].ToString(), ConnKey);
            if (dt.Rows.Count > 0)
            {
                RptDBTotIns.LocalReport.DataSources.Add(new ReportDataSource("DS_Rpt_DB_TotDrugIssued", dt));
                // OR Set Report Path  
                RptDBTotIns.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DB_TotDrugsIssued.rdlc");
                // Refresh and Display Report  
                RptDBTotIns.LocalReport.Refresh();
                //btnImgprint.Visible = true;
                RptDBTotIns.Visible = true;
                lblNoRecordFound.Visible = false;
                lblNoRecordFound.Visible = false;
                btnImgprint.Visible = true;
            }
            else
            {
                lblNoRecordFound.Visible = true;
                RptDBTotIns.Visible = false;
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
        try
        {
            Session["ReportName"] = "DBTotDrugIssued";
            string url = "Print.aspx";
            StringBuilder sb = new StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.open('");
            sb.Append(url);
            sb.Append("','_blank');");
            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(),
                         "script", sb.ToString());
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
}