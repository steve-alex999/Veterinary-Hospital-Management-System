using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;
using VHMS_DL;
using VHMS_BE;

public partial class Patient : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    Patientdet objinsert = new Patientdet();
    InstutionBAL ObjIns = new InstutionBAL();
    InstutionDAL ObjInsD = new InstutionDAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();
    DataTable ddt;
    string UniqueInstId, StateCode, UserName;
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
        if (Session["Role"].ToString() == null || Session["Role"].ToString() != "2")
        {
            Response.Redirect("~/Error.aspx");
        }
        /*DISABLE BUTTON AFTER ONE CLICK*/
        btn_Save.Attributes.Add("onclick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(btn_Save, null) + ";");
        imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
        lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        StateCode = Session["StateCd"].ToString();
        UserName = Session["UsrName"].ToString();
        UniqueInstId = Session["UniqueInstId"].ToString();
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
            btn_Save.Enabled = true;
            /*BIND STATE AND SET DEFAULT TO TELANGANA*/
            BindState();
            ddl_State.SelectedValue = StateCode;
            /*BIND ANIMALS*/
            BindAnimal();
            /*BIND DISTRICTS OF TELANGANA STATE AS IT IS SET AS DEFAULT VALUE*/
            binddisrict();
            //Panel1.Visible = false;
            Panel2.Visible = false;
            btn_Update.Visible = false;

            txtVdate.Text = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
           
                GetInsNameBAL();
                //GetRegFeeBAL();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
            GvPatientDtlsMbno.Visible = true;
            lblMsg.Visible = false;
        }
    }
   
    protected void GvPatientDtlsMbno_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvPatientDtlsMbno.PageIndex = e.NewPageIndex;

        ddt = ObjIns.AnimaldetailsMbnoBAL(UniqueInstId, txtRMbno.Text.Trim(),ConnKey);
        try
        {
            if (ddt.Rows.Count > 0)
            {
                GvPatientDtlsMbno.Visible = true;
                GvPatientDtlsMbno.DataSource = ddt;
                GvPatientDtlsMbno.DataBind();
                return;
            }
            else
            {
                objCommon.ShowAlertMessage("Mobile No does not exist");
                Panel1.Visible = false;
                GvPatientDtlsMbno.Visible = false;
                txtRMbno.Focus();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected bool Validate_Save()
    {
        if (ddl_AnimalType.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select AnimalType");
            ddl_AnimalType.Focus();
            return false;
        }
        if (ddlBreed.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Breed");
            ddlBreed.Focus();
            return false;
        }
        if ((!rbnFemale.Checked) && (!rbnMale.Checked))
        {
            objCommon.ShowAlertMessage("Select Gender");
            return false;
        }

        if (txtAnimalAge.Text.Trim() == "")
        {
            objCommon.ShowAlertMessage("Enter Animal Age");
            txtAnimalAge.Focus();
            return false;
        }
        if (txtAnimalOwner.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Owner Name");
            txtAnimalOwner.Focus();
            return false;
        }
        if (ddl_dist_code.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select District");
            ddl_dist_code.Focus();
            return false;
        }
        if (ddl_mandal_code.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Mandal");
            ddl_mandal_code.Focus();
            return false;
        }
        if (txtvillage.Text == "")
        {
            objCommon.ShowAlertMessage("Enter City/Village");
            txtvillage.Focus();
            return false;
        }
        if (txtmbno.Text == "")
        {

            objCommon.ShowAlertMessage("Please Enter Mobile Number");
            return false;
        }
        else
        {
            if (!objValidate.ISMobileNo(txtmbno.Text, 9, 9))
            {
                objCommon.ShowAlertMessage("Please Enter Valid Mobile Number");
                return false;
            }              
        }
        if (rdExempted.SelectedIndex < 0)
        {
            objCommon.ShowAlertMessage("Select an option for Exempted Category");
            rdExempted.Focus();
            return false;
        }        
        if (txtVdate.Text.Trim() != "")
        {
            if (!objValidate.IsDate(txtVdate.Text.Trim()))
            {
                objCommon.ShowAlertMessage("Enter Valid Visit Date");
                txtVdate.Focus();
                return false;
            }
        }
        return true;
    }
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void btn_Save_Click(object sender, EventArgs e)
    {
       // btn_Save.Enabled = false;
        int Genger = (rbnMale.Checked ? 0 : (rbnFemale.Checked ? 1 : 0));
        DataTable dt = new DataTable();
        if (Validate_Save())
        {

            try
            {
                DateTime Vdate = DateTime.Parse(txtVdate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
             
                objinsert.Unique_InsId = UniqueInstId;
                objinsert.Vdate = Vdate.ToString();
                objinsert.Atype = ddl_AnimalType.SelectedValue;
                objinsert.Breed = ddlBreed.SelectedValue;
                objinsert.AgeInMonth = txtAnimalAge.Text;
                objinsert.AgeInYear = ddl_AgeMonth.SelectedValue;
                objinsert.Gender = Genger;
                objinsert.AnimalOwner = txtAnimalOwner.Text.Trim();
                objinsert.StateCode = ddl_State.SelectedValue.ToString();
                objinsert.Distcode = ddl_dist_code.SelectedValue.ToString();
                objinsert.Mandcode = ddl_mandal_code.SelectedValue.ToString();
                objinsert.Village = txtvillage.Text.Trim();
                objinsert.Mobileno = txtmbno.Text;
                objinsert.ExemptedCategory = rdExempted.SelectedValue;
                objinsert.Regfee = lblRegFee.Text;
                objinsert.Flag = "I";
                dt = ObjInsD.InsertPaitentAllDAL(objinsert, ConnKey);

               btn_Save.Visible = false;
               Session["RegNo"] = dt.Rows[0]["RegistrationNo"].ToString();
               Session["VisitDate"] = Vdate;
                Response.Redirect("~/Institution/PrintCaseSheet.aspx", false);
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

    //protected void rbnSy_CheckedChanged(object sender, EventArgs e)
    //{
    //    ddl_AnimalType.Enabled = true;
    //    txtmbno.Enabled = true;
    //    Panel1.Visible = true;
    //    Panel2.Visible = false;

    //}
    //protected void rbnSn_CheckedChanged(object sender, EventArgs e)
    //{
    //    ddl_AnimalType.Enabled = false;
    //    rdExempted.Enabled = false;
    //    //txtmbno.Enabled = false;
    //    Panel1.Visible = false;
    //    Panel2.Visible = true;


    //}

    protected void ddl_dist_code_SelectedIndexChanged(object sender, EventArgs e)
    {

        BindMandal(ddl_dist_code.SelectedValue);
    }
    public void BindMandal(string dccode)
    {
        try
        {
            ddt = objDist.getMandalsByDistCodeBAL(dccode, ConnKey);
            if (ddt.Rows.Count > 0)
            {
                objCommon.BindDropDownLists(ddl_mandal_code, ddt, "MandName", "MandCode", "0");
            }
            else
            {
                ddl_mandal_code.Items.Clear();     
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    public void FetchPatientDetails(string RegNo)
    {
        try
        {
            DataTable dtPatientDtls = ObjIns.FetchPaitentDtlsBAL(RegNo, ConnKey);
            if (dtPatientDtls.Rows.Count > 0)
            {
                if (dtPatientDtls.Rows[0]["Gender"].ToString() == "Male")
                    rbnMale.Checked = true;
                else
                    rbnFemale.Checked = true;

                txtAnimalAge.Text = dtPatientDtls.Rows[0]["AgeInYear"].ToString();
                ddl_AgeMonth.SelectedValue = dtPatientDtls.Rows[0]["AgeInMonth"].ToString();
                txtAnimalOwner.Text = dtPatientDtls.Rows[0]["Owner_Name"].ToString();
                txtmbno.Text = dtPatientDtls.Rows[0]["Owner_MobileNo"].ToString();
                txtvillage.Text = dtPatientDtls.Rows[0]["Owner_Address"].ToString();
                lblRegFee.Text = dtPatientDtls.Rows[0]["Reg_Fee"].ToString();
                lblLastVstDt.Text = dtPatientDtls.Rows[0]["LastVisitDate"].ToString();
                string Dcode = dtPatientDtls.Rows[0]["Owner_DistCode"].ToString();
                binddisrict();
                ddl_dist_code.SelectedValue = Dcode;
                BindMandal(Dcode);
                ddl_mandal_code.SelectedValue = dtPatientDtls.Rows[0]["Owner_MandCode"].ToString();
                BindAnimal();
                ddl_AnimalType.SelectedValue = dtPatientDtls.Rows[0]["AnimalTypeCode"].ToString();
                BindBreed();
                ddlBreed.SelectedValue = dtPatientDtls.Rows[0]["BreedCode"].ToString();
                BindState();
                ddl_State.SelectedValue = dtPatientDtls.Rows[0]["Owner_StateCode"].ToString();
                rdExempted.SelectedValue = dtPatientDtls.Rows[0]["ExemptedCategory"].ToString();
            }
            else
            {
                objCommon.ShowAlertMessage("Registration No does not exist");
                Panel1.Visible = false;
                GvPatientDtlsMbno.Visible = false;
                txt_FregNo.Focus();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }


    }
    protected void GvPatientDtlsMbno_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "ShowPaitentdetails")
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                LinkButton lblRegNo = (LinkButton)gvrow.FindControl("linkgetregno");
                FetchPatientDetails(lblRegNo.Text);
                lblRegistrationNo.Text = lblRegNo.Text;
                ViewState["MobileSearch"] = "1";
                ViewState["RegNo"] = lblRegNo.Text.Trim();
                Panel1.Visible = true;
                btn_Save.Visible = false;
                btn_Update.Visible = true;

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
        DataTable dt = new DataTable();
        if (Validate_Save())
        {
            try
            {
                DateTime updatedt = DateTime.Parse(txtVdate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                int Gender = (rbnMale.Checked ? 0 : (rbnFemale.Checked ? 1 : 0));
               // DateTime date1 = Convert.ToDateTime(txtVdate.Text);
               // string updatedt = date1.ToString("yyyy/MM/dd");
                string RegNo;
                if (ViewState["MobileSearch"].ToString() == "1")
                    RegNo = ViewState["RegNo"].ToString();
                else
                    RegNo = txt_FregNo.Text.Trim();


                objinsert.Unique_InsId = UniqueInstId;
                objinsert.RegNo = RegNo;
                objinsert.Vdate = updatedt.ToString();
                objinsert.Atype = ddl_AnimalType.SelectedValue;
                objinsert.Breed = ddlBreed.SelectedValue;
                objinsert.AgeInMonth = txtAnimalAge.Text;
                objinsert.AgeInYear = ddl_AgeMonth.SelectedValue;
                objinsert.Gender = Gender;
                objinsert.AnimalOwner = txtAnimalOwner.Text.Trim();
                objinsert.StateCode = ddl_State.SelectedValue.ToString();
                objinsert.Distcode = ddl_dist_code.SelectedValue.ToString();
                objinsert.Mandcode = ddl_mandal_code.SelectedValue.ToString();
                objinsert.Village = txtvillage.Text.Trim();
                objinsert.Mobileno = txtmbno.Text;
                objinsert.ExemptedCategory = rdExempted.SelectedValue;
                objinsert.Regfee = lblRegFee.Text;
                objinsert.Flag = "U";
                dt = ObjInsD.InsertPaitentAllDAL(objinsert, ConnKey);

             //   dt = ObjIns.UpdatePaitentBAL(RegNo, Gender, txtAnimalAge.Text, ddl_AgeMonth.SelectedValue.ToString(), lblRegFee.Text, txtAnimalOwner.Text, ddlBreed.SelectedValue.ToString(), updatedt, ddl_State.SelectedValue.ToString(), ddl_dist_code.SelectedValue.ToString(), ddl_mandal_code.SelectedValue.ToString(), txtvillage.Text.Trim(),txtmbno.Text.Trim(), UserName, "U", ConnKey);



                Session["RegNo"] = RegNo;// dt.Rows[0]["RegistrationNo"].ToString();
                Session["VisitDate"] = updatedt;
                Response.Redirect("~/Institution/PrintCaseSheet.aspx", false);
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
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = false;
            if (txt_FregNo.Text.Trim() == "" && txtRMbno.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Kindly Provide either Registration No / Mobile No");
            }
            else
            {
                if (txt_FregNo.Text.Trim() != "")
                {
                    ViewState["MobileSearch"] = "0";
                    txtRMbno.Text = "";
                    Panel1.Visible = true;
                    btn_Save.Visible = false;
                    btn_Update.Visible = true;
                    FetchPatientDetails(txt_FregNo.Text.Trim());
                    GvPatientDtlsMbno.Visible = false;
                    return;

                }

                if (txtRMbno.Text != "")
                {
                    txt_FregNo.Text = "";
                    ddt = ObjIns.AnimaldetailsMbnoBAL( UniqueInstId, txtRMbno.Text.Trim(), ConnKey);
                    if (ddt.Rows.Count > 0)
                    {
                        ViewState["MobileSearch"] = "1";
                        GvPatientDtlsMbno.Visible = true;
                        GvPatientDtlsMbno.DataSource = ddt;
                        GvPatientDtlsMbno.DataBind();
                        return;
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("Mobile No does not exist");
                        Panel1.Visible = false;
                        GvPatientDtlsMbno.Visible = false;
                        txtRMbno.Focus();
                    }

                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }



    protected void ddl_State_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        binddisrict();
    }
    protected void BindState()
    {
        try
        {
            ddt = objDist.getstate(ConnKey);
            objCommon.BindDropDownLists(ddl_State, ddt, "StateName", "StateCode", "0");
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
    protected void binddisrict()
    {
        try
        {
            ddt = objDist.getDistrictsByStateCodeBAL(ddl_State.SelectedValue.ToString(), ConnKey);
            if (ddt.Rows.Count > 0)
            {
                objCommon.BindDropDownLists(ddl_dist_code, ddt, "DistName", "DistCode", "0");
            }
            else
            {
                ddl_dist_code.Items.Clear();
                ddl_mandal_code.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void BindBreed()
    {
        try
        {
            ddt = objDist.getBreedByAnimalTypeBAL(ddl_AnimalType.SelectedValue.ToString(), ConnKey);
            objCommon.BindDropDownLists(ddlBreed, ddt, "BreedName", "BreedCode", "0");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddlAnimalType_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        /*GET REG FEE BASED ON SELECTED ANIMAL TYPE*/
        try
        {
            DataTable dt = new DataTable();
            dt = ObjIns.GetRegFee_ByAnimalTypeBAL(UniqueInstId, ddl_AnimalType.SelectedValue, ConnKey);
            lblRegFee.Text = dt.Rows[0]["RegFee"].ToString();
            /*GET BREED*/
            BindBreed();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }

    protected void rdExempted_OnSelectedChanged(object sender, EventArgs e)
    {
        if (rdExempted.SelectedValue == "Yes")
            lblRegFee.Text = "0";
    }
    protected void rblvisttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblvisttype.SelectedValue == "New")
        {
            ddl_AnimalType.Enabled = true;
            txtmbno.Enabled = true;
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        else if (rblvisttype.SelectedValue == "Rev")
        {
            ddl_AnimalType.Enabled = false;
            rdExempted.Enabled = false;
            //txtmbno.Enabled = false;
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
    }
}
