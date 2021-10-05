using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
/// <summary>
/// <summary>
/// Summary description for Common
/// </summary>
public class CommonFuncs
{
    public void ShowAlertMessage(string error)
    {
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }
    //*******************  **********************************************
    // Description       : This method is used to bind drop down list 
    // Input Parameters  : Dropdownlist id, Dataset name, Textfield , value field , default value that 
    //                     should be shown in the drop down list
    //OutPut parameters  : None 
    //**************************************************************************
    public void BindDropDownLists(DropDownList ddl, DataTable ddt, string textfield, string valuefield, string strDefaultValue)
    {


        // if (ds.Tables.Count > 0)
        //{
        // if (ds.Tables[0].Rows.Count > 0)
        // {
        ddl.Items.Clear();
        ddl.DataSource = ddt;
        ddl.DataTextField = textfield;
        ddl.DataValueField = valuefield;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("Select", "0"));
        ////ddl.SelectedIndex = 0;
        // }
    }
    //**************************************************************************
    public void BindDropDownLists_WithAllOption(DropDownList ddl, DataTable ddt, string textfield, string valuefield, string strDefaultValue)
    {


        // if (ds.Tables.Count > 0)
        //{
        // if (ds.Tables[0].Rows.Count > 0)
        // {
        ddl.Items.Clear();
        ddl.DataSource = ddt;
        ddl.DataTextField = textfield;
        ddl.DataValueField = valuefield;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("ALL", "ALL"));
        ////ddl.SelectedIndex = 0;
        // }
    }
        public void BindCheckLists(CheckBoxList chk, DataTable ddt, string textfield, string valuefield, string strDefaultValue)
        {


            // if (ds.Tables.Count > 0)
            //{
            // if (ds.Tables[0].Rows.Count > 0)
            // {
            chk.Items.Clear();
            chk.DataSource = ddt;
            chk.DataTextField = textfield;
            chk.DataValueField = valuefield;
            chk.DataBind();
           // chk.Items.Insert(0, new ListItem("Select", "0"));
            ////ddl.SelectedIndex = 0;
            // }
        }

}