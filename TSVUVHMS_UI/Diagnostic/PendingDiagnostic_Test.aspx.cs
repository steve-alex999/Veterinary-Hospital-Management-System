using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;

public partial class PendingDiagnostic_Test : System.Web.UI.Page
{
    DiagBAL objDiag = new DiagBAL();
    InstutionBAL ObjIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
      
        string UserName = Session["UsrName"].ToString();
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
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "4")
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
                lblUsrName.Text = Session["UsrName"].ToString();
                txtDate.Text= DateTime.Today.ToString("dd/MM/yyyy");
                GetInsNameBAL();
                viewdata();
            }
            catch (Exception ex)
            {

                Response.Redirect("~/Error.aspx");
            }

        }
    }

    public void GetInsNameBAL()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ObjIns.GetInsNameBAL(Session["UniqueInstId"].ToString(), Session["UsrName"].ToString(), ConnKey);
            lblInsName.Text = dt.Rows[0]["InstitutionName"].ToString();
        }
        catch (Exception ex)
        {

            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GvPatientDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvPatientDtls.PageIndex = e.NewPageIndex;
        viewdata();
    }

    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    private void viewdata()
    {
        try
        {
            if (txt_FregNo.Text.Trim() != "")
            {
                DataTable dt1 = new DataTable();
                //string Regno = "1";
                //DateTime RegDate = DateTime.Parse(txtDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                dt1 = objDiag.getDiagDtlsRegBAL(Session["UniqueInstId"].ToString(), txt_FregNo.Text.Trim(), ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    GvPatientDtls.DataSource = dt1;
                    GvPatientDtls.DataBind();
                    if (dt1.Rows.Count > 0)
                    {
                        GvPatientDtls.HeaderRow.Cells[1].Attributes["data-class"] = "expand";
                                      //Attribute to hide column in Phone.
                        GvPatientDtls.HeaderRow.Cells[0].Attributes["data-hide"] = "phone";
                        GvPatientDtls.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                        GvPatientDtls.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                        GvPatientDtls.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                      
                        GvPatientDtls.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                {
                    GvPatientDtls.DataSource = null;
                    GvPatientDtls.DataBind();
                }
            }
            else 
            {
                DataTable dt1 = new DataTable();
                if (txtDate.Text.Trim() != "")
                {
                    if (!objValidate.IsDate(txtDate.Text.Trim()))
                    {
                        objCommon.ShowAlertMessage("Enter Valid Date");
                        txtDate.Focus();
                        return;
                    }
                }
                DateTime RegDate = DateTime.Parse(txtDate.Text, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                dt1 = objDiag.getDiagDtlsBAL(Session["UniqueInstId"].ToString(), RegDate, ConnKey);
                if (dt1.Rows.Count > 0)
                {
                    GvPatientDtls.DataSource = dt1;
                    GvPatientDtls.DataBind();
                }
                else
                {
                    GvPatientDtls.DataSource = null;
                    GvPatientDtls.DataBind();
                }
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
            Response.Redirect("~/Diagnostic/Test.aspx",false);
            Label lblRegNo1 = (Label)gRow.FindControl("lblRegNo");
        }
        catch (Exception ex)
        {
           Response.Redirect("~/Error.aspx");
        }

    }

    protected void btnSearch_Click(object sender, EventArgs e)
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

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        txt_FregNo.Text = "";
       //viewdata();
       
    }
}
