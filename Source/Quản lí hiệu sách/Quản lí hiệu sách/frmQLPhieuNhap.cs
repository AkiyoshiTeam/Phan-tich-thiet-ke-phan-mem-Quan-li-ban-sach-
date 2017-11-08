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
    public partial class frmQLPhieuNhap : Form
    {
        public frmQLPhieuNhap()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            dgvDanhSach.DataSource = PhieuNhapBUS.DanhSachPN();
            Custom1();
            dgvDanhSach.ClearSelection();
            if (dgvDanhSach.Rows.Count > 0)
            {
                dgvChiTiet.DataSource = PhieuNhapBUS.DanhSachCTPN(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
                Custom2();
                dgvChiTiet.ClearSelection();
            }
        }
        private void tsbtnLapphieu_Click(object sender, EventArgs e)
        {
            frmPhieuNhapSach frm = new frmPhieuNhapSach();
            tsbtnXoa.Enabled = false;
            frm.ShowDialog();
            LoadData();
        }

        private void tsbtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQLPhieuNhap_Load(object sender, EventArgs e)
        {
            tsbtnXoa.Enabled = false;
            dgvDanhSach.DataSource = PhieuNhapBUS.DanhSachPN();
            Custom1();
            dgvDanhSach.ClearSelection();
        }
        void Custom1()
        {
            if (!dgvDanhSach.AutoGenerateColumns)
            {
                return;
            }
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.Columns.Clear();
            dgvDanhSach.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Số phiếu nhập";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "SoPN";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Ngày nhập";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "NgayNhap";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Nhà xuất bản";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "TenNXB";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Tổng tiền (VNĐ)";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "TongTien";
            dgvCol.ReadOnly = true;
            dgvCol.DefaultCellStyle.Format = "0,00";
            dgvDanhSach.Columns.Add(dgvCol);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            dgvChiTiet.DataSource = PhieuNhapBUS.DanhSachCTPN(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
            Custom2();
            dgvChiTiet.ClearSelection();
        }

        private void dgvDanhSach_KeyUp(object sender, KeyEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            dgvChiTiet.DataSource = PhieuNhapBUS.DanhSachCTPN(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
            Custom2();
            dgvChiTiet.ClearSelection();
        }

        private void dgvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            dgvChiTiet.DataSource = PhieuNhapBUS.DanhSachCTPN(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
            Custom2();
            dgvChiTiet.ClearSelection();
        }
        void Custom2()
        {
            if (!dgvChiTiet.AutoGenerateColumns)
            {
                return;
            }
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Columns.Clear();
            dgvChiTiet.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Mã sách";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "MaSach";
            dgvCol.ReadOnly = true;
            dgvChiTiet.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Tên sách";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "TenSach";
            dgvCol.ReadOnly = true;
            dgvChiTiet.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Tác giả";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "TenTG";
            dgvCol.ReadOnly = true;
            dgvChiTiet.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Số lượng";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "SoLuongNhap";
            dgvCol.ReadOnly = true;
            dgvChiTiet.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Giá nhập (VNĐ)";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "GiaNhap";
            dgvCol.ReadOnly = true;
            dgvCol.DefaultCellStyle.Format = "0,00";
            dgvChiTiet.Columns.Add(dgvCol);
        }

        private void tsbtnXoa_Click(object sender, EventArgs e)
        {
            if (PhieuNhapBUS.XoaPN(dgvDanhSach.CurrentRow.Cells[0].Value.ToString()) == true)
            {
                LoadData();
            }
            else
                MessageBox.Show("Xóa thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
