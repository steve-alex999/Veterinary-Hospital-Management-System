using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSVUVHMS_DL;
using TSVUVHMS_BE;
using System.Data;


namespace TSVUVHMS_BL
{

    public class MasterBAL
    {



        MasterDAL objDist = new MasterDAL();

        /*Get Number*/
        public DataTable getnumber(string Maxnumder, string ConnKey)
        {
            return objDist.getnumber(Maxnumder, ConnKey);
        }
        /*INSERT DIST*/
        public DataTable getInsertDistBAL(string StateCode, string DistCode, string DistName, DateTime Date, int ACtiveSt, string UserName, string Insert, string ConnKey)
        {
            return objDist.insertDistDAL(StateCode, DistCode, DistName, Date, ACtiveSt, UserName, Insert, ConnKey);
        }
        /*VIEW DIST*/
        public DataTable viewdataBAL(string StateCode, string ConnKey)
        {
            return objDist.viewdataDAL(StateCode, ConnKey);
        }
        /*UPDATE DIST*/
        public DataTable UpdateDistBAL(string StateCode, string DistCode, string DistName, int ACtiveSt, string UserName, string ConnKey)
        {
            return objDist.UpdateDistDAL(StateCode, DistCode, DistName, ACtiveSt, UserName, ConnKey);
        }
        /*Delete District*/
        public DataTable DeletedistrictBAL(string statecode, string distcode, string distname, string Flag_IUP, string ConnKey)
        {
            return objDist.DeletedistrictDAL(statecode, distcode, distname, Flag_IUP, ConnKey);

        }
        public DataTable getdist(string StateCode, string ConnKey)
        {
            return objDist.viewdataDAL(StateCode, ConnKey);
        }
        /*INSERT Mandal*/
        public DataTable InsertMandalBAL(string DistCode, string MandalCode, string MandalName, DateTime Date, int ACtiveSt, string UserName, string INSERT, string ConnKey)
        {
            return objDist.insertMandaltDAL(DistCode, MandalCode, MandalName, Date, ACtiveSt, UserName, INSERT, ConnKey);
        }
        /* Upadate Mandal*/
        public DataTable UpdateMandalBAL(string DistCode, string MandalCode, string MandalName, int ACtiveSt, string UserName, string INSERT, string ConnKey)
        {
            return objDist.UpdateMandaltDAL(DistCode, MandalCode, MandalName, ACtiveSt, UserName, INSERT, ConnKey);
        }
        /*Delete Mandal*/
        public DataTable DeletemandalBAL(string DistCode, string MandalCode, string MandalName, string ConnKey)
        {
            return objDist.DeletemandalDAL(DistCode, MandalCode, MandalName, ConnKey);

        }
        /* INSERT AnimalType*/
        public DataTable InsertAnimalTypeBAL(string AnimalTypeCd, string AnimalTypeName, string UserName, string INSERT, string ConnKey)
        {
            return objDist.insertAnimalTypeDAL(AnimalTypeCd, AnimalTypeName, UserName, INSERT, ConnKey);
        }

        /* Upadate AnimalType*/
        public DataTable UpdateAnimalTypeBAL(string AnimalTypeCd, string AnimalTypeName, string UserName, string UPDATE, string ConnKey)
        {
            return objDist.UpdateAnimalTypeDAL(AnimalTypeCd, AnimalTypeName, UserName, UPDATE, ConnKey);
        }
        /* Upadate AnimalType*/

        /*Delete AnimalType*/
        public DataTable DeleteAnimalBAL(string AnimalTypeCd, string AnimalTypeName, string DELETE, string ConnKey)
        {
            return objDist.DeleteAnimalDAL(AnimalTypeCd, AnimalTypeName, DELETE, ConnKey);

        }
        /* INSERT Instituion Type*/
        public DataTable InsertInstituionBAL(string InstituionCd, string InstituionName, int ACtiveSt, string UserName, string INSERT, string ConnKey)
        {
            return objDist.InsertInstituionDAL(InstituionCd, InstituionName, ACtiveSt, UserName, INSERT, ConnKey);
        }

