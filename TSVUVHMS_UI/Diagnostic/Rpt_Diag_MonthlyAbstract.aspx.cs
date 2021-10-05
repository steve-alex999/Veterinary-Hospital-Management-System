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
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Net.Mime;
using System.Text;
using System.IO;
using System.Drawing;
using System.Net;

public partial class Rpt_Diag_MonthlyAbstract : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    ReportBAL objRptBL = new ReportBAL();
    Validate objValidate = new Validate();
    private IList<Stream> m_streams;

    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserName = Session["UsrName"].ToString();
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
                Response.Redirect("~/Error.aspx");
            }
        }
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "4")
        {
            Response.Redirect("~/Error.aspx");
        }
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();

                lblUsrName.Text = Session["UsrName"].ToString();
                txtFromDate.Text = txtToDt.Text = DateTime.Today.ToString("dd-MM-yyyy");
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
            DataTable dt = objRptBL.FetchDiag_MnthlyAbstractBAL(Session["UniqueInstId"].ToString(), FromDt.ToString("yyyy"), FromDt.ToString("MM"), ToDt.ToString("yyyy"), ToDt.ToString("MM"), ConnKey);
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
            Session["ReportName"] = "Diag_MnthlyAbs";
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

