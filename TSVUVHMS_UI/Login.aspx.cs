using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVUVHMS_BL;
using System.Data;
using System.Web.Security;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    
    string ConnKey;
    CommonFuncs objCommon = new CommonFuncs();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ConnStr"] = ConfigurationManager.ConnectionStrings["ConnStrCentral"].ToString();
        Session["statecd"] = "05";
        Session["statename"] = "Telangana";
        txtUname.Attributes.Add("autocomplete", "off");
        txtPwd.Attributes.Add("autocomplete", "off");
        if (!IsPostBack)
        {
            imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
            /*Random No*/
            Random _rand = new Random();
            ViewState["KeyGenerator"] = _rand.Next();
            txtUname.Focus();
            Image1.ImageUrl = "~/Cimage.aspx";
        }
    }
    protected bool CheckCaptcha()
    {
        //if (this.txtimgcode.Text == this.Session["CaptchaImageText"].ToString())
        //{
        //    return true;
        //}
        //else
        //{
        //    lblmsg.Text = "image code is not valid.";
        //    txtimgcode.Text = "";
        //    return false;
        //}
        return true;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (CheckCaptcha())
        { }
        else {
            string error = "Invalid Username & Password";
            objCommon.ShowAlertMessage(error);
            return;
        }
        LoginBAL objLogin = new LoginBAL();
        string ConnKey = Session["ConnStr"].ToString();
        DataTable dtLogin = objLogin.getLoginDetailsBAL(txtUname.Text, ConnKey);
        if (dtLogin.Rows.Count > 0)
        {
            string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
            string password = dtLogin.Rows[0]["Password"].ToString();
            string StateCode = dtLogin.Rows[0]["StateCode"].ToString();
            string DistCode = dtLogin.Rows[0]["DistCode"].ToString();
            string MandCode = dtLogin.Rows[0]["MandCode"].ToString();
            string InstitutionTypeCode = dtLogin.Rows[0]["InstitutionTypeCode"].ToString();
            string InstitutionCode = dtLogin.Rows[0]["InstitutionCode"].ToString();
            string InstitutionName = dtLogin.Rows[0]["InstitutionName"].ToString();
            string UniqueInstId = dtLogin.Rows[0]["Unique_InstId"].ToString();
            string Role = dtLogin.Rows[0]["Role"].ToString();
            string UserId = dtLogin.Rows[0]["sno"].ToString();
            
            Session["UserId"] = UserId;
           
            string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");
            try
            {
                if (txtPwdHash.Value == value.ToLower())
                {
                    Session["UserId"] = UserId;
                    Session["UsrName"] = txtUname.Text;
                    Session["StateCd"] = StateCode;
                    Session["DistCode"] = DistCode;
                    Session["MandCode"] = MandCode;
                    Session["Role"] = Role;
                    Session["InstitutionTypeCode"] = InstitutionTypeCode;
                    Session["InstitutionCode"] = InstitutionCode;
                    Session["InstitutionName"] = InstitutionName;
                    Session["UniqueInstId"] = UniqueInstId;
                    Session["menu"] = null;


                    if (dtLogin.Rows[0]["Role"].ToString() == "1") //ADMIN
                    {
                        /*SUCCESSFUL LOGIN*/
                        Session["LoginSno"] = objLogin.insertUserLoginStatusBAL(Session["UserId"].ToString(), DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Login Successful", ConnKey);
                        Session["menu"] = null;
                        Response.Redirect("~/Admin/DashBoard_Admin.aspx", false);
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "2") // INSTITUTION
                    {
                       Session["LoginSno"] = objLogin.insertUserLoginStatusBAL(Session["UserId"].ToString(), DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Login Successful", ConnKey);

                        Response.Redirect("~/Institution/DashBoard_Ins.aspx", false);
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "3") //PHARMCY
                    {
                        
                        /*SUCCESSFUL LOGIN*/
                        Session["LoginSno"] = objLogin.insertUserLoginStatusBAL(Session["UserId"].ToString(), DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Login Successful", ConnKey);
                        Session["menu"] = null;
                        Response.Redirect("~/Pharmacy/DashBoard_Phar.aspx", false);
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "4") // DIAGNOSTIC
                    {
                        
                        /*SUCCESSFUL LOGIN*/
                        Session["LoginSno"] = objLogin.insertUserLoginStatusBAL(Session["UserId"].ToString(), DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Login Successful", ConnKey);
                        Session["menu"] = null;
                        Response.Redirect("~/Diagnostic/DashBoard_Dia.aspx", false);
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "5") // DOCTOR
                    {
                        /*SUCCESSFUL LOGIN*/
                        Session["LoginSno"] = objLogin.insertUserLoginStatusBAL(Session["UserId"].ToString(), DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Login Successful", ConnKey);
                        Session["menu"] = null;
                        Response.Redirect("~/Doctor/Rpt_TodayPatientHistory.aspx", false);
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "6") // CALL CENTER OPERATOR
                    {
                        Session["LoginSno"] = objLogin.insertUserLoginStatusBAL(Session["UserId"].ToString(), DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Login Successful", ConnKey);
                        Session["menu"] = null;
                        Response.Redirect("~/Feedback/Feedback.aspx", false);
                    }
                   
                }
                else
                {
                    /*UNSUCCESSFUL LOGIN*/
                    Session["LoginSno"] = objLogin.insertUserLoginStatusBAL(Session["UserId"].ToString(), DateTime.Now, Request.ServerVariables["REMOTE_ADDR"].ToString(), "Login Failed", ConnKey);
                    ShowAlertMessage(" $('#btnLogin').validationEngine('showPrompt', 'Invalid Username & Password', 'any', 'topRight');");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
        else
        {
            /*Invalid UserName*/
            ShowAlertMessage(" $('#btnLogin').validationEngine('showPrompt', 'Invalid Username', 'any', 'topRight');");
        }


    }

    public static void ShowAlertMessage(string error)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", error, true);
        }
    }
}