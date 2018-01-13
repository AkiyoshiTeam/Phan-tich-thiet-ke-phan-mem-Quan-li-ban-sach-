using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Threading;

namespace Quản_lí_hiệu_sách
{
    public partial class frmDangNhap : Form
    {
        int dem=0;
        public frmDangNhap()
        {
            InitializeComponent();
            frmLoading frm = new frmLoading();
            frm.ShowDialog();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            NguoiDungDTO nd = new NguoiDungDTO();
            string pass = "", hoten = "", username = "", phanquyen = "";
            if(ValidateChildren(ValidationConstraints.Enabled))
            {
                while(true)
                {
                    username = txtUsername.Text;
                    foreach(DataRow row in NguoiDungBUS.DangNhap(username).Rows)
                    {
                        pass = row["Password"].ToString();
                        hoten = row["HoTen"].ToString();
                        phanquyen = row["PhanQuyen"].ToString();
                    }
                    if (txtPassword.Text == pass)
                    {
                        if (phanquyen == "Admin")
                        {
                            this.Hide();
                            frmMain frm = new frmMain(hoten, username, phanquyen);
                            frm.ShowDialog();
                            this.Show();
                            txtPassword.ResetText();
                            break;
                        }
                        else if (phanquyen == "User ")
                        {
                            this.Hide();
                            frmUser frm = new frmUser(hoten, username, phanquyen);
                            frm.ShowDialog();
                            this.Show();
                            txtPassword.ResetText();
                            break;
                        }
                    }
                    else
                    {
                        if (dem == 3)
                        {
                            MessageBox.Show("Bạn nhập sai quá 3 lần cho phép.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                            break;
                        }
                        dem++;
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.ResetText();
                        txtUsername.ResetText();
                        break;
                    }
                }
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider.SetError(txtUsername, "Vui lòng nhập username.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Vui lòng nhập password.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, null);
            }
        }
    }
}