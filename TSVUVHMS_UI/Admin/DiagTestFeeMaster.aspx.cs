using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class DiagTestFeeMaster : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    string UserName = "";
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
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "1")
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
                ddt = objDist.getIns(ConnKey);
                objCommon.BindDropDownLists(ddl_Ins_code, ddt, "InstitutionName", "InstitutionCode", "0");                
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        btn_Update.Visible = false;
    }
    public void Viewdata()
    {
        try
        {
            if (ddl_Ins_code.SelectedIndex <= 0)
            {
                objCommon.ShowAlertMessage("Select Institution");
                ddl_Ins_code.Focus();
                return;
            }
            DataTable dt1 = new DataTable();
            dt1 = objDist.viewDiagBAL(ddl_Ins_code.SelectedValue.ToString(), ConnKey);
            GvDiag.DataSource = dt1;
            GvDiag.DataBind();
            if (dt1.Rows.Count > 0)
            {
                GvDiag.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GvDiag.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GvDiag.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GvDiag.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";

                //Adds THEAD and TBODY to GridView.
                GvDiag.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GvDiag_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvDiag.PageIndex = e.NewPageIndex;
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GvDiag_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {

                DataTable dt = new DataTable();
                UserName = Session["UsrName"].ToString();
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblTestCd = (Label)gvrow.FindControl("lblTestCd");
                dt = objDist.DeleteDiagBAL(ddl_Ins_code.SelectedValue, lblTestCd.Text, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    txtTestFee.Text = "";
                    txtFeeP.Text = "";

                }
                else
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    txtTestFee.Text = "";
                    txtFeeP.Text = "";
                }
                Viewdata();
            }

            if (e.CommandName == "Edt")
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                ddlDiagTest.Enabled = false;
                ViewState["DiagTestCode"] = ((Label)(gvrow.FindControl("lblTestCd"))).Text;
                ddlDiagTest.SelectedItem.Text = ((Label)(gvrow.FindControl("lblTestName"))).Text;
                txtTestFee.Text = ((Label)(gvrow.FindControl("lblTotFee"))).Text;
                txtFeeP.Text = ((Label)(gvrow.FindControl("lblFeeP"))).Text;
                btn_Update.Visible = true;
                btn_Save.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected bool Validatedig()
    {
        if (ddl_Ins_code.SelectedIndex <= 0 )
        {
            objCommon.ShowAlertMessage("Select Institution");
            ddl_Ins_code.Focus();
            return false;
        }
        if (ddlDiagTest.Enabled==true && ddlDiagTest.SelectedIndex <= 0 )
        {
            objCommon.ShowAlertMessage("Select Diagnostic Test/Procedure");
            ddlDiagTest.Focus();
            return false;
        }
        if (txtTestFee.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Test Fee");
            txtTestFee.Focus();
            return false;
        }
        if (txtTestFee.Text == "0")
        {
            objCommon.ShowAlertMessage("Test Fee cannot be zero");
            txtTestFee.Focus();
            return false;
        }
        if (txtFeeP.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Fee Paid By The Government");
            txtFeeP.Focus();
            return false;
        }
        if (Convert.ToInt32(txtFeeP.Text) > Convert.ToInt32(txtTestFee.Text))
        {
            objCommon.ShowAlertMessage("Fee Paid by the Govt. cannot be greater than Total Test Fee");
            txtFeeP.Focus();
            return false;
        }
        return true;
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Validatedig())
            {
                UserName = Session["UsrName"].ToString();

                ddt = objDist.InsertDiagBAL(ddl_Ins_code.SelectedValue,ddlDiagTest.SelectedValue, txtTestFee.Text.Trim(), txtFeeP.Text.Trim(), UserName, ConnKey);
                if (ddt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
                    DataTable dt = objDist.GetDiagTestDtls_ByUniqueInsIdBAL(ddl_Ins_code.SelectedValue.ToString(), ConnKey);
                    objCommon.BindDropDownLists(ddlDiagTest, dt, "DiagTestName", "DiagTestCode", "0");     
                    txtTestFee.Text = "";
                    txtFeeP.Text = "";
                }
                Viewdata();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
       
        DataTable ddt = new DataTable();
        try
        {
            if (Validatedig())
            {
                ddt = objDist.UpdateDiagBAL(ddl_Ins_code.SelectedValue,ViewState["DiagTestCode"].ToString(), txtTestFee.Text.Trim(), txtFeeP.Text.Trim(), Session["UsrName"].ToString(), ConnKey);
                if (ddt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
                    DataTable dt = objDist.GetDiagTestDtls_ByUniqueInsIdBAL(ddl_Ins_code.SelectedValue.ToString(), ConnKey);
                    objCommon.BindDropDownLists(ddlDiagTest, dt, "DiagTestName", "DiagTestCode", "0");
                    ddlDiagTest.Enabled = true;
                    txtTestFee.Text = "";
                    txtFeeP.Text = "";
                    btn_Save.Visible = true;
                }
                else
                {
                    objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
                }
                Viewdata();
            }
            else
            {
                btn_Update.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddl_Ins_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*BIND GRID AND BIND TEST DDL FOR WHICH TEST FEE HAS TO BE ENTERED*/
        if (ddl_Ins_code.SelectedIndex <= 0)
        {
            objCommon.ShowAlertMessage("Select Institution");
            ddl_Ins_code.Focus();
            return;
        }
        Viewdata();
        DataTable dt = objDist.GetDiagTestDtls_ByUniqueInsIdBAL(ddl_Ins_code.SelectedValue.ToString(), ConnKey);
        objCommon.BindDropDownLists(ddlDiagTest, dt, "DiagTestName", "DiagTestCode", "0");
        ddlDiagTest.Enabled = true; 
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        DataTable dt = objDist.GetDiagTestDtls_ByUniqueInsIdBAL(ddl_Ins_code.SelectedValue.ToString(), ConnKey);
        objCommon.BindDropDownLists(ddlDiagTest, dt, "DiagTestName", "DiagTestCode", "0");
        ddlDiagTest.Enabled = true;
        txtTestFee.Text = "";
        txtFeeP.Text = "";
        btn_Save.Visible = true;
        Viewdata();
    }
}


