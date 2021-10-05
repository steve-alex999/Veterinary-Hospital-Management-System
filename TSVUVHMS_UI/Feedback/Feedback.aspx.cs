using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using VHMS_BE;
using System.Data;
using System.Web.Security;
using Microsoft.Reporting.WebForms;
using System.Text;


public partial class Feedback : System.Web.UI.Page
{
    MasterBAL objMstBL = new MasterBAL();
    InstutionBAL ObjIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();
    Feedback_BAL objFbBL = new Feedback_BAL();
    FeedbackBE objfbBE = new FeedbackBE();
    DataTable ddt;
    string StateCode, UserName;
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
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "6")
        {
            Response.Redirect("~/Error.aspx");
        }
       
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        StateCode = Session["StateCd"].ToString();
        UserName = Session["UsrName"].ToString();
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                /*Bind States - By Default set State as TELANGANA*/
                ddt = objMstBL.getstate(ConnKey);
                objCommon.BindDropDownLists(ddlState, ddt, "StateName", "StateCode", "0");
                ddlState.SelectedValue = "36";
                ddlState.Enabled = false;
                /*Bind Districts*/
                ddt = objMstBL.getDistrictsByStateCodeBAL(ddlState.SelectedValue.ToString(), ConnKey);
                objCommon.BindDropDownLists(ddlDist, ddt, "DistName", "DistCode", "0");
                txtDate.Text = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");                
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }        
        }
    }
    protected void ddlDist_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            /*Bind Institutions By Dist Code*/
            DataTable ddt = objMstBL.GetInstByDistCodeBAL(ddlState.SelectedValue.ToString(), ddlDist.SelectedValue.ToString(), ConnKey);
            objCommon.BindDropDownLists(ddlInst, ddt, "InstitutionName", "Unique_InstId", "0");
            trPatientDtls.Visible = false;
            btnSubmit.Visible = false;
            btnCloseFb.Visible = false;
            GvPatientDtls.DataSource = null;
            GvPatientDtls.DataBind();
            GvPatientDtls.Visible = true; 
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }

    }
    protected void GvPatientDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvPatientDtls.PageIndex = e.NewPageIndex;
            viewdata();           
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }        
    }

    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    private void viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            DateTime VisitDate = DateTime.Parse(txtDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            dt1 = objFbBL.GetPatientDtlsForFeedback_ByVisitDateBAL(ddlInst.SelectedValue, VisitDate,Session["UsrName"].ToString(), ConnKey);
            if (dt1.Rows.Count > 0)
            {
                GvPatientDtls.DataSource = dt1;
                GvPatientDtls.DataBind();
                GvPatientDtls.Visible = true;                
            }
            else
            {
                GvPatientDtls.DataSource = null;
                GvPatientDtls.DataBind();
                GvPatientDtls.Visible = true;                
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void lnkRegNo_Click(object sender, EventArgs e)
    {
        try
        {
            RefreshFields();
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            LinkButton lnkRegNo = (LinkButton)gRow.FindControl("linkgetregno");
            /*ASSIGN VALUES*/
            lblRegNo.Text = lnkRegNo.Text;
            lblOwnerName.Text = ((Label)gRow.FindControl("lblOwner")).Text;
            lblMobileNo.Text = ((Label)gRow.FindControl("lblMbNo")).Text;
            lblAnimal.Text = ((Label)gRow.FindControl("lblAnimalTypeDesc")).Text;
            lblRegFeePaid.Text = ((Label)gRow.FindControl("lblRFP")).Text;
            lblTestFeePaid.Text = ((Label)gRow.FindControl("lblTFP")).Text;
            lblDIssued.Text = (((Label)gRow.FindControl("lblDI")).Text) == "I" ? "Issued" : "Not Issued";
            lblVisitId_Save.Text = ((Label)gRow.FindControl("lblVisitId")).Text;
            trPatientDtls.Visible = true;
            btnSubmit.Visible = true;
            btnCloseFb.Visible = true;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }        
    }

    protected void btnGetData_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlDist.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Select District");
                ddlDist.Focus();
                return;
            }
            if (ddlInst.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Select Institution");
                ddlInst.Focus();
                return;
            }
            if (txtDate.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Select Visit Date");
                txtDate.Focus();
                return;
            }
            else
            {
                if (!objValidate.IsDate(txtDate.Text.Trim()))
                {
                    objCommon.ShowAlertMessage("Enter Valid Visit Date");
                    txtDate.Focus();
                    return ;
                }
            }
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtRegFee.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Enter Registration Fee Paid");
                txtRegFee.Focus();
                return;
            }
            if (txtTestFee.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Enter Test Fee Paid");
                txtTestFee.Focus();
                return;
            }
            if (txtAnyOthrAmt.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Enter any other amount Paid");
                txtAnyOthrAmt.Focus();
                return;
            }
            if (txtRegFee.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Enter Registration Fee Paid");
                txtRegFee.Focus();
                return;
            }
            if (rdRegServcQty.SelectedIndex < 0 )
            {
                objCommon.ShowAlertMessage("Select an option for Registration Service Quality");
                rdRegServcQty.Focus();
                return;
            }
            if (rdDocSrvcQty.SelectedIndex < 0)
            {
                objCommon.ShowAlertMessage("Select an option for Doctor Service Quality");
                rdDocSrvcQty.Focus();
                return;
            }
            if (rdPharSrvcQty.SelectedIndex < 0)
            {
                objCommon.ShowAlertMessage("Select an option for Pharmacy Service Quality");
                rdPharSrvcQty.Focus();
                return;
            }
            if (rdFreeDrugsIssued.SelectedIndex < 0)
            {
                objCommon.ShowAlertMessage("Select an option for Free Drugs Issued");
                rdFreeDrugsIssued.Focus();
                return;
            }
            if (rdDrugsPurFrmOutside.SelectedIndex < 0)
            {
                objCommon.ShowAlertMessage("Select an option for Drugs purchased from outside");
                rdDrugsPurFrmOutside.Focus();
                return;
            }
            if (rdCleanlinessInHosp.SelectedIndex < 0)
            {
                objCommon.ShowAlertMessage("Select an option for Clenaliness in Hospital");
                rdCleanlinessInHosp.Focus();
                return;
            }
            if (rdOverallExp.SelectedIndex < 0)
            {
                objCommon.ShowAlertMessage("Select an option for Over all experience");
                rdOverallExp.Focus();
                return;
            }
            DateTime VisitDate = DateTime.Parse(txtDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            int ExcessRegFeeTaken , ExcessTestFeeTaken;
            ExcessRegFeeTaken = Convert.ToInt32( txtRegFee.Text) - Convert.ToInt32( lblRegFeePaid.Text) ;
            ExcessTestFeeTaken = Convert.ToInt32( txtTestFee.Text) - Convert.ToInt32( lblTestFeePaid.Text) ;
            objfbBE.UniqueInsId = ddlInst.SelectedValue;
            objfbBE.VisitDate = VisitDate;
            objfbBE.RegNo = lblRegNo.Text;
            objfbBE.VisitId = lblVisitId_Save.Text;
            objfbBE.RegFeePaid = txtRegFee.Text.Trim();
            objfbBE.TestFeePaid = txtTestFee.Text.Trim();
            objfbBE.OtherAmtPaid = txtAnyOthrAmt.Text.Trim();
            objfbBE.Reg_ServiceQuality = rdRegServcQty.SelectedValue;
            objfbBE.Phar_ServiceQuality = rdPharSrvcQty.SelectedValue;
            objfbBE.Doctor_ServiceQuality = rdDocSrvcQty.SelectedValue;
            objfbBE.Free_DrugIssued = rdFreeDrugsIssued.SelectedValue;
            objfbBE.Drugs_Pfrmoutside = rdDrugsPurFrmOutside.SelectedValue;
            objfbBE.CleanlinessInHosp = rdCleanlinessInHosp.SelectedValue;
            objfbBE.Overall_Experience = rdOverallExp.SelectedValue;
            objfbBE.ExcessRegFeeTaken = ExcessRegFeeTaken > 0 ? "Y" : "N";
            objfbBE.ExcessRegFee = ExcessRegFeeTaken > 0 ? ExcessRegFeeTaken.ToString() : "0";
            objfbBE.ExcessTestFeeTaken = ExcessTestFeeTaken > 0 ? "Y" : "N";
            objfbBE.ExcessTestFee = ExcessTestFeeTaken > 0 ? ExcessTestFeeTaken.ToString() : "0";
            objfbBE.FreeDrugsNotIssued = rdFreeDrugsIssued.SelectedValue == "Y" ? "N" : (lblDIssued.Text == "Issued" ? "N" : "Y");
            objFbBL.InsertFeedbackDtlsBAL(objfbBE , Session["UsrName"].ToString(),ConnKey);
            objCommon.ShowAlertMessage("Feedback details submitted successfully");
            RefreshFields();
            viewdata();
            btnSubmit.Visible=false;
            btnCloseFb.Visible = false;
            trPatientDtls.Visible = false;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void RefreshFields()
    {
        txtRegFee.Text = "";
        txtTestFee.Text = "";
        txtAnyOthrAmt.Text = "";
        rdRegServcQty.ClearSelection();
        rdDocSrvcQty.ClearSelection();
        rdDrugsPurFrmOutside.ClearSelection();
        rdFreeDrugsIssued.ClearSelection();
        rdOverallExp.ClearSelection();
        rdPharSrvcQty.ClearSelection();
    }
    protected void ddlIns_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        trPatientDtls.Visible = false;
        btnSubmit.Visible = false;
        btnCloseFb.Visible = false;
        GvPatientDtls.DataSource = null;
        GvPatientDtls.DataBind();
        GvPatientDtls.Visible = true;
        RefreshFields();
    }
    protected void txtDate_OnTextChnaged(object sender, EventArgs e)
    {
        trPatientDtls.Visible = false;
        btnSubmit.Visible = false;
        btnCloseFb.Visible = false;
        GvPatientDtls.DataSource = null;
        GvPatientDtls.DataBind();
        GvPatientDtls.Visible = true;
        RefreshFields();
    }
    protected void btnCloseFb_Click(object sender, EventArgs e)
    {
        try
        {
            mpCloseFb.Show();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btnCloseFb_PopUp_Click(object sender, EventArgs e)
    {
        try
        {
            if (rdCloseFb.SelectedIndex < 0)
            {
                objCommon.ShowAlertMessage("Select an option to close feedback");
                mpCloseFb.Show();
                rdCloseFb.Focus();
                return;
            }
            DateTime VisitDate = DateTime.Parse(txtDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            objfbBE.UniqueInsId = ddlInst.SelectedValue;
            objfbBE.VisitDate = VisitDate;
            objfbBE.RegNo = lblRegNo.Text;
            objfbBE.VisitId = lblVisitId_Save.Text;
            objfbBE.CloseFb_Reason = rdCloseFb.SelectedValue;
            objFbBL.CloseFeedbackBAL(objfbBE, Session["UsrName"].ToString(), ConnKey);
            objCommon.ShowAlertMessage("Feedback Closed successfully");
            RefreshFields();
            viewdata();
            btnSubmit.Visible = false;
            btnCloseFb.Visible = false;
            trPatientDtls.Visible = false;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
}
