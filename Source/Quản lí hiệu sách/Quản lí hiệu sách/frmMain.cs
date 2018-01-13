using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BarcodeLib;
using DTO;
using BUS;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;

namespace Quản_lí_hiệu_sách
{
    public partial class frmMain : Form
    {
        string username = "", phanquyen = "";
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string Hoten,string USN,string PQ)
        {
            InitializeComponent();
            tlsHoten.Text = "Họ và tên: " + Hoten;
            tlsHoten.ForeColor = Color.Red;
            tlsDate.Text = DateTime.Now.ToShortDateString();
            username = USN;
            phanquyen = PQ;
        }
        void LoadData()
        {
            tsbtnXoa.Enabled = false;
            tsbtnSua.Enabled = false;
            dgvDanhSach.DataSource = SachBUS.DanhSachSach();
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void Custom()
        {
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
            dgvCo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvDanhSach.Columns.Add(dgvCo);

            dgvCo = new DataGridViewComboBoxColumn();
            dgvCo.HeaderText = "Nhà xuất bản";
            dgvCo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCo.DataSource = NhaXuatBanBUS.DanhSachNXB();
            dgvCo.DisplayMember = "TenNXB";
            dgvCo.ValueMember = "MaNXB";
            dgvCo.DataPropertyName = "MaNXB";
            dgvCo.ReadOnly = true;
            dgvCo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvDanhSach.Columns.Add(dgvCo);

            dgvCo = new DataGridViewComboBoxColumn();
            dgvCo.HeaderText = "Tác giả";
            dgvCo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCo.DataSource = TacGiaBUS.DanhSachTacGia();
            dgvCo.DisplayMember = "TenTG";
            dgvCo.ValueMember = "MaTG";
            dgvCo.DataPropertyName = "MaTG";
            dgvCo.ReadOnly = true;
            dgvCo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            dgvDanhSach.Columns.Add(dgvCo);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Số lượng tồn";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvCol.DataPropertyName = "SoLuongTon";
            dgvCol.ReadOnly = true;
            dgvCol.Width = 110;
            dgvDanhSach.Columns.Add(dgvCol);

            dgvCol = new DataGridViewTextBoxColumn();
            dgvCol.HeaderText = "Giá bán (VNĐ)";
            dgvCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCol.DataPropertyName = "GiaBan";
            dgvCol.ReadOnly = true;
            dgvCol.DefaultCellStyle.Format = "0,00";
            dgvDanhSach.Columns.Add(dgvCol);
        }

        private void tsbtnThem_Click(object sender, EventArgs e)
        {
            frmThemSach frm = new frmThemSach();
            tsbtnXoa.Enabled = false;
            tsbtnSua.Enabled = false;
            frm.ShowDialog();
            tsbBarcode.Image = null;
            LoadData();
        }

        private void tsbtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbtnXoa_Click(object sender, EventArgs e)
        {
            if ((int)dgvDanhSach.CurrentRow.Cells[5].Value > 0)
                MessageBox.Show("Sách còn tồn trong kho. Không thể xóa.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if(MessageBox.Show("Bạn có chắc chắn muốn xóa quyển sách này ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (SachBUS.XoaSach(dgvDanhSach.CurrentRow.Cells[0].Value.ToString()) == true)
                    {
                        tsbBarcode.Image = null;
                        LoadData();
                    }
                    else
                        MessageBox.Show("Xóa thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbtnSua_Click(object sender, EventArgs e)
        {
            SachDTO S = new SachDTO();
            S.MaSach = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
            S.TenSach = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
            S.MaTL = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
            S.MaNXB = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
            S.MaTG = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
            frmSuaSach frm = new frmSuaSach(S);
            tsbtnXoa.Enabled = false;
            tsbtnSua.Enabled = false;
            frm.ShowDialog();
            tsbBarcode.Image = null;
            LoadData();
        }

        private void phiếuNhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLPhieuNhap frm = new frmQLPhieuNhap();
            this.Hide();
            frm.ShowDialog();
            LoadData();
            tsbBarcode.Image = null;
            this.Show();
        }

        private void thểLoạiSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTheLoaiSach frm = new frmTheLoaiSach();
            this.Hide();
            frm.ShowDialog();
            LoadData();
            tsbBarcode.Image = null;
            this.Show();
        }
        void CreateBarcode()
        {
            Barcode b = new Barcode();
            b.BackColor = Color.White;
            b.ForeColor = Color.Black;
            b.IncludeLabel = true;
            b.Alignment = AlignmentPositions.CENTER;
            b.LabelPosition = LabelPositions.BOTTOMCENTER;
            b.ImageFormat = ImageFormat.Png;
            Font f = new Font("Verdana", 9f);
            b.LabelFont = f;
            b.Height = 65;
            b.Width = 180;
            tsbBarcode.Image = b.Encode(TYPE.CODE128, dgvDanhSach.CurrentRow.Cells[0].Value.ToString());
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            tsbtnSua.Enabled = true;
            CreateBarcode();
        }


        private void dgvDanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            tsbtnSua.Enabled = true;
            CreateBarcode();
        }

        private void dgvDanhSach_KeyUp(object sender, KeyEventArgs e)
        {
            tsbtnXoa.Enabled = true;
            tsbtnSua.Enabled = true;
            CreateBarcode();
        }

        private void nhàSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhaXuatBan frm = new frmNhaXuatBan();
            this.Hide();
            frm.ShowDialog();
            LoadData();
            tsbBarcode.Image = null;
            this.Show();
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTacGia frm = new frmTacGia();
            this.Hide();
            frm.ShowDialog();
            LoadData();
            tsbBarcode.Image = null;
            this.Show();
        }

        private void hóaĐơnBánSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLHoaDon frm = new frmQLHoaDon();
            this.Hide();
            frm.ShowDialog();
            LoadData();
            tsbBarcode.Image = null;
            this.Show();
        }

        private void theoTênSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemTheoTenSach frm = new frmTimKiemTheoTenSach(phanquyen);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            LoadData();
        }

        private void theoThểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemTheoTheLoai frm = new frmTimKiemTheoTheLoai(phanquyen);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            LoadData();
        }

        private void theoTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemTheoTacGia frm = new frmTimKiemTheoTacGia(phanquyen);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            LoadData();
        }

        private void theoNhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemTheoNXB frm = new frmTimKiemTheoNXB(phanquyen);
            this.Hide();
            frm.ShowDialog();
            this.Show();
            LoadData();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoDoanhThu frm = new frmBaoCaoDoanhThu();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void tồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoTonKho frm = new frmBaoCaoTonKho();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void báoCáoNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoNhapKho frm = new frmBaoCaoNhapKho();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void biểuĐồDoanhThuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBieuDo frm = new frmBieuDo();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        void SaveBarcoode()
        {
            if (tsbBarcode.Image != null)
            {
                Bitmap bmp = new Bitmap(tsbBarcode.Image);
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\Mã vạch";
                try
                {
                    bmp.Save(path + @"\" + dgvDanhSach.CurrentRow.Cells[1].Value.ToString() + ".png");
                }
                catch
                {
                    Directory.CreateDirectory(path);
                    bmp.Save(path + @"\" + dgvDanhSach.CurrentRow.Cells[1].Value.ToString() + ".png");
                }
                MessageBox.Show("Lưu mã vạch thành công.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Không thể lưu mã vạch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void tsbBarcode_Click(object sender, EventArgs e)
        {
            SaveBarcoode();
        }

        private void dgvDanhSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 's' || e.KeyChar == 'S')
                SaveBarcoode();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(username);
            frm.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLNhanVien frm = new frmQLNhanVien();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
