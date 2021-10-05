using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using Elaabh_BE;
using Elaabh_BL;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.SqlClient;
using context = System.Web.HttpContext;


public partial class Farmerdetails_MeeSeva : System.Web.UI.Page
{
    FarmerReg objFarmerBE = new FarmerReg();
    FarmerRegBAL objFarmerBAL = new FarmerRegBAL();
    SchemeBAL objschemeBAL = new SchemeBAL();
    CommonFuncs objCommon = new CommonFuncs();
    emailAndSms objemailsms = new emailAndSms();
    Validate objValidate = new Validate();
    DataTable dt;
    Meeseva_BL objMSBL = new Meeseva_BL();
    Meeseva_Functions objMF = new Meeseva_Functions();
    string ConnKey = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    string ipaddres = HttpContext.Current.Request.UserHostAddress;
    string erroepagrname = context.Current.Request.Url.ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
        //{
        //    Response.Redirect("~/Error_MeeSeva.aspx");
        //}
        //else
        //{
        //    string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
        //    string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
        //    int len = http_hos.Length;
        //    if (http_ref.IndexOf(http_hos, 0) < 0)
        //    {
        //        Response.Redirect("~/Error_MeeSeva.aspx");
        //    }
        //}
        if (!IsPostBack)
        {
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            try
            {
                if (Request.QueryString.Keys.Count > 0)
                {

                    string enc = Convert.ToString(Request.QueryString["enc"]);
                    /*STORE QUERY STRING DATABASE*/
                    DataTable dt = objMSBL.InsertQueryStringBAL(enc, erroepagrname, ipaddres, ConnKey);
                    if (dt.Rows.Count > 0)
                    {
                        ViewState["Meeseva_Id"] = dt.Rows[0][0].ToString();
                    }
                    string queryString = enc.Replace(" ", "+");
                    queryString = objMF.Decrypt(queryString);
                    IList<string> queryStringArray = queryString.Split('&');

                    ViewState["StrUniqueNo"] = Convert.ToString(queryStringArray[0].Split('=')[1]);
                    ViewState["StrSCAId"] = Convert.ToString(queryStringArray[1].Split('=')[1]);
                    ViewState["StrMeesevaUserId"] = Convert.ToString(queryStringArray[2].Split('=')[1]);
                    ViewState["StrChannelId"] = Convert.ToString(queryStringArray[3].Split('=')[1]);
                    ViewState["StrChecksum"] = Convert.ToString(queryStringArray[4].Split('=')[1]);
                    ViewState["StrMeesevaRequestId"] = Convert.ToString(queryStringArray[5].Split('=')[1]);
                    ViewState["StrServiceid"] = Convert.ToString(queryStringArray[6].Split('=')[1]);
                    ViewState["StrScaPassword"] = Convert.ToString(queryStringArray[7].Split('=')[1]);
                    ViewState["StrMeesevaFlag"] = Convert.ToString(queryStringArray[8].Split('=')[1]);
                    ViewState["StrRandomNumber"] = Convert.ToString(queryStringArray[9].Split('=')[1]);

                    /* check whether random number existed in db or not */

                    bool checkrandom = Checkrandomno(ViewState["StrRandomNumber"].ToString());
                    if (checkrandom == false)
                    {

                    /*STORE DECRYPTED VALUES IN DATABASE*/
                    objMSBL.UpdateDecryptedValuesBAL(ViewState["StrUniqueNo"].ToString(), ViewState["StrSCAId"].ToString(), ViewState["StrMeesevaUserId"].ToString(), ViewState["StrChannelId"].ToString(), ViewState["StrChecksum"].ToString(),
                        ViewState["StrMeesevaRequestId"].ToString(), ViewState["StrServiceid"].ToString(), ViewState["StrScaPassword"].ToString(), ViewState["StrMeesevaFlag"].ToString(), ViewState["StrRandomNumber"].ToString(), ViewState["Meeseva_Id"].ToString(), erroepagrname, ipaddres, ConnKey);
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("Invalid Request");
                        Response.Redirect("~/Error_MeeSeva.aspx");

                    }
                    // AS INFORMED BY MEE SEVA THIRD PARAMETER IS ALSO USER ID
                    bool check = objMF.GenerateCheckSum1(ViewState["StrSCAId"].ToString(), ViewState["StrScaPassword"].ToString(), ViewState["StrSCAId"].ToString(), ViewState["StrMeesevaUserId"].ToString(), ViewState["StrUniqueNo"].ToString(), ViewState["StrChecksum"].ToString());
                    if (check == true)
                    {
                        /*STORE CHECKSUM MATCHING STATUS*/
                        objMSBL.UpdateChecksumStatusBAL("Y", ViewState["Meeseva_Id"].ToString(), erroepagrname, ipaddres, ConnKey);
                        BindState();
                        BindDistrict();
                        BindCaste();
                        BindGender();
                        BindBankdetails();
                        Binddep();

                    }
                    else
                    {
                        /*STORE CHECKSUM MATCHING STATUS*/
                        objMSBL.UpdateChecksumStatusBAL("N", ViewState["Meeseva_Id"].ToString(), erroepagrname, ipaddres, ConnKey);
                        objCommon.ShowAlertMessage("Invalid Request");
                        Response.Redirect("~/Error_MeeSeva.aspx");

                    }
                }
                else
                {
                    Response.Redirect("~/Error_MeeSeva.aspx");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error_MeeSeva.aspx");


            }


        }
    }

