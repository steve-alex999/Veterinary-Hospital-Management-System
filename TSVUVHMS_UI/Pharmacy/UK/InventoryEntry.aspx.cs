using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using VHMS_BE;
using System.Data;
using System.Web.Security;
using System.Globalization;


public partial class EVHMS_UI_Admin_Default : System.Web.UI.Page
{
   
    PharmacyBAL objPhar = new PharmacyBAL();
    InstutionBAL objIns = new InstutionBAL();
    MasterBAL objMst = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();
    MasterBE objBE = new MasterBE();
    Pharmacy objPhBE = new Pharmacy();
    DataTable ddt;
    ListItem li;
    string INSERT, UPDATE, GData, Flag_IUP;
    string StateCode, UserName;
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
        StateCode = Session["StateCd"].ToString();
        UserName = Session["UsrName"].ToString();
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            try
            {
                imgstate.ImageUrl = "~/img/" + Session["statecd"].ToString().Trim() + ".png";
                lblstatename.Text = "GOVERNMENT OF " + Session["statename"].ToString();
                ddt = objPhar.getdrug(ConnKey);
                objCommon.BindDropDownLists(ddl_Drug, ddt, "DrugName", "DrugCode", "0");

                ddt = objPhar.getsuply( ConnKey);
                objCommon.BindDropDownLists(ddl_Suply, ddt, "SupplierName", "SupplierCode", "0");

                objBE.Action="S";
                ddt = objMst.SchemeMst_IUDR_BAL(objBE,ConnKey);
                objCommon.BindDropDownLists(ddlScheme, ddt, "SchemeName", "SchemeCode", "0");


                btn_Update.Visible = false;
                Viewdata();

                GetInsNameBAL();
                GetYear();

                for (int month = 1; month <= 12; month++)
                {

                    string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
                    ddl_Month.Items.Add(new ListItem(monthName, month.ToString().PadLeft(2, '0')));
                }
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
            // Calendar1.StartDate = DateTime.Now;   //to dissable past Date

        }

