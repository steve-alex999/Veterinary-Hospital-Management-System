using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace TSVUVHMS_DL
{
    public class ReportDAL
    {
        /* Report on Daily Stocks Received - Pharmacy*/
        public DataTable Rpt_Ph_DailyStocksRcvdDAL(DateTime FromDt, DateTime ToDt, string DistCode, string UniqueInsId, string DrugCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_PH_DailyStocksRcvd", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@FromDt", SqlDbType.DateTime).Value = FromDt;
                    da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.DateTime).Value = ToDt;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = DrugCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Report on Daily Stocks Issued - Pharmacy*/
        public DataTable Rpt_Ph_DailyStocksIssuedDAL(DateTime FromDt, DateTime ToDt, string DistCode, string UniqueInsId, string DrugCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_PH_DailyStocksIssued", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@FromDt", SqlDbType.DateTime).Value = FromDt;
                    da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.DateTime).Value = ToDt;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = DrugCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Report on Drugs Issued Daily - Pharmacy*/
        public DataTable Rpt_Ph_DrugsIssuedByRegNoDAL(DateTime Dt, string UniqueInsId, string RegNo, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_PH_DrugsIssuedByRegNo", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInstId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@IssuedDt", SqlDbType.DateTime).Value = Dt;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = RegNo;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetInsEnrolledDAL( string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DashBoardReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "E";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetRegCountDAL( string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DashBoardReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = "ALL";
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = "ALL";
                    da.SelectCommand.Parameters.Add("@MandCode", SqlDbType.VarChar).Value = "ALL";
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = "ALL";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetValueOfDrugDAL( string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DashBoardReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "A";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable DashBoardCountDAL(string StateCode, string DistCode, string MandCode, string UniqueInsId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DashBoardReport_DMY", con))
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@MandCode", SqlDbType.VarChar).Value = MandCode;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = UniqueInsId;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*DATA ANALYSIS - PATIENT VISITS*/
        public DataTable FetchDA_PaitentVisitsDAL(string Uniq_InstId, DateTime FromDt, DateTime ToDt, int StartTime, int EndTime, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_DataAnalysis_Regs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = Uniq_InstId;
                    da.SelectCommand.Parameters.Add("@FromDt", SqlDbType.Date).Value = FromDt;
                    da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.Date).Value = ToDt;
                    da.SelectCommand.Parameters.Add("@StartTime", SqlDbType.Int).Value = StartTime;
                    da.SelectCommand.Parameters.Add("@EndTime", SqlDbType.Int).Value = EndTime;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable FetchDB_TotInstutionsDAL(string StateCode, string Uniq_InstId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                if (StateCode == "goi")
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("TotInstitutions_Cntry", con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
                else
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("Rpt_DB_TotInstitutions", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                        da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = Uniq_InstId;

                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable FetchDB_TotRegistrationsDAL(string StateCode,string Uniq_InstId, string RegType, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                if (StateCode == "goi")
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("TotOpReg_or_Revisits_Cntry", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = Uniq_InstId;
                        da.SelectCommand.Parameters.Add("@RegType", SqlDbType.Char).Value = RegType;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
                else
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("Rpt_DB_TotRegistrations", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = Uniq_InstId;
                        da.SelectCommand.Parameters.Add("@RegType", SqlDbType.Char).Value = RegType;

                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable FetchDB_TotDrugIssuedDAL(string StateCode, string Uniq_InstId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                if (StateCode == "goi")
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("DrugsIssued_Cntry", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = Uniq_InstId;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
                else
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("Rpt_DB_TotDrugsIssued", con))
                    {
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = Uniq_InstId;
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public DataTable GetPatientHistoryDtlsDAL(string UniqueInsId, string RegNo, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_PatientHistory", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = RegNo;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetPatientDtlsByRegNo_VisitDateDAL(string UniqueInsId, string RegNo, DateTime VisitDate, string ConnKey, string Doctor_Id)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchPatientDtls_ByRegNo_Date", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = RegNo;
                    da.SelectCommand.Parameters.Add("@VisitDate", SqlDbType.DateTime).Value = VisitDate;
                    da.SelectCommand.Parameters.Add("@Doctor_Id", SqlDbType.Int).Value = Doctor_Id;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public void UpdateRecordSeenByDoctorDAL(string RegNo, DateTime VisitDate, string ConnKey, string Obser, string DisName)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateRecordSeenByDoctor", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = RegNo;
                    cmd.Parameters.Add("@VisitDate", SqlDbType.Date).Value = VisitDate;
                    cmd.Parameters.Add("@Doctors_Observation", SqlDbType.VarChar).Value = Obser;
                    cmd.Parameters.Add("@Diseases", SqlDbType.VarChar).Value = DisName;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public DataTable GetPatientDtlsByRegNo_or_VisitDateDAL(string UniqueInstId,string RegNo, DateTime VisitDate, string ConnKey, string Doctor_Id)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_FetchPatientDtls_ByRegNo_or_Date", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = RegNo;
                    da.SelectCommand.Parameters.Add("@VisitDate", SqlDbType.DateTime).Value = VisitDate;
                    da.SelectCommand.Parameters.Add("@Doctor_Id", SqlDbType.Int).Value = Doctor_Id;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable FetchDiag_MnthlyAbstractDAL(string Uniq_InstId, string FromYr, string FromMnth, string ToYr, string ToMnth, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_Diag_Abstract", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = Uniq_InstId;
                    da.SelectCommand.Parameters.Add("@FromYear", SqlDbType.VarChar).Value = FromYr;
                    da.SelectCommand.Parameters.Add("@FromMnth", SqlDbType.VarChar).Value = FromMnth;
                    da.SelectCommand.Parameters.Add("@ToYear", SqlDbType.VarChar).Value = ToYr;
                    da.SelectCommand.Parameters.Add("@ToMnth", SqlDbType.VarChar).Value = ToMnth;                    
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable FetchFeedbackAnalysisDAL(string Uniq_InstId, DateTime FromDt, DateTime ToDt, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_Feedback_Analysis", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = Uniq_InstId;
                    da.SelectCommand.Parameters.Add("@FeedbackTaken_FromDt", SqlDbType.Date).Value = FromDt;
                    da.SelectCommand.Parameters.Add("@FeedbackTaken_ToDt", SqlDbType.Date).Value = ToDt;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* ABSTRACT Report on Stocks Issued - Pharmacy*/
        public DataTable Rpt_Ph_StocksIssued_AbstractDAL(string FromYr, string FromMnth, string ToYr, string ToMnth, string DistCode, string UniqueInsId, string DrugCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_PH_StocksIssued_Abstract", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@FromYear", SqlDbType.VarChar).Value = FromYr;
                    da.SelectCommand.Parameters.Add("@FromMnth", SqlDbType.VarChar).Value = FromMnth;
                    da.SelectCommand.Parameters.Add("@ToYear", SqlDbType.VarChar).Value = ToYr;
                    da.SelectCommand.Parameters.Add("@ToMnth", SqlDbType.VarChar).Value = ToMnth;       
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@DrugCode", SqlDbType.VarChar).Value = DrugCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*GET hIT COUNT Details*/
        public DataTable GetHitCountDL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("HitCount", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetRolewiseMenuDL(string rolecd, string ParentMenuId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("Menus_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Roleid", SqlDbType.VarChar).Value = rolecd;
                //    da.SelectCommand.Parameters.Add("@ParentMenuId", SqlDbType.VarChar).Value = ParentMenuId;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*DASHBOARD FOR COUNTRY*/
        public DataTable DashBoardCount_CntryDAL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DashBoardReportCntry", con))
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetSchemeWsDrugsIssuedDAL(string Uniq_InstId, DateTime FromDt, DateTime ToDt, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_PH_HospWs_ShcemeWs_DrugsIssued", con))
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
        public DataTable GetBenCnt_Dst_Ins_SchemeWsDrugsIssuedDAL(string Uniq_InstId, string DistCode , DateTime FromDt, DateTime ToDt,string WithAadhar, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_SchemeWs_Aadhar_CatCnt", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = Uniq_InstId;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@FromDt", SqlDbType.Date).Value = FromDt;
                    da.SelectCommand.Parameters.Add("@ToDt", SqlDbType.Date).Value = ToDt;
                    da.SelectCommand.Parameters.Add("@Aadhar", SqlDbType.VarChar).Value = WithAadhar;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