        /* Upadate Instituion*/
        public DataTable UpdateInstituionBAL(string InstituionCd, string InstituionName, int ACtiveSt, string UserName, string UPDATE, string ConnKey)
        {
            return objDist.UpdateInstituionDAL(InstituionCd, InstituionName, ACtiveSt, UserName, UPDATE, ConnKey);
        }
        public DataTable DeleteInsTypeBAL(string InstituionCd, string Flag_IUP, string ConnKey)
        {
            return objDist.DeleteInsTypeDAL(InstituionCd, Flag_IUP, ConnKey);
        }
        public DataTable UpdateInstituionsBAL(string Unique_InstId, string InstituionName, string Vill, int ACtiveSt, string UserName, string UPDATE, string ConnKey)
        {
            return objDist.UpdateInstituionsDAL(Unique_InstId, InstituionName, Vill, ACtiveSt, UserName, UPDATE, ConnKey);
        }
        /*Insert Drug Master*/
        public DataTable getInsertDrugBAL(string DrugCd, string DrugName, string Unit, string UserName, string INSERT, string ConnKey)
        {
            return objDist.InsertDrugDAL(DrugCd, DrugName, Unit, UserName, INSERT, ConnKey);
        }
        public DataTable getUpdateDrugBAL(string DrugCd, string DrugName, string Unit, string UserName, string UPDATE, string ConnKey)
        {
            return objDist.UpdateDrugDAL(DrugCd, DrugName, Unit, UserName, UPDATE, ConnKey);
        }
        public DataTable DeleteDrugBAL(string DrugCd, string DrugName, string DELETE, string ConnKey)
        {
            return objDist.DeleteDrugDAL(DrugCd, DrugName, DELETE, ConnKey);
        }

        /* INSERT Instituions*/
        public DataTable InsertInstituionsBAL(string StateCode, string DistCode, string MandalCode, string InstypeCd, string Village, string Inscode, string InsName, DateTime Date, int ACtiveSt, string UserName, string INSERT, string ConnKey)
        {
            return objDist.InsertInstituionsDAL(StateCode, DistCode, MandalCode, InstypeCd, Village, Inscode, InsName, Date, ACtiveSt, UserName, INSERT, ConnKey);
        }
        /* INSERT RegFee*/
        public DataTable InsertRegfeeBAL(string InsCode,string AnimalCode, string RegFee, DateTime Date, string UserName, string INSERT, string ConnKey)
        {
            return objDist.InsertRegfeeDAL(InsCode, AnimalCode , RegFee, Date, UserName, INSERT, ConnKey);
        }

        public DataTable UpdateRegBAL(string InsCode,string AnimalCode, string RegFee, string UserName, DateTime Date, string UPDATE, string ConnKey)
        {
            return objDist.UpdateRegDAL(InsCode,AnimalCode, RegFee, UserName, Date, UPDATE, ConnKey);
        }
        public DataTable DeleteRegBAL(string InsCode, string AnimalCode, string RegFee, string DELETE, string ConnKey)
        {
            return objDist.DeleteRegDAL(InsCode,AnimalCode, RegFee, DELETE, ConnKey);
        }
        /*Supplier Master*/

        public DataTable InsertSuplyBAL(string StateCode, string Dcode, string Sname, string Saddress, string Email, string Mbno, int ACtiveSt, string UserName, string INSERT, string ConnKey)
        {
            return objDist.InsertSuplyDAL(StateCode, Dcode, Sname, Saddress, Email, Mbno, ACtiveSt, UserName, INSERT, ConnKey);
        }

        public DataTable UpdateSuplyBAL(string StateCode, string Dcode, string SupCode, string Sname, string Saddress, string Email, string Mbno, int ACtiveSt, string UserName, string UPDATE, string ConnKey)
        {
            return objDist.UpdateSuplyDAL(StateCode, Dcode, SupCode, Sname, Saddress, Email, Mbno, ACtiveSt, UserName, UPDATE, ConnKey);
        }
        public DataTable DeleteSuplyBAL(string SupCode, string Flag_IUP, string ConnKey)
        {
            return objDist.DeleteSuplyDAL(SupCode, Flag_IUP, ConnKey);
        }

