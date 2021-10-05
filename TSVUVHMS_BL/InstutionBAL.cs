using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSVUVHMS_DL;
using System.Data;

namespace TSVUVHMS_BL
{
    public class InstutionBAL
    {
        InstutionDAL objIns = new InstutionDAL();
        /*GET Institution Details*/
        public DataTable GetInsNameBAL(string Unique_InsId, string UserName, string ConnKey)
        {
            return objIns.GetInsNameDAL(Unique_InsId, UserName, ConnKey);
        }
        public DataTable GetInsNameBAL1(string Unique_InsId, string UserName, string ConnKey)
        {
            return objIns.GetInsNameDAL1(Unique_InsId, UserName, ConnKey);
        }
        /*GET Institution Fee Details*/
        public DataTable GetRegFeeBAL(string UniqueInstId, string ConnKey)
        {
            return objIns.GetRegFeeDAL(UniqueInstId, ConnKey);
        }
        /*GET Institution Fee Details*/
        public DataTable GetRegFee_ByAnimalTypeBAL(string UniqueInstId, string AnimalTypeCode, string ConnKey)
        {
            return objIns.GetRegFee_ByAnimalTypeDAL(UniqueInstId, AnimalTypeCode, ConnKey);
        }
        /*GET Animal Details*/
        public DataTable viewAnimaldataBAL(string ConnKey)
        {
            return objIns.viewAnimaldataDAL(ConnKey);
        }
        /* INSERT PatientReg*/
        public DataTable getInsertPaitentBAL(string Unique_InsId, DateTime Vdate, string Doctor, string Atype, string Breed, string AgeInYear, string AgeInMonth, int Gender, string AnimalOwner, string StateCode, string Dcode, string Mcode,
            string Village, string mbno, string ExemptedCat, string Regfee, string UserName, string INSERT, string Purpose, string visittype, string nos, string aadharno, string category, string divisioncd, string ConnKey, string DoctorID)
        {
            return objIns.InsertPaitentDAL(Unique_InsId, Vdate, Doctor, Atype, Breed, AgeInYear, AgeInMonth, Gender, AnimalOwner, StateCode, Dcode, Mcode, Village, mbno, ExemptedCat, Regfee, UserName, INSERT, Purpose, visittype, nos, aadharno, category, divisioncd, ConnKey, DoctorID);
        }
        /* UPDATE PatientReg*/
        public DataTable UpdatePaitentBAL(string RegNo, int Gender, string AgeInYear, string AgeInMonth, string RegFee, string AnimalOwner, string BreedCode, DateTime Vdate, string StateCode, string Dcode, string Mcode, string Village, string mbno, string UserName, string UPDATE, string Purpose, string visittype, string nos, string aadharno, string category, string divisioncd, string ConnKey, string DoctorID)
        {
            return objIns.UpdatePaitentDAL(RegNo, Gender, AgeInYear, AgeInMonth, RegFee, AnimalOwner, BreedCode, Vdate, StateCode, Dcode, Mcode, Village, mbno, UserName, UPDATE, Purpose, visittype, nos, aadharno, category, divisioncd, ConnKey, DoctorID);
        }
        /* Fetch PatientReg Based On Registration Number*/
        public DataTable FetchPaitentDtlsBAL(string Rergno, string ConnKey)
        {
            return objIns.FetchPaitentDtlsDAL(Rergno, ConnKey);
        }
        /*REPORT - CASE SHEET */
        public DataTable RptCaseSheetBAL(string Rergno, string VisitDate, string ConnKey)
        {
            return objIns.RptCaseSheetDAL(Rergno, VisitDate, ConnKey);
        }
        /*Fetch Visit Dates By Reg No*/
        public DataTable GetVisitDatesByRegNoBAL(string Regno, string ConnKey)
        {
            return objIns.GetVisitDatesByRegNoDAL(Regno, ConnKey);
        }
        /* Fetch PatientReg Based On Mobile Number*/

        public DataTable AnimaldetailsMbnoBAL(string UniqueInsId, string Mbno, string ConnKey)
        {
            return objIns.AnimaldetailsMbnoDAL(UniqueInsId, Mbno, ConnKey);
        }
        /* Fetch Animal Details AnimalType is ALL */
        public DataTable GetAnimalReportBAL(string UniqueInstId, string AnimalType, DateTime FromDate, DateTime ToDate, string ConnKey)
        {
            return objIns.GetAnimalReportDAL(UniqueInstId, AnimalType, FromDate, ToDate, ConnKey);
        }
        /* Fetch Animal Details AnimalType is DropDown Selection Value */
        public DataTable GetAtypeBAL(string UniqueInstId, string AnimalTypecd, DateTime FromDate, DateTime ToDate, string ConnKey)
        {
            return objIns.GetAtypeDAL(UniqueInstId, AnimalTypecd, FromDate, ToDate, ConnKey);

        }
        public DataTable GetAtypeRptBAL(string UniqueInstId, string AnimalTypecd, string Status, DateTime FromDate, DateTime ToDate, string ConnKey)
        {
            return objIns.GetAtypeRptDAL(UniqueInstId, AnimalTypecd, Status, FromDate, ToDate, ConnKey);

        }
        /* Total animal details with respective of animal type */
        public DataTable GetAtypeALLBAL(string UniqueInstId, DateTime FromDate, DateTime ToDate, string ConnKey)
        {
            return objIns.GetAtypeALLDAL(UniqueInstId, FromDate, ToDate, ConnKey);
        }

        public DataTable GetAtypeALL1BAL(string UniqueInstId, DateTime FromDate, DateTime ToDate, string ConnKey)
        {
            return objIns.GetAtypeALL1DAL(UniqueInstId, FromDate, ToDate, ConnKey);
        }

        public DataTable FetchFeecollectedBAL(string Uniq_InstId, DateTime FromDt, DateTime ToDt, string ConnKey)
        {
            return objIns.FetchFeecollectedDAL(Uniq_InstId, FromDt, ToDt, ConnKey);
        }
        public DataTable FetchPaitentVisitCountBAL(string Uniq_InstId, DateTime FromDt, DateTime ToDt, string ConnKey)
        {
            return objIns.FetchPaitentVisitCountDAL(Uniq_InstId, FromDt, ToDt, ConnKey);
        }
        public DataTable GetRegNoBAL(string Uniq_InstId, string ConnKey)
        {
            return objIns.GetRegNoDAL(Uniq_InstId, ConnKey);
        }
        public DataTable GetRegNoDrugIssueStatusBAL(DateTime Date, string RegNo, string Uniq_InstId, string ConnKey)
        {
            return objIns.GetRegNoDrugIssueStatusDAL(Date, RegNo, Uniq_InstId, ConnKey);
        }
        public DataTable FetchPaitentVisitCount_AbstractBAL(string Uniq_InstId, string FromYr, string FromMnth, string ToYr, string ToMnth, string ConnKey)
        {
            return objIns.FetchPaitentVisitCount_AbstractDAL(Uniq_InstId, FromYr, FromMnth, ToYr, ToMnth, ConnKey);
        }

    }
}
