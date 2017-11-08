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
    public partial class frmTacGia : Form
    {
        public frmTacGia()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void LoadData()
        {
            dgvDanhSach.DataSource = TacGiaBUS.DanhSachTacGia();
            Custom();
            dgvDanhSach.ClearSelection();
        }
        private void frmTacGia_Load(object sender, EventArgs e)
        {
            txtMaTG.Text = TacGiaBUS.GetIDTG();
            LoadData();
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
            dgvCol.HeaderText = "Mã tác giả";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "MaTG";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Tên tác giả";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "TenTG";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 160;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Địa chỉ";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "DiaChi";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTG.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
            txtTenTG.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
        }
        private void dgvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            txtMaTG.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
            txtTenTG.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
        }

        private void dgvDanhSach_KeyUp(object sender, KeyEventArgs e)
        {
            txtMaTG.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
            txtTenTG.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaTG.Text = TacGiaBUS.GetIDTG();
            txtTenTG.ResetText();
            txtDiaChi.ResetText();
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenTG.Text != "")
            {
                TacGiaDTO TG = new TacGiaDTO();
                TG.MaTG = txtMaTG.Text;
                TG.TenTG = txtTenTG.Text;
                TG.DiaChi = txtDiaChi.Text;
                if (TacGiaBUS.ThemTG(TG) == true)
                {
                    txtMaTG.Text = TacGiaBUS.GetIDTG();
                    txtTenTG.ResetText();
                    txtDiaChi.ResetText();
                    LoadData();
                }
                else
                    MessageBox.Show("Thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Tên tác giả không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(TacGiaBUS.XoaTG(dgvDanhSach.CurrentRow.Cells[0].Value.ToString())==true)
            {
                txtMaTG.Text = TacGiaBUS.GetIDTG();
                txtTenTG.ResetText();
                txtDiaChi.ResetText();
                LoadData();
            }
            else
                MessageBox.Show("Không thể xóa vì còn tồn tại sách thuộc tác giả này.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TacGiaDTO TG = new TacGiaDTO();
            TG.MaTG = txtMaTG.Text;
            TG.TenTG = txtTenTG.Text;
            TG.DiaChi = txtDiaChi.Text;
            if(TacGiaBUS.SuaTG(TG)==true)
            {
                LoadData();
            }
            else
                MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
