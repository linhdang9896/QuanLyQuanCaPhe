using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DataProvider
    {
        SqlConnection cn;
        public DataProvider() {
            string cnStr = "Server = .\\SqlExpress; database= CoffeeShop; Integrated security= true;";
            cn = new SqlConnection(cnStr);
        }
        public void Connect() {
            try
            {
                if (cn != null && cn.State == System.Data.ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex) {
                throw ex;
            }
        }

        public void DisConnect() {
            if (cn != null && cn.State == System.Data.ConnectionState.Open) {
                cn.Close();
            }
        }

        public int myExecuteScalar(string sql) {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            Connect();
            try
            {
                int number = (int)cmd.ExecuteScalar();
                return number;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally {
                DisConnect();
            }
        
        }
        public SqlDataReader myExecuteReader(string sql, CommandType type) {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = sql;
            cmd.CommandType = type; //???
            try
            {
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex) {
                throw ex;
            }
                
        }
        public int MyExecuteNonQuery(string sql, CommandType type, List<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            if (parameters != null) {
                foreach (SqlParameter parameter in parameters) {
                    cmd.Parameters.Add(parameter);
                }
            }
            Connect();
            try
            {
                int numberOfRows = cmd.ExecuteNonQuery();
                return numberOfRows;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally {
                DisConnect();
            }

        }
    }
}
