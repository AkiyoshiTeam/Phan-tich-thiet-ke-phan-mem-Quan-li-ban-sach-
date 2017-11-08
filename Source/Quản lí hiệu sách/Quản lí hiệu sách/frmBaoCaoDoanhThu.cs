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
    public partial class frmBaoCaoDoanhThu : Form
    {
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = SachBUS.BaoCaoDoanhThu(dtkNgay.Value);
            Custom();
            dgvDanhSach.ClearSelection();
            long TongTien = 0;

            for (int i = 0; i < dgvDanhSach.RowCount;i++ )
            {
                TongTien = TongTien + Int64.Parse(dgvDanhSach.Rows[i].Cells[3].Value.ToString());
            }
            txtTongtien.Text = String.Format("{0:0,0}", TongTien); 
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
            dgvCol.HeaderText = "Số lượng bán";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "SoLuongBan";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Doanh thu (VNĐ)";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "ThanhTien";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 160;
            dgvCol.DefaultCellStyle.Format = "0,00";
            dgvDanhSach.Columns.Add(dgvCol);
        }

        private void frmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            dtkNgay.Value = DateTime.Now;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmXuatBaoCaoDoanhThu frm = new frmXuatBaoCaoDoanhThu(dtkNgay.Value);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
