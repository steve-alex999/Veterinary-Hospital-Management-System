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


public partial class Test : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();
    InstutionBAL ObjIns = new InstutionBAL();
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        /*KILL COOKIE*/
        //  DeleteCookie.DelCookie();
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
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
            Random _rand = new Random();
            ViewState["keyGen"] = _rand.Next().ToString();
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
            txtFromDate.Text = txtToDt.Text = DateTime.Today.ToString("dd/MM/yyyy");
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
    protected bool Validate()
    {
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
       

        return true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if(Validate()){
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
        RptFeeCollected.LocalReport.DataSources.Clear();
        // Set a DataSource to the report  
        // First Parameter - Report DataSet Name  
        // Second Parameter - DataSource Object i.e DataTable  
        DateTime FromDt = DateTime.Parse(txtFromDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        DateTime ToDt = DateTime.Parse(txtToDt.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        DataTable dt = ObjIns.FetchFeecollectedBAL(Session["UniqueInstId"].ToString(), FromDt, ToDt, ConnKey);
        if (dt.Rows.Count > 0)
        {
            RptFeeCollected.LocalReport.DataSources.Add(new ReportDataSource("DS_RptFeeCollected", dt));
            // OR Set Report Path  
            RptFeeCollected.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/FeeCollectedRpt.rdlc");
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
    protected void RefreshOnChng()
    {
        lblNoRecordFound.Visible = false;
        btnImgprint.Visible = false;
        RptFeeCollected.Visible = false;
    }
  
    protected void btnImgprint_Click(object sender, EventArgs e)
    {
        Session["ReportName"] = "FeeCollected";
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
}

