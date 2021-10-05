using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TSVUVHMS_BL;
using TSVUVHMS_BE;
using System.Data;
using System.Web.Security;
using System.Configuration;
using System.Collections;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;

public partial class Pharmacy_IssueofDrug : System.Web.UI.Page
{

    InstutionBAL objIns = new InstutionBAL();
    PharmacyBAL objPhar = new PharmacyBAL();
    CommonFuncs objCommon = new CommonFuncs();
    MasterBAL objMst = new MasterBAL();
    MasterBE objBE = new MasterBE();
    DataTable ddt;
    ListItem li;
    string Flag_IUP, RegNo;

    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
      
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
        if (Session["Role"].ToString() == null || (Session["Role"].ToString() != "3" && Session["Role"].ToString() != "5"))
        {
            Response.Redirect("~/Error.aspx");
        }
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        if (Session["RegNo"].ToString() == null)
            Response.Redirect("~/Error.aspx");

        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                ddt = objPhar.FetchPaitentDtlsBAL(Session["RegNo"].ToString(), ConnKey);
                lblRegistrationNo.Text = ddt.Rows[0]["RegistrationNo"].ToString();
                lblOwnerNm.Text = ddt.Rows[0]["Owner_Name"].ToString();
                lblAnimal.Text = ddt.Rows[0]["AnimalTypeDesc"].ToString();

                lblVisitDt.Text = ddt.Rows[0]["Reg_Dt"].ToString();
                btn_Save.Visible = false;
                GetInsNameBAL();
                
