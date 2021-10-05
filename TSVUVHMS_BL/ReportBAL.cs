using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSVUVHMS_DL;
using System.Data;

namespace TSVUVHMS_BL
{
    public class ReportBAL
    {
        ReportDAL objRptBL = new ReportDAL();
        /* Report on Daily Stocks Received - Pharmacy*/
        public DataTable Rpt_Ph_DailyStocksRcvdBAL(DateTime FromDt, DateTime ToDt, string DistCode, string UniqueInsId, string DrugCode, string ConnKey)
        {
            return objRptBL.Rpt_Ph_DailyStocksRcvdDAL(FromDt, ToDt, DistCode, UniqueInsId, DrugCode, ConnKey);
        }
        /* Report on Daily Stocks Issued - Pharmacy*/
        public DataTable Rpt_Ph_DailyStocksIssuedBAL(DateTime FromDt, DateTime ToDt, string DistCode, string UniqueInsId, string DrugCode, string ConnKey)
        {
            return objRptBL.Rpt_Ph_DailyStocksIssuedDAL(FromDt, ToDt, DistCode, UniqueInsId, DrugCode, ConnKey);
        }
        /* Report on Drugs Issued Daily - Pharmacy*/
        public DataTable Rpt_Ph_DrugsIssuedByRegNoBAL(DateTime Dt, string UniqueInsId, string RegNo, string ConnKey)
        {
            return objRptBL.Rpt_Ph_DrugsIssuedByRegNoDAL(Dt, UniqueInsId, RegNo, ConnKey);
        }
        public DataTable GetInsEnrolledBAL( string ConnKey)
        {
            return objRptBL.GetInsEnrolledDAL( ConnKey);
        }
        public DataTable GetRegCountBAL( string ConnKey)
        {
            return objRptBL.GetRegCountDAL( ConnKey);
        }
        public DataTable GetValueOfDrugBAL( string ConnKey)
        {
            return objRptBL.GetValueOfDrugDAL( ConnKey);
        }
        public DataTable DashBoardCountBAL(string StateCode, string DistCode, string MandCode, string UniqueInsId, string ConnKey)
        {
            return objRptBL.DashBoardCountDAL(StateCode, DistCode, MandCode, UniqueInsId, ConnKey);
        }
        /*DATA ANALYSIS - PATIENT VISITS*/
        public DataTable FetchDA_PaitentVisitsBAL(string Uniq_InstId, DateTime FromDt, DateTime ToDt, int StartTime, int EndTime, string ConnKey)
        {
            return objRptBL.FetchDA_PaitentVisitsDAL(Uniq_InstId, FromDt, ToDt, StartTime, EndTime, ConnKey);
        }
        public DataTable FetchDB_TotInstutionsBAL(string StateCode, string Uniq_InstId, string ConnKey)
        {
            return objRptBL.FetchDB_TotInstutionsDAL(StateCode, Uniq_InstId, ConnKey);
        }
        public DataTable FetchDB_TotRegistrationsBAL(string StateCode, string Uniq_InstId, string RegType, string ConnKey)
        {
            return objRptBL.FetchDB_TotRegistrationsDAL(StateCode,Uniq_InstId, RegType, ConnKey);
        }
        public DataTable FetchDB_TotDrugIssuedBAL(string StateCode, string Uniq_InstId, string ConnKey)
        {
            return objRptBL.FetchDB_TotDrugIssuedDAL(StateCode,Uniq_InstId, ConnKey);
        }
        public DataTable GetPatientHistoryDtlsBAL(string UniqueInsId, string RegNo, string ConnKey)
        {
            return objRptBL.GetPatientHistoryDtlsDAL(UniqueInsId, RegNo, ConnKey);
        }
        public DataTable GetPatientDtlsByRegNo_VisitDateBAL(string UniqueInsId, string RegNo, DateTime VisitDate, string ConnKey, string Doctor_Id)
        {
            return objRptBL.GetPatientDtlsByRegNo_VisitDateDAL(UniqueInsId,RegNo, VisitDate, ConnKey, Doctor_Id);
        }
        public void UpdateRecordSeenByDoctorBAL(string RegNo, DateTime VisitDate, string ConnKey, string Obser, string DisName)
        {
            objRptBL.UpdateRecordSeenByDoctorDAL(RegNo,VisitDate, ConnKey, Obser, DisName);
        }
        public DataTable GetPatientDtlsByRegNo_or_VisitDateBAL(string UniqueInstId, string RegNo, DateTime VisitDate, string ConnKey, string Doctor_Id)
        {
            return objRptBL.GetPatientDtlsByRegNo_or_VisitDateDAL(UniqueInstId, RegNo, VisitDate, ConnKey, Doctor_Id);
        }
        public DataTable FetchDiag_MnthlyAbstractBAL(string Uniq_InstId, string FromYr , string FromMnth , string ToYr , string ToMnth, string ConnKey)
        {
            return objRptBL.FetchDiag_MnthlyAbstractDAL(Uniq_InstId, FromYr, FromMnth, ToYr, ToMnth, ConnKey);
        }
        public DataTable FetchFeedbackAnalysisBAL(string Uniq_InstId, DateTime FromDt, DateTime ToDt, string ConnKey)
        {
            return objRptBL.FetchFeedbackAnalysisDAL(Uniq_InstId, FromDt, ToDt, ConnKey);
        }
        /* ABSTRACT Report on Stocks Issued - Pharmacy*/
        public DataTable Rpt_Ph_StocksIssued_AbstractBAL(string FromYr, string FromMnth, string ToYr, string ToMnth, string DistCode, string UniqueInsId, string DrugCode, string ConnKey)
        {
            return objRptBL.Rpt_Ph_StocksIssued_AbstractDAL(FromYr, FromMnth, ToYr, ToMnth, DistCode, UniqueInsId, DrugCode, ConnKey);
        }
         /*GET hIT COUNT Details*/
        public DataTable GetHitCountBL(string ConnKey)
        {
            return objRptBL.GetHitCountDL(ConnKey);
        }
        public DataTable GetRolewiseManuBL(string roleid, string ParentMenuId, string ConnKey)
        {
            return objRptBL.GetRolewiseMenuDL(roleid, ParentMenuId, ConnKey);
        }
        public DataTable GetSchemeWsDrugsIssuedBAL(string Uniq_InstId, DateTime FromDt, DateTime ToDt, string ConnKey)
        {
            return objRptBL.GetSchemeWsDrugsIssuedDAL(Uniq_InstId, FromDt, ToDt, ConnKey);
        }
        public DataTable GetBenCnt_Dst_Ins_SchemeWsDrugsIssuedBAL(string Uniq_InstId,string DistCode, DateTime FromDt, DateTime ToDt,string WithAadhar, string ConnKey)
        {
            return objRptBL.GetBenCnt_Dst_Ins_SchemeWsDrugsIssuedDAL(Uniq_InstId,DistCode, FromDt, ToDt,WithAadhar, ConnKey);
        }
    }
}
