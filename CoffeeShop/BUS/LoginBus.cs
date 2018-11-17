using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using DAO;
using DTO;
namespace BUS
{
    public class LoginBus
    {
        public bool Login(Account acc) {
            try {
                return new LoginDAO().Login(acc);
            }
            catch(SqlException ex) {
                throw ex;
            }
        }
    }
}
