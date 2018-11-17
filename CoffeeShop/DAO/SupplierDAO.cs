using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;
namespace DAO
{
    public class SupplierDAO:DataProvider
    {
        public List<Supplier> GetSuppliers() {
            string sql = "SELECT * FROM Supplier";
            string id, name, address;
            List<Supplier> list = new List<Supplier>();
            Connect();
            try
            {
                SqlDataReader dr = myExecuteReader(sql, CommandType.Text);
                while (dr.Read())
                {
                    id = dr[0].ToString();
                    name = dr[1].ToString();
                    address = dr[2].ToString();
                    Supplier supplier = new Supplier(id, name, address);
                    list.Add(supplier);
                }
                dr.Close();
                return list;

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
