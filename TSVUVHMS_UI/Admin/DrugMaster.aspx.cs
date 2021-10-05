using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;

public partial class Admin_DrugMaster : System.Web.UI.Page
{
    int sno;
    string date;
    string INSERT, UPDATE, GData;
    string StateCode = "", Flag_IUP, UserName = "";
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
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
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        ConnKey = Session["ConnStr"].ToString();
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "1")
        {
            Response.Redirect("~/Error.aspx");
        }
        if (!IsPostBack)
        {
            try
            {
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                btn_Update.Visible = false;
                viewdata();
                BindUnit();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

    }
    private void BindUnit()
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = objDist.viewUomdataBAL(ConnKey);
            objCommon.BindDropDownLists(ddl_Units, dt1, "UnitName", "UnitCode", "0");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
    private void viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            GData = "R";
            dt1 = objDist.viewdDrugBAL(GData, ConnKey);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

            //Attribute to hide column in Phone.
            GridView1.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
            GridView1.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
            GridView1.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";

            //Adds THEAD and TBODY to GridView.
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Validate())
            {
                INSERT = "I";
                DataTable dt = new DataTable();
                dt = objDist.getInsertDrugBAL(txtDrugCode.Text.Trim(), txtDrugName.Text.Trim(), ddl_Units.SelectedItem.Text.Trim(), Session["UsrName"].ToString(), INSERT, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtDrugName.Text = "";
                    ddl_Units.SelectedValue = "0";
                    txtDrugCode.Text = "";
                    viewdata();

                }

            }
           
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
    protected bool Validate()
    {
        if (txtDrugCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Drug Code");
            txtDrugCode.Focus();
            return false;
        }
        if (txtDrugName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Drug Name");
            txtDrugName.Focus();
            return false;
        }
        string er = ddl_Units.SelectedItem.Text;
        if (ddl_Units.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Unit of Measurement");
            ddl_Units.Focus();
            return false;
        }

        return true;
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
           // if (Validate())
          //  {
                UPDATE = "U";
                DataTable dt = new DataTable();

                dt = objDist.getUpdateDrugBAL(txtDrugCode.Text.Trim(), txtDrugName.Text.Trim(), ddl_Units.SelectedItem.Text, Session["UsrName"].ToString(), UPDATE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    btn_Save.Visible = true;
                    txtDrugName.Text = "";
                    txtDrugCode.Text = "";
                    txtDrugCode.Enabled = true;
                    btn_Update.Visible = false;
                }
                viewdata();

           // }
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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {
                DataTable dt = new DataTable();
                StateCode = Session["StateCd"].ToString();
                UserName = Session["UsrName"].ToString();
                Flag_IUP = "D";
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lbldcode = (Label)gvrow.FindControl("lbldcode");
                Label lbldnm = (Label)gvrow.FindControl("lbldnm");
                dt = objDist.DeleteDrugBAL(lbldcode.Text, lbldnm.Text, Flag_IUP, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtDrugCode.Text = "";
                    txtDrugName.Text = "";
                    viewdata();

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
            viewdata();
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
            txtDrugCode.Text = ((Label)(gRow.FindControl("lbldcode"))).Text;
            txtDrugName.Text = ((Label)(gRow.FindControl("lbldnm"))).Text;
            ddl_Units.SelectedValue = ((Label)(gRow.FindControl("lblUnitCode"))).Text;
            //ddl_Units.SelectedValue = ((Label)(gRow.FindControl("lblunit"))).Text;
            txtDrugName.Text = ((Label)(gRow.FindControl("lbldnm"))).Text;
            txtDrugCode.Enabled = false;
            btn_Update.Visible = true;
            btn_Save.Visible = false;

        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        btn_Save.Visible = true;
        txtDrugName.Text = "";
        txtDrugCode.Text = "";
        txtDrugCode.Enabled = true;
        btn_Update.Visible = false;
        viewdata();
    }
}