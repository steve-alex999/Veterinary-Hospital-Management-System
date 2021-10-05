using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVUVHMS_BL;
using System.Data;
using System.Web.Security;
using System.Data.SqlClient;

public partial class EVHMS_UI_Admin_Default : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    ListItem li;
    string UserName, StateCode;
    MasterBAL objMstBL = new MasterBAL();
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {

        ConnKey = Session["ConnStr"].ToString();
        Session["StateCd"] = "05";
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
        
        if (!IsPostBack)
        {
            try
            {
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                lblUsrName.Text = Session["UsrName"].ToString();
                lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                StateCode = Session["StateCd"].ToString();
                /*Bind States - By Default set State as TELANGANA*/
                ddt = objMstBL.getstate(ConnKey);
                objCommon.BindDropDownLists(ddl_State, ddt, "StateName", "StateCode", "0");
                ddl_State.SelectedValue = StateCode;
                ddl_State.Enabled = false;
                /*Bind Districts*/
                ddt = objMstBL.getDistrictsByStateCodeBAL(ddl_State.SelectedValue.ToString(), ConnKey);
                objCommon.BindDropDownLists(ddl_dist_code, ddt, "DistName", "DistCode", "0");
                //ddt = objDist.getstate(ConnKey);
                //objCommon.BindDropDownLists(ddl_State, ddt, "StateName", "StateCode", "0");

                ddt = objDist.viewInstitutiondataBAL( ConnKey);
                objCommon.BindDropDownLists(ddl_InsType, ddt, "InstitutionTypeDesc", "InstitutionTypeCode", "0");

                ddt = objDist.GetUserTypeBAL(ConnKey);
                objCommon.BindDropDownLists(ddl_Role, ddt, "Role_Name", "Role_ID", "0");

            }

            catch (Exception ex)
            {
             
                Response.Redirect("~/Error.aspx");
            }
        }


    }



    protected bool ValidateFrom()
    {
        if (ddl_Role.SelectedIndex <= 0)
        {
            objCommon.ShowAlertMessage("Select User Type");
            ddl_Role.Focus();
            return false;
        }
        if (ddl_Role.SelectedValue == "6")
        {
            if (ddl_State.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Select State");
                ddl_dist_code.Focus();
                return false;
            }
            if (txtUname.Text == "")
            {
                objCommon.ShowAlertMessage("Enter User Name");
                txtUname.Focus();
                return false;
            }
            if (txtPwd.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Password");
                txtPwd.Focus();
                return false;
            }
        }
        else
        {
            if (ddl_State.SelectedValue == "0")
            {
                objCommon.ShowAlertMessage("Select State");
                ddl_dist_code.Focus();
                return false;
            }
            if (ddl_dist_code.SelectedValue.ToString() == "0")
            {
                objCommon.ShowAlertMessage("Select District");
                ddl_dist_code.Focus();
                return false;
            }
            if (ddl_mandal_code.SelectedValue.ToString() == "0")
            {
                objCommon.ShowAlertMessage("Select Mandal");
                ddl_mandal_code.Focus();
                return false;
            }
            if (ddl_InsType.SelectedValue.ToString() == "0")
            {
                objCommon.ShowAlertMessage("Select Institution Type");
                ddl_InsType.Focus();
                return false;
            }
            if (ddl_Inst.SelectedValue.ToString() == "0")
            {
                objCommon.ShowAlertMessage("Select Institution");
                ddl_Inst.Focus();
                return false;
            }
            if (txtUname.Text == "")
            {
                objCommon.ShowAlertMessage("Enter User Name");
                txtUname.Focus();
                return false;
            }
            if (txtPwd.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Password");
                txtPwd.Focus();
                return false;
            }
        }
        return true;
    }
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (ValidateFrom())
        {
            DataTable dt = new DataTable();
            //try
            //{
            if (ddl_Role.SelectedValue == "6")
            {
                dt = objDist.InserUserBAL(ddl_State.SelectedValue.ToString(), "", "", "", "", ddl_Role.SelectedValue.ToString(), txtUname.Text.Trim(), txtPwdHash.Value, DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), ConnKey);
            }
            else
                dt = objDist.InserUserBAL(ddl_State.SelectedValue.ToString(), ddl_dist_code.SelectedValue.ToString(), ddl_mandal_code.SelectedValue.ToString(), ddl_Inst.SelectedValue.ToString(), ddl_InsType.SelectedValue.ToString(), ddl_Role.SelectedValue.ToString(), txtUname.Text.Trim(), txtPwdHash.Value, DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), ConnKey);

            if (ddl_Role.SelectedValue == "5")
            {
                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Dtls_Doctor (Doctor) VALUES (@Doctor)"))
                    {
                        cmd.Parameters.AddWithValue("@Doctor", txtUname.Text.Trim());
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        
                        con.Close();
                    }
                }
            }
            objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
            // txtInstutionCode.Text = "";
            txtUname.Text = "";
            txtPwd.Text = "";
            GridData();
        
        //}
        //catch (Exception ex)
        //{
        //    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
        //    Response.Redirect("~/Error.aspx");
        //}
        
        }
    }

    public void Viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();

            dt1 = objDist.viewInstitutionsdataBAL(StateCode, ddl_dist_code.SelectedValue.ToString(), ConnKey);
        }

        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvUser.PageIndex = e.NewPageIndex;
        Viewdata();
    }

    protected void GvUser_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            if (e.CommandName == "Reset")
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblUname = (Label)gvrow.FindControl("lblUname");
                lblName.Text = lblUname.Text;
                mp1.Show();
                                
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }

    }

    
    protected void ddl_dist_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            /*BIND MANDALS IN THE SELECTED DISTRICT*/
            BindMandal();
            /*FETCH INSTITUTIONS IN THE SELECTED DISTRICT*/
            Viewdata();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void BindMandal()
    {
        try
        {
            ddt = objDist.getMandalsByDistCodeBAL(ddl_dist_code.SelectedValue.ToString(), ConnKey);
            objCommon.BindDropDownLists(ddl_mandal_code, ddt, "MandName", "MandCode", "0");
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
       
    }

    //protected void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        ddt = objDist.getDistrictsByStateCodeBAL(ddl_State.SelectedValue.ToString(), ConnKey);
    //        objCommon.BindDropDownLists(ddl_dist_code, ddt, "DistName", "DistCode", "0");
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Redirect("~/Error.aspx");
    //    }
    //}
    protected void ddl_InsType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddt = objDist.getIns1(ddl_State.SelectedValue.ToString(), ddl_dist_code.SelectedValue.ToString(), ddl_mandal_code.SelectedValue.ToString(), ddl_InsType.SelectedValue.ToString(), ConnKey);
            objCommon.BindDropDownLists(ddl_Inst, ddt, "InstitutionName", "InstitutionCode", "0");
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddl_Inst_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridData();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Role.SelectedIndex <= 0)
            {
                objCommon.ShowAlertMessage("Select User Type");
                ddl_Role.Focus();
                return;
            }
            if (ddl_Role.SelectedValue == "6")
                GridData();
            else
            {
                GvUser.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected bool validateBindGrid()
    {
        if (ddl_Role.SelectedValue == "6")
        {
            if (ddl_State.SelectedIndex <= 0)
            {
                objCommon.ShowAlertMessage("Select State");
                ddl_State.Focus();
                return false;
            }           
        }
        else
        {
            if (ddl_State.SelectedIndex <= 0)
            {
                objCommon.ShowAlertMessage("Select State");
                ddl_State.Focus();
                return false;
            }
            if (ddl_dist_code.SelectedIndex <= 0)
            {
                objCommon.ShowAlertMessage("Select District");
                ddl_dist_code.Focus();
                return false;
            }
            if (ddl_mandal_code.SelectedIndex <= 0)
            {
                objCommon.ShowAlertMessage("Select Mandal");
                ddl_mandal_code.Focus();
                return false;
            }
            if (ddl_InsType.SelectedIndex <= 0)
            {
                objCommon.ShowAlertMessage("Select Institution Type");
                ddl_InsType.Focus();
                return false;
            }
            if (ddl_Inst.SelectedIndex <= 0)
            {
                objCommon.ShowAlertMessage("Select Institution");
                ddl_Inst.Focus();
                return false;
            }
        }
        return true;
    }
    public void GridData()
    {
        try
        {
            DataTable dt1 = new DataTable();
            if (validateBindGrid())
            {
                if (ddl_Role.SelectedValue == "6")
                {
                    dt1 = objDist.ViewGridDataBAL(ddl_State.SelectedValue.ToString(), "ALL", "ALL", "ALL", "ALL", ddl_Role.SelectedValue.ToString(), ConnKey);
                }
                else
                {
                    dt1 = objDist.ViewGridDataBAL(ddl_State.SelectedValue.ToString(), ddl_dist_code.SelectedValue.ToString(), ddl_mandal_code.SelectedValue.ToString(), ddl_Inst.SelectedValue.ToString(), ddl_InsType.SelectedValue.ToString(), "0", ConnKey);
                }
                GvUser.Visible = true;
                GvUser.DataSource = dt1;
                GvUser.DataBind();
                if (dt1.Rows.Count > 0)
                {
                    GvUser.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                    GvUser.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";                   
                    GvUser.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btnUpdatePwd_Click(object sender, EventArgs e)
    {

        LoginBAL objLogin = new LoginBAL();
        try
        {
            int rowCount = objLogin.changepasswordBAL(lblName.Text, txtNewPwdHash.Value, ConnKey);
            if (rowCount > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                "alert('Password successfully Reset'); window.location='" +
                Request.ApplicationPath + "~/Admin/User_Creation.aspx';", true);
            }
            txtNewPwdHash.Value = "";
            txtCpwd.Text = "";
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");

        }

    }
    //protected void lnkResetPwd_Click(object sender, EventArgs e)
    //{
    //    using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
    //    {
           
    //        mp1.Show();
    //    }
    //}
    protected void ddl_mandal_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddl_InsType.ClearSelection();
            ddl_Inst.Items.Clear();
            GvUser.DataSource = null;
            GvUser.DataBind();
       
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
         txtUname.Text = "";
                txtPwd.Text = "";
                GridData();
    }
   
}