    //protected void ddldep_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        List<String> depCode_list = new List<string>();
    //        List<String> depName_list = new List<string>();

    //        foreach (System.Web.UI.WebControls.ListItem item in ddldep.Items)
    //        {
    //            if (item.Selected)
    //            {
    //                depCode_list.Add(item.Value);

    //            }

    //        }

    //        // ddl_Drug.Texts.SelectBoxCaption = String.Join(",", DieaseName_list.ToArray());
    //        ViewState["depCode_list"] = String.Join(",", depCode_list.ToArray());
    //        if (ViewState["depCode_list"].ToString() != "")
    //        {
    //            ddldep.Texts.SelectBoxCaption = "Selected";
    //        }
    //        else
    //        {
    //            ddldep.Texts.SelectBoxCaption = "Select Department";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
    //        Response.Redirect("~/Error_MeeSeva.aspx");
    //    }

    //}

    public bool Checkrandomno(string randomno)
    {
        bool ceckrandomno = false;
        dt = objMSBL.CheckrandomnoBAL(randomno, erroepagrname, ipaddres, ConnKey);
        if (dt.Rows.Count > 0)
        {

            if (dt.Rows[0][0].ToString() == "Yes")
            {

                ceckrandomno = true;

            }
            else
            {

                ceckrandomno = false;

            }

        }

        return ceckrandomno;


    }


