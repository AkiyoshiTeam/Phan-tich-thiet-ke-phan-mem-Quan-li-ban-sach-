using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;

namespace Quản_lí_hiệu_sách
{
    public partial class frmSuaSach : Form
    {
        public frmSuaSach()
        {
            InitializeComponent();
        }
        public frmSuaSach(SachDTO S)
        {
            InitializeComponent();
            cboTheLoai.DataSource = TheLoaiBUS.DanhSachTheLoai();
            cboTheLoai.DisplayMember = "TenTL";
            cboTheLoai.ValueMember = "MaTL";

            cboTacGia.DataSource = TacGiaBUS.DanhSachTacGia();
            cboTacGia.DisplayMember = "TenTG";
            cboTacGia.ValueMember = "MaTG";

            cboNXB.DataSource = NhaXuatBanBUS.DanhSachNXB();
            cboNXB.DisplayMember = "TenNXB";
            cboNXB.ValueMember = "MaNXB";

            txtMaSach.Text = S.MaSach;
            txtTenSach.Text = S.TenSach;
            cboTheLoai.SelectedValue = S.MaTL;
            cboTacGia.SelectedValue = S.MaTG;
            cboNXB.SelectedValue = S.MaNXB;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SachDTO S = new SachDTO();
            S.MaSach = txtMaSach.Text;
            S.TenSach = txtTenSach.Text;
            S.MaTL = cboTheLoai.SelectedValue.ToString();
            S.MaNXB = cboNXB.SelectedValue.ToString();
            S.MaTG = cboTacGia.SelectedValue.ToString();
            if (SachBUS.SuaSach(S) == true)
            {
                MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
