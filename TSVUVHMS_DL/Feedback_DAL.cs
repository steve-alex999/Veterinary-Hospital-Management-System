using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TSVUVHMS_BE;

namespace TSVUVHMS_DL
{
    public class Feedback_DAL
    {
        public DataTable GetPatientDtlsForFeedback_ByVisitDateDAL(string UniqueInsId, DateTime VisitDate,string UserId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Feedback_FetchRegDtlsByVisitDt", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@VisitDate", SqlDbType.DateTime).Value = VisitDate;
                    da.SelectCommand.Parameters.Add("@LoggedIn_UserId", SqlDbType.VarChar).Value = UserId;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public void InsertFeedbackDtlsDAL(FeedbackBE objBE, string UserId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlCommand cmd = new SqlCommand("Feedback_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = objBE.UniqueInsId;
                    cmd.Parameters.Add("@VisitDate", SqlDbType.Date).Value = objBE.VisitDate;
                    cmd.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = objBE.RegNo;
                    cmd.Parameters.Add("@VisitId", SqlDbType.VarChar).Value = objBE.VisitId;
                    cmd.Parameters.Add("@RegFee_Paid", SqlDbType.VarChar).Value = objBE.RegFeePaid;
                    cmd.Parameters.Add("@TestFee_Paid", SqlDbType.VarChar).Value = objBE.TestFeePaid;
                    cmd.Parameters.Add("@OtherAmt_Paid", SqlDbType.VarChar).Value = objBE.OtherAmtPaid;
                    cmd.Parameters.Add("@Reg_ServiceQuality", SqlDbType.VarChar).Value = objBE.Reg_ServiceQuality;
                    cmd.Parameters.Add("@Doctor_ServiceQuality", SqlDbType.VarChar).Value = objBE.Doctor_ServiceQuality;
                    cmd.Parameters.Add("@Phar_ServiceQuality", SqlDbType.VarChar).Value = objBE.Phar_ServiceQuality;
                    cmd.Parameters.Add("@Free_DrugIssued", SqlDbType.VarChar).Value = objBE.Free_DrugIssued;
                    cmd.Parameters.Add("@Drugs_Pfrmoutside", SqlDbType.VarChar).Value = objBE.Drugs_Pfrmoutside;
                    cmd.Parameters.Add("@CleanlinessInHosp", SqlDbType.VarChar).Value = objBE.CleanlinessInHosp;
                    cmd.Parameters.Add("@Overall_Experience", SqlDbType.VarChar).Value = objBE.Overall_Experience;
                    cmd.Parameters.Add("@ExcessRegFeeTaken", SqlDbType.VarChar).Value = objBE.ExcessRegFeeTaken;
                    cmd.Parameters.Add("@ExcessRegFee", SqlDbType.VarChar).Value = objBE.ExcessRegFee;
                    cmd.Parameters.Add("@ExcessTestFeeTaken", SqlDbType.VarChar).Value = objBE.ExcessTestFeeTaken;
                    cmd.Parameters.Add("@ExcessTestFee", SqlDbType.VarChar).Value = objBE.ExcessTestFee;
                    cmd.Parameters.Add("@FreeDrugsNotIssued", SqlDbType.VarChar).Value = objBE.FreeDrugsNotIssued;
                    cmd.Parameters.Add("@LoggedIn_UserId", SqlDbType.VarChar).Value = UserId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void CloseFeedbackDAL(FeedbackBE objBE, string UserId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlCommand cmd = new SqlCommand("Feedback_Close", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = objBE.UniqueInsId;
                    cmd.Parameters.Add("@VisitDate", SqlDbType.Date).Value = objBE.VisitDate;
                    cmd.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = objBE.RegNo;
                    cmd.Parameters.Add("@VisitId", SqlDbType.VarChar).Value = objBE.VisitId;
                    cmd.Parameters.Add("@CloseFb_Reason", SqlDbType.VarChar).Value = objBE.VisitId;
                    cmd.Parameters.Add("@LoggedIn_UserId", SqlDbType.VarChar).Value = UserId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
