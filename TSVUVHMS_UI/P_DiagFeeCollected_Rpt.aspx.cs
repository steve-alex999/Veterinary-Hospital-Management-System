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
using System.Configuration;

public partial class P_FeeCollected_Rpt : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    DiagBAL objDiag = new DiagBAL();
    MasterBAL objMstBL = new MasterBAL();
    Validate objValidate = new Validate();
    DataTable ddt;
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ConnStr"] = ConfigurationManager.ConnectionStrings["ConnStrCentral"].ToString();
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
                
                /*Bind States - By Default set State as TELANGANA*/
               
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
  
    protected void ddlDist_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        /*Bind Institutions By Dist Code*/
        DataTable ddt = objMstBL.GetInstByDistCodeBAL(Session["statecd"].ToString(), ddlDist.SelectedValue.ToString(), ConnKey);
        objCommon.BindDropDownLists(ddlInst, ddt, "InstitutionName", "Unique_InstId", "0");
        RefreshOnChng();
    }
    protected bool ValidateSubmit()
    {
       
        if (ddlDist.SelectedValue == "0")
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
            RptFeeCollected.LocalReport.DataSources.Clear();
            // Set a DataSource to the report  
            // First Parameter - Report DataSet Name  
            // Second Parameter - DataSource Object i.e DataTable  
            DateTime FromDt = DateTime.Parse(txtFromDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            DateTime ToDt = DateTime.Parse(txtToDt.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            DataTable dt = objDiag.FetchFeecollectedBAL(ddlInst.SelectedValue.ToString(), FromDt, ToDt, ConnKey);
            if (dt.Rows.Count > 0)
            {
                RptFeeCollected.LocalReport.DataSources.Add(new ReportDataSource("DS_Rpt_DiagTestFeeCollected", dt));
                // OR Set Report Path  
                RptFeeCollected.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/DiagFeeCollectedRpt.rdlc");
                // Refresh and Display Report  
                RptFeeCollected.LocalReport.Refresh();
                RptFeeCollected.Visible = true;
                lblNoRecordFound.Visible = false;
                btnImgprint.Visible = true;
            }
            else
            {
                lblNoRecordFound.Visible = true;
                RptFeeCollected.Visible = false;
                lblNoRecordFound.Text = "No Record Found!!";
                btnImgprint.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void RefreshOnChng()
    {
        try
        {
            lblNoRecordFound.Visible = false;
            btnImgprint.Visible = false;
            RptFeeCollected.Visible = false;
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
            Session["ReportName"] = "DiagFeeCollected";
            Session["UniqueInstId"] = ddlInst.SelectedValue.ToString();
            Session["FromDt"] = txtFromDate.Text.Trim();
            Session["ToDt"] = txtToDt.Text.Trim();
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
    protected void OntxtDtChanged(object sender, EventArgs e)
    {
        RefreshOnChng();
    }
}

