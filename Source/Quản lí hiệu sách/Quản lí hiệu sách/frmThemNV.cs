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
    public partial class frmThemNV : Form
    {
        public frmThemNV()
        {
            InitializeComponent();
            txtMaNV.Text = NguoiDungBUS.GetIDNguoidung();
            cboGioiTinh.SelectedItem = "Nam";
            cboPhanQuyen.SelectedItem = "Admin";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string KiemTra()
        {
            string thongbao = "";
            if (txtHoTen.Text == "")
                thongbao += "-Họ tên không được để trống.\n";
            if (txtDiaChi.Text == "")
                thongbao += "-Địa chỉ không được để trống.\n";
            if (txtDienThoai.Text == "")
                thongbao += "-Điện thoại không được để trống.\n";
            if(txtUsername.Text=="")
                thongbao += "-Username không được để trống.\n";
            if(txtCMND.Text=="")
                thongbao += "-Số CMND không được để trống.\n";
            return thongbao;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra() == "")
            {
                NguoiDungDTO ND = new NguoiDungDTO();
                ND.MaND = txtMaNV.Text;
                ND.HoTen = txtHoTen.Text;
                ND.Username = txtUsername.Text;
                ND.Password = "123456";
                ND.DiaChi = txtDiaChi.Text;
                ND.SoCMND = txtCMND.Text;
                ND.PhanQuyen = cboPhanQuyen.SelectedItem.ToString();
                ND.DienThoai = txtDienThoai.Text;
                ND.GioiTinh = cboGioiTinh.SelectedItem.ToString();
                if (NguoiDungBUS.ThemND(ND) == true)
                {
                    MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMaNV.Text = NguoiDungBUS.GetIDNguoidung();
                    txtHoTen.ResetText();
                    txtUsername.ResetText();
                    txtDiaChi.ResetText();
                    txtCMND.ResetText();
                    txtDienThoai.ResetText();
                }
                else
                    MessageBox.Show("Thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(string.Format("{0}", KiemTra()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
