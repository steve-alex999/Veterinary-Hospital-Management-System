using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TSVUVHMS_DL;
using TSVUVHMS_BL;
using System.Configuration;
public partial class VhmsHome : System.Web.UI.Page
{
    ReportDAL objRptDL = new ReportDAL();
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["ConnStr"] = ConfigurationManager.ConnectionStrings["ConnStrCentral"].ToString();
        Session["menu"] = null;
        Session["Role"] = "0";
        Session["UsrName"] = "Admin";

        if (!IsPostBack)
        {
            try
            {
                DashBoard();  
                BindState();
                BindOnboardState();
            }
           
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
             
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        // This is necessary because Safari and Chrome browsers don't display the Menu control correctly. 
        // All webpages displaying an ASP.NET menu control must inherit this class. 
        if (Request.ServerVariables["http_user_agent"].IndexOf("chrome", StringComparison.CurrentCultureIgnoreCase) != -1)
            Page.ClientTarget = "uplevel";
    }
    protected void BindOnboardState()
    {
        try
        {
            //string ConnKey = "";
            //ConnKey = ConfigurationManager.ConnectionStrings["ConnStrCentral"].ToString();
            //ddt = objDist.viewStatedataBAL(ConnKey);
            //objCommon.BindDropDownLists(ddlonboardstate, ddt, "StateName", "StateCode", "0");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
    protected void BindState()
    {
        try
        {
            string ConnKey = "";
            ConnKey = ConfigurationManager.ConnectionStrings["ConnStrCentral"].ToString();
            ddt = objDist.getstate(ConnKey);
            DataRow[] foundRows;
            DataTable results = new DataTable();
            // Use the Select method to find all rows matching the filter.
            foundRows = ddt.Select("act_status=1");
            if (foundRows.Length > 0)
            {
                results = ddt.Select("act_status=1").CopyToDataTable();
            }
            objCommon.BindDropDownLists(ddlstate, results, "StateName", "StateCode", "0");
            results = new DataTable();
            foundRows = ddt.Select("act_status=1 or Requested_dt is not null");
            if (foundRows.Length > 0)
            {
                results = ddt.Select("act_status=1 or Requested_dt is not null").CopyToDataTable();
            }
            gvstatus.DataSource = results;
            gvstatus.DataBind();


        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
    protected void ddlstate_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstate.SelectedValue != "0")
        {
            Session["ConnStr"] = null;
            Session["statecd"]  =null;
            Session["statename"] = null;
            Session["statecd"] = ddlstate.SelectedValue;
            Session["statename"] = ddlstate.SelectedItem.Text;
            Session["ConnStr"] = ConfigurationManager.ConnectionStrings["ConnStr" + ddlstate.SelectedValue + ""].ToString();
            Session["menu"] = null;
            Response.Redirect("~/Default.aspx");

        }


    }
    public void DashBoard()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = objRptDL.DashBoardCount_CntryDAL(Session["ConnStr"].ToString());
            try
            {
                lblFinYear.Text = dt.Rows[0]["FinYear"].ToString() == "" ? "0" : dt.Rows[0]["FinYear"].ToString();
            }
            catch { }
            lblNewReg.Text = dt.Rows[0]["NewReg"].ToString() == "" ? "0" : dt.Rows[0]["NewReg"].ToString();
            lblRevist.Text = dt.Rows[0]["ReVisit"].ToString() == "" ? "0" : dt.Rows[0]["ReVisit"].ToString();
            lblTotEnrollments.Text = dt.Rows[0]["Insutionsenrolled"].ToString() == "" ? "0" : dt.Rows[0]["Insutionsenrolled"].ToString();
            lblTotalValueofdrug.Text = dt.Rows[0]["ValueOfDrugs"].ToString() == "" ? "0" : dt.Rows[0]["ValueOfDrugs"].ToString();

            lblDayIns.Text = dt.Rows[0]["DayIns"].ToString() == "" ? "0" : dt.Rows[0]["DayIns"].ToString();
            lblMnthIns.Text = dt.Rows[0]["MnthIns"].ToString() == "" ? "0" : dt.Rows[0]["MnthIns"].ToString();
            lblYearIns.Text = dt.Rows[0]["YearIns"].ToString() == "" ? "0" : dt.Rows[0]["YearIns"].ToString();

            lblDayNewR.Text = dt.Rows[0]["DayNewR"].ToString() == "" ? "0" : dt.Rows[0]["DayNewR"].ToString();
            lblMnthNewR.Text = dt.Rows[0]["MnthNewR"].ToString() == "" ? "0" : dt.Rows[0]["MnthNewR"].ToString();
            lblYearNewR.Text = dt.Rows[0]["YearNewReg"].ToString() == "" ? "0" : dt.Rows[0]["YearNewReg"].ToString();

            lblDayRV.Text = dt.Rows[0]["DayRV"].ToString() == "" ? "0" : dt.Rows[0]["DayRV"].ToString();
            lblMnthRV.Text = dt.Rows[0]["MnthRV"].ToString() == "" ? "0" : dt.Rows[0]["MnthRV"].ToString();
            lblYearRV.Text = dt.Rows[0]["YearReVisit"].ToString() == "" ? "0" : dt.Rows[0]["YearReVisit"].ToString();

            lblDayI.Text = dt.Rows[0]["DayI"].ToString() == "" ? "0" : dt.Rows[0]["DayI"].ToString();
            lblMnthI.Text = dt.Rows[0]["MnthI"].ToString() == "" ? "0" : dt.Rows[0]["MnthI"].ToString();
            lblYearI.Text = dt.Rows[0]["YearValueOfDrugs"].ToString() == "" ? "0" : dt.Rows[0]["YearValueOfDrugs"].ToString();
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void LnkBtnMoreInfo_Click(object sender, EventArgs e)
    {
        LinkButton viewBtn = (LinkButton)(sender);
        string Id = Convert.ToString(viewBtn.CommandArgument);

        if (Id == "I")
        {
            Session["UniqueInstId"] = "ALL";
            Session["StateCd"] = "goi";
            Session["StateName"] = "India";
            Response.Redirect("~/P_Rpt_DB_TotInstitutions.aspx");
        }
        if (Id == "N")
        {
            Session["UniqueInstId"] = "ALL";
            Session["RegType"] = "N";
            Response.Redirect("~/P_Rpt_DB_TotRegistrations.aspx");
        }
        if (Id == "R")
        {
            Session["UniqueInstId"] = "ALL";
            Session["RegType"] = "R";
            Response.Redirect("~/P_Rpt_DB_TotRegistrations.aspx");
        }
        if (Id == "D")
        {
            Session["UniqueInstId"] = "ALL";
            Response.Redirect("~/P_Rpt_DB_TotDrugsIssued.aspx");
        }

    }
}