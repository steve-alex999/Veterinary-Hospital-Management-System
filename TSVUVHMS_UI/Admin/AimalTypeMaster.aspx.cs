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
        UserName = Session["UsrName"].ToString();
        StateCode = Session["StateCd"].ToString();
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
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

        btn_Update.Visible = false;
    }


    protected void GvAnimalType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvAnimalType.PageIndex = e.NewPageIndex;
        Viewdata();
    }

    protected void GvAnimalType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {

                DataTable dt = new DataTable();
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                DELETE = "D";
                Label lblACode = (Label)gvrow.FindControl("lblACode");
                Label lblAName = (Label)gvrow.FindControl("lblAName");
                dt = objDist.DeleteAnimalBAL(lblACode.Text, lblAName.Text, DELETE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtAnimalTCode.Text = "";
                    txtAnimalName.Text = "";
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    Viewdata();

                }
                else
                {

                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtAnimalTCode.Text = "";
                    txtAnimalName.Text = "";
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;


                }
                Viewdata();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }

    }

    protected void GvAnimalType_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GvAnimalType.EditIndex = e.NewEditIndex;
        Viewdata();
    }

    protected bool Validate()
    {
        if (txtAnimalTCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Animal Type Code");
            txtAnimalTCode.Focus();
            return false;
        }
        if (txtAnimalName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Animal Type Name");
            txtAnimalName.Focus();
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

                DataTable dt = new DataTable();

                dt = objDist.InsertAnimalTypeBAL(txtAnimalTCode.Text, txtAnimalName.Text.Trim(), UserName, "I", ConnKey);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        string message = "Inserted Successfully";
                        objCommon.ShowAlertMessage(message);
                        txtAnimalTCode.Text = "";
                        txtAnimalName.Text = "";
                    }
                    else
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());

                    }
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
            dt1 = objDist.viewAnimaldataBAL1("R", ConnKey);
            GvAnimalType.DataSource = dt1;
            GvAnimalType.DataBind();
            if (dt1.Rows.Count > 0)
            {
                GvAnimalType.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GvAnimalType.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GvAnimalType.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                GvAnimalType.HeaderRow.TableSection = TableRowSection.TableHeader;
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
            txtAnimalTCode.Text = ((Label)(gRow.FindControl("lblACode"))).Text;
            txtAnimalName.Text = ((Label)(gRow.FindControl("lblAName"))).Text;

            txtAnimalTCode.Enabled = false;

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


        DataTable dt = new DataTable();
        try
        {
            dt = objDist.UpdateAnimalTypeBAL(txtAnimalTCode.Text, txtAnimalName.Text.Trim(), UserName, "U", ConnKey);
            if (dt.Rows.Count > 0)
            {

                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                txtAnimalTCode.Text = "";
                txtAnimalName.Text = "";

                btn_Save.Visible = true;
                txtAnimalTCode.Enabled = true;


            }
            else
            {

                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());

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
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtAnimalTCode.Text = "";
        txtAnimalName.Text = "";

        btn_Save.Visible = true;
        txtAnimalTCode.Enabled = true;
        Viewdata();
    }
}
