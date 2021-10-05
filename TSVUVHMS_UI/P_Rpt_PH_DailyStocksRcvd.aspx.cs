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


public partial class P_Rpt_PH_DailyStocksRcvd : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    ReportBAL ObjRptBL = new ReportBAL();
    MasterBAL objMstBL = new MasterBAL();
    PharmacyBAL ObjPhBL = new PharmacyBAL();
    Validate objValidate = new Validate();
    DataTable ddt;
    ListItem li;
    string UserName;
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

            try
            {
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                /*BY DEFAULT SET TODAYS DATE AS FROM AND TO DATE*/
                txtFromDate.Text = txtToDt.Text = DateTime.Today.ToString("dd/MM/yyyy");

                /*Bind States - By Default set State as TELANGANA*/
                //ddt = objMstBL.getstate( ConnKey);
                //objCommon.BindDropDownLists(ddlState, ddt, "StateName", "StateCode", "0");
                //ddlState.SelectedValue = "05";
                //ddlState.Enabled = false;
                /*Bind Districts*/
                ddt = objMstBL.getDistrictsByStateCodeBAL(Session["statecd"].ToString(), ConnKey);
                objCommon.BindDropDownLists(ddlDist, ddt, "DistName", "DistCode", "0");
                //getReport();
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
            
        }
    }
    protected void ddl_Drug_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<String> DieaseID_list = new List<string>();
            List<String> DieaseName_list = new List<string>();

            foreach (System.Web.UI.WebControls.ListItem item in ddlDrug.Items)
            {
                if (item.Selected)
                {
                    DieaseID_list.Add(item.Value);
                    DieaseName_list.Add(item.Text);
                }
            }
            Session["DrugCodeList"] = String.Join(",", DieaseID_list.ToArray());
           
            RefreshOnChng();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
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
                ExceptionLogging.SendExcepToDB(ex, "Public", Request.ServerVariables["REMOTE_ADDR"].ToString());
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

            //if (ddt.Rows.Count > 0)
            //{
            //    ddl_Drug.DataSource = ddt;
            //    ddl_Drug.DataTextField = "DrugName";
            //    ddl_Drug.DataValueField = "DrugCode";
            //    ddl_Drug.DataBind();
            //}
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
    /*WILL ENABLE IN FUTURE
    protected void ddlState_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlState.SelectedValue.ToString() != "0")
        {
            ddlInst.Items.Clear();
            ddlInst.Items.Add("Select");
            //Bind Districts
            ddt = objMstBL.getDistrictsByStateCodeBAL(ddlState.SelectedValue.ToString());
            objCommon.BindDropDownLists(ddlDist, ddt, "DistName", "DistCode", "0");
        }
    }
    */
    protected void txtFromDtChanged(object sender, EventArgs e)
    {
        RefreshOnChng();
    }
}