        /*Pharmacy Receipt of Drugs */
        //public DataTable getdrug1(string UniqueInstId)
        //{
        //    return objDist.getdrugDAL1(UniqueInstId);
        //}


        /*View Institution*/

        public DataTable viewInstitutionsdataBAL(string StateCode, string DistCode, string ConnKey)
        {
            return objDist.viewInstitutionsdataDAL(StateCode, DistCode, ConnKey);
        }
        public DataTable getIns(string ConnKey)
        {
            return objDist.viewInsDAL( ConnKey);
        }
        public DataTable getIns1(string StateCode, string DistCode, string MandalCode, string InsType, string ConnKey)
        {
            return objDist.viewInstitutiondataDAL1(StateCode, DistCode, MandalCode, InsType, ConnKey);
        }
        public DataTable viewDRegBAL(string Inscd, string Flag_IUP, string ConnKey)
        {
            return objDist.viewDRegDAL(Inscd, Flag_IUP, ConnKey);
        }
        public DataTable getstate(string ConnKey)
        {
            return objDist.getstateDAL( ConnKey);
        }
        public DataTable viewDistdataBAL(string DistCode, string Flag_IUP, string ConnKey)
        {
            return objDist.viewDistdataDAL(DistCode, Flag_IUP, ConnKey);
        }
        //public DataTable viewDistdataBAL1(string DistCode)
        //{
        //    return objDist.viewDistdataDAL1(DistCode);
        //}

        public DataTable FetcIssueOfDrugDtlsBAL(string Rergno, string Date, string ConnKey)
        {
            return objDist.FetcIssueOfDrugDtlsDAL(Rergno, Date, ConnKey);
        }
        public DataTable viewAnimaldataBAL1(string Flag_IUP, string ConnKey)
        {
            return objDist.viewAnimaldataDAL1(Flag_IUP, ConnKey);
        }
        public DataTable viewAnimaldataBAL(string ConnKey)
        {
            return objDist.viewAnimaldataDAL( ConnKey);
        }
        public DataTable viewdDrugBAL(string GData, string ConnKey)
        {
            return objDist.viewdDrugDAL(GData, ConnKey);
        }
        public DataTable viewSupplierBAL(string Statecd, string Dcode, string GData, string ConnKey)
        {
            return objDist.viewSupplierDAL(Statecd, Dcode, GData, ConnKey);
        }
        public DataTable viewInstitutiondataBAL(string ConnKey)
        {
            return objDist.viewInstitutiondataDAL(ConnKey);
        }
        /*Get User TYpe */
        public DataTable GetUserTypeBAL(string ConnKey)
        {
            return objDist.GetUserTypeDAL(ConnKey);
        }

        /*State Master */

        /* View State details */
        public DataTable viewStatedataBAL( string ConnKey)
        {
            return objDist.viewStatedataDAL( ConnKey);
        }

        /* Insert Disease details */

        public DataTable InsertStateBAL(string SateCode, string StateName, string INSERT, string ConnKey)
        {
            return objDist.InsertStateDAL(SateCode, StateName, INSERT, ConnKey);
        }

        /* Upadate Disease Type*/
        public DataTable UpdateStateBAL(string SateCode, string StateName, string UPDATE, string ConnKey)
        {
            return objDist.UpdateStateDAL(SateCode, StateName, UPDATE, ConnKey);
        }

        /*Delete Disease Type*/
        public DataTable DeleteStateBAL(string SateCode, string StateName, string DELETE, string ConnKey)
        {
            return objDist.DeleteStateDAL(SateCode, StateName, DELETE, ConnKey);

        }

        /* Disease Master */

        /* View Disease details */
        public DataTable viewDiseasedataBAL( string ConnKey)
        {
            return objDist.viewDiseasedataDAL( ConnKey);
        }

        /* Insert Disease details */

        public DataTable InsertDiseaseTypeBAL(string DiseaseTypeCd, string DiseaseTypeName, string UserName, string INSERT, string ConnKey)
        {
            return objDist.insertDiseaseTypeDAL(DiseaseTypeCd, DiseaseTypeName, UserName, INSERT, ConnKey);
        }

