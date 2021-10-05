using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVUVHMS_BL;
using System.Data;
using System.Web.Security;
using Microsoft.Reporting.WebForms;
using System.Text;
using System.Data.SqlClient;


public partial class Rpt_PatientHistory : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    InstutionBAL ObjIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();
    ReportBAL objRptBL = new ReportBAL();
    DataTable ddt;
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
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "5")
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
            //try
            {
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                GetInsNameBAL();
                viewdata();
            }
            //catch (Exception ex)
            //{
            //    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            //    Response.Redirect("~/Error.aspx");
            //}        
        }
    }

    protected void GvPatientDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvPatientDtls.PageIndex = e.NewPageIndex;
            viewdata();
            Report_PatientHistory.Visible = false;
            btnImgprint.Visible = false;
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
        string RegNo;
        //try
        {
            if (txtDate.Text.Trim() == "")
                txtDate.Text = "01/01/1990";
            if (txtDate.Text.Trim() != "")
            {
                if (!objValidate.IsDate(txtDate.Text.Trim()))
                {
                    objCommon.ShowAlertMessage("Enter Valid Date");
                    txtDate.Focus();
                    return;
                }
            }
            ViewState["VisitDate"] = txtDate.Text.Trim();

            if (txt_FregNo.Text.Trim() != "")
                RegNo = txt_FregNo.Text.Trim();
            else
                RegNo="ALL";

            DataTable dt1 = new DataTable();
            DateTime VisitDate = DateTime.Parse(txtDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DoctorID FROM Dtls_Doctor WHERE Doctor=@Doctor"))
                {
                    cmd.Parameters.AddWithValue("@Doctor", lblUsrName.Text);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string id = reader[0].ToString();
                        dt1 = objRptBL.GetPatientDtlsByRegNo_or_VisitDateBAL(UniqueInstId, RegNo, VisitDate, ConnKey, id);
                    }
                    con.Close();
                }
            }

            
            if (dt1.Rows.Count > 0)
            {
                GvPatientDtls.DataSource = dt1;
                GvPatientDtls.DataBind();
                GvPatientDtls.Visible = true;
                if (dt1.Rows.Count > 0)
                {
                    GvPatientDtls.HeaderRow.Cells[1].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    GvPatientDtls.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
                    GvPatientDtls.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                    GvPatientDtls.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                    GvPatientDtls.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                    GvPatientDtls.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                    GvPatientDtls.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
                    GvPatientDtls.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                if (txtDate.Text == "01/01/1990")
                    txtDate.Text = "";

            }
            else
            {
                GvPatientDtls.DataSource = null;
                GvPatientDtls.DataBind();
                GvPatientDtls.Visible = true;
            }
            
        }
        //catch (Exception ex)
        //{
        //    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //    Response.Redirect("~/Error.aspx");
        //}


    }
    protected void lnkRegNo_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            LinkButton lblRegNo = (LinkButton)gRow.FindControl("linkgetregno");
            Session["RegNo"] = lblRegNo.Text;
            try
            {
                GvPatientDtls.HeaderRow.Cells[1].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GvPatientDtls.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
                GvPatientDtls.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GvPatientDtls.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                GvPatientDtls.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                GvPatientDtls.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                GvPatientDtls.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
                GvPatientDtls.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
            getReport(lblRegNo.Text);            
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }        
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {   
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void getReport(string RegNo)
    {
        try
        {
            Report_PatientHistory.LocalReport.DataSources.Clear();
            // Set a DataSource to the report  
            // First Parameter - Report DataSet Name  
            // Second Parameter - DataSource Object i.e DataTable  
            //DateTime FromDt = DateTime.Parse(txtFromDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            //DateTime ToDt = DateTime.Parse(txtToDt.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

            DataTable dt = objRptBL.GetPatientHistoryDtlsBAL(Session["UniqueInstId"].ToString(), RegNo, ConnKey);
            if (dt.Rows.Count > 0)
            {
                Report_PatientHistory.LocalReport.DataSources.Add(new ReportDataSource("Ds_Rpt_PatientHistory", dt));
                // OR Set Report Path  
                Report_PatientHistory.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_PatientHistory.rdlc");
                // Refresh and Display Report  
                Report_PatientHistory.LocalReport.Refresh();
                Report_PatientHistory.Visible = true;
                //lblNoRecordFound.Visible = false;
                btnImgprint.Visible = true;
            }
            else
            {
                //lblNoRecordFound.Visible = true;
                Report_PatientHistory.Visible = false;
                //lblNoRecordFound.Text = "No Record Found!!";
                btnImgprint.Visible = false;                
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
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
    protected void btnImgprint_Click(object sender, EventArgs e)
    {
        try
        {
            Session["ReportName"] = "PatientHistory";
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
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }        
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        GvPatientDtls.Visible = false;
        btnImgprint.Visible = false;
        Report_PatientHistory.Visible = false;
    }
}
