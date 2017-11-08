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
    public partial class frmBaoCaoNhapKho : Form
    {
        public frmBaoCaoNhapKho()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = SachBUS.BaoCaoNhapKho(dtkNgay.Value);
            Custom();
            dgvDanhSach.ClearSelection();
            int TongCong = 0;

            for (int i = 0; i < dgvDanhSach.RowCount; i++)
            {
                TongCong = TongCong + int.Parse(dgvDanhSach.Rows[i].Cells[2].Value.ToString());
            }
            txtTongcong.Text = TongCong.ToString();
        }
        void Custom()
        {
            if (!dgvDanhSach.AutoGenerateColumns)
            {
                return;
            }
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.Columns.Clear();
            dgvDanhSach.AllowUserToAddRows = false;

            DataGridViewTextBoxColumn dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Mã sách";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "MaSach";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Tên sách";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "TenSach";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Số lượng nhập";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "SoLuongNhap";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 200;
            dgvDanhSach.Columns.Add(dgvCol);
        }

        private void frmBaoCaoNhapKho_Load(object sender, EventArgs e)
        {
            dtkNgay.Value = DateTime.Now;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmXuatBaoCaoNhapKho frm = new frmXuatBaoCaoNhapKho(dtkNgay.Value);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
