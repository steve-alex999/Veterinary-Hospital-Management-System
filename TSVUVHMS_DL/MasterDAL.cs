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


    public class MasterDAL
    {
        /* District Details INSERT UPADATE DELETE RETRIEV */
        public DataTable insertDistDAL(string StateCode, string DistCode, string DistName, DateTime Date, int ACtiveSt, string UserName, string Insert, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DistrictMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@DistName", SqlDbType.VarChar).Value = DistName;
                    da.SelectCommand.Parameters.Add("@EffectiveDt", SqlDbType.Date).Value = Date;
                    da.SelectCommand.Parameters.Add("@Active", SqlDbType.Int).Value = ACtiveSt;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "I";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable getnumber(string Maxnumder, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetNumber", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Maxnumder", SqlDbType.VarChar).Value = Maxnumder;



                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable viewdataDAL(string StateCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DistrictMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "R";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable UpdateDistDAL(string StateCode, string DistCode, string DistName, int ACtiveSt, string UserName, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DistrictMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@DistName", SqlDbType.VarChar).Value = DistName;
                    da.SelectCommand.Parameters.Add("@Active", SqlDbType.Int).Value = ACtiveSt;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "U";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable DeletedistrictDAL(string statecode, string distcode, string distname, string Flag_IUP, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DistrictMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = statecode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = distcode;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "D";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /* END District */

        /* Mandal Details INSERT UPADATE DELETE RETRIEV */
        public DataTable insertMandaltDAL(string DistCode, string MandalCode, string MandalName, DateTime Date, int ACtiveSt, string UserName, string INSERT, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("MandalDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = MandalCode;
                    da.SelectCommand.Parameters.Add("@MandalName", SqlDbType.VarChar).Value = MandalName;
                    da.SelectCommand.Parameters.Add("@Date", SqlDbType.Date).Value = Date;
                    da.SelectCommand.Parameters.Add("@ACtiveSt", SqlDbType.Int).Value = ACtiveSt;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable UpdateMandaltDAL(string DistCode, string MandalCode, string MandalName, int ACtiveSt, string UserName, string UPDATE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("MandalDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = MandalCode;
                    da.SelectCommand.Parameters.Add("@MandalName", SqlDbType.VarChar).Value = MandalName;
                    da.SelectCommand.Parameters.Add("@ACtiveSt", SqlDbType.Int).Value = ACtiveSt;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable DeletemandalDAL(string DistCode, string MandalCode, string MandalName, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("MandalDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = MandalCode;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = "D";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable viewDistdataDAL(string DistCode, string Flag_IUP, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("MandalDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.VarChar).Value = Flag_IUP;



                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* End Mandal*/

        /* AnimalType Details INSERT UPADATE DELETE RETRIEV */
        public DataTable insertAnimalTypeDAL(string AnimalTypeCd, string AnimalTypeName, string UserName, string INSERT, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("AnimalDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCd", SqlDbType.VarChar).Value = AnimalTypeCd;
                    da.SelectCommand.Parameters.Add("@AnimalTypeName", SqlDbType.VarChar).Value = AnimalTypeName;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable UpdateAnimalTypeDAL(string AnimalTypeCd, string AnimalTypeName, string UserName, string UPDATE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("AnimalDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCd", SqlDbType.VarChar).Value = AnimalTypeCd;
                    da.SelectCommand.Parameters.Add("@AnimalTypeName", SqlDbType.VarChar).Value = AnimalTypeName;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* DELETE Animal Type*/
        public DataTable DeleteAnimalDAL(string AnimalTypeCd, string AnimalTypeName, string DELETE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("AnimalDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCd", SqlDbType.VarChar).Value = AnimalTypeCd;
                    da.SelectCommand.Parameters.Add("@AnimalTypeName", SqlDbType.VarChar).Value = AnimalTypeName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.VarChar).Value = DELETE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }

            }

        }
        public DataTable viewAnimaldataDAL1(string Flag_IUP, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("AnimalDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.VarChar).Value = Flag_IUP;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* End Animal Detals*/
        public DataTable InsertInstituionDAL(string InstituionCd, string InstituionName, int ACtiveSt, string UserName, string INSERT, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InstituionTypeDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@InstituionCd", SqlDbType.VarChar).Value = InstituionCd;
                    da.SelectCommand.Parameters.Add("@InstituionName", SqlDbType.VarChar).Value = InstituionName;
                    da.SelectCommand.Parameters.Add("@ACtiveSt", SqlDbType.Int).Value = ACtiveSt;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable UpdateInstituionDAL(string InstituionCd, string InstituionName, int ACtiveSt, string UserName, string UPDATE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InstituionTypeDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@InstituionCd", SqlDbType.VarChar).Value = InstituionCd;
                    da.SelectCommand.Parameters.Add("@InstituionName", SqlDbType.VarChar).Value = InstituionName;
                    da.SelectCommand.Parameters.Add("@ACtiveSt", SqlDbType.Int).Value = ACtiveSt;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable DeleteInsTypeDAL(string InstituionCd, string Flag_IUP, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InstituionTypeDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@InstituionCd", SqlDbType.VarChar).Value = InstituionCd;

                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = Flag_IUP;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable UpdateInstituionsDAL(string Unique_InstId, string InstituionName, string Vill, int ACtiveSt, string UserName, string UPDATE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InstituionsDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InstId", SqlDbType.VarChar).Value = Unique_InstId;
                    da.SelectCommand.Parameters.Add("@InstituionName", SqlDbType.VarChar).Value = InstituionName;
                    da.SelectCommand.Parameters.Add("@Village", SqlDbType.VarChar).Value = Vill;
                    // da.SelectCommand.Parameters.Add("@RegFee", SqlDbType.VarChar).Value = Regfee;
                    da.SelectCommand.Parameters.Add("@ACtiveSt", SqlDbType.Int).Value = ACtiveSt;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /* Drug Details*/
        public DataTable InsertDrugDAL(string DrugCd, string DrugName, string Unit, string UserName, string INSERT, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DrugMaster", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DrugCd", SqlDbType.VarChar).Value = DrugCd;
                    da.SelectCommand.Parameters.Add("@DrugName", SqlDbType.VarChar).Value = DrugName;
                    da.SelectCommand.Parameters.Add("@Unit", SqlDbType.VarChar).Value = Unit;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable UpdateDrugDAL(string DrugCd, string DrugName, string Unit, string UserName, string UPDATE, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DrugMaster", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DrugCd", SqlDbType.VarChar).Value = DrugCd;
                    da.SelectCommand.Parameters.Add("@DrugName", SqlDbType.VarChar).Value = DrugName;
                    da.SelectCommand.Parameters.Add("@Unit", SqlDbType.VarChar).Value = Unit;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable DeleteDrugDAL(string DrugCd, string DrugName, string DELETE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("DrugMaster", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DrugCd", SqlDbType.VarChar).Value = DrugCd;
                    da.SelectCommand.Parameters.Add("@DrugName", SqlDbType.VarChar).Value = DrugName;

                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = DELETE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*End DrugDetails*/
        public DataTable InsertRegfeeDAL(string InsCode,string AnimalCode, string RegFee, DateTime Date, string UserName, string INSERT, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RegMaster", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@InsCd", SqlDbType.VarChar).Value = InsCode;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.VarChar).Value = AnimalCode;
                    da.SelectCommand.Parameters.Add("@Regfee", SqlDbType.VarChar).Value = RegFee;
                    da.SelectCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable UpdateRegDAL(string InsCode,string AnimalCode, string RegFee, string UserName, DateTime Date, string UPDATE, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RegMaster", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@InsCd", SqlDbType.VarChar).Value = InsCode;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.VarChar).Value = AnimalCode;
                    da.SelectCommand.Parameters.Add("@Regfee", SqlDbType.VarChar).Value = RegFee;
                    da.SelectCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable DeleteRegDAL(string InsCode, string AnimalCode, string RegFee, string DELETE, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RegMaster", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@InsCd", SqlDbType.VarChar).Value = InsCode;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.VarChar).Value = AnimalCode;
                    da.SelectCommand.Parameters.Add("@Regfee", SqlDbType.VarChar).Value = RegFee;


                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = DELETE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable InsertInstituionsDAL(string StateCode, string DistCode, string MandalCode, string InstypeCd, string Village, string Inscode, string InsName, DateTime Date, int ACtiveSt, string UserName, string INSERT, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InstituionsDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = MandalCode;
                    da.SelectCommand.Parameters.Add("@InstypeCd", SqlDbType.VarChar).Value = InstypeCd;
                    da.SelectCommand.Parameters.Add("@Village", SqlDbType.VarChar).Value = Village;
                    da.SelectCommand.Parameters.Add("@InstituionCd", SqlDbType.VarChar).Value = Inscode;
                    da.SelectCommand.Parameters.Add("@InstituionName", SqlDbType.VarChar).Value = InsName;
                    da.SelectCommand.Parameters.Add("@Date", SqlDbType.Date).Value = Date;
                    da.SelectCommand.Parameters.Add("@ACtiveSt", SqlDbType.Int).Value = ACtiveSt;
                    da.SelectCommand.Parameters.Add("@Username", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable InsertSuplyDAL(string StateCode, string Dcode, string Sname, string Saddress, string Email, string Mbno, int ACtiveSt, string UserName, string INSERT, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@SP_StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@SP_DistCode", SqlDbType.VarChar).Value = Dcode;
                    da.SelectCommand.Parameters.Add("@SP_Name", SqlDbType.VarChar).Value = Sname;
                    da.SelectCommand.Parameters.Add("@Sp_Address", SqlDbType.VarChar).Value = Saddress;
                    da.SelectCommand.Parameters.Add("@SP_EmailID", SqlDbType.VarChar).Value = Email;
                    da.SelectCommand.Parameters.Add("@SP_MobileNo", SqlDbType.VarChar).Value = Mbno;
                    da.SelectCommand.Parameters.Add("@Active", SqlDbType.Int).Value = ACtiveSt;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable UpdateSuplyDAL(string StateCode, string Dcode, string SupCode, string Sname, string Saddress, string Email, string Mbno, int ACtiveSt, string UserName, string UPDATE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@SP_StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@SP_DistCode", SqlDbType.VarChar).Value = Dcode;
                    da.SelectCommand.Parameters.Add("@SupplierCode", SqlDbType.VarChar).Value = SupCode;
                    da.SelectCommand.Parameters.Add("@SP_Name", SqlDbType.VarChar).Value = Sname;
                    da.SelectCommand.Parameters.Add("@Sp_Address", SqlDbType.VarChar).Value = Saddress;
                    da.SelectCommand.Parameters.Add("@SP_EmailID", SqlDbType.VarChar).Value = Email;
                    da.SelectCommand.Parameters.Add("@SP_MobileNo", SqlDbType.VarChar).Value = Mbno;
                    da.SelectCommand.Parameters.Add("@Active", SqlDbType.Int).Value = ACtiveSt;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable DeleteSuplyDAL(string SupCode, string Flag_IUP, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@SupplierCode", SqlDbType.VarChar).Value = SupCode;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Flag_IUP;



                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable viewSupplierDAL(string Statecd, string Dcode, string GData, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("Supplier_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@SP_StateCode", SqlDbType.Char).Value = Statecd;
                    da.SelectCommand.Parameters.Add("@SP_DistCode", SqlDbType.VarChar).Value = Dcode;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = GData;

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
        public DataTable viewAnimaldataDAL(string ConnKey)
        {

            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                SqlDataAdapter dam = new SqlDataAdapter("select * from Mst_AnimalType", con);
                dam.Fill(ds, "Aimal");
                return ds.Tables["Aimal"];
            }
        }



        public DataTable viewdDrugDAL(string GData, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DrugMaster", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = GData;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable viewInstitutiondataDAL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InstituionTypeDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = "R";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable viewInstitutiondataDAL1(string StateCode, string DistCode, string MandalCode, string InsType, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InstituionsDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@MandalCode", SqlDbType.VarChar).Value = MandalCode;
                    da.SelectCommand.Parameters.Add("@InstypeCd", SqlDbType.VarChar).Value = InsType;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = "S";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public DataTable viewInsDAL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dam = new SqlDataAdapter("select Unique_InstId AS InstitutionCode ,InstitutionName from Mst_Institution ORDER BY InstitutionName  ", con);
                dam.Fill(ds, "Institutions");
                return ds.Tables["Institutions"];
            }
        }
        public DataTable getstateDAL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StateMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = 'S';
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            
        }
        public DataTable viewDRegDAL(string Inscd, string Flag_IUP, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("RegMaster", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@InsCd", SqlDbType.Char).Value = Inscd;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = Flag_IUP;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable viewInstitutionsdataDAL(string StateCode, string DistCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("InstituionsDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.Char).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.Char).Value = DistCode;
                    da.SelectCommand.Parameters.Add("@Flag_IUP", SqlDbType.Char).Value = "R";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            
        }
       


        /*End Of Pharmacy Inventory*/
        /*Issues Of drugs*/

        public DataTable AnimaldetailsDAL(string Unique_InsId, string date, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchPendingPatients_IssueofDrugs", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = Unique_InsId;
                    da.SelectCommand.Parameters.Add("@RegDate", SqlDbType.VarChar).Value = date;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        /* Disease Master */

        /* View Disease Type details */
        public DataTable viewDiseasedataDAL( string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DiseaseMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        /* Insert Disease Type details */
        public DataTable insertDiseaseTypeDAL(string DiseaseTypeCd, string DiseaseTypeName, string UserName, string INSERT, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DiseaseMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DiseaseCode", SqlDbType.VarChar).Value = DiseaseTypeCd;
                    da.SelectCommand.Parameters.Add("@DiseaseName", SqlDbType.VarChar).Value = DiseaseTypeName;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Update Disease Type*/
        public DataTable UpdateDiseaseTypeDAL(string DiseaseTypeCd, string DiseaseTypeName, string UserName, string UPDATE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("DiseaseMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DiseaseCode", SqlDbType.VarChar).Value = DiseaseTypeCd;
                    da.SelectCommand.Parameters.Add("@DiseaseName", SqlDbType.VarChar).Value = DiseaseTypeName;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* DELETE Disease Type*/
        public DataTable DeleteDiseaseDAL(string DiseaseTypeCd, string DiseaseTypeName, string DELETE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DiseaseMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DiseaseCode", SqlDbType.VarChar).Value = DiseaseTypeCd;
                    da.SelectCommand.Parameters.Add("@DiseaseName", SqlDbType.VarChar).Value = DiseaseTypeName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = DELETE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }
        //
        /* Disease Master */

        /* View Sate details */
        public DataTable viewStatedataDAL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StateMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        /* Insert Disease Type details */
        public DataTable InsertStateDAL(string SateCode, string StateName, string INSERT, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StateMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = SateCode;
                    da.SelectCommand.Parameters.Add("@StateName", SqlDbType.VarChar).Value = StateName;

                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Update Disease Type*/
        public DataTable UpdateStateDAL(string SateCode, string StateName, string UPDATE, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StateMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = SateCode;
                    da.SelectCommand.Parameters.Add("@StateName", SqlDbType.VarChar).Value = StateName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* DELETE Disease Type*/
        public DataTable DeleteStateDAL(string SateCode, string StateName, string DELETE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("StateMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = SateCode;
                    da.SelectCommand.Parameters.Add("@StateName", SqlDbType.VarChar).Value = StateName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = DELETE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }


        }
        //
        /*GET DISTRICTS BY STATECODE*/
        public DataTable getDistrictsByStateCodeDAL(string StateCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchDistrictsByStateCode", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        
             /*GET BREED BY ANIMAL TYPE CODE*/
        public DataTable getBreedByAnimalTypeDAL(String AnimalTypeCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchBreedByAnimalTypeCode", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.VarChar).Value = AnimalTypeCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*GET MANDALS BY DIST CODE*/
        public DataTable getMandalsByDistCodeDAL(string DistCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchMandalsByDistCode", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*USer Creation*/
        public DataTable InserUserDAL(string StateCode, string DCode, string MCode, string InsCode, string InsTCode, string Role, string UName, string Pwd, DateTime dateAndTime, string IpAddress, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("UserCreation", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    if(DCode =="")
                        da.SelectCommand.Parameters.Add("@DCode", SqlDbType.VarChar).Value = DBNull.Value;
                    else
                        da.SelectCommand.Parameters.Add("@DCode", SqlDbType.VarChar).Value = DCode;
                    if (MCode == "")
                        da.SelectCommand.Parameters.Add("@MCode", SqlDbType.VarChar).Value = DBNull.Value;
                    else
                        da.SelectCommand.Parameters.Add("@MCode", SqlDbType.VarChar).Value = MCode;
                    if(InsCode=="")
                        da.SelectCommand.Parameters.Add("@Unique_InstId", SqlDbType.VarChar).Value = DBNull.Value;
                    else
                        da.SelectCommand.Parameters.Add("@Unique_InstId", SqlDbType.VarChar).Value = InsCode;
                    if(InsTCode=="")
                        da.SelectCommand.Parameters.Add("@InsTCode", SqlDbType.VarChar).Value = DBNull.Value;
                    else
                        da.SelectCommand.Parameters.Add("@InsTCode", SqlDbType.VarChar).Value = InsTCode;

                    da.SelectCommand.Parameters.Add("@Role", SqlDbType.VarChar).Value = Role;
                    da.SelectCommand.Parameters.Add("@UName", SqlDbType.VarChar).Value = UName;
                    da.SelectCommand.Parameters.Add("@Pwd", SqlDbType.VarChar).Value = Pwd;
                    da.SelectCommand.Parameters.Add("@CreatedDt", SqlDbType.DateTime).Value = dateAndTime;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "I";
                    da.SelectCommand.Parameters.Add("@IpAddress", SqlDbType.VarChar).Value = IpAddress;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable ViewGridDataDAL(string StateCode, string DCode, string MCode, string InsCode, string InsTCode,string Role, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("UserCreation", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DCode", SqlDbType.VarChar).Value = DCode;
                    da.SelectCommand.Parameters.Add("@MCode", SqlDbType.VarChar).Value = MCode;
                    da.SelectCommand.Parameters.Add("@InsTCode", SqlDbType.VarChar).Value = InsTCode;
                    da.SelectCommand.Parameters.Add("@Unique_InstId", SqlDbType.VarChar).Value = InsCode;
                    da.SelectCommand.Parameters.Add("@Role", SqlDbType.Int).Value = Role;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = "R";
                    //da.SelectCommand.Parameters.Add("@IpAddress", SqlDbType.VarChar).Value = ipAddress;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        /* DiagTestFeeMaster  */

        /* View DiagTest  details */
        public DataTable viewDiagDAL(string UniqueInsId, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DiagTestFeeMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "R";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        /* Insert DiagTest details */
        public DataTable InsertDiagDAL(string UniqueInsId,  string TestCd, string TestFee, string FeePaid, string UserName, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DiagTestFeeMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@TestCode", SqlDbType.Int).Value = TestCd;
                    da.SelectCommand.Parameters.Add("@TotalFee", SqlDbType.Int).Value = TestFee;
                    da.SelectCommand.Parameters.Add("@FeePaidByGovt", SqlDbType.Int).Value = FeePaid;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "I";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Upadate DiagTest details */
        public DataTable UpdateDiagDAL(string UniqueInsId, string TestCd, string TestFee, string FeePaid, string UserName, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DiagTestFeeMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@TestCode", SqlDbType.Int).Value = TestCd;
                    da.SelectCommand.Parameters.Add("@TotalFee", SqlDbType.Int).Value = TestFee;
                    da.SelectCommand.Parameters.Add("@FeePaidByGovt", SqlDbType.Int).Value = FeePaid;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "U";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Delete DiagTest details */
        public DataTable DeleteDiagDAL(string UniqueInsId , string TestCd, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DiagTestFeeMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@TestCode", SqlDbType.Int).Value = TestCd;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "D";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /*BREED MASTER INSERT UPADATE DELETE RETRIVE*/
        public DataTable viewBreedDtlsDAL(string AnimalTypeCd, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("BreedMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.Int).Value = AnimalTypeCd;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "R";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Delete Animal Breed details */
        public DataTable DeleteBreedDAL(string AnimalTypeCode, string BreedCd, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("BreedMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.VarChar).Value = AnimalTypeCode;
                    da.SelectCommand.Parameters.Add("@BreedCode", SqlDbType.Int).Value = BreedCd;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "D";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Insert Animal Breed details */
        public DataTable InsertBreedDAL(string BreedCd, string AnimalType, string BreedNm, string UserName, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("BreedMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@BreedCode", SqlDbType.Int).Value = BreedCd;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.VarChar).Value = AnimalType;
                    da.SelectCommand.Parameters.Add("@BreedName", SqlDbType.VarChar).Value = BreedNm;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "I";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /* Upadate Animal Breed details */
        public DataTable UpdateBreedDAL(string BreedCd, string AnimalType, string BreedNm, string UserName, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("BreedMaster_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@BreedCode", SqlDbType.Int).Value = BreedCd;
                    da.SelectCommand.Parameters.Add("@AnimalTypeCode", SqlDbType.VarChar).Value = AnimalType;
                    da.SelectCommand.Parameters.Add("@BreedName", SqlDbType.VarChar).Value = BreedNm;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = "U";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*FETCH INSTITUTIONS BY DIST CODE*/
        public DataTable GetInstByDistCodeDAL(string StateCode, string DistCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchInstitutionsByDistCode", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*FETCH REG NOS BY INSTITUTION*/
        public DataTable GetRegNosByInstIdDAL(string UniqueInsId, DateTime SelDt, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchRegNosByUniqueInsId", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UniqueInsId", SqlDbType.VarChar).Value = UniqueInsId;
                    da.SelectCommand.Parameters.Add("@SelDt", SqlDbType.DateTime).Value = SelDt;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*UOM INSERT UPDATE DELETE SELECT*/
        public DataTable InsertUomDAL(string UnitCd, string UnitName, string UserName, string INSERT, string ConnKey)
        {


            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("UOM_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UnitCode", SqlDbType.VarChar).Value = UnitCd;
                    da.SelectCommand.Parameters.Add("@UnitName", SqlDbType.VarChar).Value = UnitName;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = INSERT;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable UpdateUomDAL(string UnitCd, string UnitName, string UserName, string UPDATE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {

                using (SqlDataAdapter da = new SqlDataAdapter("UOM_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UnitCode", SqlDbType.VarChar).Value = UnitCd;
                    da.SelectCommand.Parameters.Add("@UnitName", SqlDbType.VarChar).Value = UnitName;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.Char).Value = UPDATE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable DeleteUomDAL(string UnitCd, string UnitName, string DELETE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("UOM_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@UnitCode", SqlDbType.VarChar).Value = UnitCd;
                    da.SelectCommand.Parameters.Add("@UnitName", SqlDbType.VarChar).Value = UnitName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = DELETE;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }

            }

        }
        public DataTable viewUomdataDAL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("UOM_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }

            }
        }
        public DataTable GetUserTypeDAL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("GetUserType", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable DiagTest_IUDR_DAL(string DiagTestCode, string DiagTestName, string Action, string UserName, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("DiagTest_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DiagTestCode", SqlDbType.VarChar).Value = DiagTestCode;
                    da.SelectCommand.Parameters.Add("@DiagTestName", SqlDbType.VarChar).Value = DiagTestName;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = Action;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = UserName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetDiagTestDtls_ByUniqueInsIdDAL(string UniqueInsId, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchDiagTestByUniqueInsId", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInsId;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetAnimalType_ForRegFeeByUniqueInsIdDAL(string UniqueInsId, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchAnimalTypeByUniqueInsId", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Unique_InsId", SqlDbType.VarChar).Value = UniqueInsId;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*GET Purpose Details*/
        public DataTable GetPurposeDAL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchPurposeDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "R";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*GET Doctor Details*/
        public DataTable GetDoctorDAL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchDoctorDetails", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "R";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*GET Category Details*/
        public DataTable GetCategoryDAL(string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchCategory", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "R";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*GET Category Details*/
        public DataTable GetDivisionDAL(string StateCode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchDivision", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@flag", SqlDbType.VarChar).Value = "R";

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable getDistrictsByDivisionDAL(string StateCode, string divisioncd,string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchDistrictsByDivision", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@StateCode", SqlDbType.VarChar).Value = StateCode;
                    da.SelectCommand.Parameters.Add("@divisioncd ", SqlDbType.VarChar).Value = divisioncd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        /*SCHEME MASTER CURD OPERATIONS*/
        public DataTable SchemeMst_IUDR_DAL(MasterBE objBE, string ConnKey)
        {

            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("SchemeMst_IUDR", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@SchemeCode", SqlDbType.VarChar).Value = objBE.SchemeCode;
                    da.SelectCommand.Parameters.Add("@SchemeName", SqlDbType.VarChar).Value = objBE.SchemeName;
                    da.SelectCommand.Parameters.Add("@SchemeType", SqlDbType.VarChar).Value = objBE.SchemeType;
                    da.SelectCommand.Parameters.Add("@Action", SqlDbType.VarChar).Value = objBE.Action;
                    da.SelectCommand.Parameters.Add("@LoggedIn_User", SqlDbType.VarChar).Value = objBE.UserName;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }



        public DataTable GetVillageDAL(string DistCode, string mandalcode, string ConnKey)
        {
            using (SqlConnection con = new SqlConnection(ConnKey))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("FetchvillageByDistCode", con))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@DistCode", SqlDbType.VarChar).Value = DistCode;
                    if (mandalcode != "")
                    {
                        da.SelectCommand.Parameters.Add("@mandalCode", SqlDbType.VarChar).Value = mandalcode;
                    }


                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
