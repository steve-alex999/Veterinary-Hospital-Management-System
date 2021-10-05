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
using System.Configuration;

public partial class Rpt_DB_TotRegistrations : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    ReportBAL objRptBL = new ReportBAL();
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ConnStr"] = ConfigurationManager.ConnectionStrings["ConnStrCentral"].ToString();
        Session["statecd"] = "05";
        /*
        Session["statename"] = "Telangana";
        Session["UniqueInstId"] = "054938201";
        Session["RegType"] = "1";
        Session["UsrName"] = "Admin";
        Session["Role"] = "1";
        Session["InstitutionName"] = "Government Veterinary Hospital Raipur";
        */
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        { //Htpp Referer Check
           // if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
           //     Response.Redirect("~/Error.aspx");
           // }
           // else
           // {
                //string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
                string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
                int len = http_hos.Length;
                
            }
            if (Session["UsrName"] == null || Session["Role"] == null)
            {
                Response.Redirect("~/Error.aspx");
            }
            //if (Session["Role"].ToString() == "1")
            //{
            //    Session["UniqueInstId"] = "ALL";
            //    Imghome.PostBackUrl = "Admin/DashBoard_Admin.aspx";

            //}
            //if (Session["Role"].ToString() == "2")
            //{
            //    Imghome.PostBackUrl = "Institution/DashBoard_Ins.aspx";

            //}
            //if (Session["Role"].ToString() == "3")
            //{
            //    Imghome.PostBackUrl = "Pharmacy/DashBoard_Phar.aspx";

            //}
            //if (Session["Role"].ToString() == "4")
            //{
            //    Imghome.PostBackUrl = "Diagnostic/DashBoard_Dia.aspx";

            //}
            //if (Session["Role"].ToString() == "5")
            //{
            //    Imghome.PostBackUrl = "Doctor/Rpt_PatientHistory.aspx";

            //}
            lblUsrName.Text = Session["UsrName"].ToString();
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblInsName.Text = Session["InstitutionName"].ToString();
            try
            {
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

                if (Session["UniqueInstId"].ToString() == null)
                    Response.Redirect("~/Error.aspx");

                if (Session["RegType"].ToString() == null)
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


            DataTable dt = objRptBL.FetchDB_TotRegistrationsBAL(Session["statecd"].ToString(),Session["UniqueInstId"].ToString(), Session["RegType"].ToString(), ConnKey);
            if (dt.Rows.Count > 0)
            {
                RptDBTotIns.LocalReport.DataSources.Add(new ReportDataSource("DS_Rpt_DB_TotRegistrations", dt));
                // OR Set Report Path  
                RptDBTotIns.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DB_TotRegistrations.rdlc");
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
            Session["ReportName"] = "DBTotRegistrations";
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