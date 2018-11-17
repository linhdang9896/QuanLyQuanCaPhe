using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;
namespace BUS
{
    public class ProductCategoryBUS
    {
        ProductCategoryDAO productCategoryDAO = new ProductCategoryDAO();
        public List<ProductCategory> GetProductCategorys()
        {
            return productCategoryDAO.GetProductCategorys();
        }
    }
}
