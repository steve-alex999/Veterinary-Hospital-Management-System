using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVUVHMS_BL;
using System.Data;
using System.Web.Security;
using System.Collections;
using System.Runtime.InteropServices;
using TSVUVHMS_DL;
using TSVUVHMS_BE;
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
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                btn_Save.Enabled = true;
                /*BIND STATE AND SET DEFAULT TO TELANGANA*/
                BindState();
                ddl_State.SelectedValue = StateCode;
                /*BIND ANIMALS*/
                BindAnimal();
                /*BIND DISTRICTS OF TELANGANA STATE AS IT IS SET AS DEFAULT VALUE*/
                bindDivision();
                

                //Panel1.Visible = false;
                Panel2.Visible = false;
                btn_Update.Visible = false;
                BindDoctor();
                BindPurpose();
                BindCategory();
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

        ddt = ObjIns.AnimaldetailsMbnoBAL(UniqueInstId, txtRMbno.Text.Trim(), ConnKey);
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

        if (a1.Text == "" || a2.Text == "" || a3.Text == "")
        {
            objCommon.ShowAlertMessage("Please Enter Aadhaar Number");
            return false;
        }
        else if (a1.Text.Length != 4 || a2.Text.Length != 4 || a3.Text.Length != 4)
        {

            objCommon.ShowAlertMessage("Please Enter Valid Aadhaar Number");
            return false;


        }
        else
        {
            if (!objValidate.IsNumberOk(a1.Text + a2.Text + a3.Text))
            {
                objCommon.ShowAlertMessage("Enter Valid Aadhar No");
                txtVdate.Focus();
                return false;
            }
            string aid = Verhoeff.validateVerhoeff(a1.Text + a2.Text + a3.Text).ToString();
            if (aid == "True")
            {

            }
            else
            {
                objCommon.ShowAlertMessage("InValid Aadhaar ID -Please Check");
                a1.Text = "";
                a2.Text = "";
                a3.Text = "";
                return false;
            }

        }
        if (ddlcategory.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Category");
            ddl_mandal_code.Focus();
            return false;
        }

        string purposelist = "";

        foreach (System.Web.UI.WebControls.ListItem item in ddlpurpose.Items)
        {
            if (item.Selected)
            {
                if (purposelist == "")
                {
                    purposelist += item.Value;
                }
                else
                {
                    purposelist += "," + item.Value;
                }

            }

        }
        if (purposelist == "")
        {
            objCommon.ShowAlertMessage("Please Select Purpose");
            return false;
        }

        string doctorlist = "";

        foreach (System.Web.UI.WebControls.ListItem item in ddlDoctor.Items)
        {
            if (item.Selected)
            {
                if (doctorlist == "")
                {
                    doctorlist += item.Value;
                }
                else
                {
                    doctorlist += "," + item.Value;
                }

            }

        }
        if (doctorlist == "")
        {
            objCommon.ShowAlertMessage("Please Select Doctor");
            return false;
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

            string purposelist = "";

            foreach (System.Web.UI.WebControls.ListItem item in ddlpurpose.Items)
            {
                if (item.Selected)
                {
                    if (purposelist == "")
                    {
                        purposelist += item.Value;
                    }
                    else
                    {
                        purposelist += "," + item.Value;
                    }

                }

            }

            string doctorlist = "";

            foreach (System.Web.UI.WebControls.ListItem item in ddlDoctor.Items)
            {
                if (item.Selected)
                {
                    if (doctorlist == "")
                    {
                        doctorlist += item.Value;
                    }
                    else
                    {
                        doctorlist += "," + item.Value;
                    }

                }

            }

            DateTime Vdate = DateTime.Parse(txtVdate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            string aadharid = a1.Text + a2.Text + a3.Text;
            objinsert.Unique_InsId = UniqueInstId;
            objinsert.Vdate = Vdate.ToString();
            objinsert.Atype = ddl_AnimalType.SelectedValue;
            objinsert.Doctor = ddlDoctor.SelectedValue;
            objinsert.Breed = ddlBreed.SelectedValue;
            objinsert.AgeInMonth = ddl_AgeMonth.SelectedValue;
            objinsert.AgeInYear = txtAnimalAge.Text;
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
            objinsert.Purpose = purposelist;
            objinsert.DoctorID = doctorlist;
            objinsert.visittype = rblvtype.SelectedValue;
            objinsert.nos = txtnos.Text;
            objinsert.aadharno = aadharid;
            objinsert.category = ddlcategory.SelectedValue;
            objinsert.divisioncd = ddldivision.SelectedValue;
            objinsert.villagecd = ddlvillage.SelectedValue;
            dt = ObjInsD.InsertPaitentUKDAL(objinsert, ConnKey);


            try
            {

                //dt = ObjIns.getInsertPaitentBAL(UniqueInstId, Vdate, ddl_AnimalType.SelectedValue.ToString(), ddlBreed.SelectedValue.ToString(), txtAnimalAge.Text, ddl_AgeMonth.SelectedValue.ToString(), Genger,
                //    txtAnimalOwner.Text.Trim(), ddl_State.SelectedValue.ToString(), ddl_dist_code.SelectedValue.ToString(), ddl_mandal_code.SelectedValue.ToString(), txtvillage.Text.Trim(),
                //    txtmbno.Text.Trim(), rdExempted.SelectedValue, lblRegFee.Text, UserName, "I", purposelist, rblvtype.SelectedValue, txtnos.Text, aadharid, ddlcategory.SelectedValue,ddldivision.SelectedValue, ConnKey);
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

    protected void rbnSy_CheckedChanged(object sender, EventArgs e)
    {
        ddl_AnimalType.Enabled = true;
        txtmbno.Enabled = true;
        Panel1.Visible = true;
        Panel2.Visible = false;

    }
    protected void rbnSn_CheckedChanged(object sender, EventArgs e)
    {
        ddl_AnimalType.Enabled = false;
        rdExempted.Enabled = false;
        //txtmbno.Enabled = false;
        Panel1.Visible = false;
        Panel2.Visible = true;


    }

    protected void a3_TextChanged(object sender, EventArgs e)
    {
        string aadharid = a1.Text + a2.Text + a3.Text;
        string aid = Verhoeff.validateVerhoeff(aadharid).ToString();
        if (aid == "True")
        {

        }
        else
        {
            objCommon.ShowAlertMessage("InValid Aadhaar ID -Please Check");
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";
            return;
        }
    }
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

                BindAnimal();
                ddl_AnimalType.SelectedValue = dtPatientDtls.Rows[0]["AnimalTypeCode"].ToString();
                BindBreed();
                ddlBreed.SelectedValue = dtPatientDtls.Rows[0]["BreedCode"].ToString();
                BindState();
                ddl_State.SelectedValue = dtPatientDtls.Rows[0]["Owner_StateCode"].ToString();

                bindDivision();

                ddldivision.SelectedValue = dtPatientDtls.Rows[0]["Owner_Division_Code"].ToString();
                string Dcode = dtPatientDtls.Rows[0]["Owner_DistCode"].ToString();
                binddisrict();
                ddl_dist_code.SelectedValue = Dcode;
                BindMandal(Dcode);
                try
                {
                    ddl_mandal_code.SelectedValue = dtPatientDtls.Rows[0]["Owner_MandCode"].ToString();
                }
                catch { }
                Bindvillage();
                try
                {
                    ddlvillage.SelectedValue = dtPatientDtls.Rows[0]["Owner_villageCode"].ToString();
                }
                catch { }
                rdExempted.SelectedValue = dtPatientDtls.Rows[0]["ExemptedCategory"].ToString();

                if (dtPatientDtls.Rows[0]["Owner_Aadhar"].ToString() != "")
                {
                    //  a1.Text = dtPatientDtls.Rows[0]["Owner_Aadhar"].ToString();
                    a1.Text = dtPatientDtls.Rows[0]["Owner_Aadhar"].ToString().Substring(0, 4);
                    a2.Text = dtPatientDtls.Rows[0]["Owner_Aadhar"].ToString().Substring(4, 4);
                    a3.Text = dtPatientDtls.Rows[0]["Owner_Aadhar"].ToString().Substring(8, 4);
                }
                ddlcategory.SelectedValue = dtPatientDtls.Rows[0]["Owner_Caste"].ToString().Trim();
                txtnos.Text = dtPatientDtls.Rows[0]["No_of_Animals"].ToString().Trim();
                rblvtype.SelectedValue = dtPatientDtls.Rows[0]["Place_of_Visit"].ToString();


                if (dtPatientDtls.Rows[0]["Purpose"].ToString() != "")
                {
                    string itemsPurpose = dtPatientDtls.Rows[0]["Purpose"].ToString();

                    string[] splitPurpose = itemsPurpose.Split(new string[] { "," }, StringSplitOptions.None);

                    foreach (string purposeid in splitPurpose)
                    {
                        foreach (ListItem item in ddlpurpose.Items)
                        {
                            if (item.Value == purposeid)
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }

                if (dtPatientDtls.Rows[0]["DoctorID"].ToString() != "")
                {
                    string itemsDoctorID = dtPatientDtls.Rows[0]["DoctorID"].ToString();

                    string[] splitDoctorID = itemsDoctorID.Split(new string[] { "," }, StringSplitOptions.None);

                    foreach (string doctorid in splitDoctorID)
                    {
                        foreach (ListItem item in ddlDoctor.Items)
                        {
                            if (item.Value == doctorid)
                            {
                                item.Selected = true;
                            }
                        }
                    }
                }
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
                string purposelist = "";

                foreach (System.Web.UI.WebControls.ListItem item in ddlpurpose.Items)
                {
                    if (item.Selected)
                    {
                        if (purposelist == "")
                        {
                            purposelist += item.Value;
                        }
                        else
                        {
                            purposelist += "," + item.Value;
                        }

                    }

                }

                string doctorlist = "";

                foreach (System.Web.UI.WebControls.ListItem item in ddlDoctor.Items)
                {
                    if (item.Selected)
                    {
                        if (doctorlist == "")
                        {
                            doctorlist += item.Value;
                        }
                        else
                        {
                            doctorlist += "," + item.Value;
                        }

                    }

                }

                string aadharid = a1.Text + a2.Text + a3.Text;
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
                objinsert.Doctor = ddlDoctor.SelectedValue;
                objinsert.Atype = ddl_AnimalType.SelectedValue;
                objinsert.Breed = ddlBreed.SelectedValue;
                objinsert.AgeInYear = txtAnimalAge.Text;
                objinsert.AgeInMonth = ddl_AgeMonth.SelectedValue;
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
                objinsert.Purpose = purposelist;
                objinsert.DoctorID = doctorlist;
                objinsert.visittype = rblvtype.SelectedValue;
                objinsert.nos = txtnos.Text;
                objinsert.aadharno = aadharid;
                objinsert.category = ddlcategory.SelectedValue;
                objinsert.divisioncd = ddldivision.SelectedValue;
                objinsert.villagecd = ddlvillage.SelectedValue;
                dt = ObjInsD.UpdatePaitentUKDAL(objinsert, ConnKey);
                /// dt = ObjIns.UpdatePaitentBAL(RegNo, Gender, txtAnimalAge.Text, ddl_AgeMonth.SelectedValue.ToString(), lblRegFee.Text, txtAnimalOwner.Text, ddlBreed.SelectedValue.ToString(), updatedt, ddl_State.SelectedValue.ToString(), ddl_dist_code.SelectedValue.ToString(), ddl_mandal_code.SelectedValue.ToString(), txtvillage.Text.Trim(), txtmbno.Text.Trim(), UserName, "U", purposelist, rblvtype.SelectedValue, txtnos.Text, aadharid, ddlcategory.SelectedValue,ddldivision.SelectedValue, ConnKey);
                Session["RegNo"] = dt.Rows[0]["RegistrationNo"].ToString();
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
                    ddt = ObjIns.AnimaldetailsMbnoBAL(UniqueInstId, txtRMbno.Text.Trim(), ConnKey);
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

        bindDivision();
    }
    protected void ddldivision_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void BindDoctor()
    {
        ddt = objDist.GetDoctorBAL(ConnKey);
        if (ddt.Rows.Count > 0)
        {
            ddlDoctor.DataSource = ddt;
            ddlDoctor.DataTextField = "Doctor";
            ddlDoctor.DataValueField = "DoctorID";
            ddlDoctor.DataBind();
        }

    }
    protected void BindAnimal()
    {
        try
        {
            ddt = ObjIns.viewAnimaldataBAL(ConnKey);
            objCommon.BindDropDownLists(ddl_AnimalType, ddt, "AnimalTypeDesc", "AnimalTypeCode", "0");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void BindPurpose()
    {
        ddt = objDist.GetPurposeBAL(ConnKey);
        if (ddt.Rows.Count > 0)
        {
            ddlpurpose.DataSource = ddt;
            ddlpurpose.DataTextField = "PurposeDesc";
            ddlpurpose.DataValueField = "PurposeCode";
            ddlpurpose.DataBind();
        }

    }
    protected void BindCategory()
    {
        try
        {
            ddt = objDist.GetCategoryBAL(ConnKey);
            objCommon.BindDropDownLists(ddlcategory, ddt, "CasteName", "CasteCode", "0");
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
            ddt = objDist.getDistrictsByDivisionBAL(ddl_State.SelectedValue.ToString(), ddldivision.SelectedValue, ConnKey);
            if (ddt.Rows.Count > 0)
            {
                objCommon.BindDropDownLists(ddl_dist_code, ddt, "DistName", "DistCode", "0");

                ddl_mandal_code.Items.Clear();
                ddl_mandal_code.Items.Insert(0, new ListItem("Select", "0"));
                ddlvillage.Items.Clear();
                ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
            }
            else
            {
                ddl_dist_code.Items.Clear();
                ddl_dist_code.Items.Insert(0, new ListItem("Select", "0"));
                ddl_mandal_code.Items.Clear();
                ddl_mandal_code.Items.Insert(0, new ListItem("Select", "0"));
                ddlvillage.Items.Clear();
                ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void bindDivision()
    {
        try
        {
            ddt = objDist.GetDivisionBAL(ddl_State.SelectedValue, ConnKey);
            if (ddt.Rows.Count > 0)
            {
                objCommon.BindDropDownLists(ddldivision, ddt, "division_Name", "division_code", "0");
                ddl_dist_code.Items.Clear();
                ddl_dist_code.Items.Insert(0, new ListItem("Select", "0"));
                ddl_mandal_code.Items.Clear();
                ddl_mandal_code.Items.Insert(0, new ListItem("Select", "0"));
                ddlvillage.Items.Clear();
                ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
            }
            else
            {
                ddldivision.Items.Clear();
                ddldivision.Items.Insert(0, new ListItem("Select", "0"));
                ddl_dist_code.Items.Clear();
                ddl_dist_code.Items.Insert(0, new ListItem("Select", "0"));
                ddl_mandal_code.Items.Clear();
                ddl_mandal_code.Items.Insert(0, new ListItem("Select", "0"));
                ddlvillage.Items.Clear();
                ddlvillage.Items.Insert(0, new ListItem("Select", "0"));
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


    protected void ddl_mandal_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Bindvillage();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    private void Bindvillage()
    {
        ddt = objDist.GetVillageBAL(ddl_dist_code.SelectedValue, "", ConnKey);
        if (ddt.Rows.Count > 0)
        {
            objCommon.BindDropDownLists(ddlvillage, ddt, "VillName", "VillCode", "0");
        }
    }
}
