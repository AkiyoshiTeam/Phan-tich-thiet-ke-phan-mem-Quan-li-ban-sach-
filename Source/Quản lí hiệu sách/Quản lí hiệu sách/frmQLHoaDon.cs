using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;

namespace Quản_lí_hiệu_sách
{
    public partial class frmQLHoaDon : Form
    {
        public frmQLHoaDon()
        {
            InitializeComponent();
        }
        private void tsbtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQLHoaDon_Load(object sender, EventArgs e)
        {
            tsbtnXoa.Enabled = false;
            dgvDanhSach.DataSource = HoaDonBUS.LoadDSHoaDon();
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
            dgvCol.HeaderText = "Số hóa đơn";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "SoHD";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 110;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Ngày bán";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "NgayBan";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Tổng tiền (VNĐ)";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "Tongtien";
            dgvCol.ReadOnly = true;
            dgvCol.DefaultCellStyle.Format = "0,00";
            dgvDanhSach.Columns.Add(dgvCol);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            dgvChiTiet.DataSource = HoaDonBUS.LoadDSCTHoaDon(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
            Custom2();
            dgvChiTiet.ClearSelection();
        }

        private void dgvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            dgvChiTiet.DataSource = HoaDonBUS.LoadDSCTHoaDon(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
            Custom2();
            dgvChiTiet.ClearSelection();
        }

        private void dgvDanhSach_KeyUp(object sender, KeyEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            dgvChiTiet.DataSource = HoaDonBUS.LoadDSCTHoaDon(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
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
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "MaSach";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 90;
            dgvChiTiet.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Tên sách";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "TenSach";
            dgvCol.ReadOnly = true;
            dgvChiTiet.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Số lượng bán";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "SoLuongBan";
            dgvCol.ReadOnly = true;
            dgvChiTiet.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Giá bán (VNĐ)";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "GiaBan";
            dgvCol.ReadOnly = true;
            dgvCol.DefaultCellStyle.Format = "0,00";
            dgvChiTiet.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Thành tiền (VNĐ)";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "ThanhTien";
            dgvCol.ReadOnly = true;
            dgvCol.DefaultCellStyle.Format = "0,00";
            dgvChiTiet.Columns.Add(dgvCol);
        }
        void LoadData()
        {
            dgvDanhSach.DataSource = HoaDonBUS.LoadDSHoaDon();
            Custom1();
            dgvDanhSach.ClearSelection();

            if (dgvDanhSach.Rows.Count > 0)
            {
                dgvChiTiet.DataSource = HoaDonBUS.LoadDSCTHoaDon(dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
                Custom2();
                dgvChiTiet.ClearSelection();
            }
        }

        private void tsbtnXoa_Click(object sender, EventArgs e)
        {
            if (HoaDonBUS.XoaHD(dgvDanhSach.CurrentRow.Cells[0].Value.ToString()) == true)
            {
                LoadData();
            }
            else
                MessageBox.Show("Xóa thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbtnLapphieu_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            tsbtnXoa.Enabled = false;
            frm.ShowDialog();
            LoadData();
        }
    }
}
