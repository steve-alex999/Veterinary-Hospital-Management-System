using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class BreedMaster : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    InstutionBAL ObjIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    string UserName,Connkey;
    DataTable ddt;
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
        lblUsrName.Text = UserName = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                ConnKey = Session["ConnStr"].ToString();
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                BindAnimal();
                btn_Update.Visible = false;
            }

            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }


    }
    public void Viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            dt1 = objDist.viewBreedDtlsBAL(ddl_AnimalType.SelectedValue.ToString(), ConnKey);
            GvBreed.DataSource = dt1;
            GvBreed.DataBind();
            if (dt1.Rows.Count > 0)
            {
                GvBreed.HeaderRow.Cells[0].Attributes["data-class"] = "expand";
                GvBreed.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GvBreed.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GvBreed.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                GvBreed.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void BindAnimal()
    {
        try
        {
            ddt = ObjIns.viewAnimaldataBAL( ConnKey);
            objCommon.BindDropDownLists(ddl_AnimalType, ddt, "AnimalTypeDesc", "AnimalTypeCode", "0");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GvBreed_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvBreed.PageIndex = e.NewPageIndex;
        Viewdata();

    }

    protected void GvBreed_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {
                DataTable dt = new DataTable();
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblBreedCd = (Label)gvrow.FindControl("lblBreedCd");
                dt = objDist.DeleteBreedBAL(ddl_AnimalType.SelectedValue.ToString(), lblBreedCd.Text, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtBreedCode.Text = "";
                    ddl_AnimalType.Enabled = true;
                    txtBreedName.Text = "";
                     btn_Update.Visible = false;
                    btn_Save.Visible = true;

                }
                else
                {
                    ddl_AnimalType.Enabled = true;
                    btn_Update.Visible = false;
                    btn_Save.Visible = true;
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    
                }
                Viewdata();

            }

            if (e.CommandName == "Edt")
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                txtBreedCode.Text = ((Label)(gvrow.FindControl("lblBreedCd"))).Text;
                txtBreedName.Text = ((Label)(gvrow.FindControl("lblBreedNm"))).Text;
                ddl_AnimalType.SelectedValue = ((Label)(gvrow.FindControl("lblAnimalTyeCd"))).Text;
                ddl_AnimalType.Enabled = false;
                txtBreedCode.Enabled = false;
                btn_Update.Visible = true;
                btn_Save.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }

    protected bool ValidateBreed()
    {
        if (ddl_AnimalType.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select AnimalType");
            ddl_AnimalType.Focus();
            return false;
        }
        if (txtBreedCode.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Breed Code");
            txtBreedCode.Focus();
            return false;
        }
        if (txtBreedName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Breed Name");
            txtBreedName.Focus();
            return false;
        }
        return true;
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateBreed())
            {
                ddt = objDist.InsertBreedBAL(txtBreedCode.Text.Trim(), ddl_AnimalType.SelectedValue.ToString(), txtBreedName.Text.Trim(), UserName, ConnKey);
                if (ddt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
                    txtBreedCode.Text = "";
                    txtBreedName.Text = "";
                }
                Viewdata();
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


    protected void btn_Update_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        try
        {
            if (ValidateBreed())
            {

                dt = objDist.UpdateBreedBAL(txtBreedCode.Text.Trim(), ddl_AnimalType.SelectedValue.ToString(), txtBreedName.Text.Trim(), UserName, ConnKey);
                if (dt.Rows.Count > 0)
                {

                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtBreedCode.Text = "";
                    ddl_AnimalType.Enabled = true;
                    txtBreedName.Text = "";
                    btn_Save.Visible = true;
                    txtBreedCode.Enabled = true;
                    btn_Update.Visible = false;

                }
                else
                {
                    txtBreedCode.Text = "";
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                    txtBreedName.Text = "";
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    

                }
                Viewdata();
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
    protected void ddl_AnimalType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtBreedCode.Text = "";
        ddl_AnimalType.Enabled = true;
        txtBreedName.Text = "";
        btn_Save.Visible = true;
        txtBreedCode.Enabled = true;
        btn_Update.Visible = false;
        Viewdata();
    }
}