    public void GetFarmerdetails(string RegNo, string AId, string MNO)
    {
        dt = new DataTable();
        DataTable dtdata;
        try
        {
            objFarmerBE.FarmerId = RegNo;
            objFarmerBE.AadhaarId = AId;
            objFarmerBE.MobileNo = MNO;
            dt = objFarmerBAL.ReportFarmerBAL(objFarmerBE);
            //objFarmerBE.MobileNo = MNO;
            //dt = objFarmerBAL.GetFarmerdetailsBAL(objFarmerBE);
            if (dt.Rows.Count > 0)
            {
                tblerbl.Visible = false;
                btnConfirm.Visible = true;
                tbleFarmer.Visible = true;
                tblconfirm.Visible = true;
                ViewState["FarmerId"] = dt.Rows[0]["FarmerId"].ToString();
                txtfarmername.Text = dt.Rows[0]["FarmerName"].ToString();
                txtForHname.Text = dt.Rows[0]["FatherName"].ToString();
                //ddlgender.SelectedItem.Text = dt.Rows[0]["Gender"].ToString();
                foreach (ListItem item in ddlgender.Items)
                {
                    if (dt.Rows[0]["Gender"].ToString() == item.Text)
                    {
                        ddlgender.SelectedValue = item.Value;
                    }
                }
                ddldist.SelectedValue = dt.Rows[0]["DistCode"].ToString();
                objFarmerBE.dist_code = dt.Rows[0]["DistCode"].ToString();
                dtdata = new DataTable();
                dtdata = objFarmerBAL.GetmandalsBAL(objFarmerBE);
                if (dtdata.Rows.Count > 0)
                {

                    Bindddl(ddlmandal, dtdata, "MandName", "MandCode", "Select Mandal");

                }
                ddlmandal.SelectedValue = dt.Rows[0]["MandCode"].ToString();
                objFarmerBE.MandCode = dt.Rows[0]["MandCode"].ToString();
                dtdata = new DataTable();
                dtdata = objFarmerBAL.GetvillBAL(objFarmerBE);
                if (dtdata.Rows.Count > 0)
                {

                    Bindddl(ddlvillage, dtdata, "VillName", "VillCode", "Select Village");

                }
                ddlvillage.SelectedValue = dt.Rows[0]["VillCode"].ToString();
                ddlcaste.SelectedValue = dt.Rows[0]["Caste"].ToString();
                txtaddr.Text = dt.Rows[0]["Address"].ToString();
                // rbldisable.SelectedValue = dt.Rows[0]["Disability"].ToString();
                if (dt.Rows[0]["Disability"].ToString() == "1")
                {
                    rbldisable.Items[0].Selected = true;
                    txtpercdisab.Text = dt.Rows[0]["Disability_Percent"].ToString();
                }
                else
                {
                    txtpercdisab.Enabled = false;
                    rbldisable.Items[1].Selected = true;
                }

                txtincome.Text = dt.Rows[0]["Income"].ToString();
                a1.Text = dt.Rows[0]["AadhaarId"].ToString().Substring(0, 4);
                a2.Text = dt.Rows[0]["AadhaarId"].ToString().Substring(4, 4);
                a3.Text = dt.Rows[0]["AadhaarId"].ToString().Substring(8, 4);
                txtemail.Text = dt.Rows[0]["MAILID"].ToString();
                txtmobile.Text = dt.Rows[0]["MobileNo"].ToString();

                if (dt.Rows[0]["DeptCode"].ToString() != "")
                {
                    string[] deptarray = dt.Rows[0]["DeptCode"].ToString().Split(',');

                    for (int d = 0; d < deptarray.Count(); d++)
                    {
                        foreach (System.Web.UI.WebControls.ListItem item in ddldep.Items)
                        {
                            if (item.Value == deptarray[d])
                            {
                                item.Selected = true;
                            }

                        }

                    }



                }

                ddlbankname.SelectedValue = dt.Rows[0]["bankcode"].ToString();
                txtaccount.Text = dt.Rows[0]["AccountNo"].ToString();
                txtifsc.Text = dt.Rows[0]["IFSCCode"].ToString();
                ViewState["SchemeApplied"] = dt.Rows[0]["SchemeApplied"];
                ViewState["IsEligible"] = dt.Rows[0]["IsEligible"];
                if (dt.Rows[0]["SchemeApplied"].ToString() == "1" && dt.Rows[0]["IsEligible"].ToString() == "1" && dt.Rows[0]["IsSanctioned"].ToString() == "0")
                {
                    btn_Payment.Enabled = true;
                    txtfarmername.Enabled = true;
                    ddldep.Enabled = false;
                    txtForHname.Enabled = false;
                    txtaddr.Enabled = true;
                    ddlgender.Enabled = false;
                    ddlstatename.Enabled = false;
                    ddldist.Enabled = false;
                    ddlmandal.Enabled = false;
                    ddlvillage.Enabled = false;
                    ddlcaste.Enabled = false;
                    a1.Enabled = false;
                    a2.Enabled = false;
                    a3.Enabled = false;
                    txtpercdisab.Enabled = false;
                    rbldisable.Enabled = false;
                    txtincome.Enabled = false;
                    txtemail.Enabled = false;
                    ddlbankname.Enabled = true;
                    txtaccount.Enabled = true;
                    txtifsc.Enabled = true;
                }
                else if (dt.Rows[0]["SchemeApplied"].ToString() == "1" && dt.Rows[0]["IsEligible"].ToString() == "0" && dt.Rows[0]["IsSanctioned"].ToString() == "0")
                {
                    btn_Payment.Enabled = true;
                    txtfarmername.Enabled = true;
                    ddldep.Enabled = false;
                    ddlcaste.Enabled = false;
                }
                else if (dt.Rows[0]["SchemeApplied"].ToString() == "0" && dt.Rows[0]["IsEligible"].ToString() == "0" && dt.Rows[0]["IsSanctioned"].ToString() == "1")
                {
                    btn_Payment.Enabled = false;
                    txtfarmername.Enabled = false;
                    ddldep.Enabled = false;
                    txtForHname.Enabled = false;
                    txtaddr.Enabled = false;
                    ddlgender.Enabled = false;
                    ddlstatename.Enabled = false;
                    ddldist.Enabled = false;
                    ddlmandal.Enabled = false;
                    ddlvillage.Enabled = false;
                    ddlcaste.Enabled = false;
                    a1.Enabled = false;
                    a2.Enabled = false;
                    a3.Enabled = false;
                    txtpercdisab.Enabled = false;
                    rbldisable.Enabled = false;
                    txtincome.Enabled = false;
                    txtemail.Enabled = false;
                    ddlbankname.Enabled = false;
                    txtaccount.Enabled = false;
                    txtifsc.Enabled = false;
                }

            }
            else
            {

                objCommon.ShowAlertMessage("No data found for enterd mobile number");
                tbleFarmer.Visible = false;
                tblconfirm.Visible = false;
                tblerbl.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error_MeeSeva.aspx");


        }


    }

    public void Binddep()
    {
        dt = new DataTable();
        try
        {
            dt = objschemeBAL.getdepBAL();
            if (dt.Rows.Count > 0)
            {
                ddldep.Items.Clear();
                ddldep.DataSource = dt;
                ddldep.DataTextField = "DeptName";
                ddldep.DataValueField = "DeptCode";
                ddldep.DataBind();

            }

        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error_MeeSeva.aspx");

        }

    }

    public void BindCaste()
    {
        dt = new DataTable();
        try
        {
            dt = objFarmerBAL.getCastBAL();
            if (dt.Rows.Count > 0)
            {
                Bindddl(ddlcaste, dt, "CasteName", "CasteCode", "Select Caste");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error_MeeSeva.aspx");


        }


    }

    public void BindBankdetails()
    {
        dt = new DataTable();
        try
        {
            dt = objFarmerBAL.getBankBAL();
            if (dt.Rows.Count > 0)
            {
                Bindddl(ddlbankname, dt, "BankName", "BankCode", "Select Bank");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error_MeeSeva.aspx");


        }


    }

    public void BindGender()
    {
        dt = new DataTable();
        try
        {
            dt = objFarmerBAL.getGenderBAL();
            if (dt.Rows.Count > 0)
            {
                Bindddl(ddlgender, dt, "GenderName", "GenderCode", "Select Gender");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error_MeeSeva.aspx");

        }


    }

    public void BindState()
    {
        dt = new DataTable();
        //  Bindddl(ddlstatename, dt, "Telangana", "36", "Telangana");
        ddlstatename.Items.Clear();
        ddlstatename.Items.Insert(0, new ListItem("Telangana", "36"));
        ddlstatename.DataBind();

    }
    public void BindDistrict()
    {
        dt = new DataTable();
        objFarmerBE.statecode = ddlstatename.SelectedValue.ToString();
        try
        {
            dt = objFarmerBAL.getdistBE(objFarmerBE);
            if (dt.Rows.Count > 0)
            {
                Bindddl(ddldist, dt, "DistName", "DistCode", "Select District");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error_MeeSeva.aspx");

        }


    }


    public void Bindddl(DropDownList ddl, DataTable dt, string Text, string value, string select)
    {
        ddl.Items.Clear();
        ddl.DataSource = dt;
        ddl.DataTextField = Text;
        ddl.DataValueField = value;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem(select, ""));

    }

    protected void ddldist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldist.SelectedIndex > 0)
        {

            objFarmerBE.dist_code = ddldist.SelectedValue.ToString();
            try
            {
                dt = objFarmerBAL.GetmandalsBAL(objFarmerBE);
                if (dt.Rows.Count > 0)
                {

                    Bindddl(ddlmandal, dt, "MandName", "MandCode", "Select Mandal");

                }
                else
                {

                    objCommon.ShowAlertMessage("No Data Found");
                    ddlmandal.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error_MeeSeva.aspx");


            }
        }
        else
        {

            ddlmandal.Items.Clear();
            ddlvillage.Items.Clear();

        }
    }

    protected void ddlmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmandal.SelectedIndex > 0)
        {

            objFarmerBE.dist_code = ddldist.SelectedValue.ToString();
            objFarmerBE.MandCode = ddlmandal.SelectedValue.ToString();
            try
            {
                dt = objFarmerBAL.GetvillBAL(objFarmerBE);
                if (dt.Rows.Count > 0)
                {

                    Bindddl(ddlvillage, dt, "VillName", "VillCode", "Select Village");

                }
                else
                {

                    objCommon.ShowAlertMessage("No Data Found");
                    ddlvillage.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error_MeeSeva.aspx");

            }
        }
        else
        {

            ddlvillage.Items.Clear();

        }
    }

    protected void a3_TextChanged(object sender, EventArgs e)
    {

        if (a1.Text != "" && a2.Text != "" && a3.Text != "")
        {
            //FilupldAadhar.Enabled = true;
            // lblaadharstar.Visible = true;
            //RequiredFieldValidator1.Enabled = true;
        }

    }

    protected void rbldisable_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbldisable.SelectedIndex == 0)
        {

            // Filuplddisab.Enabled = true;
            // lbldisstar.Visible = true;
            txtpercdisab.Enabled = true;
            // RequiredFieldValidator3.Enabled = true;
        }
        else
        {

            //Filuplddisab.Enabled = false;
            // lbldisstar.Visible = false;
            txtpercdisab.Enabled = false;
            // RequiredFieldValidator3.Enabled = false;
        }
    }

