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


public partial class P_Rpt_DrugsAvailability : System.Web.UI.Page
{
   
    PharmacyBAL objPhar = new PharmacyBAL();
    InstutionBAL objIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    MasterBAL objMstBL = new MasterBAL();
    DataTable ddt;
    string[] drugcode;
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");

                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                /*Bind Districts*/
                ddt = objMstBL.getDistrictsByStateCodeBAL(Session["statecd"].ToString(), ConnKey);
                objCommon.BindDropDownLists(ddlDist, ddt, "DistName", "DistCode", "0");
            }
            catch (Exception ex)
            {
               
                Response.Redirect("~/Error.aspx");
            }
            
        }     

        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
       
    }
   
    protected void ddlDist_OnSelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {/*Bind Institutions By Dist Code*/
            DataTable ddt = objMstBL.GetInstByDistCodeBAL(Session["statecd"].ToString(), ddlDist.SelectedValue.ToString(), ConnKey);
            objCommon.BindDropDownLists(ddlInst, ddt, "InstitutionName", "Unique_InstId", "0");
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
        RptDrugAvailability.Visible = false;
    }
    protected void BindDrugs()
    {
        try
        {

            ddt = objPhar.getdrugIns(ddlInst.SelectedValue.ToString(), ConnKey);
            if (ddt.Rows.Count > 0)
            {
                ddl_Drug.DataSource = ddt;
                ddl_Drug.DataTextField = "DrugName";
                ddl_Drug.DataValueField = "DrugCode";
                ddl_Drug.DataBind();
            }
        }
        catch (Exception ex)
        {
            
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddl_Drug_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<String> DieaseID_list = new List<string>();
            List<String> DieaseName_list = new List<string>();

            foreach (System.Web.UI.WebControls.ListItem item in ddl_Drug.Items)
            {
                if (item.Selected)
                {
                    DieaseID_list.Add(item.Value);
                    DieaseName_list.Add(item.Text);
                }
            }
            Session["DrugCodeList"] = String.Join(",", DieaseID_list.ToArray());
            //if (Session["DrugCodeList"].ToString() != "")
            //{
            //    ddl_Drug.Texts.SelectBoxCaption = "Selected";
            //}
            //else
            //{
            //    ddl_Drug.Texts.SelectBoxCaption = "Select Drugs";
            //}
            RefreshOnChng();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected bool Validateform()
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
    public void getReports()
    {
        try
        {
            string s = Session["DrugCodeList"].ToString();
            RptDrugAvailability.LocalReport.DataSources.Clear();
            ddt = objPhar.getDrugsAvailBAL1(ddlInst.SelectedValue, Session["DrugCodeList"].ToString(), rblSortvalue.SelectedValue, rblSortorder.SelectedValue, ConnKey);
            if (ddt.Rows.Count > 0)
            {
                RptDrugAvailability.LocalReport.DataSources.Add(new ReportDataSource("DS_RptDrugAvailability", ddt));
                // OR Set Report Path  
                RptDrugAvailability.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/Rpt_DrugAvailability.rdlc");
                RptDrugAvailability.ShowPrintButton = true;
                // Refresh and Display Report  
                RptDrugAvailability.LocalReport.Refresh();
                RptDrugAvailability.Visible = true;
                lblNoRecordFound.Visible = false;
                btnImgprint.Visible = true;
            }
            else
            {
                lblNoRecordFound.Visible = true;
                RptDrugAvailability.Visible = false;
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
            Session["ReportName"] = "DrugsAvailability";
            Session["UniqueInstId"] = ddlInst.SelectedValue.ToString();
            Session["Sort"] = rblSortvalue.SelectedValue;
            Session["Order"] = rblSortorder.SelectedValue;
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

    protected void ddlIns_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            /*BIND DRUGS*/
            BindDrugs();
            RefreshOnChng();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
}