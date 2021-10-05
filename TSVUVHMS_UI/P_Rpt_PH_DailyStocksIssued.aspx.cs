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


public partial class P_Rpt_PH_DailyStocksIssued : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    ReportBAL ObjRptBL = new ReportBAL();
    MasterBAL objMstBL = new MasterBAL();
    PharmacyBAL ObjPhBL = new PharmacyBAL();
    Validate objValidate = new Validate();
    DataTable ddt;    
    string UserName;
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                /*BY DEFAULT SET TODAYS DATE AS FROM AND TO DATE*/
                txtFromDate.Text = txtToDt.Text = DateTime.Today.ToString("dd/MM/yyyy");

               
                /*Bind Districts*/
                ddt = objMstBL.getDistrictsByStateCodeBAL(Session["statecd"].ToString(), ConnKey);
                objCommon.BindDropDownLists(ddlDist, ddt, "DistName", "DistCode", "0");
                ddlDrug.Items.Clear();
                ddlDrug.Items.Insert(0, new ListItem("Select", "0"));
                //getReport();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
            
        }
    }
    /*SERVER SIDE VALIDATIONS*/
    protected bool ValidateSubmit()
    {
        //if (ddlState.SelectedValue == "0")
        //{
        //    objCommon.ShowAlertMessage("Select State");
        //    ddlState.Focus();
        //    return false;
        //}
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ValidateSubmit())
        {
        try
        {
            getReport(rdRptType.SelectedValue);
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "Public", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
       
    }
    }
    protected void RefreshOnChng()
    {
        lblNoRecordFound.Visible = false;
        btnImgprint.Visible = false;
        RptDailyStocksIssued.Visible = false;
    }
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void getReport(string ReportType)
    {
        try
        {
            RptDailyStocksIssued.LocalReport.DataSources.Clear();
            // Set a DataSource to the report  
            // First Parameter - Report DataSet Name  
            // Second Parameter - DataSource Object i.e DataTable  
            DateTime FromDt = DateTime.Parse(txtFromDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            DateTime ToDt = DateTime.Parse(txtToDt.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

            DataTable dt = new DataTable();
            if (ReportType == "D")
            {
                dt = ObjRptBL.Rpt_Ph_DailyStocksIssuedBAL(FromDt, ToDt, ddlDist.SelectedValue.ToString(), ddlInst.SelectedValue.ToString(), ddlDrug.SelectedValue.ToString(), ConnKey);
                if (dt.Rows.Count > 0)
                {
                    Session["ReportName"] = "DailyStocksIssued";
                    Session["FromDt"] = txtFromDate.Text.Trim();
                    Session["ToDt"] = txtToDt.Text.Trim();
                    RptDailyStocksIssued.LocalReport.DataSources.Add(new ReportDataSource("Ds_Rpt_Ph_DailyStocksIssued", dt));
                    // OR Set Report Path  
                    RptDailyStocksIssued.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Ph_DailyStocksIssued.rdlc");
                    // Refresh and Display Report  
                    RptDailyStocksIssued.LocalReport.Refresh();
                    RptDailyStocksIssued.Visible = true;
                    lblNoRecordFound.Visible = false;
                    btnImgprint.Visible = true;
                }
                else
                {
                    lblNoRecordFound.Visible = true;
                    RptDailyStocksIssued.Visible = false;
                    lblNoRecordFound.Text = "No Record Found!!";
                    btnImgprint.Visible = false;
                }
            }
            else
            {
                Session["ReportName"] = "Abstract_StocksIssued";
                Session["FromDt"] = txtFromDate.Text.Trim();
                Session["ToDt"] = txtToDt.Text.Trim();
                dt = ObjRptBL.Rpt_Ph_StocksIssued_AbstractBAL(FromDt.ToString("yyyy"), FromDt.ToString("MM"), ToDt.ToString("yyyy"), ToDt.ToString("MM"), ddlDist.SelectedValue.ToString(), ddlInst.SelectedValue.ToString(), ddlDrug.SelectedValue.ToString(), ConnKey);
                if (dt.Rows.Count > 0)
                {
                    RptDailyStocksIssued.LocalReport.DataSources.Add(new ReportDataSource("Ds_Rpt_StocksIssued_Abstract", dt));
                    // OR Set Report Path  
                    RptDailyStocksIssued.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Ph_StocksIssued_Abstract.rdlc");
                    // Refresh and Display Report  
                    RptDailyStocksIssued.LocalReport.Refresh();
                    RptDailyStocksIssued.Visible = true;
                    lblNoRecordFound.Visible = false;
                    btnImgprint.Visible = true;
                }
                else
                {
                    lblNoRecordFound.Visible = true;
                    RptDailyStocksIssued.Visible = false;
                    lblNoRecordFound.Text = "No Record Found!!";
                    btnImgprint.Visible = false;
                }
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
            DataTable ddt = objMstBL.GetInstByDistCodeBAL(Session["statecd"].ToString(), ddlDist.SelectedValue.ToString(), ConnKey);
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
    protected void rdRptType_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshOnChng();
    }
}

