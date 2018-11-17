using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;
using System.Data;
namespace DAO
{
    public class ProductCategoryDAO:DataProvider
    {
        public List<ProductCategory> GetProductCategorys()
        {
            string sql = "SELECT * FROM ProductCategory";
            int id;
            string name;
            List<ProductCategory> list = new List<ProductCategory>();
            Connect();
            try
            {
                SqlDataReader dr = myExecuteReader(sql, CommandType.Text);
                while (dr.Read())
                {
                    id = (int)dr[0];
                    name = dr[1].ToString();

                    ProductCategory productCategory = new ProductCategory(id, name);
                    list.Add(productCategory);
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
