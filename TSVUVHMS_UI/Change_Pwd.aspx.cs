using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVUVHMS_BL;
using System.Configuration;
using System.Data;
using System.Web.Security;

public partial class UserProfile : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
  //  string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        /*KILL COOKIE*/
        //  DeleteCookie.DelCookie();
        //Htpp Referer Check
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
                // Response.Redirect("~/Error.aspx");
            }
        }
        if (Session["UsrName"] == null || Session["Role"] == null)
        {
            Response.Redirect("~/Error.aspx");
        }
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            Random _rand = new Random();
            ViewState["keyGen"] = _rand.Next().ToString();
            //if (Session["Role"].ToString() == "1")
            //{
            //    Session["UniqueInstId"] = "ALL";
            //    Imghome.PostBackUrl = "Admin/DashBoard_Admin.aspx";
                
            //}
            //if (Session["Role"].ToString() == "2")
            //{
            //    Imghome.PostBackUrl = "Institution/DashBoard_Ins.aspx";
               
            //}
            //if (Session["Role"].ToString() == "3")
            //{
            //    Imghome.PostBackUrl = "Pharmacy/DashBoard_Phar.aspx";
               
            //}
            //if (Session["Role"].ToString() == "4")
            //{
            //    Imghome.PostBackUrl = "Diagnostic/DashBoard_Dia.aspx";

            //}
            //if (Session["Role"].ToString() == "5")
            //{
            //    Imghome.PostBackUrl = "Doctor/Rpt_PatientHistory.aspx";

            //}
            lblUsrName.Text = Session["UsrName"].ToString();
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            /*GET FARMER REGISTRATION AND SCHEME APPLICATIONS COUNT*/

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        LoginBAL objLogin = new LoginBAL();
        DataTable dtLogin = objLogin.getLoginDetailsBAL(Session["UsrName"].ToString(), ConnKey);
        if (dtLogin.Rows.Count > 0)
        {
            string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["keyGen"].ToString(), "SHA1");
            string password = dtLogin.Rows[0]["Password"].ToString();
            string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");
            if (password.ToLower() != txtNewPwdHash.Value)
            {
                if (txtOldPwdHash.Value == value.ToLower())
                {
                    int rowCount = objLogin.changepasswordBAL(Session["UsrName"].ToString(), txtNewPwdHash.Value, ConnKey);
                    if (rowCount > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
    "alert('Password successfully changed'); window.location='" +
    Request.ApplicationPath + "/Change_Pwd.aspx';", true);
                    }
                    else
                    {
                        txtOldPwdHash.Value = "";
                        txtNewPwdHash.Value = "";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
    "alert('Invalid Password '); window.location='" +
    Request.ApplicationPath + "/Change_Pwd.aspx';", true);
                    }
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
       "alert('New Password should not be same as old password'); window.location='" +
       Request.ApplicationPath + "/Change_Pwd.aspx';", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
   "alert('New Password should not be same as old password'); window.location='" +
   Request.ApplicationPath + "/Change_Pwd.aspx';", true);
        }
    }
    public static void ShowAlertMessage(string error)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }


}