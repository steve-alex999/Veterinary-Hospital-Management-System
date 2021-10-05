using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class EVHMS_UI_Pharmacy_DrugConsumption : System.Web.UI.Page
{

    PharmacyBAL objPhar = new PharmacyBAL();
    InstutionBAL objIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    ListItem li;
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
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "3")
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
                string StateCode = Session["StateCd"].ToString();
                string UserName = Session["UsrName"].ToString();
                /*BIND DRUGS FOR WHICH AVERAGE CONSUMPTION IS NOT YET PROPOSED*/
                BindNoAvgConsumptionDtls_Drugs();
                Viewdata();
                btn_Update.Visible = false;
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
        try
        {
            DataTable dt = new DataTable();
            dt = objIns.GetInsNameBAL(Session["UniqueInstId"].ToString(), Session["UsrName"].ToString(), ConnKey);
            lblInsName.Text = dt.Rows[0]["InstitutionName"].ToString();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    /*BIND DRUGS FOR WHICH AVERAGE CONSUMPTION IS NOT YET PROPOSED*/
    protected void BindNoAvgConsumptionDtls_Drugs()
    {
        try
        {
            DataTable dtDrugs = objPhar.getInstdrugBAL(Session["UniqueInstId"].ToString(), ConnKey);
            objCommon.BindDropDownLists(ddl_drug, dtDrugs, "DrugName", "DrugCode", "0");
        }

        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    /*BIND ALL DRUGS*/
    protected void BindAllDrugs()
    {
        try
        {
            DataTable dtDrugs = objPhar.getdrug(ConnKey);
            objCommon.BindDropDownLists(ddl_drug, dtDrugs, "DrugName", "DrugCode", "0");
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
            ddt = objPhar.getdrugsInfo(Session["UniqueInstId"].ToString(), ConnKey);
            // objCommon.BindDropDownLists(ddl_drug, ddt, "DrugName", "DrugCode", "0");
            grdDrugCons.DataSource = ddt;
            grdDrugCons.DataBind();
            if (ddt.Rows.Count > 0)
            {
                grdDrugCons.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                grdDrugCons.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                grdDrugCons.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                grdDrugCons.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                grdDrugCons.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                grdDrugCons.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }


    protected void grdDrugCons_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grdDrugCons.PageIndex = e.NewPageIndex;
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }


    }
    

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (ddl_drug.SelectedIndex != 0 && lblUnitMsrmt.Text != "" && txtAvgConsumption.Text.Trim() != "")
        {
          
            INSERT = "I";
       
            try
            {
                DataTable dt = objPhar.InsertDrugConsumptionBAL(Session["UniqueInstId"].ToString(), ddl_drug.SelectedValue.ToString(), Convert.ToInt32(txtAvgConsumption.Text.Trim()), Session["UsrName"].ToString(), INSERT, ConnKey);

                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtAvgConsumption.Text = "";
                    lblUnitMsrmt.Text = "";
                    ddl_drug.ClearSelection();
                }


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
        else
        {
            objCommon.ShowAlertMessage("Please Enter Details");

        }
        Viewdata();
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btnsubmit.NamingContainer;
            txtAvgConsumption.Text = ((Label)gvrow.FindControl("lblAvgConsumptionPerDay")).Text;
            /*FETCH DRUGS*/
            BindAllDrugs();
            ddl_drug.SelectedValue = ((Label)(gvrow.FindControl("lblDrugCode"))).Text;
            lblUnitMsrmt.Text = ((Label)gvrow.FindControl("lblUnitMsrmt")).Text;
            btn_Update.Visible = true;
            btn_Save.Visible = false;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        if (lblUnitMsrmt.Text != "")
        {
            UPDATE = "U";
            string UserName = Session["UsrName"].ToString();
            string UniqueInstId = Session["UniqueInstId"].ToString();
            try
            {
                DataTable dt = objPhar.UpdateDrugConsumptionBAL(UniqueInstId, ddl_drug.SelectedValue.ToString(), Convert.ToInt32(txtAvgConsumption.Text.Trim()), UserName, UPDATE, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtAvgConsumption.Text = "";
                    lblUnitMsrmt.Text = "";
                    ddl_drug.ClearSelection();
                    btn_Update.Visible = false;
                    btn_Save.Visible = true;
                    /*BIND DRUGS FOR WHICH AVERAGE CONSUMPTION IS NOT YET PROPOSED*/
                    BindNoAvgConsumptionDtls_Drugs();

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
        else
        {
            objCommon.ShowAlertMessage("There is no Unit Measurement");

        }
        Viewdata();
    }






    protected void ddl_drug_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_drug.SelectedIndex > 0)
            {
                btn_Save.Visible = true;
                btn_Update.Visible = false;
                txtAvgConsumption.Text = "";
                string SelectedDrugCode = ddl_drug.SelectedValue.ToString();
                ddt = objPhar.getUnitmsr(ddl_drug.SelectedValue.ToString(), ConnKey);
                /*BIND DRUGS FOR WHICH AVERAGE CONSUMPTION IS NOT YET PROPOSED*/
                BindNoAvgConsumptionDtls_Drugs();
                ddl_drug.SelectedValue = SelectedDrugCode;
                if (ddt.Rows.Count > 0)
                {
                    lblUnitMsrmt.Text = ddt.Rows[0]["Unit"].ToString();
                }
                else
                {

                    lblUnitMsrmt.Text = "";

                }

            }
            else
            {
                BindNoAvgConsumptionDtls_Drugs();
                btn_Save.Visible = true;
                btn_Update.Visible = false;
                lblUnitMsrmt.Text = "";
                txtAvgConsumption.Text = "";

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
        txtAvgConsumption.Text = "";
        lblUnitMsrmt.Text = "";
        ddl_drug.ClearSelection();
        btn_Update.Visible = false;
        btn_Save.Visible = true;
        /*BIND DRUGS FOR WHICH AVERAGE CONSUMPTION IS NOT YET PROPOSED*/
        BindNoAvgConsumptionDtls_Drugs();
        Viewdata();
    }
}