        /* Upadate Disease Type*/
        public DataTable UpdateDiseaseTypeBAL(string DiseaseTypeCd, string DiseaseTypeName, string UserName, string UPDATE, string ConnKey)
        {
            return objDist.UpdateDiseaseTypeDAL(DiseaseTypeCd, DiseaseTypeName, UserName, UPDATE, ConnKey);
        }


        /*Delete Disease Type*/
        public DataTable DeleteDiseaseBAL(string DiseaseTypeCd, string DiseaseTypeName, string DELETE, string ConnKey)
        {
            return objDist.DeleteDiseaseDAL(DiseaseTypeCd, DiseaseTypeName, DELETE, ConnKey);

        }
        /*GET DISTRICTS BY STATECODE*/
        public DataTable getDistrictsByStateCodeBAL(String StateCode, string ConnKey)
        {
            return objDist.getDistrictsByStateCodeDAL(StateCode, ConnKey);
        }
        /*GET BREED BY ANIMAL TYPE CODE*/
        public DataTable getBreedByAnimalTypeBAL(String AnimalTypeCode, string ConnKey)
        {
            return objDist.getBreedByAnimalTypeDAL(AnimalTypeCode, ConnKey);
        }
        /*GET MANDALS BY DIST CODE*/
        public DataTable getMandalsByDistCodeBAL(String DistCode, string ConnKey)
        {
            return objDist.getMandalsByDistCodeDAL(DistCode, ConnKey);
        }
        /* USer Creation */
       // public DataTable InserUserBAL(string StateCode, string DCode, string MCode, string InsCode, string InsTCode, string Role, string UName, string Pwd, DateTime dateAndTime, string ipAddress)
        //{
        //    return objDist.InserUserDAL(StateCode, DCode, MCode, InsCode, InsTCode, Role, UName, Pwd, dateAndTime, ipAddress);
        //} 
        public DataTable InserUserBAL(string StateCode, string DCode, string MCode, string InsCode, string InsTCode, string Role, string UName, string Pwd, DateTime dateAndTime, string IpAddress, string ConnKey)
        {
            return objDist.InserUserDAL(StateCode, DCode, MCode, InsCode, InsTCode, Role, UName, Pwd, dateAndTime, IpAddress, ConnKey);
        }
        public DataTable ViewGridDataBAL(string StateCode, string DCode, string MCode, string InsCode, string InsTCode,string Role, string ConnKey)
        {
            return objDist.ViewGridDataDAL(StateCode, DCode, MCode, InsCode, InsTCode,Role, ConnKey);
        }
        /*DiagTestFeeMaster */

        /* View DiagTestFee details */
        public DataTable viewDiagBAL(string UniqueInsId, string ConnKey)
        {
            return objDist.viewDiagDAL(UniqueInsId,ConnKey);
        }

        /* Insert DiagTestFee details */

        public DataTable InsertDiagBAL(string UniqueInsId , string TestCd, string TestFee, string FeePaid, string UserName, string ConnKey)
        {
            return objDist.InsertDiagDAL(UniqueInsId ,TestCd,TestFee, FeePaid, UserName, ConnKey);
        }

        public DataTable UpdateDiagBAL(string UniqueInsId, string TestCd, string TestFee, string FeePaid, string UserName, string ConnKey)
        {
            return objDist.UpdateDiagDAL(UniqueInsId ,TestCd, TestFee, FeePaid, UserName, ConnKey);
        }
        public DataTable DeleteDiagBAL(string UniqueInsId , string TestCd, string ConnKey)
        {
            return objDist.DeleteDiagDAL(UniqueInsId,TestCd, ConnKey);
        }
        /* END Diagstics Details*/
        /*BREED MASTER INSERT UPADATE DELETE RETRIVE*/
        /*GRID VIEW BREED DETAILS */


        public DataTable viewBreedDtlsBAL(string AnimalTypeCd, string ConnKey)
        {
            return objDist.viewBreedDtlsDAL(AnimalTypeCd, ConnKey);
        }
        /*DELETE BREED DETAILS*/
        public DataTable DeleteBreedBAL(string AnimalTypeCode, string BreedCd, string ConnKey)
        {
            return objDist.DeleteBreedDAL(AnimalTypeCode, BreedCd, ConnKey);
        }
          /* Insert Animal Breed details */

