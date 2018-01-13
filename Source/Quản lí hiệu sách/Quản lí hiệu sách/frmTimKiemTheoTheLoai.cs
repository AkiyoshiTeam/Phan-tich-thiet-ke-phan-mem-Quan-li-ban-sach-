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
    public partial class frmTimKiemTheoTheLoai : Form
    {
        string phanquyen = "";
        public frmTimKiemTheoTheLoai()
        {
            InitializeComponent();
        }

        public frmTimKiemTheoTheLoai(string PQ)
        {
            InitializeComponent();
            phanquyen = PQ;
        }
        void LoadData()
        {
            if (SachBUS.TimKiemTheoTheLoai(cboTheLoai.SelectedValue.ToString()).Rows.Count > 0)
            {
                dgvDanhSach.DataSource = SachBUS.TimKiemTheoTheLoai(cboTheLoai.SelectedValue.ToString());
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
                dgvDanhSach.DataSource = SachBUS.TimKiemTheoTheLoai(cboTheLoai.SelectedValue.ToString());
                Custom();
                dgvDanhSach.ClearSelection();
            }
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
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

            DataGridViewButtonColumn dgvBtt = new DataGridViewButtonColumn();
            dgvBtt.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvBtt.HeaderText = "Cập nhật";
            dgvDanhSach.Columns.Add(dgvBtt);

            dgvBtt = new DataGridViewButtonColumn();
            dgvBtt.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dgvBtt.HeaderText = "Xóa";
            dgvDanhSach.Columns.Add(dgvBtt);
        }
        private void frmTimKiemTheoTheLoai_Load(object sender, EventArgs e)
        {
            cboTheLoai.DataSource = TheLoaiBUS.DanhSachTheLoai();
            cboTheLoai.DisplayMember = "TenTL";
            cboTheLoai.ValueMember = "MaTL";
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (phanquyen == "Admin")
                {
                    SachDTO S = new SachDTO();
                    S.MaSach = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    S.TenSach = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    S.MaTL = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                    S.MaNXB = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                    S.MaTG = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                    frmSuaSach frm = new frmSuaSach(S);
                    frm.ShowDialog();
                    LoadData();
                }
                else
                    MessageBox.Show("Bạn không phải là Admin nên không thực hiện được chức năng này.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.ColumnIndex == 8)
            {
                if (phanquyen == "Admin")
                {
                    if ((int)dgvDanhSach.CurrentRow.Cells[5].Value > 0)
                        MessageBox.Show("Sách còn tồn trong kho. Không thể xóa.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa quyển sách này ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (SachBUS.XoaSach(dgvDanhSach.CurrentRow.Cells[0].Value.ToString()) == true)
                            {
                                LoadData();
                            }
                            else
                                MessageBox.Show("Xóa thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Bạn không phải là Admin nên không thực hiện được chức năng này.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
