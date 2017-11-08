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
    public partial class frmNhaXuatBan : Form
    {
        public frmNhaXuatBan()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void LoadData()
        {
            dgvDanhSach.DataSource = NhaXuatBanBUS.DanhSachNXB();
            Custom();
            dgvDanhSach.ClearSelection();
        }
        private void frmNhaXuatBan_Load(object sender, EventArgs e)
        {
            txtMaNXB.Text = NhaXuatBanBUS.GetIDNXB();
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
            dgvCol.HeaderText = "Mã nhà xuất bản";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCol.DataPropertyName = "MaNXB";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Tên nhà xuất bản";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "TenNXB";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 160;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Địa chỉ";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "DiaChi";
            dgvCol.ReadOnly = true;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Điện thoại";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "DienThoai";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 110;
            dgvDanhSach.Columns.Add(dgvCol);
        }
        string KiemTra()
        {
            string thongbao = "";
            if (txtTenNXB.Text == "")
                thongbao += "-Tên nhà xuất bản không được để trống.\n";
            if (txtDiaChi.Text == "")
                thongbao += "-Địa chỉ không được để trống.\n";
            if (txtDienThoai.Text == "")
                thongbao += "-Điện thoại không được để trống.\n";
            return thongbao;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra() == "")
            {
                NhaXuatBanDTO NXB = new NhaXuatBanDTO();
                NXB.MaNXB = txtMaNXB.Text;
                NXB.TenNXB = txtTenNXB.Text;
                NXB.DiaChi = txtDiaChi.Text;
                NXB.DienThoai = txtDienThoai.Text;
                if(NhaXuatBanBUS.ThemNXB(NXB)==true)
                {
                    txtMaNXB.Text = NhaXuatBanBUS.GetIDNXB();
                    txtTenNXB.ResetText();
                    txtDiaChi.ResetText();
                    txtDienThoai.ResetText();
                    LoadData();
                }
                else
                    MessageBox.Show("Thêm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(string.Format("{0}", KiemTra()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaNXB.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
            txtTenNXB.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
            txtDienThoai.Text = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
        }
        private void dgvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaNXB.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
            txtTenNXB.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
            txtDienThoai.Text = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
        }

        private void dgvDanhSach_KeyUp(object sender, KeyEventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            txtMaNXB.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
            txtTenNXB.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
            txtDienThoai.Text = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtMaNXB.Text = NhaXuatBanBUS.GetIDNXB();
            txtTenNXB.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            LoadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (NhaXuatBanBUS.XoaNXB(dgvDanhSach.CurrentRow.Cells[0].Value.ToString()) == true)
            {
                txtMaNXB.Text = NhaXuatBanBUS.GetIDNXB();
                txtTenNXB.ResetText();
                txtDiaChi.ResetText();
                txtDienThoai.ResetText();
                LoadData();
            }
            else
                MessageBox.Show("Không thể xóa vì còn tồn tại sách thuộc nhà xuất bản đó.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhaXuatBanDTO NXB = new NhaXuatBanDTO();
            NXB.MaNXB = txtMaNXB.Text;
            NXB.TenNXB = txtTenNXB.Text;
            NXB.DiaChi = txtDiaChi.Text;
            NXB.DienThoai = txtDienThoai.Text;
            if (NhaXuatBanBUS.SuaNXB(NXB) == true)
            {
                LoadData();
            }
            else
                MessageBox.Show("Cập nhật thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
