using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAO;
using System.Data.SqlClient;
namespace BUS
{
    public class ProductBUS
    {
        ProductDAO productDAO = new ProductDAO();
        public List<Product> GetProducts() {
            return productDAO.GetProducts();
        }
        public int Add(Product product) {
            try
            {
                return productDAO.Add(product);
            }
            catch (SqlException ex) {
                throw ex;
            }
        }

        public int Delete(string id) {
            try
            {
                return productDAO.Delete(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