        public DataTable InsertBreedBAL(string BreedCd, string AnimalType, string BreedNm, string UserName, string ConnKey)
        {
            return objDist.InsertBreedDAL(BreedCd, AnimalType, BreedNm, UserName, ConnKey);
        }
        public DataTable UpdateBreedBAL(string BreedCd, string AnimalType, string BreedNm, string UserName, string ConnKey)
        {
            return objDist.UpdateBreedDAL(BreedCd, AnimalType, BreedNm, UserName, ConnKey);
        }
        
        /* END Animal Breed Details*/

        /*FETCH INSTITUTIONS BY DIST CODE*/
        public DataTable GetInstByDistCodeBAL(string StateCode, string DistCode, string ConnKey)
        {
            return objDist.GetInstByDistCodeDAL(StateCode, DistCode, ConnKey);
        }
        /*FETCH REG NOS BY INSTITUTION*/
        public DataTable GetRegNosByInstIdBAL(string UniqueInsId, DateTime SelDt, string ConnKey)
        {
            return objDist.GetRegNosByInstIdDAL(UniqueInsId, SelDt, ConnKey);
        }

        /*UOM INSERT UPDATE DELETE SELECT*/

        public DataTable InsertUomBAL(string UnitCd, string UnitName, string UserName, string INSERT, string ConnKey)
        {
            return objDist.InsertUomDAL(UnitCd, UnitName, UserName, INSERT, ConnKey);
        }
        public DataTable UpdateUomBAL(string UnitCd, string UnitName, string UserName, string UPDATE, string ConnKey)
        {
            return objDist.UpdateUomDAL(UnitCd, UnitName, UserName, UPDATE, ConnKey);
        }
        public DataTable DeleteUomBAL(string UnitCd, string UnitName, string DELETE, string ConnKey)
        {
            return objDist.DeleteUomDAL(UnitCd, UnitName, DELETE, ConnKey);

        }
        public DataTable viewUomdataBAL( string ConnKey)
        {
            return objDist.viewUomdataDAL( ConnKey);
        }
        public DataTable DiagTest_IUDR_BAL(string DiagTestCode, string DiagTestName, string Action, string UserName, string ConnKey)
        {
            return objDist.DiagTest_IUDR_DAL(DiagTestCode, DiagTestName , Action, UserName, ConnKey);
        }
        public DataTable GetDiagTestDtls_ByUniqueInsIdBAL(string UniqueInsId, string ConnKey)
        {
            return objDist.GetDiagTestDtls_ByUniqueInsIdDAL(UniqueInsId, ConnKey);
        }
        public DataTable GetAnimalType_ForRegFeeByUniqueInsIdBAL(string UniqueInsId, string ConnKey)
        {
            return objDist.GetAnimalType_ForRegFeeByUniqueInsIdDAL(UniqueInsId, ConnKey);
        }
        public DataTable GetPurposeBAL(string ConnKey)
        {
            return objDist.GetPurposeDAL(ConnKey);
        }
        public DataTable GetDoctorBAL(string ConnKey)
        {
            return objDist.GetDoctorDAL(ConnKey);
        }
        public DataTable GetCategoryBAL(string ConnKey)
        {
            return objDist.GetCategoryDAL(ConnKey);
        }
        public DataTable GetDivisionBAL(string StateCode, string ConnKey)
        {
            return objDist.GetDivisionDAL(StateCode,ConnKey);
        }
        /*GET DISTRICTS BY Division Code*/

        public DataTable getDistrictsByDivisionBAL(String StateCode,string divisioncd, string ConnKey)
        {
            return objDist.getDistrictsByDivisionDAL(StateCode, divisioncd, ConnKey);
        }
        public DataTable SchemeMst_IUDR_BAL(MasterBE objBE, string ConnKey)
        {
            return objDist.SchemeMst_IUDR_DAL(objBE, ConnKey);
        }

        public DataTable GetVillageBAL(string DistCode, string MandalCode, string ConnKey)
        {
            return objDist.GetVillageDAL(DistCode, MandalCode, ConnKey);


        }
    }
}
