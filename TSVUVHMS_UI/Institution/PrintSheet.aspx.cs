using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VHMS_BL;
using System.Data;
using System.Web.Security;


public partial class Institution_Sheet : System.Web.UI.Page
{
    InstutionBAL ObjIns = new InstutionBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    ListItem li;
    string ConnKey;
    protected void Page_Load(object sender, EventArgs e)
    {
        ConnKey = Session["ConnStr"].ToString();
        if (!IsPostBack)
        {
            GetInsNameBAL();
            //  string RegNo = Request.QueryString["RegNo"];
            String RegNo = "2016081502";
            string gender;

            ddt = ObjIns.FetchPaitentDtlsBAL(RegNo, ConnKey);
            lblRegNo.Text = ddt.Rows[0]["RegistrationNo"].ToString();
            gender = ddt.Rows[0]["Gender"].ToString();
            lblAge.Text = ddt.Rows[0]["Age"].ToString();
            lblOwner.Text = ddt.Rows[0]["Owner_Name"].ToString();
            lblAddress.Text = ddt.Rows[0]["Owner_Address"].ToString();
            lblDist.Text = ddt.Rows[0]["DistName"].ToString();
            lblMandal.Text = ddt.Rows[0]["MandName"].ToString();
            lblAnimal.Text = ddt.Rows[0]["AnimalTypeDesc"].ToString();

            //lblFee.Text = ddt.Rows[0]["Reg_Fee"].ToString();
            lblMbno.Text = ddt.Rows[0]["Owner_MobileNo"].ToString();
            if (gender == "0")
            {
                lblGender.Text = "Male";
            }
            else
            {
                lblGender.Text = "Female";
            }
        }
    }
    public void GetInsNameBAL()
    {
        string StateCode = Session["StateCd"].ToString();
        string UserName = Session["UsrName"].ToString();
        string UniqueInstId = Session["UniqueInstId"].ToString();
        DataTable dt = new DataTable();
        dt = ObjIns.GetInsNameBAL(UniqueInstId, UserName, ConnKey);
        lblInsName.Text = dt.Rows[0]["InstitutionName"].ToString();
    }
}