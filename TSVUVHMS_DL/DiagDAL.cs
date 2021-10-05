using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace TSVUVHMS_DL
{
    public class DiagDAL
    {
       public DataTable getTestDAL(string UniqueInsId , string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DiagTestFeeMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "S";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }
        /*Diag Details */
        public DataTable getDiagDtlsDAL(string UniqueInstId, DateTime RegDate, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Undergo_DiagTest_GetData", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@Date", SqlDbType.Date).Value = RegDate;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = 'D';
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*Diag Details Based On Registration*/
        public DataTable getDiagDtlsRegDAL(string UniqueInstId, string Regno, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Undergo_DiagTest_GetData", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = Regno;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = 'R';
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
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
     
       // public DataTable GetTestDtlsDAL(string UniqueInstId, string TestCode)
        public DataTable GetTestDtlsDAL(string UniqueInsId, string TestCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Fetch_TestDtls", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@TestCode", SqlDbType.VarChar).Value = TestCode;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }

            }
        }

        public void InsertDiagTestsDAL(string Unique_InsId, string RegNo, string TestCode,string ExemptedCategory, string Username, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlCommand cmd = new SqlCommand("Update_DiagTestData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = Unique_InsId;
                    cmd.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = RegNo;
                    cmd.Parameters.Add("@ExemptedCategory", SqlDbType.VarChar).Value = ExemptedCategory;
                    cmd.Parameters.Add("@TestCodes", SqlDbType.VarChar).Value = TestCode;
                    cmd.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = Username;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public DataTable GetTestRepotDAL(string RegNo, string UniqueInstId, DateTime TestDate, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchTestDtls_DiagTest", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = RegNo;
                    da.SelectCommand.Parameters.Add("@Unique_InstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@TestDate", SqlDbType.Date).Value = TestDate;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;

                }
            }

        }
        /*Fetch Test Dates By Reg No*/
        public DataTable GetTestDatesByRegNoDAL(string Regno, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchTestDates_ByRegNo", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = Regno;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable FetchFeecollectedDAL(string Uniq_InstId, DateTime FromDt, DateTime ToDt, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_DiagTestFeeCollected", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = Uniq_InstId;
                    da.SelectCommand.Parameters.Add("@FromDt", SqlDbType.Date).Value = FromDt;
                    da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.Date).Value = ToDt;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
       
    }
}
