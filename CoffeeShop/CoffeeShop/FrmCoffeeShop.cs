using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class FrmCoffeeShop : Form
    {
        public FrmCoffeeShop()
        {
            InitializeComponent();
        }

        private void FrmCoffeeShop_Load(object sender, EventArgs e)
        {
            
            this.Show();
            this.Enabled = false;

            frmLogin frm = new frmLogin();
            DialogResult result = frm.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.Enabled = true;
                lblWelcome.Text = "Chào Mừng Bạn!";
            }
        }

        private void menuProduct_Click(object sender, EventArgs e)
        {
            frmProduct frmPro = new frmProduct();
            frmPro.ShowDialog();
        }
    }
}
