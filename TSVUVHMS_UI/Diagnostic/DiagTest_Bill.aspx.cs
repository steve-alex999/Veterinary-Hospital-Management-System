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


public partial class Institution_Sheet : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    InstutionBAL ObjIns = new InstutionBAL();
    DiagBAL objDiag = new DiagBAL();
    CommonFuncs objCommon = new CommonFuncs();
   
    string UniqueInstId, StateCode, UserName;
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
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "4")
        {
            Response.Redirect("~/Error.aspx");
        }
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        StateCode = Session["StateCd"].ToString();
        UserName = Session["UsrName"].ToString();
        UniqueInstId = Session["UniqueInstId"].ToString();
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            btnImgprint.Visible = false;
            lblNoRecordFound.Visible = false;
            imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
            lblUsrName.Text = Session["UsrName"].ToString();
            try
            {
                GetInsNameBAL();

            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtRegno.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Kindly Enter Registration No");
                txtRegno.Focus();
                return;
            }

            Session["RegNo"] = txtRegno.Text.Trim();


            getTestDatesByRegNo();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
       
    }
    protected void getTestDatesByRegNo()
    {
        try
        {
            DataTable dt = objDiag.GetTestDatesByRegNoBAL(txtRegno.Text.Trim(), ConnKey);
            if (dt.Rows.Count > 0)
            {
                GvVisitDates.Visible = true;
                GvVisitDates.DataSource = dt;
                GvVisitDates.DataBind();
                if (dt.Rows.Count > 0)
                {
                    GvVisitDates.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    GvVisitDates.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                lblNoRecordFound.Visible = false;
            }
            else
            {
                lblNoRecordFound.Visible = true;
                GvVisitDates.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GvVisitDates_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvVisitDates.PageIndex = e.NewPageIndex;
        getTestDatesByRegNo();
    }
    protected void getReport(string RegNo, string UniqueInstId, DateTime TestDate)
    {
        try
        {
            RptDiagTest.LocalReport.DataSources.Clear();
            // Set a DataSource to the report  
            // First Parameter - Report DataSet Name  
            // Second Parameter - DataSource Object i.e DataTable  

            DataTable dt = objDiag.GetTestRepotBAL(Session["RegNo"].ToString(), Session["UniqueInstId"].ToString(), TestDate, ConnKey);
            if (dt.Rows.Count > 0)
            {
                RptDiagTest.LocalReport.DataSources.Add(new ReportDataSource("DS_RptDiagTest", dt));
                // OR Set Report Path  
                RptDiagTest.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DiagTest.rdlc");
                // Refresh and Display Report  
                RptDiagTest.LocalReport.Refresh();
                btnImgprint.Visible = true;
            }
            else
            {
                lblNoRecordFound.Visible = true;
                RptDiagTest.Visible = false;
                lblNoRecordFound.Text = "No Record Found!!";
                btnImgprint.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }


    protected void btnImgprint_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            Session["ReportName"] = "DiagTestBill";
            string Regno = Session["RegNo"].ToString();
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
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void GvVisitDates_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "TestDate")
            {

                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lnkbtnTestDate = (Label)gvrow.FindControl("lblTestDate");
                DateTime TestDate = DateTime.Parse(lnkbtnTestDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                Session["TestDate"] = lnkbtnTestDate.Text;
                getReport(txtRegno.Text.Trim(), Session["UniqueInstId"].ToString(),TestDate);
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
}
