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
    public partial class frmTheLoaiSach : Form
    {
        public frmTheLoaiSach()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            dgvDanhSach.DataSource = TheLoaiBUS.DanhSachTheLoai();
            Custom();
            dgvDanhSach.ClearSelection();
        }
        private void frmTheLoaiSach_Load(object sender, EventArgs e)
        {
            txtMaTL.Text = TheLoaiBUS.GetIDTheLoai();
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
            dgvCol.HeaderText = "Mã thể loại";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "MaTL";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Tên thể loại";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "TenTL";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaTL.Text = TheLoaiBUS.GetIDTheLoai();
            txtTenTL.ResetText();
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            LoadData();
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = false;

            txtMaTL.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
            txtTenTL.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
        }

        private void dgvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = false;

            txtMaTL.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
            txtTenTL.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
        }

        private void dgvDanhSach_KeyUp(object sender, KeyEventArgs e)
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = false;

            txtMaTL.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
            txtTenTL.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenTL.Text == "")
                MessageBox.Show("Tên thể loại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                TheLoaiDTO TL = new TheLoaiDTO();
                TL.MaTL = txtMaTL.Text;
                TL.TenTL = txtTenTL.Text;
                if(TheLoaiBUS.ThemTL(TL)==true)
                {
                    txtMaTL.Text = TheLoaiBUS.GetIDTheLoai();
                    txtTenTL.ResetText();
                    LoadData();
                }
                else
                    MessageBox.Show("Thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (TheLoaiBUS.XoaTL(dgvDanhSach.CurrentRow.Cells[0].Value.ToString()) == true)
            {
                txtMaTL.Text = TheLoaiBUS.GetIDTheLoai();
                txtTenTL.ResetText();
                LoadData();
            }
            else
                MessageBox.Show("Không thể xóa vì còn tồn tại sách thuộc thể loại đó.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            TheLoaiDTO TL = new TheLoaiDTO();
            TL.MaTL = txtMaTL.Text;
            TL.TenTL = txtTenTL.Text;
            if(TheLoaiBUS.SuaTL(TL)==true)
            {
                LoadData();
            }
            else
                MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
