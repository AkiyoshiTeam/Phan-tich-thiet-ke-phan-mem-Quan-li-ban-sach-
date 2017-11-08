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

namespace Quản_lí_hiệu_sách
{
    public partial class frmDoiMatKhau : Form
    {
        string username;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        public frmDoiMatKhau(string USN)
        {
            InitializeComponent();
            username = USN;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            string oldpass = "", newpass = "";
            foreach (DataRow row in NguoiDungBUS.DangNhap(username).Rows)
            {
                oldpass = row["Password"].ToString();
            }
            if (txtMKCu.Text == oldpass)
            {
                newpass = txtMKmoi.Text;
                if (NguoiDungBUS.ChangePassword(username, newpass) == true)
                {
                    MessageBox.Show("Thay đổi thành công.", "Imformation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thay đổi mật khẩu thất bại.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMKCu.ResetText();
                    txtMKmoi.ResetText();
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMKCu.ResetText();
                txtMKmoi.ResetText();
            }
        }
    }
}
