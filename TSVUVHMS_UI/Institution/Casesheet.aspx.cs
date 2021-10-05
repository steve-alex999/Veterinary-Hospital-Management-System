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
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    ListItem li;
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
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "2")
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
            imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            btnImgprint.Visible = false;
            lblNoRecordFound.Visible = false;
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
        if (txtRegno.Text.Trim() == "")
        {
            objCommon.ShowAlertMessage("Kindly Enter Registration No");
            txtRegno.Focus();
            return;
        }

        Session["RegNo"] = txtRegno.Text.Trim();
        try
        {
            getVisitDatesByRegNo();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
        //Response.Redirect("~/Institution/PrintCaseSheet.aspx");
    }
    protected void getVisitDatesByRegNo()
    {
        try
        {
            DataTable dt = ObjIns.GetVisitDatesByRegNoBAL(txtRegno.Text.Trim(), ConnKey);
            if (dt.Rows.Count > 0)
            {
                GvVisitDates.DataSource = dt;
                GvVisitDates.DataBind();
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
        try
        {
            GvVisitDates.PageIndex = e.NewPageIndex;
            getVisitDatesByRegNo();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void getReport(string RegNo, string VisitDate)
    {
        try
        {


          RptCasesheet.LocalReport.DataSources.Clear();            
            DataTable dt = ObjIns.RptCaseSheetBAL(Session["RegNo"].ToString(), VisitDate, ConnKey);
            if (dt.Rows.Count > 0) RptCasesheet.LocalReport.DataSources.Add(new ReportDataSource("Ds_RecpComDtls", dt));
            {
                 
                RptCasesheet.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                //working in Server
                string imagePath = new Uri(Server.MapPath("~/img/" + Session["statecd"].ToString().Trim() + ".png")).AbsoluteUri;
                //working in local
                //  string imagePath = GetFullRootUrl() + "/vhms/img/" + Session["statecd"].ToString().Trim() + ".png";

                
                
              
                // OR Set Report Path  
                RptCasesheet.LocalReport.EnableExternalImages = true;
                RptCasesheet.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Casesheet.rdlc");
                
                RptCasesheet.LocalReport.SetParameters(new ReportParameter("imagepath", imagePath));
                RptCasesheet.LocalReport.SetParameters(new ReportParameter("StateName", Session["statename"].ToString()));
                // Refresh and Display Report  
                RptCasesheet.LocalReport.Refresh();
            }
        }
        catch (Exception ex)
        {
            //  ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            // Response.Redirect("~/Error.aspx");
        }
    }

    public string GetFullRootUrl()
    {
        HttpRequest request = HttpContext.Current.Request;
        //string url = ConfigurationManager.AppSettings["VirtualDirectory"].ToString();
        int index = request.Url.AbsoluteUri.IndexOf(request.Url.AbsolutePath);
        return request.Url.AbsoluteUri.Substring(0, index);
    }

    protected void btnImgprint_Click(object sender, ImageClickEventArgs e)
    {

        string url = "Print_CaseSheet.aspx";
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.open('");
        sb.Append(url);
        sb.Append("','_blank');");
        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(),
                     "script", sb.ToString());
    }
    //IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void GvVisitDates_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "VisitDate")
        {

            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lnkbtnVisitDate = (Label)gvrow.FindControl("lblVisitDate");
            //DateTime Visitdate = DateTime.Parse(lnkbtnVisitDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            try
            {
                Session["VisitDate"] = (Convert.ToDateTime(lnkbtnVisitDate.Text)).ToString("yyyy/MM/dd");
                getReport(txtRegno.Text.Trim(), (Convert.ToDateTime(lnkbtnVisitDate.Text)).ToString("yyyy/MM/dd"));
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
}