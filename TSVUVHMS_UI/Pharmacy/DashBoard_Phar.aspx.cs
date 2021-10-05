using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class DashBoard_Phar : System.Web.UI.Page
{
    InstutionBAL ObjIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    ReportBAL ObjRptBL = new ReportBAL();
    DataTable ddt;
    string UniqueInstId, StateCode, UserName,DistCode,MandCode;
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
        imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
        lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
       
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        StateCode = Session["StateCd"].ToString();
        UserName = Session["UsrName"].ToString();
        UniqueInstId = Session["UniqueInstId"].ToString();
        DistCode = Session["DistCode"].ToString();
        MandCode = Session["MandCode"].ToString();
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                GetInsNameBAL();
                DashBoard(StateCode, DistCode, MandCode, UniqueInstId);
                //GetRegFeeBAL();
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
            dt = ObjIns.GetInsNameBAL(UniqueInstId, UserName, ConnKey);
            lblInsName.Text = dt.Rows[0]["InstitutionName"].ToString();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    public void DashBoard(string StateCode, string DistCode, string MandCode, string UniqueInsId)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = ObjRptBL.DashBoardCountBAL(StateCode, DistCode, MandCode, UniqueInstId, ConnKey);
            lblFinYear.Text = dt.Rows[0]["FinYear"].ToString();
            lblNewReg.Text = dt.Rows[0]["NewReg"].ToString();
            lblRevist.Text = dt.Rows[0]["ReVisit"].ToString();
            lblTotEnrollments.Text = dt.Rows[0]["Insutionsenrolled"].ToString();
            lblTotalValueofdrug.Text = dt.Rows[0]["ValueOfDrugs"].ToString();

            lblDayIns.Text = dt.Rows[0]["DayIns"].ToString();
            lblMnthIns.Text = dt.Rows[0]["MnthIns"].ToString();
            lblYearIns.Text = dt.Rows[0]["YearIns"].ToString();

            lblDayNewR.Text = dt.Rows[0]["DayNewR"].ToString();
            lblMnthNewR.Text = dt.Rows[0]["MnthNewR"].ToString();
            lblYearNewR.Text = dt.Rows[0]["YearNewReg"].ToString();

            lblDayRV.Text = dt.Rows[0]["DayRV"].ToString();
            lblMnthRV.Text = dt.Rows[0]["MnthRV"].ToString();
            lblYearRV.Text = dt.Rows[0]["YearReVisit"].ToString();

            lblDayI.Text = dt.Rows[0]["DayI"].ToString();
            lblMnthI.Text = dt.Rows[0]["MnthI"].ToString();
            lblYearI.Text = dt.Rows[0]["YearValueOfDrugs"].ToString();
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
            StateCode = Session["StateCd"].ToString();
            Response.Redirect("~/Rpt_DB_TotInstitutions.aspx", false);
        }
        if (Id == "N")
        {
            UniqueInstId = Session["UniqueInstId"].ToString();
            Session["RegType"] = "N";
            Response.Redirect("~/Rpt_DB_TotRegistrations.aspx", false);
        }
        if (Id == "R")
        {
            UniqueInstId = Session["UniqueInstId"].ToString();
            Session["RegType"] = "R";
            Response.Redirect("~/Rpt_DB_TotRegistrations.aspx", false);
        }
        if (Id == "D")
        {
            UniqueInstId = Session["UniqueInstId"].ToString();
            Response.Redirect("~/Rpt_DB_TotDrugsIssued.aspx", false);
        }
    }
}
