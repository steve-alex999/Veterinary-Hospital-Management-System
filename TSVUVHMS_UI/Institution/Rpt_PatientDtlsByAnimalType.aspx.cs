using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Data;
using VHMS_BL;
using VHMS_BE;
using System.Web.Security;
using System.Collections;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Text;
public partial class Institution_Report : System.Web.UI.Page
{
    InstutionBAL ObjIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();
    DataTable ddt;
    string UniqueInstId, StateCode, UserName, Action;
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
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "2")
        {
            Response.Redirect("~/Error.aspx");
        }
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        UserName = Session["UsrName"].ToString();
        StateCode = Session["StateCd"].ToString();
        UniqueInstId = Session["UniqueInstId"].ToString();
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtFromDate.Text = txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
            ddt = ObjIns.viewAnimaldataBAL(ConnKey);
            try
            {
                objCommon.BindDropDownLists_WithAllOption(ddl_AnimalType, ddt, "AnimalTypeDesc", "AnimalTypeCode", "0");
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
            GetInsNameBAL();

        }

        // total = 0;

    }
    protected bool DateValidation()
    {
        if (txtFromDate.Text.Trim() == "")
        {
            objCommon.ShowAlertMessage("Select From Date  ");
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
        if (txtToDate.Text == "")
        {
            objCommon.ShowAlertMessage("Select To Date  ");
            txtToDate.Focus();
            return false;
        }
        else
        {
            if (!objValidate.IsDate(txtToDate.Text.Trim()))
            {
                objCommon.ShowAlertMessage("Enter Valid To Date");
                txtToDate.Focus();
                return false;
            }
        }


        return true;

    }
    protected void RptVwr_Back(object sender, BackEventArgs e)
    {
        Session["ATypeCd"] = "ALL";
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (DateValidation())
        {

            getReport();
        }

    }



    public void GetInsNameBAL()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ObjIns.GetInsNameBAL(UniqueInstId, UserName, ConnKey);
            lblInsName.Text = dt.Rows[0]["InstitutionName"].ToString();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }


    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    public void getReport()
    {
        try
        {

            // Rpt_PatientStatistics.Visible = true;
            lblParam.Text = ddl_AnimalType.SelectedValue.ToString();

            DateTime FromDate = DateTime.Parse(txtFromDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            DateTime ToDate = DateTime.Parse(txtToDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            if (lblParam.Text == "ALL")
            {
                Session["ATypeCd"] = "ALL";
                DataTable dt = ObjIns.GetAnimalReportBAL(Session["UniqueInstId"].ToString(), ddl_AnimalType.SelectedValue.ToString(), FromDate, ToDate, ConnKey);
                //Assign dataset to report datasource
                if (dt.Rows.Count > 0)
                {
                    ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                    Rpt_PatientStatistics.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_TotalPaitentCount.rdlc");
                    //Assign datasource to reportviewer control
                    Rpt_PatientStatistics.LocalReport.DataSources.Clear();
                    Rpt_PatientStatistics.LocalReport.DataSources.Add(datasource);
                    Rpt_PatientStatistics.LocalReport.Refresh();
                    Rpt_PatientStatistics.Visible = true;
                    lblNoRecordFound.Visible = false;
                    btnImgprint.Visible = true;
                }
                else
                {
                    lblNoRecordFound.Visible = true;
                    Rpt_PatientStatistics.Visible = false;
                    lblNoRecordFound.Text = "No Record Found!!";
                    btnImgprint.Visible = false;
                }

            }
            else
            {

                Session["ATypeCd"] = ddl_AnimalType.SelectedValue.ToString();
                string Status = "R";
                DataTable dt = ObjIns.GetAtypeRptBAL(Session["UniqueInstId"].ToString(), lblParam.Text, Status, FromDate, ToDate, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    Session["ATypeCd"] = "R";
                    Session["AnimalTypeCode"] = lblParam.Text;
                    ReportDataSource datasource = new ReportDataSource("Ds_PatientDtls", dt);
                    //Assign dataset to report datasource

                   
                    Rpt_PatientStatistics.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_AnimalTypeWiseDtls.rdlc");
                    //Assign datasource to reportviewer control
                    Rpt_PatientStatistics.LocalReport.DataSources.Clear();
                    Rpt_PatientStatistics.LocalReport.DataSources.Add(datasource);
                    Rpt_PatientStatistics.LocalReport.Refresh();
                    Rpt_PatientStatistics.Visible = true;
                    lblNoRecordFound.Visible = false;
                    btnImgprint.Visible = true;

                }
                else
                {
                    lblNoRecordFound.Visible = true;
                    Rpt_PatientStatistics.Visible = false;
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

    protected void ReportViewer1_Drillthrough(object sender, DrillthroughEventArgs e)
    {
        try
        {
        Rpt_PatientStatistics.Visible = true;


        ReportParameterInfoCollection DrillThroughValues =

e.Report.GetParameters();
        string[] Params = new string[2];
        int i = 0;

        foreach (ReportParameterInfo d in DrillThroughValues)
        {

            Params[i] = d.Values[0].ToString().Trim();
            i += 1;

        }
        //ReportViewer reportviewer = new ReportViewer();
        //reportviewer.ProcessingMode = ProcessingMode.Local;
        //// Add a handler for drillthrough.
        //reportviewer.Back += new
        //    BackEventHandler(BackEventHandlerFunc);
        //reportviewer.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_TotalPaitentCount.rdlc");
        // btnImgprint.Visible = true;
        //reportviewer.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_TotalPaitentCount.rdlc");



        LocalReport localreport = (LocalReport)e.Report;
        DateTime FromDate = DateTime.Parse(txtFromDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        DateTime ToDate = DateTime.Parse(txtToDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

        if (e.ReportPath.ToString() == "Rpt_AllAnimalTypeDtls")
        {

            Session["ATypeCd"] = "T";
            DataTable dt = ObjIns.GetAtypeALL1BAL(Session["UniqueInstId"].ToString(), FromDate, ToDate, ConnKey);
            ReportDataSource datasource = new ReportDataSource("Ds_PatientDtls", dt);
            localreport.DataSources.Clear();
            localreport.DataSources.Add(datasource);
            localreport.Refresh();

        }

        else if (e.ReportPath.ToString() == "Rpt_AnimalTypeWiseDtls")
        {
            Session["AnimalTypeCode"] = Params[1];
            Session["ATypeCd"] = "R";
            Session["Status"] = Params[0];
            DataTable dt = ObjIns.GetAtypeRptBAL(Session["UniqueInstId"].ToString(), Params[1], Params[0], FromDate, ToDate, ConnKey);
            // DataTable dt = ObjIns.GetAtypeRptBAL(Session["UniqueInstId"].ToString(), lblParam.Text, FromDate, ToDate);
            ReportDataSource datasource = new ReportDataSource("Ds_PatientDtls", dt);
            localreport.DataSources.Clear();
            localreport.DataSources.Add(datasource);
            localreport.Refresh();
        }

        //DataTable dt = ObjIns.GetAtypeALLBAL(Session["UniqueInstId"].ToString(), FromDate, ToDate);


        //Assign dataset to report datasource

        }

        catch (Exception ex)
        {

            Response.Redirect("~/Error.aspx");
        }


    }
    protected void ddl_AnimalType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void btnImgprint_Click(object sender, ImageClickEventArgs e)
    {
        Session["ReportName"] = "PatientDtlsstatistics";
        Session["FromDt"] = txtFromDate.Text.Trim();
        Session["ToDt"] = txtToDate.Text.Trim();
        //Session["AnimalTypeCode"] = lblParam.Text;
        //Session["ATypeCd"] = lblParam.Text;
        //Session["AnimalToatl"]="T";


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
    protected void Rpt_PatientStatistics_Back(object sender, BackEventArgs e)
    {
        Session["ATypeCd"] = "ALL";
    }

}