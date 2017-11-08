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
    public partial class frmQLNhanVien : Form
    {
        public frmQLNhanVien()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            tsbtnXoa.Enabled = false;
            tsbtnSua.Enabled = false;
            dgvDanhSach.DataSource = NguoiDungBUS.LoadDSNhanVien();
            Custom();
            dgvDanhSach.ClearSelection();
        }
        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void Custom()
        {
            if(!dgvDanhSach.AutoGenerateColumns)
            {
                return;
            }

            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.Columns.Clear();
            dgvDanhSach.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Mã người dùng";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvCol.DataPropertyName = "MaND";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Họ tên";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "HoTen";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 250;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Giới tính";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvCol.DataPropertyName = "GioiTinh";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Username";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvCol.DataPropertyName = "Username";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Password";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvCol.DataPropertyName = "Password";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Địa chỉ";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "DiaChi";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = " CMND";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "SoCMND";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 120;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Điện thoại";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "DienThoai";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 110;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Phân quyền";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvCol.DataPropertyName = "PhanQuyen";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);
        }

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.Value != null)
                {
                    e.Value = new string('●', e.Value.ToString().Length);
                }
            }
        }

        private void tsbtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnThem_Click(object sender, EventArgs e)
        {
            frmThemNV frm = new frmThemNV();
            tsbtnXoa.Enabled = false;
            tsbtnSua.Enabled = false;
            frm.ShowDialog();
            LoadData();
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            tsbtnSua.Enabled = true;
        }

        private void dgvDanhSach_KeyUp(object sender, KeyEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            tsbtnSua.Enabled = true;
        }

        private void dgvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            tsbtnSua.Enabled = true;
        }

        private void tsbtnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (NguoiDungBUS.XoaND(dgvDanhSach.CurrentRow.Cells[0].Value.ToString()) == true)
                    LoadData();
                else
                    MessageBox.Show("Xóa thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbtnSua_Click(object sender, EventArgs e)
        {
            NguoiDungDTO ND = new NguoiDungDTO();
            ND.MaND = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
            ND.HoTen = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
            ND.GioiTinh = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
            ND.Username = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
            ND.DiaChi = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
            ND.SoCMND = dgvDanhSach.CurrentRow.Cells[6].Value.ToString();
            ND.DienThoai = dgvDanhSach.CurrentRow.Cells[7].Value.ToString();
            ND.PhanQuyen = dgvDanhSach.CurrentRow.Cells[8].Value.ToString();
            frmSuaNV frm = new frmSuaNV(ND);
            tsbtnXoa.Enabled = false;
            tsbtnSua.Enabled = false;
            frm.ShowDialog();
            LoadData();
        }
    }
}
