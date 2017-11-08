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
    public partial class frmBaoCaoTonKho : Form
    {
        public frmBaoCaoTonKho()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = SachBUS.DanhSachSach();
            Custom();
            dgvDanhSach.ClearSelection();
            for (int i = 0; i < dgvDanhSach.RowCount; i++)
            {
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.BackColor = Color.Yellow;
                if (int.Parse(dgvDanhSach.Rows[i].Cells[2].Value.ToString()) <= 10)
                {
                    dgvDanhSach.Rows[i].DefaultCellStyle = style;
                }
            }
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
            dgvCol.HeaderText = "Số lượng tồn";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "SoLuongTon";
            dgvCol.Width = 200;
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmXuatThongKeTonKho frm = new frmXuatThongKeTonKho();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
