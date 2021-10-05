using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;
using System.Text;
using Microsoft.Reporting.WebForms;


public partial class Rpt_PH_DrugsIssuedByRegNo : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    ReportBAL ObjRptBL = new ReportBAL();
    MasterBAL objMstBL = new MasterBAL();
    Validate objValidate = new Validate();

    DataTable ddt;
    string UniqueInsId;
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {

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
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "3")
        {
            Response.Redirect("~/Error.aspx");
        }
        lblUsrName.Text = Session["UsrName"].ToString();
        UniqueInsId = Session["UniqueInstId"].ToString();
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                /*BY DEFAULT SET TODAYS DATE AS FROM AND TO DATE*/
                txtDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

                /*Bind RegNos*/
                DateTime Dt = DateTime.Parse(txtDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                ddt = objMstBL.GetRegNosByInstIdBAL(UniqueInsId, Dt, ConnKey);
                objCommon.BindDropDownLists_WithAllOption(ddlRegNo, ddt, "RegistrationNo", "RegistrationNo", "0");

                getReport();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }
    }
    /*SERVER SIDE VALIDATIONS*/
    protected bool ValidateSubmit()
    {
        if (ddlRegNo.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select RegistartionNo");
            ddlRegNo.Focus();
            return false;
        }

        if (txtDate.Text.Trim() == "")
        {
            objCommon.ShowAlertMessage("Select Date");
            txtDate.Focus();
            return false;
        }
        else
        {
            if (!objValidate.IsDate(txtDate.Text.Trim()))
            {
                objCommon.ShowAlertMessage("Enter Valid Date");
                txtDate.Focus();
                return false;
            }
        }
        return true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ValidateSubmit())
        {
            try
            {
                getReport();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }

        }
    }

    protected void getReport()
    {
        try
        {
            RptDrugsIssuedByRegNo.LocalReport.DataSources.Clear();
            // Set a DataSource to the report  
            // First Parameter - Report DataSet Name  
            // Second Parameter - DataSource Object i.e DataTable  
            DateTime Dt = DateTime.Parse(txtDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            DataTable dt = ObjRptBL.Rpt_Ph_DrugsIssuedByRegNoBAL(Dt, UniqueInsId, ddlRegNo.SelectedValue.ToString(), ConnKey);
            if (dt.Rows.Count > 0)
            {
                RptDrugsIssuedByRegNo.LocalReport.DataSources.Add(new ReportDataSource("Ds_Rpt_Ph_DrugsIssuedByRegNo", dt));
                // OR Set Report Path  
                RptDrugsIssuedByRegNo.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Ph_DrugsIssuedByRegNo.rdlc");
                // Refresh and Display Report  
                RptDrugsIssuedByRegNo.LocalReport.Refresh();
                RptDrugsIssuedByRegNo.Visible = true;
                lblNoRecordFound.Visible = false;
                btnImgprint.Visible = true;
            }
            else
            {
                lblNoRecordFound.Visible = true;
                RptDrugsIssuedByRegNo.Visible = false;
                lblNoRecordFound.Text = "No Record Found!!";
                btnImgprint.Visible = false;
            }
        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void btnImgprint_Click(object sender, EventArgs e)
    {
        Session["ReportName"] = "DrugsIssuedByRegNo";
        Session["SelDt"] = txtDate.Text.Trim();
        Session["InsId"] = UniqueInsId;
        Session["RegNo"] = ddlRegNo.SelectedValue.ToString();
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
    protected void ddlRegNo_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        RptDrugsIssuedByRegNo.Visible = false;
        btnImgprint.Visible = false;
        lblNoRecordFound.Visible = false;
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            RptDrugsIssuedByRegNo.Visible = false;
            btnImgprint.Visible = false;
            lblNoRecordFound.Visible = false;
            /*BIND REG NOS*/
            DateTime Dt = DateTime.Parse(txtDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            ddt = objMstBL.GetRegNosByInstIdBAL(UniqueInsId, Dt, ConnKey);
            objCommon.BindDropDownLists_WithAllOption(ddlRegNo, ddt, "RegistrationNo", "RegistrationNo", "0");
        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
}

