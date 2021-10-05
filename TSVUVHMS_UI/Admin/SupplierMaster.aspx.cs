using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class EVHMS_UI_Admin_Default : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    ListItem li;
    string INSERT, UPDATE, GData, Flag_IUP, lblSupCode;
    Validate objValidate = new Validate();
    string UserName, StateCode;
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
        UserName = Session["UsrName"].ToString();
        StateCode = Session["StateCd"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                ddt = objDist.getstate(ConnKey);
                objCommon.BindDropDownLists(ddl_State, ddt, "StateName", "StateCode", "0");
                btn_Update.Visible = false;
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
    protected void GridView1_RowCancelling(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;


    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {
                DataTable dt = new DataTable();

                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblSupCode = (Label)gvrow.FindControl("lblSupCode");

                dt = objDist.DeleteSuplyBAL(lblSupCode.Text, "D", ConnKey);
                if (dt.Rows.Count > 0)
                {

                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtSname.Text = "";
                    txtSaddress.Text = "";
                    txtemail.Text = "";
                    txtMbno.Text = "";
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    Viewdata();
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GridView1.EditIndex = e.NewEditIndex;
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
   
    protected bool Validate()
    {
        if (ddl_State.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select State");
            ddl_State.Focus();
            return false;
        }
        if (ddl_dist_code.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select District");
            ddl_dist_code.Focus();
            return false;
        }
        if (txtSname.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Name");
            txtSname.Focus();
            return false;
        }
        if (txtSaddress.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Address");
            txtSaddress.Focus();
            return false;
        }
        if (txtMbno.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Mobile Number");
            txtMbno.Focus();
            return false;
        }
        if (txtemail.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Email");
            txtemail.Focus();
            return false;
        }
        if (txtemail.Text != "")
        {
            if (!objValidate.IsValidEmail(txtemail.Text))
            {

                objCommon.ShowAlertMessage("Please Enter Valid Email");
                return false;
            }
        }
        if (!objValidate.ISMobileNo(txtMbno.Text, 9, 9))
        {

            objCommon.ShowAlertMessage("Please Enter Valid Mobile Number");
            return false;
        }

        return true;
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (Validate())
        {

            int ActiveSt =Convert.ToInt16(rbnSy.SelectedValue);
            DataTable dt = new DataTable();
            try
            {
                dt = objDist.InsertSuplyBAL(ddl_State.SelectedValue.ToString(), ddl_dist_code.SelectedValue.ToString(), txtSname.Text.Trim(), txtSaddress.Text.Trim(), txtemail.Text.Trim(), txtMbno.Text.Trim(), ActiveSt, UserName, "I", ConnKey);

                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtSname.Text = "";
                    txtSaddress.Text = "";
                    txtemail.Text = "";
                    txtMbno.Text = "";
                }
                Viewdata();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
            finally
            {

            }
        }
    }

    public void Viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = objDist.viewSupplierBAL(ddl_State.SelectedValue.ToString(), ddl_dist_code.SelectedValue.ToString(), "R", ConnKey);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            if (dt1.Rows.Count > 0)
            {
                GridView1.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GridView1.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";

                //Adds THEAD and TBODY to GridView.
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            string status = ((Label)(gRow.FindControl("lblstatus"))).Text;
            txtSname.Text = ((Label)(gRow.FindControl("lblSName"))).Text;
            txtSaddress.Text = ((Label)(gRow.FindControl("lblSaddress"))).Text;
            txtemail.Text = ((Label)(gRow.FindControl("lblemail"))).Text;
            txtMbno.Text = ((Label)(gRow.FindControl("lblMbno"))).Text;
            Session[lblSupCode] = ((Label)(gRow.FindControl("lblSupCode"))).Text;

            if (status == "Yes")
            {
                rbnSy.SelectedValue = "1";
            }
            if (status == "No")
            {
                rbnSy.SelectedValue = "0";
            }
            btn_Save.Visible = false;
            btn_Update.Visible = true;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            if (Validate())
            {
                UPDATE = "U";
                int ActiveSt =Convert.ToInt16(rbnSy.SelectedValue);
                DataTable dt = new DataTable();

                dt = objDist.UpdateSuplyBAL(ddl_State.SelectedValue.ToString(), ddl_dist_code.SelectedValue.ToString(), Session[lblSupCode].ToString(), txtSname.Text.Trim(), txtSaddress.Text.Trim(), txtemail.Text.Trim(), txtMbno.Text.Trim(), ActiveSt, Session["UsrName"].ToString(), UPDATE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtSname.Text = "";
                    txtSaddress.Text = "";
                    txtemail.Text = "";
                    txtMbno.Text = "";
                    Viewdata();
                  

                }
                Viewdata();
                btn_Save.Visible = true;
                btn_Update.Visible = false;

            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
        finally
        {

        }
    }


    protected void ddl_dist_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Viewdata();

        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }


    protected void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddt = objDist.getDistrictsByStateCodeBAL(ddl_State.SelectedValue.ToString(), ConnKey);
            objCommon.BindDropDownLists(ddl_dist_code, ddt, "DistName", "DistCode", "0");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtSname.Text = "";
        txtSaddress.Text = "";
        txtemail.Text = "";
        txtMbno.Text = "";
        Viewdata();
        btn_Save.Visible = true;
        btn_Update.Visible = false;
    }
}
