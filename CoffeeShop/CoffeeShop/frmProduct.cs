using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Data.SqlClient;
namespace CoffeeShop
{
    public partial class frmProduct : Form
    {
        ProductBUS productBus;
        SupplierBUS supplierBus;
        ProductCategoryBUS productCategoryBus;
        public frmProduct()
        {
            InitializeComponent();
            productBus = new ProductBUS();
            supplierBus = new SupplierBUS();
            productCategoryBus = new ProductCategoryBUS();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            List<Product> list = productBus.GetProducts();
            List<Supplier> listSupplier = supplierBus.GetSuppliers();
            List<ProductCategory> listProductCategory = productCategoryBus.GetProductCategorys();
            dgvProduct.DataSource = list;
            // setting combobox nha cung cap
            cboNCC.DataSource = listSupplier;
            cboNCC.DisplayMember = "name";
            cboNCC.ValueMember = "id";

            // settinig combobox loai
            cboLoai.DataSource = listProductCategory;
            cboLoai.DisplayMember = "name";
            cboLoai.ValueMember = "id";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id, name, supplierId;
            float purchasePrice, sellingPrice;
            int categoryId;
            id = txtId.Text;
            name = txtName.Text;
            purchasePrice = float.Parse(txtPurchase.Text);
            sellingPrice = float.Parse(txtSelling.Text);
            categoryId = int.Parse(cboLoai.SelectedValue.ToString());
            supplierId = cboNCC.SelectedValue.ToString();
            Product product = new Product(id, name, purchasePrice, sellingPrice, categoryId, supplierId);
            try {
                int numberOfRows = productBus.Add(product);
                if (numberOfRows > 0) {
                    dgvProduct.DataSource = productBus.GetProducts();
                }
            }
            catch (SqlException ex) {
                MessageBox.Show("Loi them san pham. \n" + ex.Message, "Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = e.ColumnIndex;
            if (dgvProduct.Columns[col] is DataGridViewButtonColumn && dgvProduct.Columns[col].Name == "Delete")
            {
                // delete product - event CellClick
                int currentIndex = dgvProduct.CurrentCell.RowIndex;
                string productId = dgvProduct.Rows[currentIndex].Cells[1].Value.ToString();
                try
                {
                    int number = productBus.Delete(productId);
                    if (number > 0)
                    {
                        dgvProduct.DataSource = productBus.GetProducts();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Loi xoa san pham. \n" + ex.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            
        }
    }
}
