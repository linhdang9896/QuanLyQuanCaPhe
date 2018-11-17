using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using BUS;
using DTO;

namespace CoffeeShop
{
    public partial class frmLogin : Form
    {
        LoginBus loginBUS;
        public frmLogin()
        {
            InitializeComponent();
            loginBUS = new LoginBus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtUser.Text.Trim();
            pass = txtPass.Text;

            bool b = false;
            try
            {
                Account acc = new Account(user, pass);
                b = loginBUS.Login(acc);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi dang nhap!\n" + ex.Message, "Dang Nhap");
            }

            if (b)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                DialogResult result = MessageBox.Show("U & P KHONG DUNG!", "Đăng nhập", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    Application.Exit();
                }
                else
                {
                    txtUser.Text = "";
                    txtPass.Text = "";
                    txtUser.Focus();
                }
            }
        }
    }
}
