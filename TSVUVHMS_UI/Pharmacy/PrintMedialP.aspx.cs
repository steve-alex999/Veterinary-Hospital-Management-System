using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class Institution_Sheet : System.Web.UI.Page
{

    PharmacyBAL objPhar = new PharmacyBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    ListItem li;
    decimal tot = 0;
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ConnKey = Session["ConnStr"].ToString();
            if (!IsPostBack)
            {
                if (Session["RegNo"].ToString() == null)
                    Response.Redirect("~/Error.aspx");
                if (Session["Date"].ToString() == null)
                    Response.Redirect("~/Error.aspx");
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                string gender;

                ddt = objPhar.FetcIssueOfDrugDtlsBAL(Session["RegNo"].ToString(), Session["Date"].ToString(), ConnKey);
                lblRegNo.Text = ddt.Rows[0]["RegistrationNo"].ToString();
                gender = ddt.Rows[0]["Gender"].ToString();
                lblAge.Text = ddt.Rows[0]["Age"].ToString();
                lblOwner.Text = ddt.Rows[0]["Owner_Name"].ToString();
                lblAddress.Text = ddt.Rows[0]["Owner_Address"].ToString();

                DateTime date1 = Convert.ToDateTime(ddt.Rows[0]["Reg_Dt"].ToString());
                lblDate.Text = date1.ToString("dd/MM/yyyy");


                lblAnimal.Text = ddt.Rows[0]["AnimalTypeDesc"].ToString();
                lblDisease.Text = ddt.Rows[0]["DiseaseList"].ToString();
                lblIns.Text = ddt.Rows[0]["InstitutionName"].ToString();
                //lblDrugs.Text = ddt.Rows[0]["DrugName"].ToString();
                lblMbno.Text = ddt.Rows[0]["Owner_MobileNo"].ToString();
                if (gender == "0")
                {
                    lblGender.Text = "Male";
                }
                else
                {
                    lblGender.Text = "Female";
                }

                gvIssueofDrugs.DataSource = ddt;
                gvIssueofDrugs.DataBind();
                if (ddt.Rows.Count > 0)
                {
                    gvIssueofDrugs.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                    //Attribute to hide column in Phone.
                    gvIssueofDrugs.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                    gvIssueofDrugs.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                
                    //Adds THEAD and TBODY to GridView.
                    gvIssueofDrugs.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }


    protected void gvIssueofDrugs_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // tot + = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
                tot += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotal = (Label)e.Row.FindControl("lblAmounttotal");
                lblTotal.Text = tot.ToString();
                Label lblGovtTotal = (Label)e.Row.FindControl("lblGovtotal");
                lblGovtTotal.Text = tot.ToString();
                Label lblNotPaytotal = (Label)e.Row.FindControl("lblNotPaytotal");
                lblNotPaytotal.Text = (Convert.ToDecimal(lblTotal.Text) - Convert.ToDecimal(lblGovtTotal.Text)).ToString();

            }
        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

}