using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using BUS;
using DTO;

namespace Quản_lí_hiệu_sách
{
    public partial class frmBieuDo : Form
    {
        public frmBieuDo()
        {
            InitializeComponent();
        }

        private void frmBieuDo_Load(object sender, EventArgs e)
        {
            chBieuDo.ChartAreas["ChartArea1"].AxisX.Title = "Ngày tháng";
            chBieuDo.ChartAreas["ChartArea1"].AxisY.Title = "Doanh thu";
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
            dgvCol.HeaderText = "Ngày tháng";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "NgayBan";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Tổng doanh thu";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "Doanhthu";
            dgvCol.DefaultCellStyle.Format = "0,00 VNĐ";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVeBieuDo_Click(object sender, EventArgs e)
        {
            chBieuDo.Series["Doanh thu"].Points.Clear();
            int i = 0;
            foreach (DataRow row in SachBUS.BieuDo(dtkTu.Value,dtkDen.Value).Rows)
            {
                chBieuDo.Series["Doanh thu"].Points.Add(Int64.Parse(row["Doanhthu"].ToString()));
                chBieuDo.Series["Doanh thu"].Points[i].Color = Color.Red;
                chBieuDo.Series["Doanh thu"].Points[i].BorderWidth = 2;
                chBieuDo.Series["Doanh thu"].Points[i].AxisLabel = DateTime.Parse(row["NgayBan"].ToString()).ToShortDateString();
                chBieuDo.Series["Doanh thu"].Points[i].Label = string.Format("{0:0,0}", row["Doanhthu"]);
                i++;
            }

            dgvDanhSach.DataSource = SachBUS.BieuDo(dtkTu.Value, dtkDen.Value);
            Custom();
            dgvDanhSach.ClearSelection();
        }
    }
}
