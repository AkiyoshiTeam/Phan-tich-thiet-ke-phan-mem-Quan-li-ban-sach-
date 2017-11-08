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
    public partial class frmThemSach : Form
    {
        public frmThemSach()
        {
            InitializeComponent();
        }

        private void frmThemSach_Load(object sender, EventArgs e)
        {
            cboTheLoai.DataSource = TheLoaiBUS.DanhSachTheLoai();
            cboTheLoai.DisplayMember = "TenTL";
            cboTheLoai.ValueMember = "MaTL";

            cboTacGia.DataSource = TacGiaBUS.DanhSachTacGia();
            cboTacGia.DisplayMember = "TenTG";
            cboTacGia.ValueMember = "MaTG";

            cboNXB.DataSource = NhaXuatBanBUS.DanhSachNXB();
            cboNXB.DisplayMember = "TenNXB";
            cboNXB.ValueMember = "MaNXB";

            txtMaSach.Text = SachBUS.GetIDSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenSach.Text == "")
                MessageBox.Show("-Tên sách không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                SachDTO S = new SachDTO();
                S.MaSach = txtMaSach.Text;
                S.TenSach = txtTenSach.Text;
                S.MaTL = cboTheLoai.SelectedValue.ToString();
                S.MaNXB = cboNXB.SelectedValue.ToString();
                S.MaTG = cboTacGia.SelectedValue.ToString();
                if (SachBUS.ThemSach(S) == true)
                {
                    MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaSach.Text = SachBUS.GetIDSach();
                    txtTenSach.ResetText();
                }
                else
                    MessageBox.Show("Thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
