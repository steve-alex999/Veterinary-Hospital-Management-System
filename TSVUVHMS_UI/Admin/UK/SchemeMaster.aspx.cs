using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVUVHMS_BL;
using TSVUVHMS_BE;
using System.Data;
using System.Web.Security;

public partial class Admin_SchemeMaster : System.Web.UI.Page
{
    int sno;
    string date;
    string INSERT, UPDATE, GData;
    string StateCode = "", Flag_IUP, UserName = "";
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    MasterBE objBE = new MasterBE();
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
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }

    }    
    private void viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            objBE.Action = "R";
            objBE.UserName = Session["UsrName"].ToString();
            dt1 = objDist.SchemeMst_IUDR_BAL(objBE,ConnKey);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            if (dt1.Rows.Count > 0)
            {
                GridView1.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                GridView1.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
             //   GridView1.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
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
                objBE.Action = "I";
                objBE.UserName = Session["UsrName"].ToString();
                objBE.SchemeCode = txtSchemeCode.Text.Trim();
                objBE.SchemeName = txtSchemeName.Text.Trim();
                objBE.SchemeType =  ddlSchemeType.SelectedItem.Text.Trim();
                DataTable dt = new DataTable();
                dt = objDist.SchemeMst_IUDR_BAL(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtSchemeName.Text = "";
                    ddlSchemeType.SelectedValue = "0";
                    txtSchemeCode.Text = "";
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
        if (txtSchemeCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Scheme Code");
            txtSchemeCode.Focus();
            return false;
        }
        if (txtSchemeName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Scheme Name");
            txtSchemeName.Focus();
            return false;
        }
        string er = ddlSchemeType.SelectedItem.Text;
        if (ddlSchemeType.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Scheme Type");
            ddlSchemeType.Focus();
            return false;
        }

        return true;
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
                DataTable dt = new DataTable();
                objBE.Action = "U";
                objBE.UserName = Session["UsrName"].ToString();
                objBE.SchemeCode = txtSchemeCode.Text.Trim();
                objBE.SchemeName = txtSchemeName.Text.Trim();
                objBE.SchemeType = ddlSchemeType.SelectedItem.Text.Trim();
                dt = objDist.SchemeMst_IUDR_BAL(objBE,ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    btn_Save.Visible = true;
                    txtSchemeName.Text = "";
                    txtSchemeCode.Text = "";
                    txtSchemeCode.Enabled = true;
                    btn_Update.Visible = false;
                }
                viewdata();
               
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
                objBE.Action = "D";
                objBE.UserName = Session["UsrName"].ToString();
                
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblSchemeCode = (Label)gvrow.FindControl("lblSchemeCode");
                Label lblSchemeName = (Label)gvrow.FindControl("lblSchemeName");
                objBE.SchemeCode = lblSchemeCode.Text;
                objBE.SchemeName = lblSchemeName.Text;
                
                dt = objDist.SchemeMst_IUDR_BAL(objBE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtSchemeCode.Text = "";
                    txtSchemeName.Text = "";
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
            txtSchemeCode.Text = ((Label)(gRow.FindControl("lblSchemeCode"))).Text;
            txtSchemeName.Text = ((Label)(gRow.FindControl("lblSchemeName"))).Text;
            ddlSchemeType.SelectedValue = ((Label)(gRow.FindControl("lblSchemeType"))).Text;            
            txtSchemeCode.Enabled = false;
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

    }
}