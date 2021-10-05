using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using TSVUVHMS_BL;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Logout : System.Web.UI.Page
{
    ReportBAL ObjRptBL = new ReportBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        //string statecd = "";
        //string statenm = "";
        //string ConnStr = "";
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
                Response.Redirect("~/Error.aspx");
            }
        }
        if (!IsPostBack)
        {
          
            imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
            lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
        
            LoginBAL objLogin = new LoginBAL();
            if (Session["LoginSno"] != null)
            {
                try
                {
                    statecd.Text = Session["statecd"].ToString().Trim();
                    statename.Text = Session["statename"].ToString().Trim();
                    statec.Text = Session["ConnStr"].ToString().Trim();
                   

                    objLogin.updateUserLoginStatusBAL(Convert.ToInt32(Session["LoginSno"].ToString()), "Logout Success", DateTime.Now, Session["ConnStr"].ToString());
                    Session["UsrName"] = null;
                    Session["UsrType"] = null;
                    Session.Abandon();
                    Session.Clear();
                    Session.RemoveAll();

                    Session["statecd"] = statecd.Text;
                    Session["statename"] = statename.Text;
                    Session["ConnStr"] = statec.Text;
                    Session["Role"] = "0";


                }
                catch (Exception ex)
                {
                    ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                    Response.Redirect("~/Error.aspx");
                }
            }
            loadstatesession();
        }
       
    }
    protected void loadstatesession()
    {
        Session["statecd"] = statecd.Text;
        Session["statename"] = statename.Text;
        Session["ConnStr"] = statec.Text;
        Session["Role"] = "0";
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["statecd"] = statecd.Text;
        Session["statename"] = statename.Text;
        Session["ConnStr"] = statec.Text;
        Session["Role"] = "0";
        Response.Redirect("~/login.aspx");
    }
   
}