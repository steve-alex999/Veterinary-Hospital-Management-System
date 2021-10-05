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
using System.IO;
using System.Drawing;
using System.Net;

public partial class P_Rpt_Diag_MonthlyAbstract : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    ReportBAL objRptBL = new ReportBAL();
    MasterBAL objMstBL = new MasterBAL();
    Validate objValidate = new Validate();
    DataTable ddt;
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {

        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
            try
            {
                txtFromDate.Text = txtToDt.Text = DateTime.Today.ToString("dd/MM/yyyy");
                /*Bind States - By Default set State as TELANGANA*/
               
                /*Bind Districts*/
                ddt = objMstBL.getDistrictsByStateCodeBAL(Session["statecd"].ToString(), ConnKey);
                objCommon.BindDropDownLists(ddlDist, ddt, "DistName", "DistCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, "Public", Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
         /*WILL ENABLE IN FUTURE
    protected void ddlState_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedValue.ToString() != "0")
        {
            ddlInst.Items.Clear();
            ddlInst.Items.Add("Select");
            //Bind Districts
            ddt = objMstBL.getDistrictsByStateCodeBAL(ddlState.SelectedValue.ToString());
            objCommon.BindDropDownLists(ddlDist, ddt, "DistName", "DistCode", "0");
        }
    }
    */
    protected void ddlDist_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            /*Bind Institutions By Dist Code*/
            DataTable ddt = objMstBL.GetInstByDistCodeBAL(Session["statecd"].ToString(), ddlDist.SelectedValue.ToString(), ConnKey);
            objCommon.BindDropDownLists(ddlInst, ddt, "InstitutionName", "Unique_InstId", "0");
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }

    }
    protected bool Validate()
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
        if (Validate())
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
            Rpt_Diag_MnthAbs.LocalReport.DataSources.Clear();
            // Set a DataSource to the report  
            // First Parameter - Report DataSet Name  
            // Second Parameter - DataSource Object i.e DataTable  
            DateTime FromDt = DateTime.Parse(txtFromDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            DateTime ToDt = DateTime.Parse(txtToDt.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            Session["FromYr"] = FromDt.ToString("yyyy");
            Session["FromMnth"] = FromDt.ToString("MM");

            Session["ToYr"] = ToDt.ToString("yyyy");
            Session["ToMnth"] = ToDt.ToString("MM");
            

            DataTable dt = objRptBL.FetchDiag_MnthlyAbstractBAL(ddlInst.SelectedValue.ToString(), FromDt.ToString("yyyy"), FromDt.ToString("MM"), ToDt.ToString("yyyy"), ToDt.ToString("MM"), ConnKey);
            if (dt.Rows.Count > 0)
            {
                Rpt_Diag_MnthAbs.LocalReport.DataSources.Add(new ReportDataSource("Ds_Rpt_Diag_MonthlyAbstract", dt));
                // OR Set Report Path  
                Rpt_Diag_MnthAbs.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Diag_MonthlyAbstarct.rdlc");
                // Refresh and Display Report  
                Rpt_Diag_MnthAbs.LocalReport.Refresh();
                //btnImgprint.Visible = true;
                Rpt_Diag_MnthAbs.Visible = true;
                lblNoRecordFound.Visible = false;
                lblNoRecordFound.Visible = false;
                btnImgprint.Visible = true;
            }
            else
            {
                lblNoRecordFound.Visible = true;
                Rpt_Diag_MnthAbs.Visible = false;
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


    protected void RefreshOnChng()
    {
        lblNoRecordFound.Visible = false;
        btnImgprint.Visible = false;
        Rpt_Diag_MnthAbs.Visible = false;
    }
   

    protected void btnImgprint_Click(object sender, EventArgs e)
    {
        try
        {
            Session["UniqueInstId"] = ddlInst.SelectedValue.ToString();
            Session["ReportName"] = "Diag_MnthlyAbs";
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

