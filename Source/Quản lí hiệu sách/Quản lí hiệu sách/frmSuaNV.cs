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
    public partial class frmSuaNV : Form
    {
        public frmSuaNV()
        {
            InitializeComponent();
        }
        public frmSuaNV(NguoiDungDTO ND)
        {
            InitializeComponent();
            txtMaNV.Text = ND.MaND;
            txtHoTen.Text = ND.HoTen;
            txtUsername.Text = ND.Username;
            txtDiaChi.Text = ND.DiaChi;
            txtDienThoai.Text = ND.DienThoai;
            cboPhanQuyen.SelectedItem = ND.PhanQuyen;
            cboGioiTinh.SelectedItem = ND.GioiTinh;
            txtCMND.Text = ND.SoCMND;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            NguoiDungDTO ND = new NguoiDungDTO();
            ND.MaND = txtMaNV.Text;
            ND.HoTen = txtHoTen.Text;
            ND.Username = txtUsername.Text;
            ND.DiaChi = txtDiaChi.Text;
            ND.SoCMND = txtCMND.Text;
            ND.PhanQuyen = cboPhanQuyen.SelectedItem.ToString();
            ND.DienThoai = txtDienThoai.Text;
            ND.GioiTinh = cboGioiTinh.SelectedItem.ToString();
            if(NguoiDungBUS.SuaND(ND)==true)
            {
                MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
