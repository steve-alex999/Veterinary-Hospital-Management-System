using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;

public partial class Admin_DiagnosticTestMaster : System.Web.UI.Page
{
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
            dt1 = objDist.DiagTest_IUDR_BAL("","" , "R","", ConnKey);
            GvDiagTest.DataSource = dt1;
            GvDiagTest.DataBind();

            if (dt1.Rows.Count > 0)
            {
                GvDiagTest.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GvDiagTest.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GvDiagTest.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";


                //Adds THEAD and TBODY to GridView.
                GvDiagTest.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                DataTable dt = new DataTable();
                dt = objDist.DiagTest_IUDR_BAL(txtDiagTestCode.Text.Trim(), txtDiagTestName.Text.Trim(),"I", Session["UsrName"].ToString(), ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtDiagTestName.Text = "";
                    txtDiagTestCode.Text = "";
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
        if (txtDiagTestCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Diagnostic Test / Procedure Code");
            txtDiagTestCode.Focus();
            return false;
        }
        if (txtDiagTestName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Diagnostic Test / Procedure Name");
            txtDiagTestName.Focus();
            return false;
        }
        return true;
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            if (Validate())
            {
                DataTable dt = new DataTable();

                dt = objDist.DiagTest_IUDR_BAL(txtDiagTestCode.Text.Trim(), txtDiagTestName.Text.Trim(),"U",Session["UsrName"].ToString(), ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    btn_Save.Visible = true;
                    txtDiagTestCode.Text = "";
                    txtDiagTestName.Text = "";
                    txtDiagTestCode.Enabled = true;
                    btn_Update.Visible = false;
                }
                viewdata();
           }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GvDiagTest_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvDiagTest.PageIndex = e.NewPageIndex;
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GvDiagTest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {
                DataTable dt = new DataTable();
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblDiagTestCode = (Label)gvrow.FindControl("lblDiagTestCode");
                Label lblDiagTestName = (Label)gvrow.FindControl("lblDiagTestName");
                dt = objDist.DiagTest_IUDR_BAL(lblDiagTestCode.Text.Trim(), "", "D", "", ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtDiagTestCode.Text = "";
                    txtDiagTestName.Text = "";
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
    protected void GvDiagTest_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GvDiagTest.EditIndex = e.NewEditIndex;
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
            txtDiagTestCode.Text = ((Label)(gRow.FindControl("lblDiagTestCode"))).Text;
            txtDiagTestName.Text = ((Label)(gRow.FindControl("lblDiagTestName"))).Text;
            txtDiagTestCode.Enabled = false;
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
        txtDiagTestCode.Text = "";
        txtDiagTestName.Text = "";
        viewdata();
    }
}