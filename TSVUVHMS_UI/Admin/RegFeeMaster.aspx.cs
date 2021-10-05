using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class Admin_RegFeeMaster : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();
    DataTable ddt;
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
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "1")
        {
            Response.Redirect("~/Error.aspx");
        }
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                this.txt_Date.Text = DateTime.Today.ToString("dd/MM/yyyy");
                StateCode = Session["StateCd"].ToString();
                UserName = Session["UsrName"].ToString();
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                ddt = objDist.getIns(ConnKey);
                objCommon.BindDropDownLists(ddl_Ins_code, ddt, "InstitutionName", "InstitutionCode", "0");
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

                Label lblInsCode = (Label)gvrow.FindControl("lblInsCode");
                Label lblRegf = (Label)gvrow.FindControl("lblRegf");
                dt = objDist.DeleteRegBAL(lblInsCode.Text,ViewState["AnimalTypeCode"].ToString(), lblRegf.Text, Flag_IUP, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtregfee.Text = "";
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    ddlAnimal.Enabled = true;
                    BindAnimal();
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
        if (ddl_Ins_code.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Institution Name");
            ddl_Ins_code.Focus();
            return false;
        }
        if (ddlAnimal.Enabled== true && ddlAnimal.SelectedIndex <=0)
        {
            objCommon.ShowAlertMessage("Select Animal Type");
            ddlAnimal.Focus();
            return false;
        }
        if (txtregfee.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Regsistarion Fee");
            txtregfee.Focus();
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
                dt = objDist.InsertRegfeeBAL(ddl_Ins_code.SelectedValue.ToString(),ddlAnimal.SelectedValue, txtregfee.Text, date, Session["UsrName"].ToString(), "I", ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txt_Date.Text = "";
                    txtregfee.Text = "";
                    txt_Date.Enabled = true;
                    BindAnimal();
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
    protected void BindAnimal()
    {
        try
        {
            ddt = objDist.GetAnimalType_ForRegFeeByUniqueInsIdBAL(ddl_Ins_code.SelectedValue, ConnKey);
            objCommon.BindDropDownLists(ddlAnimal, ddt, "AnimalTypeDesc", "AnimalTypeCode", "0");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddl_Ins_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindAnimal();
            Viewdata();
            txt_Date.Enabled = true;
            btn_Save.Visible = true;
            btn_Update.Visible = false;
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
            dt1 = objDist.viewDRegBAL(ddl_Ins_code.SelectedValue.ToString(), "R", ConnKey);
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
            txtregfee.Text = ((Label)(gRow.FindControl("lblRegf"))).Text;
            txt_Date.Text = ((Label)(gRow.FindControl("lbleffdate"))).Text;
            ViewState["AnimalTypeCode"] = ((Label)(gRow.FindControl("lblAnimalTypeCode"))).Text;
            ddlAnimal.Enabled = false;
            ddlAnimal.SelectedItem.Text = ((Label)(gRow.FindControl("lblAnimal"))).Text;
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
        DataTable dt = new DataTable();
        try
        {
            if (Validate())
            {
                DateTime Effectivedate = DateTime.Parse(txt_Date.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                dt = objDist.UpdateRegBAL(ddl_Ins_code.SelectedValue.ToString(),ViewState["AnimalTypeCode"].ToString(), txtregfee.Text, Session["UsrName"].ToString(), Effectivedate, "U", ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());

                    txt_Date.Text = "";
                    txtregfee.Text = "";
                    txtregfee.Enabled = true;
                    txt_Date.Enabled = true;
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    ddlAnimal.Enabled = true;
                    BindAnimal();
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
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txt_Date.Text = "";
        txtregfee.Text = "";
        txtregfee.Enabled = true;
        txt_Date.Enabled = true;
        btn_Save.Visible = true;
        btn_Update.Visible = false;
        ddlAnimal.Enabled = true;
        BindAnimal();
        Viewdata();
    }
}
