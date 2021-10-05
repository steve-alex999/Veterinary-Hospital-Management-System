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


public partial class Rpt_PH_DailyStocksRcvd : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    ReportBAL ObjRptBL = new ReportBAL();
    MasterBAL objMstBL = new MasterBAL();
    PharmacyBAL ObjPhBL = new PharmacyBAL();
    Validate objValidate = new Validate();
    DataTable ddt;
    ListItem li;
    string ConnKey;
    string UniqueInstId, StateCode, UserName;
    protected void Page_Load(object sender, EventArgs e)
    {
       
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
                // Response.Redirect("~/Error.aspx");
            }
        }
        if (Session["UsrName"] == null || Session["Role"] == null)
        {
            Response.Redirect("~/Error.aspx");
        }
        lblUsrName.Text = Session["UsrName"].ToString();
        UserName = Session["UsrName"].ToString();
        StateCode = Session["StateCd"].ToString();
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
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
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblInsName.Text = Session["InstitutionName"].ToString();
            try
            {
                /*BY DEFAULT SET TODAYS DATE AS FROM AND TO DATE*/
                txtFromDate.Text = txtToDt.Text = DateTime.Today.ToString("dd/MM/yyyy");

                /*Bind Districts*/
                ddt = objMstBL.getDistrictsByStateCodeBAL(StateCode, ConnKey);
                objCommon.BindDropDownLists(ddlDist, ddt, "DistName", "DistCode", "0");
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }


            //getReport();
            
        }
    }
    /*SERVER SIDE VALIDATIONS*/
    protected bool ValidateSubmit()
    {
        if(ddlDist.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select District");
            ddlDist.Focus();
            return false;
        }
        if (ddlInst.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Institution");
            ddlInst.Focus();
            return false;
        }
        if (ddlDrug.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Drug");
            ddlDrug.Focus();
            return false;
        }
        if (txtFromDate.Text == "")
        {
            objCommon.ShowAlertMessage("Select From Date");
            txtFromDate.Focus();
            return false;
        }
        else
        {
            if (!objValidate.IsDate(txtFromDate.Text.Trim()))
            {
                objCommon.ShowAlertMessage("Enter Valid From Date");
                txtFromDate.Focus();
                return false;
            }
        }
        if (txtToDt.Text == "")
        {
            objCommon.ShowAlertMessage("Select To Date");
            txtToDt.Focus();
            return false;
        }
        else
        {
            if (!objValidate.IsDate(txtToDt.Text.Trim()))
            {
                objCommon.ShowAlertMessage("Enter Valid To Date");
                txtToDt.Focus();
                return false;
            }
        }
        return true;
    }
    protected void RefreshOnChng()
    {
        lblNoRecordFound.Visible = false;
        btnImgprint.Visible = false;
        RptDailyStocksRcvd.Visible = false;
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
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void getReport()
    {
        try
        {
            RptDailyStocksRcvd.LocalReport.DataSources.Clear();
            // Set a DataSource to the report  
            // First Parameter - Report DataSet Name  
            // Second Parameter - DataSource Object i.e DataTable  
            DateTime FromDt = DateTime.Parse(txtFromDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            DateTime ToDt = DateTime.Parse(txtToDt.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            DataTable dt = ObjRptBL.Rpt_Ph_DailyStocksRcvdBAL(FromDt, ToDt, ddlDist.SelectedValue.ToString(), ddlInst.SelectedValue.ToString(), ddlDrug.SelectedValue.ToString(), ConnKey);
            if (dt.Rows.Count > 0)
            {
                RptDailyStocksRcvd.LocalReport.DataSources.Add(new ReportDataSource("Ds_Rpt_Ph_DailyStocksRcvd", dt));
                // OR Set Report Path  
                RptDailyStocksRcvd.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Ph_DailyStocksRcvd.rdlc");
                // Refresh and Display Report  
                RptDailyStocksRcvd.LocalReport.Refresh();
                RptDailyStocksRcvd.Visible = true;
                lblNoRecordFound.Visible = false;
                btnImgprint.Visible = true;
            }
            else
            {
                lblNoRecordFound.Visible = true;
                RptDailyStocksRcvd.Visible = false;
                lblNoRecordFound.Text = "No Record Found!!";
                btnImgprint.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }

   
    protected void ddlDist_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            /*Bind Institutions By Dist Code*/
            DataTable ddt = objMstBL.GetInstByDistCodeBAL(StateCode, ddlDist.SelectedValue.ToString(), ConnKey);
            objCommon.BindDropDownLists(ddlInst, ddt, "InstitutionName", "Unique_InstId", "0");
            RefreshOnChng();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
            
    }
    protected void ddlInst_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            /*Fetch Drugs*/
            DataTable ddt = ObjPhBL.getdrugIns(ddlInst.SelectedValue.ToString(), ConnKey);
            objCommon.BindDropDownLists_WithAllOption(ddlDrug, ddt, "DrugName", "DrugCode", "0");
            RefreshOnChng();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btnImgprint_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ReportName"] = "DailyStocksRcvd";
            Session["FromDt"] = txtFromDate.Text.Trim();
            Session["ToDt"] = txtToDt.Text.Trim();
            Session["DistCode"] = ddlDist.SelectedValue.ToString();
            Session["InsId"] = ddlInst.SelectedValue.ToString();
            Session["DrugCode"] = ddlDrug.SelectedValue.ToString();

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
    protected void txtFromDtChanged(object sender, EventArgs e)
    {
        RefreshOnChng();
    }
}