    protected void ddlcaste_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcaste.SelectedIndex > 0)
        {
            if (ddlcaste.SelectedItem.Text != "OC")
            {

                //  Filupldcast.Enabled = true;
                // RequiredFieldValidator2.Enabled = true;
                // lblcastestar.Visible = true;
            }
            else
            {

                // Filupldcast.Enabled = false;
                // lblcastestar.Visible = false;
                // RequiredFieldValidator2.Enabled = false;

            }

        }

    }


    protected void btn_Payment_Click(object sender, EventArgs e)
    {
        try
        {

            if (txtfarmername.Text == "")
            {

                objCommon.ShowAlertMessage("Please Enter  Name");
                return;
            }
            if (txtForHname.Text == "")
            {

                objCommon.ShowAlertMessage("Please Enter Father/Husband  Name");
                return;
            }
            if (ddlgender.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Please Select Gender");
                return;

            }
            if (ddldist.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Please Select District");
                return;

            }
            if (ddlmandal.SelectedIndex == 0)
            {
                objCommon.ShowAlertMessage("Please Select Mandal");
                return;

            }
            if (ddlvillage.SelectedIndex == 0)
            {

                objCommon.ShowAlertMessage("Please Select Village");
                return;
            }
            if (ddlcaste.SelectedIndex == 0)
            {

                objCommon.ShowAlertMessage("Please Select Caste");
                return;
            }
            if (txtaddr.Text == "")
            {
                objCommon.ShowAlertMessage("Please Enter Address");
                return;
            }
            if (rbldisable.SelectedIndex == 0)
            {

                objCommon.ShowAlertMessage("Please Select Disability");
                return;
            }
            if (txtincome.Text == "")
            {

                objCommon.ShowAlertMessage("Please Enter Income");
                return;
            }
            if (a1.Text == "" || a2.Text == "" || a3.Text == "")
            {

                objCommon.ShowAlertMessage("Please Enter Aadhaar Number");
                return;
            }


            if (txtmobile.Text == "")
            {

                objCommon.ShowAlertMessage("Please Enter Mobile Number");
                return;
            }
            else
            {
                if (!objValidate.ISMobileNo(txtmobile.Text, 9, 9))
                {
                    objCommon.ShowAlertMessage("Please Enter Valid Mobile Number");
                    return;
                }
            }

            if (ddldep.SelectedValue == "")
            {

                objCommon.ShowAlertMessage("Please Select Department");
                return;
            }



            if (ddlbankname.SelectedIndex == 0)
            {

                objCommon.ShowAlertMessage("Please Select Bank");
                return;
            }

            if (txtaccount.Text == "")
            {

                objCommon.ShowAlertMessage("Please Enter Account Number");
                return;
            }
            if (txtifsc.Text == "")
            {

                objCommon.ShowAlertMessage("Please Enter IFSC Code");
                return;
            }
            else
            {

                if (!objValidate.IsIfsc(txtifsc.Text))
                {
                    objCommon.ShowAlertMessage("Please Enter Valid IFSC Code");
                    return;
                }



            }


            dt = new DataTable();
            objFarmerBE.FarmerId = ViewState["FarmerId"].ToString();
            objFarmerBE.FatherName = txtForHname.Text.Trim();
            objFarmerBE.farmer_name = txtfarmername.Text.Trim();
            objFarmerBE.gender = Convert.ToInt32(ddlgender.SelectedValue);
            objFarmerBE.statecode = ddlstatename.SelectedValue;
            objFarmerBE.dist_code = ddldist.SelectedValue;
            objFarmerBE.MandCode = ddlmandal.SelectedValue;
            objFarmerBE.vill_code = ddlvillage.SelectedValue;
            objFarmerBE.Caste = Convert.ToInt32(ddlcaste.SelectedValue);
            if (ddlgender.SelectedItem.Text == "Female Widow")
            {

                objFarmerBE.Widow = 1;

            }
            else
            {

                objFarmerBE.Widow = 0;

            }
            if (rbldisable.SelectedIndex == 0)
            {

                objFarmerBE.Disability = 1;
                objFarmerBE.Disability_Percent = Convert.ToInt32(txtpercdisab.Text.Trim());
            }
            else
            {

                objFarmerBE.Disability = 0;

            }

            objFarmerBE.Income = Convert.ToInt32(txtincome.Text.Trim());
            objFarmerBE.AadhaarId = a1.Text.Trim() + a2.Text.Trim() + a3.Text.Trim();
            objFarmerBE.Email_Id = txtemail.Text.Trim();
            objFarmerBE.MobileNo = txtmobile.Text.Trim();
            objFarmerBE.BankCode = ddlbankname.SelectedValue.ToString();
            // objFarmerBE.BranchName = txtbranch.Text.Trim();
            objFarmerBE.AccountNo = txtaccount.Text.Trim();
            objFarmerBE.IFSCCode = txtifsc.Text.Trim();
   
            string myIP = Request.ServerVariables["REMOTE_ADDR"].ToString();
            objFarmerBE.IpAddress = myIP;
            objFarmerBE.Address = txtaddr.Text.Trim();
            objFarmerBE.Web_Mobile = "MS";
            objFarmerBE.SchemeApplied = Convert.ToInt32(ViewState["SchemeApplied"]);
            objFarmerBE.IsEligible = Convert.ToInt32(ViewState["IsEligible"]);
            List<String> depCode_list = new List<string>();

            foreach (System.Web.UI.WebControls.ListItem item in ddldep.Items)
            {
                if (item.Selected)
                {
                    depCode_list.Add(item.Value);

                }

            }
            objFarmerBE.DeptCode = String.Join(",", depCode_list.ToArray());

            bool Transflag = Dopayment();
            if (Transflag == true)
            {
                dt = objFarmerBAL.UpdateFarmerBAL(objFarmerBE);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName == "SUCCESS")
                    {
                        objMSBL.UpdateTransactionResponseBAL(ViewState["AmountCharged"].ToString(), ViewState["TRANSID"].ToString(), ViewState["ERRORCODE"].ToString(), ViewState["Msg"].ToString(), ViewState["Status"].ToString(), ViewState["FarmerId"].ToString(), 0, ViewState["Meeseva_Id"].ToString(), erroepagrname, ipaddres, ConnKey);
                        //Response.Redirect("~/Blank_MeeSeva.aspx", false);
                        string msg = "Registration details updated Successfully. Your Registration Number is : " + ViewState["FarmerId"].ToString();
                        objemailsms.sendSms(txtmobile.Text.Trim(), msg);
                        Session["FRID"] = ViewState["FarmerId"].ToString();
                        Session["AID"] = "1";
                        Session["MNO"] = "1";
                        Session["Type"] = "F";
                        Response.Redirect("~/Report_Former_MeeSeva.aspx", false);

                    }
                    else
                    {

                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());

                    }



                }
            }
            else
            {

                objCommon.ShowAlertMessage("Transaction failured");

            }

        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error_MeeSeva.aspx");

        }
    }

    protected void ddldep_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<String> depCode_list = new List<string>();
            List<String> depName_list = new List<string>();

            foreach (System.Web.UI.WebControls.ListItem item in ddldep.Items)
            {
                if (item.Selected)
                {
                    depCode_list.Add(item.Value);
                }
            }
            // ddl_Drug.Texts.SelectBoxCaption = String.Join(",", DieaseName_list.ToArray());
            ViewState["depCode_list"] = String.Join(",", depCode_list.ToArray());
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {

            MeeSevaWebSrvc.MeeSevaWebService obj = new MeeSevaWebSrvc.MeeSevaWebService();


            /*MEE SEVA PAYMENT DETAILS*/
            string[] arrPaymentDetails = new string[9];

            /*CHACK SUM PARAMETRS*/
            arrPaymentDetails[0] = ViewState["StrUniqueNo"].ToString();
            arrPaymentDetails[1] = ViewState["StrSCAId"].ToString();
            arrPaymentDetails[2] = "CA";
            arrPaymentDetails[3] = ViewState["StrMeesevaUserId"].ToString();
            arrPaymentDetails[4] = ViewState["StrChannelId"].ToString();
            arrPaymentDetails[5] = ViewState["Meeseva_Id"].ToString();
            arrPaymentDetails[6] = ViewState["StrMeesevaRequestId"].ToString();
            arrPaymentDetails[7] = ViewState["StrServiceid"].ToString();
            arrPaymentDetails[8] = ViewState["StrScaPassword"].ToString();




            /*ARRAY FOR PAYMENT AMOUNT CHARGES*/
            string[] arrAmount = new string[5];
            arrAmount[0] = "25";
            arrAmount[1] = "0";
            arrAmount[2] = "0";
            arrAmount[3] = "0";
            arrAmount[4] = "0";



            /*ARRAY FOR TRANSACTION PARAMETERS*/
            string[] arrTransParams = new string[4];
            arrTransParams[0] = "Applicant Name";
            arrTransParams[1] = "DistrictId";
            arrTransParams[2] = "Mobile Number";
            arrTransParams[3] = "Total Amount";



            /*ARRAY FOR TRANSACTION DETAILS*/
            string[] arrTransDetails = new string[4];
            arrTransDetails[0] = txtfarmername.Text;
            arrTransDetails[1] = ddldist.SelectedValue;
            arrTransDetails[2] = txtmobile.Text;
            arrTransDetails[3] = "25";



            string Checksum = objMF.GenerateCheckSum(ViewState["StrSCAId"].ToString(), ViewState["StrScaPassword"].ToString(), ViewState["StrSCAId"].ToString(), ViewState["StrMeesevaUserId"].ToString(), ViewState["StrUniqueNo"].ToString());

            XmlNode MEESEVA = obj.GetPaymentGatewayResponse(arrPaymentDetails, arrAmount, arrTransParams, arrTransDetails, "MEESEVA", "MEESEVA", Checksum);


            string errorcode = MEESEVA.ChildNodes.Item(0).InnerText;
            string message = MEESEVA.ChildNodes.Item(1).InnerText;
            string transcode = MEESEVA.ChildNodes.Item(2).InnerText;


            /*WEB SERVICE 1 RESPONSE*/
            objMSBL.UpdatePaymentResponseBAL(transcode, errorcode, message, (errorcode == "0" ? "Y" : "N"), ViewState["Meeseva_Id"].ToString(), erroepagrname, ipaddres, ConnKey);
            if (errorcode == "0")
            {
                trusrchargeshead.Visible = true;
                trusrcharges.Visible = true;
                btnConfirm.Visible = false;


            }
            else
            {
                objCommon.ShowAlertMessage("Request failed");
                return;

            }

        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error_MeeSeva.aspx");

        }
    }

    public bool Dopayment()
    {
        bool flag = false;
        try
        {

            MeeSevaWebSrvc.MeeSevaWebService obj = new MeeSevaWebSrvc.MeeSevaWebService();


            /*MEE SEVA PAYMENT DETAILS*/

            string[] arrPaymentDetails = new string[12];

            arrPaymentDetails[0] = ViewState["StrUniqueNo"].ToString();
            arrPaymentDetails[1] = ViewState["StrSCAId"].ToString();
            arrPaymentDetails[2] = "CA";
            arrPaymentDetails[3] = ViewState["StrMeesevaUserId"].ToString();
            arrPaymentDetails[4] = ViewState["StrChannelId"].ToString();
            arrPaymentDetails[5] = ViewState["Meeseva_Id"].ToString();
            arrPaymentDetails[6] = ViewState["StrMeesevaRequestId"].ToString();
            arrPaymentDetails[7] = ViewState["StrServiceid"].ToString();
            arrPaymentDetails[8] = ViewState["Meeseva_Id"].ToString();
            arrPaymentDetails[9] = "00";
            arrPaymentDetails[10] = ViewState["StrScaPassword"].ToString();
            arrPaymentDetails[11] = ViewState["StrMeesevaFlag"].ToString();





            /*ARRAY FOR PAYMENT AMOUNT CHARGES*/
            string[] arrAmount = new string[5];
            arrAmount[0] = "25";
            arrAmount[1] = "0";
            arrAmount[2] = "0";
            arrAmount[3] = "0";
            arrAmount[4] = "0";



            /*ARRAY FOR TRANSACTION PARAMETERS*/

            string[] arrTransParams = new string[9];

            arrTransParams[0] = "Applicant Name";
            arrTransParams[1] = "District";
            arrTransParams[2] = "Mandal";
            arrTransParams[3] = "Village";
            arrTransParams[4] = "SLA";
            arrTransParams[5] = "DeliveryType";
            arrTransParams[6] = "TotalAmount";
            arrTransParams[7] = "Status";
            arrTransParams[8] = "SLAEnddate";





            /*ARRAY FOR TRANSACTION DETAILS*/

            string[] arrTransDetails = new string[9];

            arrTransDetails[0] = txtfarmername.Text;
            arrTransDetails[1] = ddldist.SelectedValue.ToString();
            arrTransDetails[2] = ddlmandal.SelectedValue.ToString();
            arrTransDetails[3] = ddlvillage.SelectedValue.ToString();
            arrTransDetails[4] = "0";
            arrTransDetails[5] = "Manual";
            arrTransDetails[6] = "25";
            arrTransDetails[7] = "04";
            arrTransDetails[8] = DateTime.Now.ToString("dd/MM/yyyy");


            string Checksum = objMF.GenerateCheckSum(ViewState["StrSCAId"].ToString(), ViewState["StrScaPassword"].ToString(), ViewState["StrSCAId"].ToString(), ViewState["StrMeesevaUserId"].ToString(), ViewState["StrUniqueNo"].ToString());

            XmlNode MEESEVA = obj.GetPaymentTransId(arrPaymentDetails, arrAmount, arrTransParams, arrTransDetails, "MEESEVA", "MEESEVA", Checksum);

            string APPLICATIONNO = MEESEVA.ChildNodes.Item(0).InnerText;
            string ERRORCODE = MEESEVA.ChildNodes.Item(1).InnerText;
            string TRANSID = MEESEVA.ChildNodes.Item(2).InnerText;

            ViewState["AmountCharged"] = "25";
            ViewState["TRANSID"] = TRANSID;
            ViewState["ERRORCODE"] = ERRORCODE;
            ViewState["Msg"] = (ERRORCODE == "0" ? "Success" : "Failured");
            ViewState["Status"] = (ERRORCODE == "0" ? "Y" : "N");


            if (ERRORCODE == "0")
            {
                flag = true;
            }
            else
            {

                flag = false;
            }

        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error_MeeSeva.aspx");

        }
        return flag;

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {

        if (rblFarmerAck.SelectedIndex == -1)
        {

            objCommon.ShowAlertMessage("Please select  Registration Id/Mobile Number/Aadhaar Id");
            return;
        }

        string FarmerId = "";
        string AadharId = "";
        string MobileNo = "";
        if (rblFarmerAck.SelectedIndex == 0)
        {

            AadharId = txtAadhar.Text.Trim();
            if (AadharId == "")
            {
                objCommon.ShowAlertMessage("Please Enter  Aadhaar Id");
                return;

            }
            FarmerId = "1";
            MobileNo = "1";

        }
        if (rblFarmerAck.SelectedIndex == 1)
        {
            FarmerId = txtFarmerReg.Text.Trim();
            if (FarmerId == "")
            {
                objCommon.ShowAlertMessage("Please Enter  Registration Id");
                return;

            }
            AadharId = "1";
            MobileNo = "1";

        }
        if (rblFarmerAck.SelectedIndex == 2)
        {

            FarmerId = "1";
            AadharId = "1";
            MobileNo = txtMbl.Text.Trim();
            if (MobileNo == "")
            {

                objCommon.ShowAlertMessage("Please Enter Mobile Number");
                return;
            }
            else
            {
                if (!objValidate.ISMobileNo(MobileNo, 9, 9))
                {
                    objCommon.ShowAlertMessage("Please Enter Valid Mobile Number");
                    return;
                }
            }

        }

        GetFarmerdetails(FarmerId, AadharId, MobileNo);



    }

    protected void rblFarmerAck_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (rblFarmerAck.SelectedIndex == 0)
        {
            trAadhar.Visible = true;
            trFarmer.Visible = false;
            trMobile.Visible = false;
            txtAadhar.Text = "";
            txtFarmerReg.Text = "";
            txtMbl.Text = "";

        }
        else if (rblFarmerAck.SelectedIndex == 1)
        {

            trFarmer.Visible = true;
            trAadhar.Visible = false;
            trMobile.Visible = false;
            txtAadhar.Text = "";
            txtFarmerReg.Text = "";
            txtMbl.Text = "";

        }
        else if (rblFarmerAck.SelectedIndex == 2)
        {

            trFarmer.Visible = false;
            trAadhar.Visible = false;
            trMobile.Visible = true;
            txtAadhar.Text = "";
            txtFarmerReg.Text = "";
            txtMbl.Text = "";
        }
        else
        {

            trFarmer.Visible = false;
            trAadhar.Visible = false;
            trMobile.Visible = false;

        }


    }
}