        //ExCalender.StartDate = DateTime.Now; 
    }
    public void GetYear()
   {
       int curYear = DateTime.Now.Year;

            for (int i = 1; i <= 5; ++i)
            {

                ListItem tmp = new ListItem();
                tmp.Value = curYear.ToString();

                tmp.Text = curYear.ToString();

                ddl_Year.Items.Add(tmp);

                curYear = DateTime.Now.AddYears(i).Year;
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
    protected void GvInventory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvInventory.PageIndex = e.NewPageIndex;
            Viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GvInventory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {
                DataTable dt = new DataTable();

                Flag_IUP = "D";
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblReceiptNo = (Label)gvrow.FindControl("lblReceiptNo");

                dt = objPhar.ConfirmInvetoryBAL(lblReceiptNo.Text, Flag_IUP, ConnKey);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    // txtExdate.Text = "";
                    txtReceiptDate.Text = "";
                    txtValue.Text = "";
                    txtBatchNo.Text = "";
                    //  lblUnit.Text = "";
                    txtDquantity.Text = "";
                    txtqtyeachpack.Text = "";
                    txtnoofpackages.Text = "";
                }
                Viewdata();

            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected bool Validate()
    {

        if (ddl_Suply.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Supplier");
            ddl_Suply.Focus();
            return false;
        }

        if (ddl_Drug.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Drug Name");
            ddl_Drug.Focus();
            return false;
        }

        if (txtBatchNo.Text == "")
        {
            objCommon.ShowAlertMessage("Enter BatchNo");
            txtBatchNo.Focus();
            return false;
        }
        if (rbnDosagesperpack.SelectedValue == "")
        {
            objCommon.ShowAlertMessage("Select Dosages Per Pack");
            txtqtyeachpack.Focus();
            return false;
        }

        if (txtqtyeachpack.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Quantity in each pack");
            txtqtyeachpack.Focus();
            return false;
        }
        /*SHOIULD ALLOW TILL 1 LAKH QUANTITY */
        if (Convert.ToDouble( txtqtyeachpack.Text.Trim()) > 100000.00)
        {
            objCommon.ShowAlertMessage("Quantity in each pack can't be greater than 1 lakh");
            txtqtyeachpack.Focus();
            return false;
        }
        if (txtnoofpackages.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Quantity(No.of packages)");
            txtnoofpackages.Focus();
            return false;
        }
        if (txtReceiptDate.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Receipt Date");
            txtReceiptDate.Focus();
            return false;
        }
        else
        {
            if (!objValidate.IsDate(txtReceiptDate.Text.Trim()))
            {
                objCommon.ShowAlertMessage("Enter Valid Receipt Date");
                txtReceiptDate.Focus();
                return false;
            }
        }
        if (txtDquantity.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Drug Quantity");
            txtDquantity.Focus();
            return false;
        }

        if (txtValue.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Value of Drugs Received (Rs.)");
            txtValue.Focus();
            return false;
        }
        if (ddlScheme.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Scheme Name");
            ddlScheme.Focus();
            return false;
        }
        return true;
    }

    protected void GvInventory_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GvInventory.EditIndex = e.NewEditIndex;
        Viewdata();
    }

    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (Validate())
        {
            DataTable dt = new DataTable();
            try
            {
                DateTime DateofReceipt =  DateTime.Parse(txtReceiptDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
                string ExpiryDt = ddl_Month.SelectedValue.ToString() + "/" + ddl_Year.SelectedValue.ToString();
               // DateTime.Now.ToString("yyyyMM");
               // DateTime ExpiryDt = DateTime.Parse(ExpiryD1, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).);
               // DateTime myDate = DateTime.ParseExact(ExpiryDt, "yyyy-MM", System.Globalization.CultureInfo.InvariantCulture);
                objPhBE.InsId = Session["UniqueInstId"].ToString();
                objPhBE.Supplier = ddl_Suply.SelectedValue.ToString();
                objPhBE.DrugCd =  ddl_Drug.SelectedValue.ToString();
                objPhBE.DosagesPerPack = rbnDosagesperpack.SelectedValue.ToString();
                objPhBE.Qtyineachpack = txtqtyeachpack.Text.Trim() ;
                objPhBE.BatchNo = txtBatchNo.Text.Trim();
                objPhBE.ExpDt = ExpiryDt;
                objPhBE.Noofpackages = txtnoofpackages.Text.Trim();
                objPhBE.DtReceipt = DateofReceipt;
                objPhBE.Valueofdrug = txtValue.Text.Trim();
                objPhBE.Drugqty = txtDquantity.Text.Trim();
                objPhBE.SchemeCd = ddlScheme.SelectedValue.ToString();
                objPhBE.UserName = UserName;
                objPhBE.Action = "I";

                dt = objPhar.InsertInvetoryBAL(objPhBE, ConnKey);
                if (dt.Rows.Count > 0)
                {


                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                   // txtExdate.Text = "";
                    txtReceiptDate.Text = "";
                    txtValue.Text = "";
                    txtBatchNo.Text = "";
                    //  lblUnit.Text = "";
                    txtDquantity.Text = "";
                    txtqtyeachpack.Text = "";
                    txtnoofpackages.Text = "";
                    

                 
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

    }

    public void Viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            GData = "R";

            dt1 = objPhar.viewInventoryBAL(Session["UniqueInstId"].ToString(), GData, ConnKey);

            GvInventory.DataSource = dt1;
            GvInventory.DataBind();
            if (dt1.Rows.Count > 0)
            {
                GvInventory.HeaderRow.Cells[0].Attributes["data-class"] = "expand";

                //Attribute to hide column in Phone.
                GvInventory.HeaderRow.Cells[1].Attributes["data-hide"] = "phone";
                GvInventory.HeaderRow.Cells[2].Attributes["data-hide"] = "phone";
                GvInventory.HeaderRow.Cells[3].Attributes["data-hide"] = "phone";
                GvInventory.HeaderRow.Cells[4].Attributes["data-hide"] = "phone";
                GvInventory.HeaderRow.Cells[5].Attributes["data-hide"] = "phone";
                GvInventory.HeaderRow.Cells[6].Attributes["data-hide"] = "phone";
                GvInventory.HeaderRow.Cells[7].Attributes["data-hide"] = "phone";
                GvInventory.HeaderRow.Cells[8].Attributes["data-hide"] = "phone";
                GvInventory.HeaderRow.Cells[9].Attributes["data-hide"] = "phone";
                GvInventory.HeaderRow.Cells[10].Attributes["data-hide"] = "phone";
                GvInventory.HeaderRow.Cells[11].Attributes["data-hide"] = "phone";
                //Adds THEAD and TBODY to GridView.
                GvInventory.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;

            ddl_Suply.SelectedValue = ((Label)(gRow.FindControl("lblSuplCd"))).Text;
            ddl_Drug.SelectedValue = ((Label)(gRow.FindControl("lblDrugCd"))).Text;
            ddlScheme.SelectedValue = ((Label)(gRow.FindControl("lblSchemeCode"))).Text;
            txtBatchNo.Text = ((Label)(gRow.FindControl("lblBtno"))).Text;
            string Exdate = ((Label)(gRow.FindControl("lblActExpDt"))).Text;
            string[] a = Exdate.Split('/');
            string month = a[1];
            string year = a[2];
            ddl_Month.SelectedValue = a[1];
            ddl_Year.SelectedValue = a[2];

            lblUntsMesmt.Text = ((Label)(gRow.FindControl("lblUnit"))).Text;
            //ddl_Units.SelectedValue = ((Label)(gRow.FindControl("lblunit"))).Text;
            DateTime date = Convert.ToDateTime(Exdate);
            string Dosageperpack = ((Label)(gRow.FindControl("lblDosageperpack"))).Text;

            if (Dosageperpack == "Multiple")
                rbnDosagesperpack.SelectedValue = "1";
            else
                rbnDosagesperpack.SelectedValue = "0";
            //   txtExdate.Text = date.ToString("dd/MM/yyyy");
            txtDquantity.Text = ((Label)(gRow.FindControl("lblQty"))).Text;
            txtqtyeachpack.Text = ((Label)(gRow.FindControl("lblQtyeachpack"))).Text;
            txtnoofpackages.Text = ((Label)(gRow.FindControl("lblqtynoofpackages"))).Text;
            string Recdate = ((Label)(gRow.FindControl("lblRcdate"))).Text;
            DateTime date1 = Convert.ToDateTime(Recdate);
            txtReceiptDate.Text = date1.ToString("dd/MM/yyyy");
            lblReceiptNo1.Text = ((Label)(gRow.FindControl("lblReceiptNo"))).Text;
            string ValueofDrug = ((Label)(gRow.FindControl("lblVdrug"))).Text;
            txtValue.Text = ValueofDrug;


            btn_Save.Visible = false;
            btn_Update.Visible = true;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
       
        try
        {
            string ReciptNo;
            
            ReciptNo = lblReceiptNo1.Text;


            DateTime DateofReceipt = DateTime.Parse(txtReceiptDate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            string ExpiryDt = ddl_Month.SelectedValue.ToString() + "/" + ddl_Year.SelectedValue.ToString();
            //DateTime ExpiryDt = DateTime.Parse(txtExdate.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;

            DataTable dt = new DataTable();
            objPhBE.Supplier = ddl_Suply.SelectedValue.ToString();
            objPhBE.DrugCd = ddl_Drug.SelectedValue.ToString();
            objPhBE.DosagesPerPack = rbnDosagesperpack.SelectedValue.ToString();
            objPhBE.Qtyineachpack = txtqtyeachpack.Text.Trim();
            objPhBE.BatchNo = txtBatchNo.Text.Trim();
            objPhBE.ExpDt = ExpiryDt;
            objPhBE.Noofpackages = txtnoofpackages.Text.Trim();
            objPhBE.DtReceipt = DateofReceipt;
            objPhBE.Valueofdrug = txtValue.Text.Trim();
            objPhBE.Drugqty = txtDquantity.Text.Trim();
            objPhBE.ReceiptNo = ReciptNo;
            objPhBE.SchemeCd = ddlScheme.SelectedValue.ToString();
            objPhBE.UserName = UserName;
            objPhBE.Action = "U";
            dt = objPhar.UpdateInsventoryBAL(objPhBE, ConnKey);
            
            if (dt.Rows.Count > 0)
            {

                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                txtBatchNo.Text = "";
                txtDquantity.Text = "";
               // txtExdate.Text = "";
                txtReceiptDate.Text = "";
                txtValue.Text = "";
                lblUntsMesmt.Text = "";
                txtqtyeachpack.Text = "";
                txtnoofpackages.Text = "";
                Viewdata();


            }

            btn_Save.Visible = true;
            btn_Update.Visible = false;
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
    protected void ddl_Drug_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Drug.SelectedIndex <= 0)
            {
                objCommon.ShowAlertMessage("Select Drug");
                ddl_Drug.Focus();
                return;
            }
            ddt = objPhar.getUnitmsr(ddl_Drug.SelectedValue.ToString(), ConnKey);
            lblUntsMesmt.Text = ddt.Rows[0]["Unit"].ToString();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void rbnDosagesperpack_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbnDosagesperpack.SelectedValue == "0")
            {
                txtqtyeachpack.Text = "1";
                txtqtyeachpack.Enabled = false;
                txtDquantity.Text = "";
                txtnoofpackages.Text = "";
            }
            if (rbnDosagesperpack.SelectedValue == "1")
            {
                txtqtyeachpack.Text = "";
                txtqtyeachpack.Enabled = true;
                txtDquantity.Text = "";
                txtnoofpackages.Text = "";
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void txtnoofpackages_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtnoofpackages.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Enter No of Packages");
                txtnoofpackages.Focus();
                return;
            }
            if (txtqtyeachpack.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Enter Quantity in each pack first");
                txtqtyeachpack.Focus();
                return;
            }
            else
            {
                decimal eachpackages = Convert.ToDecimal(txtnoofpackages.Text);
                decimal qtyeachpack = Convert.ToDecimal(txtqtyeachpack.Text);
                decimal Quantity = qtyeachpack * eachpackages;
                txtDquantity.Text = Quantity.ToString();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void txtqtyeachpack_OnTextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtnoofpackages.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Enter No of Packages");
                txtnoofpackages.Focus();
                return;
            }
            if (txtqtyeachpack.Text.Trim() == "")
            {
                objCommon.ShowAlertMessage("Enter Quantity in each pack first");
                txtqtyeachpack.Focus();
                return;
            }
            if (txtnoofpackages.Text.Trim() != "")
            {
                decimal eachpackages = Convert.ToDecimal(txtnoofpackages.Text);
                decimal qtyeachpack = Convert.ToDecimal(txtqtyeachpack.Text);
                decimal Quantity = qtyeachpack * eachpackages;
                txtDquantity.Text = Quantity.ToString();
            }
            else
                txtDquantity.Text = "";
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        txtBatchNo.Text = "";
        txtDquantity.Text = "";
        // txtExdate.Text = "";
        txtReceiptDate.Text = "";
        txtValue.Text = "";
        lblUntsMesmt.Text = "";
        txtqtyeachpack.Text = "";
        txtnoofpackages.Text = "";
        Viewdata();
        btn_Save.Visible = true;
        btn_Update.Visible = false;
        ddt = objPhar.getdrug(ConnKey);
        objCommon.BindDropDownLists(ddl_Drug, ddt, "DrugName", "DrugCode", "0");

        ddt = objPhar.getsuply(ConnKey);
        objCommon.BindDropDownLists(ddl_Suply, ddt, "SupplierName", "SupplierCode", "0");

        objBE.Action = "S";
        ddt = objMst.SchemeMst_IUDR_BAL(objBE, ConnKey);
        objCommon.BindDropDownLists(ddlScheme, ddt, "SchemeName", "SchemeCode", "0");
    }
}
