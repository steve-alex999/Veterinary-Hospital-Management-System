using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class LogException : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/emp.xml"));
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }
        catch (Exception ex)
        {

            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Label1.Text = "Some Technical Error occurred,Please visit after some time";

        }     

    }
}