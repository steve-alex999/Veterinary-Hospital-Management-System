using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class StateMaster : System.Web.UI.Page
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
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
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

    protected void GvSate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvSate.PageIndex = e.NewPageIndex;
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GvSate_RowCommand(object sender, GridViewCommandEventArgs e)
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
                Label lblSCode = (Label)gvrow.FindControl("lblSCode");
                Label lblSName = (Label)gvrow.FindControl("lblSName");
                dt = objDist.DeleteStateBAL(lblSCode.Text, lblSName.Text, DELETE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    // if (dt.Rows[0][0].ToString() == "3")
                    //{
                    //string aa = "Deleted Successfully";
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtstateCode.Text = "";
                    txtstateName.Text = "";
                    Viewdata();

                    // }

                }
                else
                {

                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtstateCode.Text = "";
                    txtstateName.Text = "";


                }
            }

            if (e.CommandName == "Edt")
            {


                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                DELETE = "D";
                txtstateCode.Text = ((Label)(gvrow.FindControl("lblSCode"))).Text;
                txtstateName.Text = ((Label)(gvrow.FindControl("lblSName"))).Text;

                txtstateCode.Enabled = false;
                btn_Update.Visible = true;
                btn_Save.Visible = false;


            }
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GvSate_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            GvSate.EditIndex = e.NewEditIndex;
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    public bool ValiadteState()
    {
        if (txtstateCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter State Code");
            txtstateCode.Focus();
            return false;

        }
        if (txtstateName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter State Name");
            txtstateName.Focus();
            return false;
        }
        return true;
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValiadteState())
            {
                INSERT = "I";
                DataTable dt = new DataTable();
                dt = objDist.InsertStateBAL(txtstateCode.Text, txtstateName.Text.Trim(), INSERT, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtstateCode.Text = "";
                    txtstateName.Text = "";

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

    public void Viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = objDist.viewStatedataBAL( ConnKey);
            GvSate.DataSource = dt1;
            GvSate.DataBind();
            if (dt1.Rows.Count > 0)
            {
                GvSate.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GvSate.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GvSate.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                GvSate.HeaderRow.TableSection = TableRowSection.TableHeader;
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
      
        UPDATE = "U";
        DataTable dt = new DataTable();
        try
        {
            if (ValiadteState())
            {
                dt = objDist.UpdateStateBAL(txtstateCode.Text, txtstateName.Text.Trim(), UPDATE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtstateCode.Text = "";
                    txtstateName.Text = "";
                    btn_Save.Visible = true;
                    txtstateCode.Enabled = true;
                
                }
                else
                {

                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());

                }
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

    protected void txtstateCode_TextChanged(object sender, EventArgs e)
    {
        if (txtstateCode.Text.Length < 2)
        {
            txtstateCode.Text = "0" + txtstateCode.Text;
        }
        else
        {
            txtstateCode.Text = txtstateCode.Text;
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {

    }
}