                /*FETCH SCHEMES AND THEN BASED ON THE SCHEME SELECTED , FETCH DRUGS*/
                BindSchemes();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
    private void BindSchemes()
    {
        try
        {
            DataTable dt1 = new DataTable();
            objBE.Action = "S";
            dt1 = objMst.SchemeMst_IUDR_BAL(objBE, ConnKey);
            objCommon.BindDropDownLists(ddlScheme, dt1, "SchemeName", "SchemeCode", "0");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
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
    
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (gvIssueofDrugs.Rows.Count == 0)
            {
                objCommon.ShowAlertMessage("Issue atleast one drug");
                return;
            }

            int DrugsIssuedCnt = 0;
            // int DrugsAmountCnt = 0;
            /*VALIDATE IF FOR ATLEAST ONE DRUG IS ISSUED OR NOT*/
            foreach (GridViewRow gr in gvIssueofDrugs.Rows)
            {

                if ((Convert.ToDecimal(((TextBox)gr.FindControl("txtqty")).Text) != 0) && (Convert.ToDecimal(((Label)gr.FindControl("lblAmount")).Text) != 0))
                    DrugsIssuedCnt++;
                //if (Convert.ToDecimal(((Label)gr.FindControl("lblAmount")).Text) != 0)
                //    DrugsAmountCnt++;
            }
            if (DrugsIssuedCnt == 0)
            {
                objCommon.ShowAlertMessage("Issued Quantity is zero (OR) Calculate Amout is zero, Kindly verify");
                return;
            }
            //if (DrugsAmountCnt == 0)
            //{
            //    objCommon.ShowAlertMessage("Calculate Amout is zero , Kindly verify");
            //    return;
            //}

            /*VALIDATE IF DRUGS ARE ENTERTED OR NOT*/
            if (true)
            {

                DataTable ddt = new DataTable();
                ddt.Columns.Add("DrugCode", typeof(string));
                ddt.Columns.Add("Unit", typeof(string));
                ddt.Columns.Add("BatchNo", typeof(string));
                ddt.Columns.Add("ReceiptNo", typeof(Int64));
                ddt.Columns.Add("QuantityIssued", typeof(decimal));
                ddt.Columns.Add("Amount", typeof(decimal));
                int i = 0;

                foreach (GridViewRow gr in gvIssueofDrugs.Rows)
                {
                    if ((Convert.ToDecimal(((TextBox)gr.FindControl("txtqty")).Text) != 0) && (Convert.ToDecimal(((Label)gr.FindControl("lblAmount")).Text) != 0))
                    {
                        ddt.Rows.Add();

                        ddt.Rows[i]["DrugCode"] = ((Label)gr.FindControl("lblDrugCode")).Text;
                        ddt.Rows[i]["Unit"] = "";
                        ddt.Rows[i]["BatchNo"] = ((Label)gr.FindControl("lblbtno")).Text;
                        ddt.Rows[i]["ReceiptNo"] = ((Label)gr.FindControl("lblReceiptNo")).Text;
                        ddt.Rows[i]["Amount"] = Convert.ToDecimal(((Label)gr.FindControl("lblAmount")).Text);
                        ddt.Rows[i]["QuantityIssued"] = Convert.ToDecimal(((TextBox)gr.FindControl("txtqty")).Text);
                        /*VALIDATIONS*/
                        //TextBox txtqty = (TextBox)sender;

                        if (!CheckQuantityIssued(ddt.Rows[i]["QuantityIssued"].ToString(), ((Label)gr.FindControl("lblAQty")).Text, ((Label)gr.FindControl("lblMaxQtyTobeissued")).Text))
                        {
                            ((TextBox)gr.FindControl("txtqty")).Focus();
                            return;
                        }
                        i++;
                    }
                    else
                    {
                        objCommon.ShowAlertMessage("Issued Quantity is zero (OR) Calculate Amout is zero, Kindly verify");
                        return;
                    }
                }

                string query = "select Doctors_Observation from Dtls_PatientVisits where RegNo=@RegNo";
                string query1 = "select DiseaseList from Dtls_PatientVisits where RegNo=@RegNo";

                string obser="";
                string dise="";

                using (SqlConnection con = new SqlConnection(ConnKey))
                {
                    using (SqlConnection con1 = new SqlConnection(ConnKey))
                    {
                        con.Open();
                        con1.Open();
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            using (SqlCommand cmd1 = new SqlCommand(query1))
                            {
                                cmd.Parameters.AddWithValue("@RegNo", Session["RegNo"].ToString());
                                cmd.Connection = con;
                                cmd1.Parameters.AddWithValue("@RegNo", Session["RegNo"].ToString());
                                cmd1.Connection = con1;

                                SqlDataReader reader = cmd.ExecuteReader();
                                SqlDataReader reader1 = cmd1.ExecuteReader();

                                while (reader.Read())
                                {
                                    obser = reader[0].ToString();
                                }
                                while (reader1.Read())
                                {
                                    dise = reader1[0].ToString();
                                    objPhar.InsertIssueDrug_bySchemeBAL(ddt, Session["UniqueInstId"].ToString(), obser, dise, lblRegistrationNo.Text, "I", Session["VisitId"].ToString(), ddlScheme.SelectedValue.ToString(), ConnKey);    
                                }
                                
                                // Call Close when done reading.
                                reader.Close();
                                con.Close();

                                reader1.Close();
                                con1.Close();
                            }
                        }  
                    }
                }

                Session["RegNo"] = lblRegistrationNo.Text;
                string date = lblDate.Text;
                date = DateTime.Now.ToString("yyyy/MM/dd");
                Session["Date"] = date;
                Response.Redirect("~/Pharmacy/PrintMedialP.aspx", false);

            }
        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }


    }


    protected void ddl_Drug_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbldrug.Text = "";

    }
    protected bool ValidateDrug()
    {

        if (ddl_Drug.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Drug");
            ddl_Drug.Focus();
            return false;
        }
        return true;

    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateDrug())
            {
                /*CHECK IF DRUG IS ALREADY ADDED TO THE LIST OR NOT*/
                foreach (GridViewRow gr in gvIssueofDrugs.Rows)
                {
                    if (ddl_Drug.SelectedItem.Text.ToString() == ((Label)gr.FindControl("lbldrug")).Text)
                    {
                        objCommon.ShowAlertMessage("Drug already added");
                        return;
                    }
                }

                btn_Save.Visible = true;

                /*FETCH SELEECTED DRUG DETAILS*/
                ddt = objPhar.getdrugdetails_bySchemeBAL(Session["UniqueInstId"].ToString(), ddl_Drug.SelectedValue.ToString(),ddlScheme.SelectedValue.ToString(), ConnKey);

                /*BIND PREVIOUS SELECTED DRUGS*/
                DataTable dt = new DataTable();
                dt.Columns.Add("ReceiptNo", typeof(Int64));
                dt.Columns.Add("DrugCode", typeof(string));
                dt.Columns.Add("DrugName", typeof(string));
                dt.Columns.Add("BatchNo", typeof(string));
                dt.Columns.Add("expirydate", typeof(string));
                dt.Columns.Add("Unit", typeof(string));
                dt.Columns.Add("ValueofDrug", typeof(decimal));
                dt.Columns.Add("AvailableQty", typeof(decimal));
                dt.Columns.Add("QuantityIssued", typeof(decimal));
                dt.Columns.Add("Amount", typeof(decimal));
                dt.Columns.Add("MaxQtyToBeIssued", typeof(decimal));

                int i = 0;

                foreach (GridViewRow gr in gvIssueofDrugs.Rows)
                {
                    dt.Rows.Add();
                    dt.Rows[i]["ReceiptNo"] = ((Label)gr.FindControl("lblReceiptNo")).Text;
                    dt.Rows[i]["DrugCode"] = ((Label)gr.FindControl("lblDrugCode")).Text;
                    dt.Rows[i]["DrugName"] = ((Label)gr.FindControl("lbldrug")).Text;
                    dt.Rows[i]["BatchNo"] = ((Label)gr.FindControl("lblbtno")).Text;
                    dt.Rows[i]["expirydate"] = ((Label)gr.FindControl("lblExpiryDt")).Text;
                    dt.Rows[i]["Unit"] = ((Label)gr.FindControl("lblUnit")).Text;
                    dt.Rows[i]["ValueofDrug"] = Convert.ToDecimal(((Label)gr.FindControl("lblVdrug")).Text);
                    dt.Rows[i]["AvailableQty"] = Convert.ToDecimal(((Label)gr.FindControl("lblAQty")).Text);
                    dt.Rows[i]["MaxQtyToBeIssued"] = Convert.ToDecimal(((Label)gr.FindControl("lblMaxQtyTobeissued")).Text);
                    string QtyIssued = ((TextBox)gr.FindControl("txtqty")).Text;
                    string Amount = ((Label)gr.FindControl("lblAmount")).Text;
                    if (QtyIssued != "")
                    {
                        dt.Rows[i]["QuantityIssued"] = Convert.ToDecimal(QtyIssued);

                    }
                    else
                        dt.Rows[i]["QuantityIssued"] = 0;
                    if (Amount != "")
                        dt.Rows[i]["Amount"] = Convert.ToDecimal(Amount);
                    else
                        dt.Rows[i]["Amount"] = 0.0;

                    i++;
                }



                dt.Merge(ddt);
                if (dt.Rows.Count > 0)
                {

                    gvIssueofDrugs.Visible = true;
                    gvIssueofDrugs.DataSource = dt;
                    gvIssueofDrugs.DataBind();
                    lbldrug.Visible = false;
                    if (dt.Rows.Count > 0)
                    {
                        gvIssueofDrugs.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                        //Attribute to hide column in Phone.
                        gvIssueofDrugs.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                        gvIssueofDrugs.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                        gvIssueofDrugs.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                        gvIssueofDrugs.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                        gvIssueofDrugs.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                        gvIssueofDrugs.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
                        gvIssueofDrugs.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
                      gvIssueofDrugs.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";
                      gvIssueofDrugs.HeaderRow.Cells[9].Attributes["data-hide"] = "phone";
                        //gvIssueofDrugs.HeaderRow.Cells[10].Attributes["data-hide"] = "phone";
                        //gvIssueofDrugs.HeaderRow.Cells[11].Attributes["data-hide"] = "phone";
                        //Adds THEAD and TBODY to GridView.
                        gvIssueofDrugs.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }

                }
                else
                {
                    gvIssueofDrugs.DataSource = new object[] { null };
                    //gvIssueofDrugs.DataBind();

                    lbldrug.Visible = true;
                    lbldrug.Text = "Drug Not Available";

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
                TextBox txtqty = (e.Row.FindControl("txtqty") as TextBox);
                Label QtyIssued = (e.Row.FindControl("lblQtyIssued") as Label);
                Label lblAmount = (e.Row.FindControl("lblAmount") as Label);
                Label lblMaxQtyIssued = (e.Row.FindControl("lblMaxQtyTobeissued") as Label);
                if (QtyIssued.Text == "")
                {
                    txtqty.Text = "0";
                    lblAmount.Text = "0.0";
                    // lblMaxQtyIssued.Text = "0.0";

                }

                Label lblAQty = (e.Row.FindControl("lblAQty") as Label);
                //if (QtyIssued.Text != "0")
                //{
                //    txtqty.Text = QtyIssued.Text;
                //}
                //if (lblAQty.Text == "0")
                //{

                //    e.Row.Visible = false;

                //}

            }
        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected bool CheckQuantityIssued(string QtyIssued, string AvailableQty, string MaxQtyToBeIssued)
    {
        if (QtyIssued != "")
        {
            decimal txtqty1 = Convert.ToDecimal(QtyIssued);

            if (txtqty1 > Convert.ToDecimal(AvailableQty))
            {
                objCommon.ShowAlertMessage("insufficient stock. Try issuing less quantity");
                return false;
            }
            if (Convert.ToDecimal(MaxQtyToBeIssued) != 0)
            {
                if (txtqty1 > Convert.ToDecimal(MaxQtyToBeIssued))
                {
                    objCommon.ShowAlertMessage("Issuing quantity for this drug should be less than " + Convert.ToDecimal(MaxQtyToBeIssued));
                    return false;
                }

            }
        }
        else
        {
            objCommon.ShowAlertMessage("Enter quantity");
            return false;
            //txtqty.Text = "0";
            //GridViewRow gvRow = (GridViewRow)txtqty.Parent.Parent;
            //Label Amount = (Label)gvRow.FindControl("lblAmount");
            //Amount.Text = "0.00";

        }
        return true;

    }
    protected void txtqty_OnTextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox txtqty = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txtqty.Parent.Parent;
            if (!CheckQuantityIssued(txtqty.Text, ((Label)gvRow.FindControl("lblAQty")).Text, ((Label)gvRow.FindControl("lblMaxQtyTobeissued")).Text))
            {
                txtqty.Focus();
            }

        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }



    protected void gvIssueofDrugs_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DrugCode", typeof(string));
            dt.Columns.Add("DrugName", typeof(string));
            dt.Columns.Add("BatchNo", typeof(string));
            dt.Columns.Add("ReceiptNo", typeof(Int64));
            dt.Columns.Add("expirydate", typeof(string));
            dt.Columns.Add("Unit", typeof(string));
            dt.Columns.Add("ValueofDrug", typeof(decimal));
            dt.Columns.Add("AvailableQty", typeof(decimal));
            dt.Columns.Add("QuantityIssued", typeof(decimal));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("MaxQtyToBeIssued", typeof(decimal));
            int i = 0;
            foreach (GridViewRow gr in gvIssueofDrugs.Rows)
            {
                dt.Rows.Add();
                dt.Rows[i]["DrugCode"] = ((Label)gr.FindControl("lblDrugCode")).Text;
                dt.Rows[i]["DrugName"] = ((Label)gr.FindControl("lbldrug")).Text;
                dt.Rows[i]["BatchNo"] = ((Label)gr.FindControl("lblbtno")).Text;
                dt.Rows[i]["ReceiptNo"] = ((Label)gr.FindControl("lblReceiptNo")).Text;
                dt.Rows[i]["expirydate"] = ((Label)gr.FindControl("lblExpiryDt")).Text;
                dt.Rows[i]["Unit"] = ((Label)gr.FindControl("lblUnit")).Text;
                dt.Rows[i]["ValueofDrug"] = Convert.ToDecimal(((Label)gr.FindControl("lblVdrug")).Text);
                dt.Rows[i]["AvailableQty"] = Convert.ToDecimal(((Label)gr.FindControl("lblAQty")).Text);
                dt.Rows[i]["QuantityIssued"] = Convert.ToDecimal(((TextBox)gr.FindControl("txtqty")).Text);
                dt.Rows[i]["Amount"] = Convert.ToDecimal(((Label)gr.FindControl("lblAmount")).Text);
                dt.Rows[i]["MaxQtyToBeIssued"] = ((Label)gr.FindControl("lblMaxQtyTobeissued")).Text;
                // dt.Rows[i]["Amount"] = ((Label)gr.FindControl("lblAmount")).Text;
                i++;
            }
            dt.Rows.RemoveAt(e.RowIndex);
            //if (dt.Rows.Count == 0)
            //{
            //    dt.Rows.Add();
            //}
            //  gvIssueofDrugs.Columns.Clear();
            gvIssueofDrugs.DataSource = null;
            gvIssueofDrugs.DataSource = dt;
            gvIssueofDrugs.DataBind();
        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }

    protected void gvIssueofDrugs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Add")
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                DataTable dt = new DataTable();
                dt.Columns.Add("DrugCode", typeof(string));
                dt.Columns.Add("DrugName", typeof(string));
                dt.Columns.Add("BatchNo", typeof(string));
                dt.Columns.Add("ReceiptNo", typeof(Int64));
                dt.Columns.Add("expirydate", typeof(string));
                dt.Columns.Add("Unit", typeof(string));
                dt.Columns.Add("ValueofDrug", typeof(decimal));
                dt.Columns.Add("AvailableQty", typeof(decimal));
                dt.Columns.Add("QuantityIssued", typeof(decimal));
                dt.Columns.Add("Amount", typeof(decimal));
                dt.Columns.Add("MaxQtyToBeIssued", typeof(decimal));
                int i = 0;
                foreach (GridViewRow gr in gvIssueofDrugs.Rows)
                {
                    dt.Rows.Add();
                    dt.Rows[i]["DrugCode"] = ((Label)gr.FindControl("lblDrugCode")).Text;
                    dt.Rows[i]["DrugName"] = ((Label)gr.FindControl("lbldrug")).Text;
                    dt.Rows[i]["BatchNo"] = ((Label)gr.FindControl("lblbtno")).Text;
                    dt.Rows[i]["ReceiptNo"] = ((Label)gr.FindControl("lblReceiptNo")).Text;
                    dt.Rows[i]["expirydate"] = ((Label)gr.FindControl("lblExpiryDt")).Text;
                    dt.Rows[i]["Unit"] = ((Label)gr.FindControl("lblUnit")).Text;
                    dt.Rows[i]["ValueofDrug"] = Convert.ToDecimal(((Label)gr.FindControl("lblVdrug")).Text);
                    dt.Rows[i]["AvailableQty"] = Convert.ToDecimal(((Label)gr.FindControl("lblAQty")).Text);
                    dt.Rows[i]["QuantityIssued"] = Convert.ToDecimal(((TextBox)gr.FindControl("txtqty")).Text);
                    dt.Rows[i]["MaxQtyToBeIssued"] = ((Label)gr.FindControl("lblMaxQtyTobeissued")).Text == "" ? 0 : Convert.ToDecimal(((Label)gr.FindControl("lblMaxQtyTobeissued")).Text);

                    if (Convert.ToDecimal(dt.Rows[i]["QuantityIssued"]) <= Convert.ToDecimal(dt.Rows[i]["AvailableQty"]))
                    {
                        dt.Rows[i]["Amount"] = (Convert.ToDecimal(dt.Rows[i]["ValueofDrug"]) * Convert.ToDecimal(dt.Rows[i]["QuantityIssued"]));
                        //  = Convert.ToDecimal(((Label)gr.FindControl("lblAmount")).Text);

                    }
                    else
                    {
                        dt.Rows[i]["Amount"] = "0.00";

                        objCommon.ShowAlertMessage("insufficient stock. Try issuing less quantity");
                        ((TextBox)gr.FindControl("txtqty")).Focus();
                        return;

                    }
                    // dt.Rows[i]["Amount"] = ((Label)gr.FindControl("lblAmount")).Text;
                    i++;
                }

                //if (dt.Rows.Count == 0)
                //{
                //    dt.Rows.Add();
                //}
                gvIssueofDrugs.DataSource = dt;
                gvIssueofDrugs.DataBind();

            }
        }


        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }


    }




    protected void ddl_Scheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlScheme.SelectedValue.ToString() != "0")
        {
            ddt = objPhar.getdrugbySchemeBAL(ddlScheme.SelectedValue.ToString(), Session["UniqueInstId"].ToString(), ConnKey);
            objCommon.BindDropDownLists(ddl_Drug, ddt, "DrugName", "DrugCode", "0");
        }

    }
}
