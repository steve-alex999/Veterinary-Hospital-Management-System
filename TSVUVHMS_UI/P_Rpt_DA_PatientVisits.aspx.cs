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

public partial class P_Rpt_DA_PatientVisits : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    MasterBAL objMstBL = new MasterBAL();
    ReportBAL objRptBL = new ReportBAL();
    Validate objValidate = new Validate();
    ReportBAL ObjRptBL = new ReportBAL();
    DataTable ddt;
    string ConnKey;

    protected void Page_Load(object sender, EventArgs e)
    {
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
               
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

                /*BY DEFAULT SET TODAYS DATE AS FROM AND TO DATE*/
                txtFromDate.Text = txtToDt.Text = DateTime.Today.ToString("dd/MM/yyyy");

                /*Bind States - By Default set State as TELANGANA*/
                
                /*Bind Districts*/
                ddt = objMstBL.getDistrictsByStateCodeBAL(Session["statecd"].ToString(), ConnKey);
                objCommon.BindDropDownLists(ddlDist, ddt, "DistName", "DistCode", "0");
                //getReport();
                /*BIND START TIME & END TIME*/
                ddlStartTime.DataSource = GenerateTime(8, 24);
                ddlStartTime.DataBind();
                ddlEndTime.DataSource = GenerateTime(Convert.ToInt16(ddlStartTime.SelectedItem.Text) + 1, 24);                         
                ddlEndTime.DataBind();
                ddlEndTime.SelectedValue = ddlEndTime.Items.FindByText("24").Value;       
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
  
    protected List<string> GenerateTime(int StartHour, int EndHour)
    {
       
            List<string> TimeIntervals = new List<string>();
            for (int i = StartHour; i <= EndHour; i++)
                TimeIntervals.Add(i.ToString());

            return TimeIntervals;
       
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
            Rpt_DA_PatientVisits.LocalReport.DataSources.Clear();
            // Set a DataSource to the report  
            // First Parameter - Report DataSet Name  
            // Second Parameter - DataSource Object i.e DataTable  
            DateTime FromDt = DateTime.Parse(txtFromDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            DateTime ToDt = DateTime.Parse(txtToDt.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

            DataTable dt = objRptBL.FetchDA_PaitentVisitsBAL(ddlInst.SelectedValue.ToString(), FromDt, ToDt, Convert.ToInt16(ddlStartTime.SelectedItem.Text), Convert.ToInt16(ddlEndTime.SelectedItem.Text), ConnKey);
            if (dt.Rows.Count > 0)
            {
                Rpt_DA_PatientVisits.LocalReport.DataSources.Add(new ReportDataSource("Ds_Rpt_DA_PatientVisits", dt));
                // OR Set Report Path  
                Rpt_DA_PatientVisits.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_Analysis_PaitentVisits.rdlc");
                // Refresh and Display Report  
                Rpt_DA_PatientVisits.LocalReport.Refresh();
                //btnImgprint.Visible = true;
                Rpt_DA_PatientVisits.Visible = true;
                lblNoRecordFound.Visible = false;
                lblNoRecordFound.Visible = false;
                btnImgprint.Visible = true;
            }
            else
            {
                lblNoRecordFound.Visible = true;
                Rpt_DA_PatientVisits.Visible = false;
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
        Rpt_DA_PatientVisits.Visible = false;
    }



    protected void btnImgprint_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ReportName"] = "DA_PatientVisits";
            Session["UniqueInstId"] = ddlInst.SelectedValue.ToString();
            Session["FromDt"] = txtFromDate.Text.Trim();
            Session["ToDt"] = txtToDt.Text.Trim();
            Session["StartTime"] = ddlStartTime.SelectedItem.Text;
            Session["EndTime"] = ddlEndTime.SelectedItem.Text;

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
    protected void ddlStartTime_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlStartTime.SelectedValue != "0")
            {
                ddlEndTime.DataSource = GenerateTime(Convert.ToInt16(ddlStartTime.SelectedItem.Text) + 1, 24);
                ddlEndTime.DataBind();
                ddlEndTime.SelectedValue = ddlEndTime.Items.FindByText("24").Value;  
                RefreshOnChng();
            }
            else
                objCommon.ShowAlertMessage("Select Start Time");
        }

        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void txtDateOnChange(object sender, EventArgs e)
    {
        RefreshOnChng();
    }
}


