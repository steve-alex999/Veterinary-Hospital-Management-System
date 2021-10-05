using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class DiseaseMaster : System.Web.UI.Page
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
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                DELETE = "D";
                Label lblDCode = (Label)gvrow.FindControl("lblDCode");
                Label lblDName = (Label)gvrow.FindControl("lblDName");
                dt = objDist.DeleteDiseaseBAL(lblDCode.Text, lblDName.Text, DELETE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtDiseaseTCode.Text = "";
                    txtDiseaseName.Text = "";
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    Viewdata();

                }
                else
                {
                    txtDiseaseTCode.Text = "";
                    txtDiseaseName.Text = "";
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    
                }
            }

            if (e.CommandName == "Edt")
            {

                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                DELETE = "D";
                txtDiseaseTCode.Text = ((Label)(gvrow.FindControl("lblDCode"))).Text;
                txtDiseaseName.Text = ((Label)(gvrow.FindControl("lblDName"))).Text;
                txtDiseaseTCode.Enabled = false;
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
    protected bool Validatedisease()
    {
        if (txtDiseaseTCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Disease Code");
            txtDiseaseTCode.Focus();
            return false;
        }
        if (txtDiseaseName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Disease Name");
            txtDiseaseName.Focus();
            return false;
        }
        return true;
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (Validatedisease())
            {
                INSERT = "I";
                DataTable dt = new DataTable();
                dt = objDist.InsertDiseaseTypeBAL(txtDiseaseTCode.Text, txtDiseaseName.Text.Trim(), Session["UsrName"].ToString(), INSERT, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtDiseaseTCode.Text = "";
                    txtDiseaseName.Text = "";
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
            dt1 = objDist.viewDiseasedataBAL( ConnKey);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            if (dt1.Rows.Count > 0)
            {
                GridView1.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GridView1.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";


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

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        UPDATE = "U";
        DataTable dt = new DataTable();
        try
        {
            if (Validatedisease())
            {
                dt = objDist.UpdateDiseaseTypeBAL(txtDiseaseTCode.Text, txtDiseaseName.Text.Trim(), Session["UsrName"].ToString(), UPDATE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtDiseaseTCode.Text = "";
                    txtDiseaseName.Text = "";
                    btn_Save.Visible = true;
                    txtDiseaseTCode.Enabled = true;

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
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtDiseaseTCode.Text = "";
        txtDiseaseName.Text = "";
        btn_Save.Visible = true;
        txtDiseaseTCode.Enabled = true;
        Viewdata();
    }
}
