using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TSVUVHMS_BE;
namespace TSVUVHMS_DL
{
    public class InstutionDAL
    {
        /*GET Institution Details*/
        public DataTable GetInsNameDAL(string Unique_InsId, string UserName, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetInsDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = Unique_InsId;
                    da.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetInsNameDAL1(string Unique_InsId, string UserName, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetInsDetails1", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = Unique_InsId;
                    da.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = UserName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }
        /* INSERT PatientReg*/
        public DataTable InsertPaitentDAL(string Unique_InsId, DateTime Vdate, string Doctor, string Atype, string Breed, string AgeInYear, string AgeInMonth, int Gender, string AnimalOwner, string StateCode,
            string Dcode, string Mcode, string Village, string mbno, string ExemptedCat, string Regfee, string UserName, string INSERT, string Purpose, string visittype, string nos, string aadharno, string category, string divisioncd, string ConnKey, string DoctorID)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("PaitentDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Vdate", SqlDbType.Date).Value = Vdate;
                    da.SelectCommand.Parameters.Add("@Doctor", SqlDbType.Date).Value = Doctor;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = Unique_InsId;
                    da.SelectCommand.Parameters.Add("@Atype", SqlDbType.VarChar).Value = Atype;
                    da.SelectCommand.Parameters.Add("@BreedCode", SqlDbType.VarChar).Value = Breed;
                    da.SelectCommand.Parameters.Add("@AgeInYear", SqlDbType.Int).Value = AgeInYear;
                    da.SelectCommand.Parameters.Add("@AgeInmonth", SqlDbType.Int).Value = AgeInMonth;
                    da.SelectCommand.Parameters.Add("@Gender", SqlDbType.Char).Value = Gender;
                    da.SelectCommand.Parameters.Add("@AnimalOwner", SqlDbType.VarChar).Value = AnimalOwner;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@Dcode", SqlDbType.VarChar).Value = Dcode;
                    da.SelectCommand.Parameters.Add("@Mcode", SqlDbType.VarChar).Value = Mcode;
                    da.SelectCommand.Parameters.Add("@Village", SqlDbType.VarChar).Value = Village;
                    da.SelectCommand.Parameters.Add("@Mbno", SqlDbType.VarChar).Value = mbno;
                    da.SelectCommand.Parameters.Add("@ExemptedCatgeory", SqlDbType.VarChar).Value = ExemptedCat;
                    da.SelectCommand.Parameters.Add("@Regfee", SqlDbType.VarChar).Value = Regfee;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;
                    da.SelectCommand.Parameters.Add("@aadharno", SqlDbType.Char).Value = aadharno;
                    da.SelectCommand.Parameters.Add("@purpose", SqlDbType.Char).Value = Purpose;
                    da.SelectCommand.Parameters.Add("@category", SqlDbType.Char).Value = category;
                    da.SelectCommand.Parameters.Add("@nos", SqlDbType.Char).Value = nos;
                    da.SelectCommand.Parameters.Add("@typeofvisit", SqlDbType.Char).Value = visittype;
                    da.SelectCommand.Parameters.Add("@divisioncd", SqlDbType.Char).Value = divisioncd;
                    da.SelectCommand.Parameters.Add("@Doctor_Id", SqlDbType.VarChar).Value = DoctorID;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
            }

        }
        /* UPDATE PatientReg*/
        public DataTable UpdatePaitentDAL(string RegNo, int Gender, string AgeInYear, string AgeInMonth, string RegFee, string AnimalOwner, string BreedCode, DateTime Vdate, string StateCode, string Dcode,
            string Mcode, string Village, string mbno, string UserName, string UPDATE, string Purpose, string visittype, string nos, string aadharno, string category, string divisioncd, string ConnKey, string DoctorID)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("PaitentDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Vdate", SqlDbType.Date).Value = Vdate;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = RegNo;
                    da.SelectCommand.Parameters.Add("@Gender", SqlDbType.Char).Value = Gender;
                    da.SelectCommand.Parameters.Add("@BreedCode", SqlDbType.VarChar).Value = BreedCode;
                    da.SelectCommand.Parameters.Add("@AgeInYear", SqlDbType.Int).Value = AgeInYear;
                    da.SelectCommand.Parameters.Add("@AgeInmonth", SqlDbType.Int).Value = AgeInMonth;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@Dcode", SqlDbType.VarChar).Value = Dcode;
                    da.SelectCommand.Parameters.Add("@Mcode", SqlDbType.VarChar).Value = Mcode;
                    da.SelectCommand.Parameters.Add("@Village", SqlDbType.VarChar).Value = Village;
                    da.SelectCommand.Parameters.Add("@Regfee", SqlDbType.Int).Value = RegFee;
                    da.SelectCommand.Parameters.Add("@AnimalOwner", SqlDbType.VarChar).Value = AnimalOwner;
                    da.SelectCommand.Parameters.Add("@Mbno", SqlDbType.VarChar).Value = mbno;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = UPDATE;
                    da.SelectCommand.Parameters.Add("@aadharno", SqlDbType.Char).Value = aadharno;
                    da.SelectCommand.Parameters.Add("@purpose", SqlDbType.Char).Value = Purpose;
                    da.SelectCommand.Parameters.Add("@category", SqlDbType.Char).Value = category;
                    da.SelectCommand.Parameters.Add("@nos", SqlDbType.Char).Value = nos;
                    da.SelectCommand.Parameters.Add("@typeofvisit", SqlDbType.Char).Value = visittype;
                    da.SelectCommand.Parameters.Add("@divisioncd", SqlDbType.Char).Value = divisioncd;
                    da.SelectCommand.Parameters.Add("@Doctor_Id", SqlDbType.VarChar).Value = DoctorID;
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
                using (SqlDataAdapter da = new SqlDataAdapter("FetchPatientDtls_ReVisit", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = Rergno;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*REPORT - CASE SHEET */
        public DataTable RptCaseSheetDAL(string Rergno, string VisitDate, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_PatientCaseSheet", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = Rergno;
                    da.SelectCommand.Parameters.Add("@VisitDate", SqlDbType.Date).Value = VisitDate;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }
        /*Fetch Visit Dates By Reg No*/
        public DataTable GetVisitDatesByRegNoDAL(string Regno, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchVisitDates_ByRegNo", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = Regno;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Fetch PatientReg Based On Mobile Number*/
        public DataTable AnimaldetailsMbnoDAL(string UniqueInsId, string Mbno, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchPatients_Mbno", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@MbNo", SqlDbType.VarChar).Value = Mbno;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }
        /* Fetch Animal Details AnimalType is ALL */
        public DataTable GetAnimalReportDAL(string UniqueInstId, string AnimalType, DateTime FromDate, DateTime ToDate, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("AnimalDetalis_RDLC", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.VarChar).Value = AnimalType;
                    da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                    da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "A";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Fetch Animal Details AnimalType is DropDown Selection Value */
        public DataTable GetAtypeDAL(string UniqueInstId, string AnimalTypecd, DateTime FromDate, DateTime ToDate, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("AnimalDetalis_RDLC", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.VarChar).Value = AnimalTypecd;
                    da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                    da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "R";



                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }
        public DataTable GetAtypeRptDAL(string UniqueInstId, string AnimalTypecd, string Status, DateTime FromDate, DateTime ToDate, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("AnimalDetalis_RDLC", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.VarChar).Value = AnimalTypecd;
                    da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                    da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Status;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Total animal details with respective of animal type */
        public DataTable GetAtypeALLDAL(string UniqueInstId, DateTime FromDate, DateTime ToDate, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("AnimalDetalis_RDLC", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                    da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "T";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }
        public DataTable GetAtypeALL1DAL(string UniqueInstId, DateTime FromDate, DateTime ToDate, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_DetailsReport", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = FromDate;
                    da.SelectCommand.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = ToDate;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "T";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*GET Institution Registration Fee Details*/

        public DataTable GetRegFeeDAL(string UniqueInstId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetRegDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInstId", SqlDbType.VarChar).Value = UniqueInstId;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*GET Registration Fee Details BY INSTITUTION AND ANIMAL TYPE*/

        public DataTable GetRegFee_ByAnimalTypeDAL(string UniqueInstId, string AnimalTypeCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetRegDetails_ByAnimalType", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInstId", SqlDbType.VarChar).Value = UniqueInstId;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.VarChar).Value = AnimalTypeCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /*GET Animal Details*/
        public DataTable viewAnimaldataDAL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("AnimalDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.VarChar).Value = "S";

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
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_FeeCollected_ByIns", con))
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



        public DataTable FetchPaitentVisitCountDAL(string Uniq_InstId, DateTime FromDt, DateTime ToDt, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_Visit_ReVisitCnt_ByIns", con))
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
        public DataTable GetRegNoDAL(string Uniq_InstId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchRegNoByInstitutions", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = Uniq_InstId;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetRegNoDrugIssueStatusDAL(DateTime Date, string RegNo, string Uniq_InstId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("PatientDrugIssuesStatus", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = RegNo;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = Uniq_InstId;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }
        public DataTable FetchPaitentVisitCount_AbstractDAL(string Uniq_InstId, string FromYr, string FromMnth, string ToYr, string ToMnth, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Rpt_Visit_ReVisitCnt_ByIns_Abstract", con))
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
        public DataTable DoctorDetailsDAL(Patientdet obj, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DoctorDetails", con))
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DoctorID", SqlDbType.Int).Value = obj.DoctorID;
                    da.SelectCommand.Parameters.Add("@Doctor", SqlDbType.VarChar).Value = obj.Doctor;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
            }

        }
        public DataTable InsertPaitentUKDAL(Patientdet obj, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("PaitentDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Vdate", SqlDbType.Date).Value = obj.Vdate;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = obj.Unique_InsId;
                    da.SelectCommand.Parameters.Add("@Atype", SqlDbType.VarChar).Value = obj.Atype;
                    da.SelectCommand.Parameters.Add("@Doctor", SqlDbType.VarChar).Value = obj.Doctor;
                    da.SelectCommand.Parameters.Add("@BreedCode", SqlDbType.VarChar).Value = obj.Breed;
                    da.SelectCommand.Parameters.Add("@AgeInYear", SqlDbType.Int).Value = obj.AgeInYear;
                    da.SelectCommand.Parameters.Add("@AgeInmonth", SqlDbType.Int).Value = obj.AgeInMonth;
                    da.SelectCommand.Parameters.Add("@Gender", SqlDbType.Char).Value = obj.Gender;
                    da.SelectCommand.Parameters.Add("@AnimalOwner", SqlDbType.VarChar).Value = obj.AnimalOwner;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = obj.StateCode;
                    da.SelectCommand.Parameters.Add("@Dcode", SqlDbType.VarChar).Value = obj.Distcode;
                    da.SelectCommand.Parameters.Add("@Mcode", SqlDbType.VarChar).Value = obj.Mandcode;
                    da.SelectCommand.Parameters.Add("@Village", SqlDbType.VarChar).Value = obj.Village;
                    da.SelectCommand.Parameters.Add("@Mbno", SqlDbType.VarChar).Value = obj.Mobileno;
                    da.SelectCommand.Parameters.Add("@ExemptedCatgeory", SqlDbType.VarChar).Value = obj.ExemptedCategory;
                    da.SelectCommand.Parameters.Add("@Regfee", SqlDbType.VarChar).Value = obj.Regfee;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = obj.UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = obj.Flag;

                    da.SelectCommand.Parameters.Add("@aadharno", SqlDbType.Char).Value = obj.aadharno;
                    da.SelectCommand.Parameters.Add("@purpose", SqlDbType.Char).Value = obj.Purpose;
                    da.SelectCommand.Parameters.Add("@category", SqlDbType.Char).Value = obj.category;
                    da.SelectCommand.Parameters.Add("@nos", SqlDbType.Char).Value = obj.nos;
                    da.SelectCommand.Parameters.Add("@typeofvisit", SqlDbType.Char).Value = obj.visittype;
                    da.SelectCommand.Parameters.Add("@divisioncd", SqlDbType.Char).Value = obj.divisioncd;
                    da.SelectCommand.Parameters.Add("@villagecd", SqlDbType.Char).Value = obj.villagecd;
                    da.SelectCommand.Parameters.Add("@Doctor_Id", SqlDbType.VarChar).Value = obj.DoctorID;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
            }

        }
        public DataTable InsertPaitentAllDAL(Patientdet obj, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("PaitentDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Vdate", SqlDbType.Date).Value = obj.Vdate;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = obj.Unique_InsId;
                    da.SelectCommand.Parameters.Add("@Atype", SqlDbType.VarChar).Value = obj.Atype;
                    da.SelectCommand.Parameters.Add("@Doctor", SqlDbType.VarChar).Value = obj.Doctor;
                    da.SelectCommand.Parameters.Add("@BreedCode", SqlDbType.VarChar).Value = obj.Breed;
                    da.SelectCommand.Parameters.Add("@AgeInYear", SqlDbType.Int).Value = obj.AgeInYear;
                    da.SelectCommand.Parameters.Add("@AgeInmonth", SqlDbType.Int).Value = obj.AgeInMonth;
                    da.SelectCommand.Parameters.Add("@Gender", SqlDbType.Char).Value = obj.Gender;
                    da.SelectCommand.Parameters.Add("@AnimalOwner", SqlDbType.VarChar).Value = obj.AnimalOwner;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = obj.StateCode;
                    da.SelectCommand.Parameters.Add("@Dcode", SqlDbType.VarChar).Value = obj.Distcode;
                    da.SelectCommand.Parameters.Add("@Mcode", SqlDbType.VarChar).Value = obj.Mandcode;
                    da.SelectCommand.Parameters.Add("@Village", SqlDbType.VarChar).Value = obj.Village;
                    da.SelectCommand.Parameters.Add("@Mbno", SqlDbType.VarChar).Value = obj.Mobileno;
                    da.SelectCommand.Parameters.Add("@ExemptedCatgeory", SqlDbType.VarChar).Value = obj.ExemptedCategory;
                    da.SelectCommand.Parameters.Add("@Regfee", SqlDbType.VarChar).Value = obj.Regfee;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = obj.UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = obj.Flag;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = obj.RegNo;
                    da.SelectCommand.Parameters.Add("@Doctor_Id", SqlDbType.VarChar).Value = obj.DoctorID;
                    //da.SelectCommand.Parameters.Add("@aadharno", SqlDbType.Char).Value = obj.aadharno;
                    //da.SelectCommand.Parameters.Add("@purpose", SqlDbType.Char).Value = obj.Purpose;
                    //da.SelectCommand.Parameters.Add("@category", SqlDbType.Char).Value = obj.category;
                    //da.SelectCommand.Parameters.Add("@nos", SqlDbType.Char).Value = obj.nos;
                    //da.SelectCommand.Parameters.Add("@typeofvisit", SqlDbType.Char).Value = obj.visittype;
                    //da.SelectCommand.Parameters.Add("@divisioncd", SqlDbType.Char).Value = obj.divisioncd;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }
            }

        }
        public DataTable UpdatePaitentUKDAL(Patientdet obj, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("PaitentDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Vdate", SqlDbType.Date).Value = obj.Vdate;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = obj.RegNo;
                    da.SelectCommand.Parameters.Add("@Gender", SqlDbType.Char).Value = obj.Gender;
                    da.SelectCommand.Parameters.Add("@Doctor", SqlDbType.VarChar).Value = obj.Doctor;
                    da.SelectCommand.Parameters.Add("@BreedCode", SqlDbType.VarChar).Value = obj.Breed;
                    da.SelectCommand.Parameters.Add("@AgeInYear", SqlDbType.Int).Value = obj.AgeInYear;
                    da.SelectCommand.Parameters.Add("@AgeInmonth", SqlDbType.Int).Value = obj.AgeInMonth;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = obj.StateCode;
                    da.SelectCommand.Parameters.Add("@Dcode", SqlDbType.VarChar).Value = obj.Distcode;
                    da.SelectCommand.Parameters.Add("@Mcode", SqlDbType.VarChar).Value = obj.Mandcode;
                    da.SelectCommand.Parameters.Add("@Village", SqlDbType.VarChar).Value = obj.Village;
                    da.SelectCommand.Parameters.Add("@Regfee", SqlDbType.Int).Value = obj.Regfee;
                    da.SelectCommand.Parameters.Add("@AnimalOwner", SqlDbType.VarChar).Value = obj.AnimalOwner;
                    da.SelectCommand.Parameters.Add("@Mbno", SqlDbType.VarChar).Value = obj.Mobileno;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = obj.UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = obj.Flag;
                    da.SelectCommand.Parameters.Add("@aadharno", SqlDbType.Char).Value = obj.aadharno;
                    da.SelectCommand.Parameters.Add("@purpose", SqlDbType.Char).Value = obj.Purpose;
                    da.SelectCommand.Parameters.Add("@category", SqlDbType.Char).Value = obj.category;
                    da.SelectCommand.Parameters.Add("@nos", SqlDbType.Char).Value = obj.nos;
                    da.SelectCommand.Parameters.Add("@typeofvisit", SqlDbType.Char).Value = obj.visittype;
                    da.SelectCommand.Parameters.Add("@divisioncd", SqlDbType.Char).Value = obj.divisioncd;
                    da.SelectCommand.Parameters.Add("@villagecd", SqlDbType.Char).Value = obj.villagecd;
                    da.SelectCommand.Parameters.Add("@Doctor_Id", SqlDbType.VarChar).Value = obj.DoctorID;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }

        public DataTable UpdatePaitentALLDAL(Patientdet obj, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("PaitentDetails", con))
                {

                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Vdate", SqlDbType.Date).Value = obj.Vdate;
                    da.SelectCommand.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = obj.RegNo;
                    da.SelectCommand.Parameters.Add("@Gender", SqlDbType.Char).Value = obj.Gender;
                    da.SelectCommand.Parameters.Add("@BreedCode", SqlDbType.VarChar).Value = obj.Breed;
                    da.SelectCommand.Parameters.Add("@AgeInYear", SqlDbType.Int).Value = obj.AgeInYear;
                    da.SelectCommand.Parameters.Add("@AgeInmonth", SqlDbType.Int).Value = obj.AgeInMonth;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = obj.StateCode;
                    da.SelectCommand.Parameters.Add("@Dcode", SqlDbType.VarChar).Value = obj.Distcode;
                    da.SelectCommand.Parameters.Add("@Mcode", SqlDbType.VarChar).Value = obj.Mandcode;
                    da.SelectCommand.Parameters.Add("@Village", SqlDbType.VarChar).Value = obj.Village;
                    da.SelectCommand.Parameters.Add("@Regfee", SqlDbType.Int).Value = obj.Regfee;
                    da.SelectCommand.Parameters.Add("@AnimalOwner", SqlDbType.VarChar).Value = obj.AnimalOwner;
                    da.SelectCommand.Parameters.Add("@Mbno", SqlDbType.VarChar).Value = obj.Mobileno;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = obj.UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = obj.Flag;
                    da.SelectCommand.Parameters.Add("@Doctor_Id", SqlDbType.VarChar).Value = obj.DoctorID;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }

        }

    }

}
