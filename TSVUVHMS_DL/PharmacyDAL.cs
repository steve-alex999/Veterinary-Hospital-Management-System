using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TSVUVHMS_BE;
using System.Data.SqlClient;
using System.Configuration;

namespace TSVUVHMS_DL
{
    public class PharmacyDAL
    {
        /* Drugs */
        public DataTable getdrugDAL( string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DrugMaster", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.VarChar).Value = "S";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Suppliers */
        public DataTable getsuplyDAL( string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "S";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Confirm Drug Details*/
        public DataTable ConfirmInvetoryBAL(string ReciptNo, string Flag_IUP, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ReceiptofDrugs_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ReceiptNo", SqlDbType.VarChar).Value = ReciptNo;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Flag_IUP;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }
        /*Insert Inventory Details*/
        public DataTable InsertInvetoryDAL(Pharmacy objPhBe, string ConnKey)
        {
            SqlCommand cmd;
            SqlDataAdapter da;
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                if (objPhBe.SchemeCd != null)
                {
                    cmd = new SqlCommand("ReceiptofDrugs_Scheme_IUDR", con);                    
                }
                else
                {
                    cmd = new SqlCommand("ReceiptofDrugs_IUDR", con);                    
                }
                    cmd.CommandType = CommandType.StoredProcedure;
                    da = new SqlDataAdapter(cmd);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = objPhBe.InsId;
                    da.SelectCommand.Parameters.Add("@SupplierCode", SqlDbType.VarChar).Value = objPhBe.Supplier;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = objPhBe.DrugCd;
                    da.SelectCommand.Parameters.Add("@Dosageperpack", SqlDbType.Char).Value = objPhBe.DosagesPerPack;
                    da.SelectCommand.Parameters.Add("@Qtyeachpack", SqlDbType.VarChar).Value = objPhBe.Qtyineachpack;
                    da.SelectCommand.Parameters.Add("@BatchNo", SqlDbType.VarChar).Value = objPhBe.BatchNo;
                    da.SelectCommand.Parameters.Add("@ExpiryDate", SqlDbType.DateTime).Value = objPhBe.ExpDt;
                    da.SelectCommand.Parameters.Add("@Noofpackages", SqlDbType.VarChar).Value = objPhBe.Noofpackages;
                    da.SelectCommand.Parameters.Add("@ReceiptDate", SqlDbType.DateTime).Value = objPhBe.DtReceipt;
                    da.SelectCommand.Parameters.Add("@ValueofDrug", SqlDbType.VarChar).Value = objPhBe.Valueofdrug;
                    da.SelectCommand.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = objPhBe.Drugqty;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = objPhBe.UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = objPhBe.Action;
                    da.SelectCommand.Parameters.Add("@SchemeCode", SqlDbType.Char).Value = objPhBe.SchemeCd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                
            }
        }
        public DataTable viewInventoryDAL(string UniqueInstId, string GData, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ReceiptofDrugs_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId ", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = GData;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable UpdateInsventoryDAL(Pharmacy objPhBe, string ConnKey)
        {
            SqlCommand cmd;
            SqlDataAdapter da;
           using (SqlConnection con = new SqlConnection(ConnKey))
            {
                if (objPhBe.SchemeCd != null)
                {
                    cmd = new SqlCommand("ReceiptofDrugs_Scheme_IUDR", con);                    
                }
                else
                {
                    cmd = new SqlCommand("ReceiptofDrugs_IUDR", con);                    
                }
                    cmd.CommandType = CommandType.StoredProcedure;
                    da = new SqlDataAdapter(cmd);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.Add("@SupplierCode", SqlDbType.VarChar).Value = objPhBe.Supplier;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = objPhBe.DrugCd;
                    da.SelectCommand.Parameters.Add("@Dosageperpack", SqlDbType.Char).Value = objPhBe.DosagesPerPack;
                    da.SelectCommand.Parameters.Add("@Qtyeachpack", SqlDbType.VarChar).Value = objPhBe.Qtyineachpack;
                    da.SelectCommand.Parameters.Add("@BatchNo", SqlDbType.VarChar).Value = objPhBe.BatchNo;
                    da.SelectCommand.Parameters.Add("@ExpiryDate", SqlDbType.Date).Value = objPhBe.ExpDt;
                    da.SelectCommand.Parameters.Add("@Noofpackages", SqlDbType.VarChar).Value = objPhBe.Noofpackages;
                    da.SelectCommand.Parameters.Add("@ReceiptDate", SqlDbType.Date).Value = objPhBe.DtReceipt;
                    da.SelectCommand.Parameters.Add("@ValueofDrug", SqlDbType.VarChar).Value = objPhBe.Valueofdrug;
                    da.SelectCommand.Parameters.Add("@ReceiptNo", SqlDbType.BigInt).Value = objPhBe.ReceiptNo;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = objPhBe.UserName;
                    da.SelectCommand.Parameters.Add("@Quantity", SqlDbType.VarChar).Value = objPhBe.Drugqty;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = objPhBe.Action;
                    da.SelectCommand.Parameters.Add("@SchemeCode", SqlDbType.Char).Value = objPhBe.SchemeCd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                
            }
        }
        public DataTable DeleteInvetoryDAL(string ReciptNo, string Flag_IUP, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("ReceiptofDrugs_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ReceiptNo", SqlDbType.VarChar).Value = ReciptNo;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Flag_IUP;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }
        /* get unit measurement for selected drug */
        public DataTable getUnitmsrDAL(string getUnitmsr, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_GetUnitForDrug", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = getUnitmsr;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Fetch PatientReg Based On Registration Number*/
        public DataTable FetchPaitentDtlsDAL(string Rergno, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetDiagPatientDtls", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = Rergno;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable getdrugInsDAL(string UniqueInstId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchDrugsByIns", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInstId;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public void InsertIssueDrugDAL(DataTable dt, string InsCode, string Obser, string DisName, string RegNo, string Flag_IUP, string VisitId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlCommand cmd = new SqlCommand("IssueofDrugs", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Tbl_DrugsIssued", SqlDbType.Structured).Value = dt;
                    cmd.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = InsCode;
                    cmd.Parameters.Add("@RegistrationNo", SqlDbType.VarChar).Value = RegNo;
                    cmd.Parameters.Add("@Doctors_Observation", SqlDbType.VarChar).Value = Obser;
                    cmd.Parameters.Add("@Diseases", SqlDbType.VarChar).Value = DisName;
                    cmd.Parameters.Add("@IssuedSt", SqlDbType.VarChar).Value = Flag_IUP;
                    cmd.Parameters.Add("@VisitId", SqlDbType.VarChar).Value = VisitId;
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void InsertIssueDrug_bySchemeDAL(DataTable dt, string InsCode, string Obser, string DisName, string RegNo, string Flag_IUP, string VisitId, string SchemeCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlCommand cmd = new SqlCommand("IssueofDrugs", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Tbl_DrugsIssued", SqlDbType.Structured).Value = dt;
                    cmd.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = InsCode;
                    cmd.Parameters.Add("@RegistrationNo", SqlDbType.VarChar).Value = RegNo;
                    cmd.Parameters.Add("@Doctors_Observation", SqlDbType.VarChar).Value = Obser;
                    cmd.Parameters.Add("@Diseases", SqlDbType.VarChar).Value = DisName;
                    cmd.Parameters.Add("@IssuedSt", SqlDbType.VarChar).Value = Flag_IUP;
                    cmd.Parameters.Add("@VisitId", SqlDbType.VarChar).Value = VisitId;
                    cmd.Parameters.Add("@SchemeCode", SqlDbType.VarChar).Value = SchemeCode;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public DataTable getdrugdetailsDAL(string UniqueInsId, string Drugcode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchDrugDtls_IssueofDrugs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = Drugcode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable getdrugdetails_bySchemeDAL(string UniqueInsId, string Drugcode,string SchemeCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchDrugDtls_IssueofDrugs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = Drugcode;
                    da.SelectCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar).Value = SchemeCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable FetcIssueOfDrugDtlsDAL(string Rergno, string Date, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchDetails_IssueOfDrug", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = Rergno;
                    da.SelectCommand.Parameters.Add("@RegDate", SqlDbType.Date).Value = Date;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Get Drug Availability Data */
        public DataTable getDrugsAvailDAL(string UniqInstCode, string DrugCodeList, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_DrugsAvailability_PharmacyWs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqInstCode;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = DrugCodeList;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Insert Drug Consumption Data */
        public DataTable getInstdrugDAL(string UniqInstCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SP_GetDrugsbyInst", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqInstCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /* Drug Consumption */
        /* Get Drug Consumption Data */
        public DataTable getdrugsInfoDAL(string UniqueInstId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DrugAvgConsumptionPerMonth_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InstId", SqlDbType.VarChar).Value = UniqueInstId;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }



        }

        /* Insert Drug Consumption Data */
        public DataTable InsertDrugConsumptionDAL(string UniqueInstId, string drugcode, int AvgConsumption, string UserName, string INSERT, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DrugAvgConsumptionPerMonth_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = drugcode;
                    da.SelectCommand.Parameters.Add("@AvgConsumption", SqlDbType.VarChar).Value = AvgConsumption;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /* Update Drug Consumption Data */
        public DataTable UpdateDrugConsumptionDAL(string UniqueInstId, string drugcode, int AvgConsumption, string UserName, string UPDATE, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DrugAvgConsumptionPerMonth_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = drugcode;
                    da.SelectCommand.Parameters.Add("@AvgConsumption", SqlDbType.VarChar).Value = AvgConsumption;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Get Drug Availability Data */
        public DataTable getDrugsAvailDAL1(string UniqInstCode, string DrugCodeList, string rbvalue, string rborder, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_DrugsAvailability_PharmacyWs_sort", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqInstCode;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = DrugCodeList;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = rbvalue;
                    da.SelectCommand.Parameters.Add("@Order", SqlDbType.VarChar).Value = rborder;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*Issues Of drugs*/

        public DataTable AnimaldetailsDAL(string Unique_InsId, DateTime date, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchPendingPatients_IssueofDrugs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = Unique_InsId;
                    da.SelectCommand.Parameters.Add("@RegDate", SqlDbType.DateTime).Value = date;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*ISSUE OF DRUGS - FETCH DRUGS BASED ON SCHEME SELECTED*/
        public DataTable getdrugbySchemeDAL(string SchemeCode, string UniqueInstId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchDrugsByScheme", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar).Value = SchemeCode;                    
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
       
    }

}
