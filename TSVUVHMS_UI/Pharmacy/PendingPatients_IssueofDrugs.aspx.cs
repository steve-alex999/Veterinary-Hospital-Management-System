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
using System.Collections;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;

public partial class Pharmacy_IssueofDrug : System.Web.UI.Page
{

    PharmacyBAL objPhar = new PharmacyBAL();
    InstutionBAL ObjIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();

    string ConnKey, StateCode, InstitutionCode, UserName;
    protected void Page_Load(object sender, EventArgs e)
    {
       
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

        if (Session["Role"].ToString() == null || (Session["Role"].ToString() != "3" && Session["Role"].ToString() != "5")) 
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
                this.txtDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
                viewdata();

                GetInsNameBAL();
            }


            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
    public void GetInsNameBAL()
    {

        DataTable dt = new DataTable();
        dt = ObjIns.GetInsNameBAL(Session["UniqueInstId"].ToString(), Session["UsrName"].ToString(), ConnKey);
        lblInsName.Text = dt.Rows[0]["InstitutionName"].ToString();
    }



    protected void Cal_DtofReg_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            viewdata();
        }

        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    private void viewdata()
    {
        try
        {
            if (txtDate.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Select Date");
                txtDate.Focus();
                return ;
            }
            else
            {
                if (!objValidate.IsDate(txtDate.Text.Trim()))
                {
                    objCommon.ShowAlertMessage("Enter Valid Date");
                    txtDate.Focus();
                    return ;
                }
            }
            DateTime date = DateTime.Parse(txtDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            DataTable dt1 = new DataTable();

            dt1 = objPhar.AnimaldetailsBAL(Session["UniqueInstId"].ToString(), date, ConnKey);
            if (dt1.Rows.Count > 0)
            {
                GvPatientDtls.Visible = true;
                GvPatientDtls.DataSource = dt1;
                GvPatientDtls.DataBind();
                lblMsg.Visible = false;
                if (dt1.Rows.Count > 0)
                {
                    GvPatientDtls.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    GvPatientDtls.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                    GvPatientDtls.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                    GvPatientDtls.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                   
                    //Adds THEAD and TBODY to GridView.
                    GvPatientDtls.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            else
            {
                GvPatientDtls.Visible = false;
                lblMsg.Visible = true;
                lblMsg.Text = "No Records in selected date";
            }
        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void lnkRegNo_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            LinkButton lblRegNo = (LinkButton)gRow.FindControl("linkgetregno");
            Session["RegNo"] = lblRegNo.Text;
            Session["VisitId"] = ((Label)gRow.FindControl("lblVisitId")).Text;
            if(Session["StateCd"].ToString() == "05")
                Response.Redirect("~/Pharmacy/UK/IssueofDrug.aspx", false);
            else
                Response.Redirect("~/Pharmacy/IssueofDrug.aspx", false);
            //Label lblRegNo1 = (Label)gRow.FindControl("lblRegNo");
        }



        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
    protected void GvPatientDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvPatientDtls.PageIndex = e.NewPageIndex;
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }


    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        try
        {

            viewdata();
        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
   
}
