using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;
namespace BUS
{
    public class SupplierBUS
    {
        SupplierDAO supplierDAO = new SupplierDAO();
        public List<Supplier> GetSuppliers()
        {
            return supplierDAO.GetSuppliers();
        }
    }
}
