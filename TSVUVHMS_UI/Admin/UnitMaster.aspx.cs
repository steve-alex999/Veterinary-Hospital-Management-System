using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class DiseaseMaster : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
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
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
       
        if (!IsPostBack)
        {
            try
            {
                ConnKey = Session["ConnStr"].ToString();
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                Viewdata();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

        btn_Update.Visible = false;
    }


    protected void GvUnits_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvUnits.PageIndex = e.NewPageIndex;
            Viewdata();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GvUnits_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Dlt")
            {

                DataTable dt = new DataTable();
                StateCode = Session["StateCd"].ToString();
                UserName = Session["UsrName"].ToString();
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                DELETE = "D";
                Label lblUCode = (Label)gvrow.FindControl("lblUCode");
                Label lblUName = (Label)gvrow.FindControl("lblUName");
                dt = objDist.DeleteUomBAL(lblUCode.Text, lblUName.Text, DELETE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtUnitCode.Text = "";
                    txtUnitName.Text = "";
                    btn_Save.Visible = true;
                    txtUnitCode.Enabled = true;
                    btn_Update.Visible = false;
                    Viewdata();
                }
                else
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtUnitCode.Text = "";
                    txtUnitName.Text = "";
                    btn_Save.Visible = true;
                    txtUnitCode.Enabled = true;
                    btn_Update.Visible = false;


                }
            }

            if (e.CommandName == "Edt")
            {

                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                DELETE = "D";
                txtUnitCode.Text = ((Label)(gvrow.FindControl("lblUCode"))).Text;
                txtUnitName.Text = ((Label)(gvrow.FindControl("lblUName"))).Text;
                txtUnitCode.Enabled = false;
                btn_Update.Visible = true;
                btn_Save.Visible = false;

            }
            Viewdata();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }


    protected bool Validate()
    {
        if (txtUnitCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Unit Code");
            txtUnitCode.Focus();
            return false;
        }
        if (txtUnitName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Unit Name");
            txtUnitName.Focus();
            return false;
        }
        return true;
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Validate())
            {
                string StateCode = Session["StateCd"].ToString();
                INSERT = "I";
                string UserName = Session["UsrName"].ToString();

                DataTable dt = new DataTable();

                dt = objDist.InsertUomBAL(txtUnitCode.Text, txtUnitName.Text.Trim(), UserName, INSERT, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtUnitCode.Text = "";
                    txtUnitName.Text = "";

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
            dt1 = objDist.viewUomdataBAL( ConnKey);
            GvUnits.DataSource = dt1;
            GvUnits.DataBind();
            if (dt1.Rows.Count > 0)
            {
                GvUnits.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GvUnits.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GvUnits.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";


                //Adds THEAD and TBODY to GridView.
                GvUnits.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
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
                DataTable dt = new DataTable();

                dt = objDist.UpdateUomBAL(txtUnitCode.Text, txtUnitName.Text.Trim(), Session["UsrName"].ToString(), UPDATE, ConnKey);
                if (dt.Rows.Count > 0)
                {

                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtUnitCode.Text = "";
                    txtUnitName.Text = "";
                    btn_Save.Visible = true;
                    txtUnitCode.Enabled = true;

                }
                else
                {
                    txtUnitCode.Text = "";
                    txtUnitName.Text = "";
                    btn_Save.Visible = true;
                    txtUnitCode.Enabled = true;
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

    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtUnitCode.Text = "";
        txtUnitName.Text = "";
        btn_Save.Visible = true;
        txtUnitCode.Enabled = true;
        Viewdata();
    }
}
