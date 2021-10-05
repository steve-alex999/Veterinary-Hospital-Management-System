using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using TSVUVHMS_BL;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;


public partial class ErrPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
  
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("~/VhmsHome.aspx");
    }
}