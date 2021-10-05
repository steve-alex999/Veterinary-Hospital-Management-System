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
    Validate objValidate = new Validate();
    string INSERT, UPDATE;
    string StateCode = "", Flag_IUP, UserName = "";
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
                getDistrictDtls();
                this.txt_Date.Text = DateTime.Today.ToString("dd/MM/yyyy");
                lblDcode.Visible = false;
                btn_Update.Visible = false;
            }

            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }



    protected bool Validate()
    {
        if (txtDistCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter District Code");
            txtDistCode.Focus();
            return false;
        }
        if (txtDistName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter District Name");
            txtDistName.Focus();
            return false;
        }
        return true;
    }
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Validate())
            {
                INSERT = "I";
                int ActiveSt =Convert.ToInt16(rbnSy.SelectedValue);
                DataTable dt = new DataTable();
                if (txt_Date.Text.Trim() != "")
                {
                    if (!objValidate.IsDate(txt_Date.Text.Trim()))
                    {
                        objCommon.ShowAlertMessage("Enter Valid Date");
                        txt_Date.Focus();
                        return;
                    }
                }

                DateTime date = DateTime.Parse(txt_Date.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                dt = objDist.getInsertDistBAL(Session["StateCd"].ToString(), txtDistCode.Text.Trim(), txtDistName.Text.Trim(), date, ActiveSt, Session["UsrName"].ToString(), INSERT, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txt_Date.Text = "";
                    txtDistName.Text = "";
                    txtDistCode.Text = "";
                }
                getDistrictDtls();

            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }


    protected void getDistrictDtls()
    {
        try
        {
            DataTable dtDistricts = new DataTable();
            dtDistricts = objDist.getdist(Session["StateCd"].ToString(), ConnKey);
            GvDistricts.DataSource = dtDistricts;
            GvDistricts.DataBind();
            if (dtDistricts.Rows.Count > 0)
            {
                GvDistricts.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GvDistricts.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GvDistricts.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GvDistricts.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                GvDistricts.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                GvDistricts.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GvDistricts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvDistricts.PageIndex = e.NewPageIndex;
            getDistrictDtls();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GvDistricts_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GvDistricts.EditIndex = e.NewEditIndex;
            getDistrictDtls();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GvDistricts_RowCommand(object sender, GridViewCommandEventArgs e)
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
                Label lbldistcode = (Label)gvrow.FindControl("lbldcode");
                Label lbldistname = (Label)gvrow.FindControl("lbldnm");
                dt = objDist.DeletedistrictBAL(StateCode, lbldistcode.Text, lbldistname.Text, Flag_IUP, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtDistCode.Text = "";
                    txt_Date.Text = "";

                    txtDistCode.Enabled = true;
                    txtDistName.Text = "";
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    getDistrictDtls();
                }
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
            txtDistCode.Text = ((Label)(gRow.FindControl("lbldcode"))).Text;

            txt_Date.Text = ((Label)(gRow.FindControl("lbleffdate"))).Text;
            txtDistName.Text = ((Label)(gRow.FindControl("lbldnm"))).Text;
            if (status == "Yes")
            {
                rbnSy.SelectedValue = "1";
            }
            if (status == "No")
            {
                rbnSy.SelectedValue = "0";
            }
            txtDistCode.Enabled = false;
            txt_Date.Enabled = false;

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
            if (Validate())
            {
                UPDATE = "U";
                int ActiveSt = Convert.ToInt16(rbnSy.SelectedValue);
                DataTable dt = new DataTable();

                dt = objDist.UpdateDistBAL(Session["StateCd"].ToString(), txtDistCode.Text, txtDistName.Text.Trim(), ActiveSt, Session["UsrName"].ToString(), ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    btn_Save.Visible = true;
                    txtDistCode.Enabled = true;
                    txt_Date.Text = "";
                    txtDistName.Text = "";
                    txtDistCode.Text = "";
                    btn_Update.Visible = false;

                }
                getDistrictDtls();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }


    protected void txtDistCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtDistCode.Text.Length < 2)
            {
                txtDistCode.Text = "0" + txtDistCode.Text;
            }
            else
            {
                txtDistCode.Text = txtDistCode.Text;
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
        btn_Save.Visible = true;
        txtDistCode.Enabled = true;
        txt_Date.Text = "";
        txtDistName.Text = "";
        txtDistCode.Text = "";
        btn_Update.Visible = false;
        getDistrictDtls();
    }
}