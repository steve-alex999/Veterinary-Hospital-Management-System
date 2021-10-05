using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVUVHMS_BL;
using System.Data;
using System.Web.Security;
using System.Text;
using Microsoft.Reporting.WebForms;
using System.Configuration;
using System.Globalization;
using System.IO;
public partial class VhmsHome : System.Web.UI.Page
{
    ReportBAL ObjRptBL = new ReportBAL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                Session["statecd"] = "05";
                Session["statename"] = "Telangana";
                Session["Role"] = "0";
                Session["ConnStr"] = ConfigurationManager.ConnectionStrings["ConnStrCentral"].ToString();
                DataTable dt = new DataTable();
             
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                 GetHitCount();
                DashBoard(Session["statecd"].ToString(), "ALL", "ALL", "ALL");

            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }


    protected void ddlstate_OnSelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void GetHitCount()
    {
        DataTable dt = new DataTable();
        dt = ObjRptBL.GetHitCountBL(Session["ConnStr"].ToString());
       // lblhitcount.Text = Convert.ToInt64(dt.Rows[0]["HitCount"]).ToString("N0", new CultureInfo("en-IN")); ;
    }
    public void DashBoard(string StateCode, string DistCode, string MandCode, string UniqueInsId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ObjRptBL.DashBoardCountBAL(StateCode, DistCode, MandCode, UniqueInsId, Session["ConnStr"].ToString());
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
            //Session["StateCd"] = "ALL";
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