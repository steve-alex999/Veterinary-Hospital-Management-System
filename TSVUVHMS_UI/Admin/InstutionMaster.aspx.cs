using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class EVHMS_UI_Admin_Default : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();
    DataTable ddt;
    ListItem li;
    string UserName, StateCode;
    string INSERT, UPDATE, RETRIEVAL;
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
        UserName = Session["UsrName"].ToString();
        StateCode = Session["StateCd"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                ddt = objDist.getDistrictsByStateCodeBAL(StateCode, ConnKey);
                objCommon.BindDropDownLists(ddl_dist_code, ddt, "DistName", "DistCode", "0");
                ddt = objDist.viewInstitutiondataBAL(ConnKey);
                objCommon.BindDropDownLists(ddl_Institution, ddt, "InstitutionTypeDesc", "InstitutionTypeCode", "0");
                this.txt_Date.Text = DateTime.Today.ToString("dd/MM/yyyy");
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
        if (ddl_Institution.SelectedValue.ToString() == "0")
        {
            objCommon.ShowAlertMessage("Select Institution Type");
            ddl_Institution.Focus();
            return false;
        }
        if (txtVillage.Text == "")
        {
            objCommon.ShowAlertMessage("Enter City/Village");
            txtVillage.Focus();
            return false;
        }
        if (txtInstutionCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Institution Code");
            txtInstutionCode.Focus();
            return false;
        }
        if (txtInstutionName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Institution Name");
            txtInstutionName.Focus();
            return false;
        }
        if (txt_Date.Text == "")
        {
            objCommon.ShowAlertMessage("Select Effective Date");
            txt_Date.Focus();
            return false;
        }
        else
        {
            if (!objValidate.IsDate(txt_Date.Text.Trim()))
            {
                objCommon.ShowAlertMessage("Enter Valid Date");
                txt_Date.Focus();
                return false;
            }
        }
        if (rbnSy.SelectedValue == "" )
        {
            objCommon.ShowAlertMessage("Select Active Status");
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
                int ActiveSt =Convert.ToInt16(rbnSy.SelectedValue);
                DateTime EffectiveDate = DateTime.Parse(txt_Date.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                DataTable dt = new DataTable();
                dt = objDist.InsertInstituionsBAL(StateCode, ddl_dist_code.SelectedValue.ToString(), ddl_mandal_code.SelectedValue.ToString(), ddl_Institution.SelectedValue.ToString(), txtVillage.Text.ToString(), txtInstutionCode.Text, txtInstutionName.Text.Trim(), EffectiveDate, ActiveSt, UserName, "I", ConnKey);
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                // txtInstutionCode.Text = "";
                txtInstutionCode.Text = "";
                txtInstutionName.Text = "";
                txtVillage.Text = "";
                txt_Date.Text = "";
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
            dt1 = objDist.viewInstitutionsdataBAL(StateCode, ddl_dist_code.SelectedValue.ToString(), ConnKey);
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
                GridView1.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                GridView1.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";

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
            string status = ((Label)(gRow.FindControl("lblstatus"))).Text;
            ViewState["Unique_InsId"] = ((Label)(gRow.FindControl("lblUniqueInstId"))).Text;
            txtInstutionCode.Text = ((Label)(gRow.FindControl("lblInstCode"))).Text;
            txtInstutionName.Text = ((Label)(gRow.FindControl("lblInstName"))).Text;
            txtVillage.Text = ((Label)(gRow.FindControl("lblvillageName"))).Text;
            txt_Date.Text = ((Label)(gRow.FindControl("lblEffectiveDt"))).Text;
            ddl_dist_code.SelectedValue = ((Label)(gRow.FindControl("lblDcode"))).Text;
            ddl_mandal_code.SelectedValue = ((Label)(gRow.FindControl("lblMcode"))).Text;
            ddl_Institution.SelectedValue = ((Label)(gRow.FindControl("lblInscode"))).Text;
            //if (status == "Yes")
            //    rbnSy.Checked = true;
            //if (status == "No")
            //    rbnSn.Checked = true;
            if (status == "Yes")
            {
                rbnSy.SelectedValue = "1";
            }
            if (status == "No")
            {
                rbnSy.SelectedValue = "0";
            }
            btn_Save.Visible = false;
            btn_Update.Visible = true;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        try
        {
            if (Validate())
            {
                int ActiveSt =Convert.ToInt16(rbnSy.SelectedValue);
                DataTable dt = new DataTable();
                dt = objDist.UpdateInstituionsBAL(ViewState["Unique_InsId"].ToString(), txtInstutionName.Text.Trim(), txtVillage.Text.Trim(), ActiveSt, UserName, "U", ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtInstutionCode.Text = "";
                    txtInstutionName.Text = "";
                    txtVillage.Text = "";
                    txt_Date.Text = "";
                    btn_Update.Visible = false;
                    btn_Save.Visible = true;

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
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
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
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }

    protected void txtInstutionCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtInstutionCode.Text.Length < 2)
            {
                txtInstutionCode.Text = "0" + txtInstutionCode.Text;
            }
            else
            {
                txtInstutionCode.Text = txtInstutionCode.Text;
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

    }
}
