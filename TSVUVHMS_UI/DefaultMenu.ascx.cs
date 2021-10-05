using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using TSVUVHMS_BL;
using System.Configuration;

public partial class DefaultMenu : System.Web.UI.UserControl
{
    ReportBAL ObjRptBL = new ReportBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt = GetData(0);
            PopulateMenu(dt, 0, null);
        }
    }
    private DataTable GetData(int parentMenuId)
    {
        Session["ConnStr"] = ConfigurationManager.ConnectionStrings["ConnStrCentral"].ToString();
        
        DataTable dt = new DataTable();
        DataTable results = new DataTable();
        if (Session["menu"] != null)
        {
            dt = (DataTable)Session["menu"];
        }

        if (dt.Rows.Count > 0)
        {
            try
            {
                if (parentMenuId == 0)
                {
                    results = dt.Select("ParentMenuId=0").CopyToDataTable();
                }
                else
                {
                    DataRow[] foundRows;

                    // Use the Select method to find all rows matching the filter.
                    foundRows = dt.Select("ParentMenuId=" + parentMenuId + "");
                    if (foundRows.Length > 0)
                    {
                        results = dt.Select("ParentMenuId=" + parentMenuId + "").CopyToDataTable();
                    }
                }
            }
            catch
            {

            }
        }
        else
        {
            dt = ObjRptBL.GetRolewiseManuBL(Session["Role"].ToString(), parentMenuId.ToString(), Session["ConnStr"].ToString());
            Session["menu"] = dt;
            results = dt.Select("ParentMenuId=0").CopyToDataTable();
        }
        return results;
    }

    private void PopulateMenu(DataTable dt, int parentMenuId, MenuItem parentMenuItem)
    {
        string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
        foreach (DataRow row in dt.Rows)
        {
            MenuItem menuItem = new MenuItem
            {
                Value = row["MenuId"].ToString(),
                Text = row["Title"].ToString(),
                NavigateUrl = row["Url"].ToString(),
                Selected = row["Url"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase)
            };
            if (parentMenuId == 0)
            {

                Menu1.Items.Add(menuItem);
                DataTable dtChild = this.GetData(int.Parse(menuItem.Value));
                PopulateMenu(dtChild, int.Parse(menuItem.Value), menuItem);
            }
            else
            {
                parentMenuItem.ChildItems.Add(menuItem);
            }
        }
    }

}