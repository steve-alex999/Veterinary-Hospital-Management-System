using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;
using System.Configuration;
using System.Collections;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;

public partial class Diag_Test : System.Web.UI.Page
{

    InstutionBAL objIns = new InstutionBAL();

    DiagBAL objDiag = new DiagBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt,Chddt;
    decimal tot = 0, tot1 = 0;
    string ConnKey;
   
    protected void Page_Load(object sender, EventArgs e)
    {
      
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
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "4")
        {
            Response.Redirect("~/Error.aspx");
        }
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        if (Session["RegNo"].ToString() == null)
            Response.Redirect("~/Error.aspx");

        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                ddt = objDiag.FetchPaitentDtlsBAL(Session["RegNo"].ToString(), ConnKey);
                lblRegistrationNo.Text = ddt.Rows[0]["RegistrationNo"].ToString();
                lblOwnerNm.Text = ddt.Rows[0]["Owner_Name"].ToString();
                ViewState["Animal"] = lblAnimal.Text = ddt.Rows[0]["AnimalTypeDesc"].ToString();
                lblVisitId.Text = ddt.Rows[0]["VisitId"].ToString();
                lblVisitDt.Text = ddt.Rows[0]["Reg_Dt"].ToString();

                GetInsNameBAL();
                BindData();
                btn_Save.Visible = false;
                btn_Save.Enabled = true;
            }
            catch (Exception ex)
            {

                Response.Redirect("~/Error.aspx");
            }

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

            Response.Redirect("~/Error.aspx");
        }
    }
    protected bool Validate_Save()
    {
        if (rdExempted.SelectedIndex < 0)
        {
            objCommon.ShowAlertMessage("Select an option for Exempted Category");
            rdExempted.Focus();
            return false;
        }
        if (chktest.SelectedValue == "")
        {
            objCommon.ShowAlertMessage("Select Test");
            chktest.Focus();
            return false;
        }
        return true;
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        btn_Save.Enabled = false;
        try
        {
            if (Validate_Save())
            {
                //objDiag.ChkTestBAL(Session["RegNo"].ToString(), lblTestcode.Text, ConnKey);
                objDiag.InsertDiagTestsBAL(Session["UniqueInstId"].ToString(), Session["RegNo"].ToString(), lblTestcode.Text, rdExempted.SelectedValue, Session["UsrName"].ToString(), ConnKey);
                btn_Save.Visible = false;     
                Session["TestDate"] = lblDate.Text;
                
                Response.Redirect("~/Diagnostic/Rpt_Diag_Test.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void BindData()
    {
        try
        {
            ddt = objDiag.getTestBAL(Session["UniqueInstId"].ToString(), ConnKey);
            objCommon.BindCheckLists(chktest, ddt, "TestName", "TestCode", "0");
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void BindDiagTestGrid()
    {
        try
        {
            if (rdExempted.SelectedIndex < 0)
            {
                objCommon.ShowAlertMessage("Select an option for Exempted Category");
                rdExempted.Focus();

                foreach (ListItem item in chktest.Items)
                {
                    item.Selected = false;
                }
                return;
            }
            List<String> TestID_list = new List<string>();
            List<String> TestName_list = new List<string>();

            foreach (System.Web.UI.WebControls.ListItem item in chktest.Items)
            {
                if (item.Selected)
                {
                    TestID_list.Add(item.Value);
                    TestName_list.Add(item.Text);
                }

                lblTestcode.Text = String.Join(",", TestID_list.ToArray());
                //lblDName.Text = String.Join(",", TestName_list.ToArray());
            }

            ddt = objDiag.GetTestDtlsBAL(Session["UniqueInstId"].ToString(), lblTestcode.Text, ConnKey);
            if (ddt.Rows.Count > 0)
            {
                /*IF EXEMPTED CATEGORY IS YES THEN FEE PAYABLE IS ZERO*/
                if (rdExempted.SelectedValue == "Yes")
                {
                    for (int i = 0; i < ddt.Rows.Count; i++)
                        ddt.Rows[i]["FeePaidByGovt"] = ddt.Rows[i]["TotalTestFee"].ToString();
                }
                else
                {
                    /*IF ANIMAL IS DOG OR CAT  , ONLY THEN TEST FEE SHOULD BE COLLECTED ,, ELSE IT IS ZERO*/
                    if (ViewState["Animal"].ToString() != "Cat" && ViewState["Animal"].ToString() != "Dog")
                    {
                        for (int i = 0; i < ddt.Rows.Count; i++)
                            ddt.Rows[i]["FeePaidByGovt"] = ddt.Rows[i]["TotalTestFee"].ToString();
                    }
                }
                GvTestDtls.Visible = true;
                GvTestDtls.DataSource = ddt;
                GvTestDtls.DataBind();
                btn_Save.Visible = true;
            }
            else
            {
                GvTestDtls.DataSource = null;
                GvTestDtls.DataBind();
                btn_Save.Visible = false;
            }

        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void chktest_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDiagTestGrid();
    }
    protected void GvTestDtls_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            GridViewRow row = (GridViewRow)GvTestDtls.Rows[e.RowIndex];
            Label lblTcode = (Label)row.FindControl("lblTcode");

            DataTable dt = new DataTable();
            dt.Columns.Add("TestCode", typeof(int));
            dt.Columns.Add("TestName", typeof(string));
            dt.Columns.Add("TotalTestFee", typeof(int));
            dt.Columns.Add("FeePaidByGovt", typeof(int));
            int i = 0;
            foreach (GridViewRow gr in GvTestDtls.Rows)
            {
                dt.Rows.Add();
                dt.Rows[i]["TestCode"] = ((Label)gr.FindControl("lblTcode")).Text;
                dt.Rows[i]["TestName"] = ((Label)gr.FindControl("lblTname")).Text;
                dt.Rows[i]["TotalTestFee"] = ((Label)gr.FindControl("lblAmount")).Text;
                dt.Rows[i]["FeePaidByGovt"] = ((Label)gr.FindControl("lblPaidBygovt")).Text;
                // dt.Rows[i]["Amount"] = ((Label)gr.FindControl("lblAmount")).Text;
                i++;
            }
            Label TestCode = (Label)GvTestDtls.Rows[e.RowIndex].FindControl("lblTcode");
            foreach (ListItem item in chktest.Items)
            {

                if (item.Value == TestCode.Text)
                {

                    item.Selected = false;
                    break;

                }

            }
            List<String> TestID_list = new List<string>();
            List<String> TestName_list = new List<string>();

            foreach (System.Web.UI.WebControls.ListItem item in chktest.Items)
            {
                if (item.Selected)
                {
                    TestID_list.Add(item.Value);
                    TestName_list.Add(item.Text);
                }

                lblTestcode.Text = String.Join(",", TestID_list.ToArray());
                //lblDName.Text = String.Join(",", TestName_list.ToArray());
            }
            dt.Rows.RemoveAt(e.RowIndex);
            GvTestDtls.DataSource = null;
            GvTestDtls.DataSource = dt;
            GvTestDtls.DataBind();
            if (dt.Rows.Count > 0)
            {
                GvTestDtls.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                GvTestDtls.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GvTestDtls.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GvTestDtls.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
               

                GvTestDtls.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GvTestDtls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // tot + = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
                tot += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalTestFee"));
                tot1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "FeePaidByGovt"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotal = (Label)e.Row.FindControl("lblAmounttotal");
                lblTotal.Text = tot.ToString();
                Label lblGovtTotal = (Label)e.Row.FindControl("lblGovtotal");
                lblGovtTotal.Text = tot1.ToString();
                Label lblNotPaytotal = (Label)e.Row.FindControl("lblNotPaytotal");
                lblNotPaytotal.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblGovtTotal.Text)).ToString();

            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void rdExempted_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        BindDiagTestGrid();
    }
}
