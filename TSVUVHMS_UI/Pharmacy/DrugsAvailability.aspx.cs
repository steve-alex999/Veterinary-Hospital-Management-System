using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVUVHMS_BL;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Text;


public partial class Pharmacy_DrugsAvailability : System.Web.UI.Page
{

    PharmacyBAL objPhar = new PharmacyBAL();
    InstutionBAL objIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    string[] drugcode;
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
        if (Session["UsrName"] == null || Session["Role"] == null)
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
                //if (Session["Role"].ToString() == "1")
                //{
                //    Session["UniqueInstId"] = "ALL";
                //    Imghome.PostBackUrl = "~/Admin/DashBoard_Admin.aspx";

                //}
                //if (Session["Role"].ToString() == "2")
                //{
                //    Imghome.PostBackUrl = "~/Institution/DashBoard_Ins.aspx";

                //}
                //if (Session["Role"].ToString() == "3")
                //{
                //    Imghome.PostBackUrl = "~/Pharmacy/DashBoard_Phar.aspx";

                //}
                //if (Session["Role"].ToString() == "4")
                //{
                //    Imghome.PostBackUrl = "~/Diagnostic/DashBoard_Dia.aspx";

                //}
                //if (Session["Role"].ToString() == "5")
                //{
                //    Imghome.PostBackUrl = "~/Doctor/Rpt_PatientHistory.aspx";

                //}

                GetInsNameBAL();
                BindDrugs();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

    }

    protected void BindDrugs()
    {
        ddt = objPhar.getdrugIns(Session["UniqueInstId"].ToString(), ConnKey);
        if (ddt.Rows.Count > 0)
        {
            ddl_Drug.DataSource = ddt;
            ddl_Drug.DataTextField = "DrugName";
            ddl_Drug.DataValueField = "DrugCode";
            ddl_Drug.DataBind();
        }

    }
    protected void ddl_Drug_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<String> DrugID_list = new List<string>();
            List<String> DrugName_list = new List<string>();

            foreach (System.Web.UI.WebControls.ListItem item in ddl_Drug.Items)
            {
                if (item.Selected)
                {
                    DrugID_list.Add(item.Value);
                    DrugName_list.Add(item.Text);
                }

            }

            // ddl_Drug.Texts.SelectBoxCaption = String.Join(",", DieaseName_list.ToArray());
            Session["DrugCodeList"] = String.Join(",", DrugID_list.ToArray());
            if (Session["DrugCodeList"].ToString() != "")
            {
                ddl_Drug.Texts.SelectBoxCaption = "Selected";
            }
            else
            {
                ddl_Drug.Texts.SelectBoxCaption = "Select Drugs";
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
    protected bool Validateform()
    {
        if (ddl_Drug.SelectedValue == "")
        {
            objCommon.ShowAlertMessage("Select Drug ");

            return false;
        }
        if (rblSortvalue.SelectedValue == "")
        {
            objCommon.ShowAlertMessage("Select Any One in Sort");

            return false;
        }
        if (rblSortorder.SelectedValue == "")
        {
            objCommon.ShowAlertMessage("Select Any One in Order");

            return false;
        }

        return true;
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (Validateform())
        {
            getReports();


        }
    }
    public void GetInsNameBAL()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objIns.GetInsNameBAL(Session["UniqueInstId"].ToString(), Session["UsrName"].ToString(), ConnKey);
            lblInsName.Text = dt.Rows[0]["InstitutionName"].ToString();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    public void getReports()
    {
        try
        {
            string s = Session["DrugCodeList"].ToString();
            RptDrugAvailability.LocalReport.DataSources.Clear();
            ddt = objPhar.getDrugsAvailBAL1(Session["UniqueInstId"].ToString(), Session["DrugCodeList"].ToString(), rblSortvalue.SelectedValue, rblSortorder.SelectedValue, ConnKey);
            RptDrugAvailability.LocalReport.DataSources.Add(new ReportDataSource("DS_RptDrugAvailability", ddt));
            // OR Set Report Path  
            RptDrugAvailability.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DrugAvailability.rdlc");
            RptDrugAvailability.ShowPrintButton = true;
            // Refresh and Display Report  
            RptDrugAvailability.LocalReport.Refresh();

            btnImgprint.Visible = true;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }

    protected void btnImgprint_Click(object sender, ImageClickEventArgs e)
    {
        LocalReport Rpt = RptDrugAvailability.LocalReport;
        Session["Rpt"] = Rpt;
        string url = "Print_DrugAvailability.aspx";
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