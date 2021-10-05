using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TSVUVHMS_DL
{
   public class LoginDAL
    {
       public DataTable getLoginDetailsDAL(string username,string ConnKey)
       {
           using (SqlConnection con = new SqlConnection(ConnKey))
           {
               using (SqlDataAdapter da = new SqlDataAdapter("GetLoginDetails", con))
               {
                   da.SelectCommand.CommandType = CommandType.StoredProcedure;
                   da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                   DataTable dt = new DataTable();
                   da.Fill(dt);
                   return dt;
               }
           }
       }
       public void updatePWDDAL(string UsrName, string password, string ConnKey)
       {
           using (SqlConnection con = new SqlConnection(ConnKey))
           {
               using (SqlCommand cmd = new SqlCommand("USP_updateUserPwd", con))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@UsrLogin", SqlDbType.VarChar).Value = UsrName;
                   cmd.Parameters.Add("@UsrPwd", SqlDbType.VarChar).Value = password;
                   con.Open();
                   cmd.ExecuteNonQuery();
                   con.Close();
               }
           }
       }
       public int changepasswordDAL(string username, string newpwd, string ConnKey)
       {
           using (SqlConnection con = new SqlConnection(ConnKey))
           {
               SqlCommand cmd = new SqlCommand("dbo.ChangePwd", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
               cmd.Parameters.Add("@newpwd", SqlDbType.NVarChar).Value = newpwd;
               con.Open();
               int rowCoutn = cmd.ExecuteNonQuery();
               con.Close();
               return rowCoutn;
           }
       }
       public int insertUserLoginStatusDAL(string userId, DateTime dateAndTime, string ipAddress, string loginStatus, string ConnKey)
       {
           using (SqlConnection con = new SqlConnection(ConnKey))
           {
               SqlCommand cmd = new SqlCommand("UserLoginStatus_IU", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@UserId", SqlDbType.NVarChar).Value = userId;
               cmd.Parameters.Add("@Login_or_LogoutDateAndTime", SqlDbType.DateTime).Value = dateAndTime;
               cmd.Parameters.Add("@IpAddress", SqlDbType.NVarChar).Value = ipAddress;
               cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = loginStatus;
               cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "I";
               cmd.Parameters.Add("@LoginSno", SqlDbType.Int);

               //cmd.Parameters.Add("@LogoutDateAndTime", SqlDbType.DateTime).Value = LogoutDateAndTime;
               cmd.Parameters["@LoginSno"].Direction = ParameterDirection.Output;
               con.Open();
               cmd.ExecuteNonQuery();
               int code = Convert.ToInt32(cmd.Parameters["@LoginSno"].Value);
               con.Close();
               con.Dispose();
               return code;
           }
       }
       public void updateUserLoginStatusDAL(int id, string status, DateTime logouttime, string ConnKey)
       {
           using (SqlConnection con = new SqlConnection(ConnKey))
           {
               SqlCommand cmd = new SqlCommand("UserLoginStatus_IU", con);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add("@LoginSno_toUpdate", SqlDbType.BigInt).Value = id;
               cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = status;
               cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = "U";
               cmd.Parameters.Add("@Login_or_LogoutDateAndTime", SqlDbType.DateTime).Value = logouttime;
               cmd.Parameters.Add("@LoginSno", SqlDbType.Int);
               cmd.Parameters["@LoginSno"].Direction = ParameterDirection.Output;
               con.Open();
               cmd.ExecuteNonQuery();
               con.Close();
           }
       }
    }
}
