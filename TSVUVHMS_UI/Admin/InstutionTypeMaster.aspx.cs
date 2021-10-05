using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class EVHMS_UI_Admin_MandalMaster : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    ListItem li;
    string INSERT, UPDATE, StateCode = "", UserName = "", Flag_IUP;
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
                Viewdata();
                btn_Update.Visible = false;
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

    }

    protected void GvInsType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvInsType.PageIndex = e.NewPageIndex;
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }

    protected void GvInsType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GvInsType.EditIndex = e.NewEditIndex;
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GvInsType_RowCommand(object sender, GridViewCommandEventArgs e)
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
                Label lblInstTypeCode = (Label)gvrow.FindControl("lblInstTypeCode");
                Label lblInstTypeName = (Label)gvrow.FindControl("lblInstTypeName");
                dt = objDist.DeleteInsTypeBAL(lblInstTypeCode.Text, Flag_IUP, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtInstutionCode.Text = "";
                    txtInstutionName.Text = "";
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    txtInstutionCode.Enabled = true;
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
    public bool ValidateInsType()
    {
        if (txtInstutionCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Instution Type Code");
            return false;
        }
        if (txtInstutionName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Instution Type Name");
            return false;
        }
        return true;
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateInsType())
            {
                int ActiveSt = Convert.ToInt16(rbnSy.SelectedValue);
                INSERT = "I";
                DataTable dt = new DataTable();
                dt = objDist.InsertInstituionBAL(txtInstutionCode.Text, txtInstutionName.Text.Trim(), ActiveSt, Session["UsrName"].ToString(), INSERT, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtInstutionCode.Text = "";
                    txtInstutionName.Text = "";
                }
                Viewdata();
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

    public void Viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = objDist.viewInstitutiondataBAL( ConnKey);
            GvInsType.DataSource = dt1;
            GvInsType.DataBind();
            GvInsType.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

            //Attribute to hide column in Phone.
            GvInsType.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
            GvInsType.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
            GvInsType.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
           
            //Adds THEAD and TBODY to GridView.
            GvInsType.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            txtInstutionCode.Text = ((Label)(gRow.FindControl("lblInstTypeCode"))).Text;
            txtInstutionName.Text = ((Label)(gRow.FindControl("lblInstTypeName"))).Text;
            string status = ((Label)(gRow.FindControl("lblstatus"))).Text;
            if (status == "Yes")
            {
                rbnSy.SelectedValue = "1";
            }
            if (status == "No")
            {
                rbnSy.SelectedValue = "0";
            }
            txtInstutionCode.Enabled = false;
            btn_Update.Visible = true;
            btn_Save.Visible = false;
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
            if (ValidateInsType())
            {
                UPDATE = "U";
                int ActiveSt = Convert.ToInt16(rbnSy.SelectedValue);
                DataTable dt = new DataTable();
                dt = objDist.UpdateInstituionBAL(txtInstutionCode.Text, txtInstutionName.Text.Trim(), ActiveSt, Session["UsrName"].ToString(), UPDATE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtInstutionCode.Text = "";
                    txtInstutionName.Text = "";
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    txtInstutionCode.Enabled = true;
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
    protected void txtInstutionCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtInstutionCode.Text.Length < 2)
            {
                txtInstutionCode.Text = "0" + txtInstutionCode.Text;
            }
            else
            {
                txtInstutionCode.Text = txtInstutionCode.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtInstutionCode.Text = "";
        txtInstutionName.Text = "";
        btn_Save.Visible = true;
        btn_Update.Visible = false;
        txtInstutionCode.Enabled = true;
        Viewdata();
    }
}
