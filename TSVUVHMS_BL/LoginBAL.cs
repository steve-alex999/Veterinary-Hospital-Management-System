using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSVUVHMS_DL;
using System.Data;

namespace TSVUVHMS_BL
{
    public class LoginBAL
    {
        LoginDAL objLogin = new LoginDAL();
        public DataTable getLoginDetailsBAL(string username, string ConnKey)
        {
            return objLogin.getLoginDetailsDAL(username, ConnKey);
        }
        public void updatePWDBAL(string UsrName, string password, string ConnKey)
        {
            objLogin.updatePWDDAL(UsrName, password, ConnKey);
        }
        public int changepasswordBAL(string username, string newpwd, string ConnKey)
        {

            return objLogin.changepasswordDAL(username, newpwd, ConnKey);
        }
        public int insertUserLoginStatusBAL(string userId, DateTime dateAndTime, string ipAddress, string loginStatus, string ConnKey)
        {
            return objLogin.insertUserLoginStatusDAL(userId, dateAndTime, ipAddress, loginStatus, ConnKey);            
        }
        public void updateUserLoginStatusBAL(int id, string status, DateTime logouttime, string ConnKey)
        {
            objLogin.updateUserLoginStatusDAL(id, status, logouttime, ConnKey);
        }
    }
}
