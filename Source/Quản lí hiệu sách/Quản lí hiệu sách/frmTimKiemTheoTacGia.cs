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
    public partial class frmTimKiemTheoTacGia : Form
    {
        public frmTimKiemTheoTacGia()
        {
            InitializeComponent();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (SachBUS.TimKiemTheoTacGia(txtTenTG.Text).Rows.Count > 0)
            {
                dgvDanhSach.DataSource = SachBUS.TimKiemTheoTacGia(txtTenTG.Text);
                Custom();
                dgvDanhSach.ClearSelection();
                for (int i = 0; i < dgvDanhSach.RowCount; i++)
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = Color.Yellow;
                    if (int.Parse(dgvDanhSach.Rows[i].Cells[5].Value.ToString()) <= 10)
                    {
                        dgvDanhSach.Rows[i].DefaultCellStyle = style;
                    }
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvDanhSach.DataSource = SachBUS.TimKiemTheoTacGia(txtTenTG.Text);
                Custom();
                dgvDanhSach.ClearSelection();
                txtTenTG.ResetText();
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
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "TenSach";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 400;
            dgvDanhSach.Columns.Add(dgvCol);

            DataGridViewComboBoxColumn dgvCo = new DataGridViewComboBoxColumn();
            dgvCo.HeaderText = "Thể loại";
            dgvCo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCo.DataSource = TheLoaiBUS.DanhSachTheLoai();
            dgvCo.DisplayMember = "TenTL";
            dgvCo.ValueMember = "MaTL";
            dgvCo.DataPropertyName = "MaTL";
            dgvCo.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCo);

            dgvCo = new DataGridViewComboBoxColumn();
            dgvCo.HeaderText = "Nhà xuất bản";
            dgvCo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCo.DataSource = NhaXuatBanBUS.DanhSachNXB();
            dgvCo.DisplayMember = "TenNXB";
            dgvCo.ValueMember = "MaNXB";
            dgvCo.DataPropertyName = "MaNXB";
            dgvCo.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCo);

            dgvCo = new DataGridViewComboBoxColumn();
            dgvCo.HeaderText = "Tác giả";
            dgvCo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCo.DataSource = TacGiaBUS.DanhSachTacGia();
            dgvCo.DisplayMember = "TenTG";
            dgvCo.ValueMember = "MaTG";
            dgvCo.DataPropertyName = "MaTG";
            dgvCo.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCo);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Số lượng tồn";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "SoLuongTon";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 110;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Giá bán";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "GiaBan";
            dgvCol.ReadOnly = true;
            dgvCol.DefaultCellStyle.Format = "0,00 VNĐ";
            dgvDanhSach.Columns.Add(dgvCol);
        }
    }
}
