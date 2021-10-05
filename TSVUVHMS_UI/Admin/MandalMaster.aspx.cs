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
    Validate objValidate = new Validate();
    DataTable ddt;
    ListItem li;
    string StateCode = "", Flag_IUP, UserName = "";
    string INSERT, UPDATE, DELETE;
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
        imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
        lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                this.txt_Date.Text = DateTime.Today.ToString("dd/MM/yyyy");
                StateCode = Session["StateCd"].ToString();
                UserName = Session["UsrName"].ToString();
                ddt = objDist.getDistrictsByStateCodeBAL(Session["StateCd"].ToString(), ConnKey);
                objCommon.BindDropDownLists(ddl_dist_code, ddt, "DistName", "DistCode", "0");
                btn_Update.Visible = false;
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }

    protected void GvMandal_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvMandal.PageIndex = e.NewPageIndex;
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GvMandal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {
                DataTable dt = new DataTable();
                StateCode = Session["StateCd"].ToString();
                UserName = Session["UsrName"].ToString();

                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                HiddenField hdndistcode = (HiddenField)gvrow.FindControl("hdndistcode");
                Label lblMCode = (Label)gvrow.FindControl("lblMCode");
                Label lblMName = (Label)gvrow.FindControl("lblMName");
                dt = objDist.DeletemandalBAL(hdndistcode.Value, lblMCode.Text, lblMName.Text, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtMandalCode.Text = "";
                    txtMandalName.Text = "";
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

    protected void GvMandal_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GvMandal.EditIndex = e.NewEditIndex;
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

        if (ddl_dist_code.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select District");
            ddl_dist_code.Focus();
            return false;
        }
        if (txtMandalCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Mandal Code");
            txtMandalCode.Focus();
            return false;
        }
        if (txtMandalName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Mandal Name");
            txtMandalName.Focus();
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
                int ActiveSt = Convert.ToInt16(rbnSy.SelectedValue);
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
                dt = objDist.InsertMandalBAL(ddl_dist_code.SelectedValue.ToString(), txtMandalCode.Text, txtMandalName.Text.Trim(), date, ActiveSt, Session["UsrName"].ToString(), INSERT, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txt_Date.Text = "";
                    txtMandalName.Text = "";
                    txtMandalCode.Text = "";
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
    public void Viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            Flag_IUP = "R";
            dt1 = objDist.viewDistdataBAL(ddl_dist_code.SelectedValue.ToString(), Flag_IUP, ConnKey);
            GvMandal.DataSource = dt1;
            GvMandal.DataBind();
            GvMandal.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

            //Attribute to hide column in Phone.
            GvMandal.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
            GvMandal.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
            GvMandal.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
            GvMandal.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
            //Adds THEAD and TBODY to GridView.
            GvMandal.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            txtMandalCode.Text = ((Label)(gRow.FindControl("lblMCode"))).Text;
            txtMandalName.Text = ((Label)(gRow.FindControl("lblMName"))).Text;
            txt_Date.Text = ((Label)(gRow.FindControl("lbleffdate"))).Text;

            if (status == "Yes")
            {
                rbnSy.SelectedValue = "1";
            }
            if (status == "No")
            {
                rbnSy.SelectedValue = "0";
            }
            lblMcode.Visible = false;
            txt_Date.Enabled = false;
            btn_Update.Visible = true;
            btn_Save.Visible = false;
            txtMandalCode.Enabled = false;
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
                dt = objDist.UpdateMandalBAL(ddl_dist_code.SelectedValue.ToString(), txtMandalCode.Text, txtMandalName.Text.Trim(), ActiveSt, Session["UsrName"].ToString(), UPDATE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtMandalName.Text = "";
                    txtMandalCode.Enabled = true;
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    txtMandalCode.Text = "";

                }
                else
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
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
    protected void txtMandalCode_TextChanged(object sender, EventArgs e)
    {
        if (txtMandalCode.Text.Length < 2)
        {
            txtMandalCode.Text = "0" + txtMandalCode.Text;
        }
        else
        {
            txtMandalCode.Text = txtMandalCode.Text;
        }

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtMandalName.Text = "";
        txtMandalCode.Enabled = true;
        btn_Save.Visible = true;
        btn_Update.Visible = false;
        txtMandalCode.Text = "";
        Viewdata();
    }
}
