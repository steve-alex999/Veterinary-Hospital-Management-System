using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSVUVHMS_DL;
using System.Data;


namespace TSVUVHMS_BL
{
    public class DiagBAL
    {
        DiagDAL objDiagDAL = new DiagDAL();

        public DataTable getTestBAL(string UniqueInsId, string ConnKey)
        {
            return objDiagDAL.getTestDAL(UniqueInsId,ConnKey);

        }
        //public DataTable getDiagDtlsBAL(string UniqueInstId, string Regno, DateTime RegDate)
        //{
        //    return objDiagDAL.getDiagDtlsDAL(UniqueInstId, Regno,RegDate);
        //}
        public DataTable getDiagDtlsBAL(string UniqueInstId, DateTime RegDate, string ConnKey)
        {
            return objDiagDAL.getDiagDtlsDAL(UniqueInstId, RegDate, ConnKey);
        }
        public DataTable getDiagDtlsRegBAL(string UniqueInstId, string Regno, string ConnKey)
        {
            return objDiagDAL.getDiagDtlsRegDAL(UniqueInstId, Regno, ConnKey);
        }
        public DataTable FetchPaitentDtlsBAL(string Rergno, string ConnKey)
        {
            return objDiagDAL.FetchPaitentDtlsDAL(Rergno, ConnKey);

        }
        public DataTable GetTestDtlsBAL(string UniqueInsId, string TestCode, string ConnKey)
        {
            return objDiagDAL.GetTestDtlsDAL(UniqueInsId,TestCode, ConnKey);

        }
        public DataTable FetchFeecollectedBAL(string Uniq_InstId, DateTime FromDt, DateTime ToDt, string ConnKey)
        {
            return objDiagDAL.FetchFeecollectedDAL(Uniq_InstId, FromDt, ToDt, ConnKey);
        }


        public void InsertDiagTestsBAL(string Unique_InsId, string RegNo, string TestCode, string ExemptedCategory, string Username, string ConnKey)
        {
            objDiagDAL.InsertDiagTestsDAL(Unique_InsId,RegNo, TestCode, ExemptedCategory,Username, ConnKey);
        }

        public DataTable GetTestRepotBAL(string RegNo, string UniqueInstId, DateTime TestDate, string ConnKey)
        {
            return objDiagDAL.GetTestRepotDAL(RegNo, UniqueInstId, TestDate, ConnKey);
        }
        /*Fetch Test Dates By Reg No*/
        public DataTable GetTestDatesByRegNoBAL(string Regno, string ConnKey)
        {
            return objDiagDAL.GetTestDatesByRegNoDAL(Regno, ConnKey);
        }
    }
}
