using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSVUVHMS_BE;
using TSVUVHMS_DL;
using System.Data;

namespace TSVUVHMS_BL
{
    
    public class PharmacyBAL
    {
        PharmacyDAL objPharDAL = new PharmacyDAL();

        public DataTable getdrug(string ConnKey)
        {
            return objPharDAL.getdrugDAL( ConnKey);
        }
        public DataTable getsuply( string ConnKey)
        {
            return objPharDAL.getsuplyDAL(ConnKey);
        }
        /* Confirm Drug Details*/
        public DataTable ConfirmInvetoryBAL(string ReciptNo, string Flag_IUP, string ConnKey)
        {
            return objPharDAL.ConfirmInvetoryBAL(ReciptNo, Flag_IUP, ConnKey);
        }
        /* Insert Invetory Details*/
        public DataTable InsertInvetoryBAL(Pharmacy objPhBe , string ConnKey)
        {
            return objPharDAL.InsertInvetoryDAL(objPhBe, ConnKey);
        }
      
        public DataTable viewInventoryBAL(string UniqueInstId, string GData, string ConnKey)
        {
            return objPharDAL.viewInventoryDAL(UniqueInstId, GData, ConnKey);
        }
        public DataTable UpdateInsventoryBAL(Pharmacy objPhBE, string ConnKey)
        {
            return objPharDAL.UpdateInsventoryDAL(objPhBE, ConnKey);
        }
        public DataTable DeleteInvetoryBAL(string ReciptNo, string Flag_IUP, string ConnKey)
        {
            return objPharDAL.DeleteInvetoryDAL(ReciptNo, Flag_IUP, ConnKey);
        }
        /* get unit measurement for selected drug */

        public DataTable getUnitmsr(string getUnitmsr, string ConnKey)
        {
            return objPharDAL.getUnitmsrDAL(getUnitmsr, ConnKey);

        }

        public DataTable FetchPaitentDtlsBAL(string Rergno, string ConnKey)
        {
            return objPharDAL.FetchPaitentDtlsDAL(Rergno, ConnKey);
        }
        /*Pharmacy Receipt of Drugs */
        public DataTable getdrugIns(string UniqueInstId, string ConnKey)
        {
            return objPharDAL.getdrugInsDAL(UniqueInstId, ConnKey);
        }
        public void InsertIssueDrugBAL(DataTable dt, string InsCode, string Obser, string DisName, string RegNo, string Flag_IUP,string VisitId, string ConnKey)
        {
            objPharDAL.InsertIssueDrugDAL(dt, InsCode, Obser, DisName, RegNo, Flag_IUP,VisitId, ConnKey);
        }
        public void InsertIssueDrug_bySchemeBAL(DataTable dt, string InsCode, string Obser, string DisName, string RegNo, string Flag_IUP, string VisitId, string SchemeCode, string ConnKey)
        {
            objPharDAL.InsertIssueDrug_bySchemeDAL(dt, InsCode, Obser, DisName, RegNo, Flag_IUP, VisitId, SchemeCode, ConnKey);
        }
        public DataTable getdrugdetailsBAL(string UniqueInsId, string Drugcode, string ConnKey)
        {
            return objPharDAL.getdrugdetailsDAL(UniqueInsId, Drugcode, ConnKey);
        }
        public DataTable getdrugdetails_bySchemeBAL(string UniqueInsId, string Drugcode,string SchemeCode, string ConnKey)
        {
            return objPharDAL.getdrugdetails_bySchemeDAL(UniqueInsId, Drugcode,SchemeCode, ConnKey);
        }
        public DataTable FetcIssueOfDrugDtlsBAL(string Rergno, string Date, string ConnKey)
        {
            return objPharDAL.FetcIssueOfDrugDtlsDAL(Rergno, Date, ConnKey);
        }
        /* Get Drug Availability Data */

        public DataTable getDrugsAvailBAL(string UniqInstCode, string DrugCodeList, string ConnKey)
        {
            return objPharDAL.getDrugsAvailDAL(UniqInstCode, DrugCodeList, ConnKey);

        }
        /* Get Institution  Drugs Data */

        public DataTable getInstdrugBAL(string UniqInstCode, string ConnKey)
        {
            return objPharDAL.getInstdrugDAL(UniqInstCode, ConnKey);

        }
        /* Get Drug Consumption Data */

        public DataTable getdrugsInfo(string UniqueInstId, string ConnKey)
        {
            return objPharDAL.getdrugsInfoDAL(UniqueInstId, ConnKey);

        }

        /* Insert  Drug Consumption Data */

        public DataTable InsertDrugConsumptionBAL(string UniqueInstId, string drugcode, int AvgConsumption, string UserName, string INSERT, string ConnKey)
        {
            return objPharDAL.InsertDrugConsumptionDAL(UniqueInstId, drugcode, AvgConsumption, UserName, INSERT, ConnKey);

        }
        /* Update  Drug Consumption Data*/

        public DataTable UpdateDrugConsumptionBAL(string UniqueInstId, string drugcode, int AvgConsumption, string UserName, string UPDATE, string ConnKey)
        {
            return objPharDAL.UpdateDrugConsumptionDAL(UniqueInstId, drugcode, AvgConsumption, UserName, UPDATE, ConnKey);

        }
        /* Get Drug Availability Data */

        public DataTable getDrugsAvailBAL1(string UniqInstCode, string DrugCodeList, string rbvalue, string rborder, string ConnKey)
        {
            return objPharDAL.getDrugsAvailDAL1(UniqInstCode, DrugCodeList, rbvalue, rborder, ConnKey);

        }
        /*Issues Of Drugs*/
        public DataTable AnimaldetailsBAL(string Unique_InsId, DateTime Date, string ConnKey)
        {
            return objPharDAL.AnimaldetailsDAL(Unique_InsId, Date, ConnKey);
        }
        /*ISSUE OF DRUGS - FETCH DRUGS BASED ON SCHEME SELECTED*/
        public DataTable getdrugbySchemeBAL(string SchemeCode , string UniqueInstId, string ConnKey)
        {
            return objPharDAL.getdrugbySchemeDAL(SchemeCode, UniqueInstId, ConnKey);
        }
    }
}
