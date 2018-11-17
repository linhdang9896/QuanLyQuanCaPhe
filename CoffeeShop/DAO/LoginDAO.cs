using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using DTO;
namespace DAO
{
    public class LoginDAO:DataProvider
    {

        public bool Login(Account acc)
        {
            string sql = "SELECT COUNT(Username) FROM Users WHERE Username = '" + acc.UserName + "'AND Password ='" + acc.Password + "'";
            try
            {
                int number = (int)myExecuteScalar(sql);
                if (number > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
