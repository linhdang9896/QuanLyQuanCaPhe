using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DTO;
using System.Data;
namespace DAO
{
    public class ProductDAO:DataProvider
    {
        public List<Product> GetProducts() {
            string sql = "SELECT * FROM Product";
            string id, name, supplierid;
            float purchaseprice, sellingprice;
            int categoryid;
            List<Product> list = new List<Product>();
            Connect();
            try
            {
                SqlDataReader dr = myExecuteReader(sql, CommandType.Text);
                while (dr.Read())
                {
                    id = dr[0].ToString();
                    name = dr[1].ToString();
                    purchaseprice = float.Parse(dr[2].ToString());
                    sellingprice = float.Parse(dr[3].ToString());
                    categoryid = (int)dr[4];
                    supplierid = dr[5].ToString();

                    Product product = new Product(id, name, purchaseprice, sellingprice, categoryid, supplierid);
                    list.Add(product);
                }
                dr.Close();
                return list;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally {
                DisConnect();
            }


            
        }
        public int Add(Product product) {
            //string sql = "INSERT INTO Product VALUES('" + product.Id + "', '" + product.Name + "', '" + product.PurchasePrice + "', '" + product.SellingPrice + "', '" + product.CategoryId + "', '" + product.SupplierId + "')";
            string sql = "INSERT INTO Product VALUES(@id, @name, @purchasePrice, @sellingPrice, @categoryId, @supplierId)";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", product.Id));
            parameters.Add(new SqlParameter("@name", product.Name));
            parameters.Add(new SqlParameter("@purchasePrice", product.PurchasePrice));
            parameters.Add(new SqlParameter("@sellingPrice", product.SellingPrice));
            parameters.Add(new SqlParameter("@categoryId", product.CategoryId));
            parameters.Add(new SqlParameter("@supplierId", product.SupplierId));

            try
            {
                return (MyExecuteNonQuery(sql, CommandType.Text, parameters));
            }
            catch (SqlException ex){
                throw ex;
            }
        }
        public int Delete(string id) {
            string sql = "DELETE From Product WHERE id = @id";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@id", id));
            try
            {
                return (MyExecuteNonQuery(sql, CommandType.Text, parameters));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
