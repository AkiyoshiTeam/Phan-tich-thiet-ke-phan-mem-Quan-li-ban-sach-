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
using System.IO;
using System.Drawing.Imaging;

namespace Quản_lí_hiệu_sách
{
    public partial class frmPhieuNhapSach : Form
    {
        int i;
        long Tien;
        public frmPhieuNhapSach()
        {
            InitializeComponent();
        }

        private void frmPhieuNhapSach_Load(object sender, EventArgs e)
        {
            cboNXB.DataSource = NhaXuatBanBUS.DanhSachNXB();
            cboNXB.DisplayMember = "TenNXB";
            cboNXB.ValueMember = "MaNXB";
            dgvDanhSach.AllowUserToAddRows = false;
            dtkNgayNhap.Value = DateTime.Now;
            dgvDanhSach.Rows.Clear();
        }

        private void btnLapPhieuMoi_Click(object sender, EventArgs e)
        {
            i = 0;
            Tien = 0;
            txtTongtien.Text = "0";
            btnGhiPhieu.Enabled = true;
            btnLapPhieuMoi.Enabled = false;
            btnThemSach.Enabled = false;
            cboNXB.Enabled = true;
            txtSoPN.Text = PhieuNhapBUS.GetIDPhieuNhap();
            txtMaSach.ResetText();
            txtTenSach.ResetText();
            txtSoLuong.ResetText();
            txtTacgia.ResetText();
            txtGiaNhap.ResetText();
            txtTheloai.ResetText();
            dtkNgayNhap.Value = DateTime.Now;
            dgvDanhSach.Rows.Clear();
        }

        private void btnGhiPhieu_Click(object sender, EventArgs e)
        {
            // Tạo mã vạch QR
            MessagingToolkit.QRCode.Codec.QRCodeEncoder encoder = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
            encoder.QRCodeScale = 3;
            Bitmap bmp = encoder.Encode(txtSoPN.Text);
            // Chuyển hình ảnh ra dạng nhị phân
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            byte[] bmpBytes = ms.GetBuffer();
            bmp.Dispose();
            ms.Close();

            PhieuNhapDTO PN = new PhieuNhapDTO();
            PN.SoPN = txtSoPN.Text;
            PN.NgayNhap = dtkNgayNhap.Value;
            PN.MaNXB = cboNXB.SelectedValue.ToString();
            PN.HinhAnh = bmpBytes;
            if (PhieuNhapBUS.ThemPN(PN) == true)
            {
                btnLapPhieuMoi.Enabled = true;
                btnThemSach.Enabled = true;
                btnGhiPhieu.Enabled = false;
                btnIn.Enabled = true;
                cboNXB.Enabled = false;

                AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
                foreach(DataRow row in SachBUS.DanhSachTenSachTheoNXB(cboNXB.SelectedValue.ToString()).Rows)
                {
                    auto.Add(row["TenSach"].ToString());
                }
                txtTenSach.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtTenSach.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtTenSach.AutoCompleteCustomSource = auto;
            }
            else
                MessageBox.Show("Thêm phiếu nhập thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtTenSach_TextChanged(object sender, EventArgs e)
        {
            if (SachBUS.DanhSachSachTheoTen(txtTenSach.Text).Rows.Count > 0)
            {
                foreach (DataRow row in SachBUS.DanhSachSachTheoTen(txtTenSach.Text).Rows)
                {
                    txtMaSach.Text = row["MaSach"].ToString();
                    txtTheloai.Text = row["TenTL"].ToString();
                    txtTacgia.Text = row["TenTG"].ToString();
                }
            }
            else
            {
                txtMaSach.ResetText();
                txtTheloai.ResetText();
                txtTacgia.ResetText();
                txtSoLuong.ResetText();
                txtGiaNhap.ResetText();
            }
        }
        string KiemTra()
        {
            string thongbao = "";
            if (txtTenSach.Text == "")
                thongbao += "-Tên sách không được để trống.\n";
            if (txtSoLuong.Text == "")
                thongbao += "-Số lượng không được để trống.\n";
            if (txtGiaNhap.Text == "")
                thongbao += "-Giá nhập không được để trống.\n";
            return thongbao;
        }
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            int j = 0;
            if (KiemTra() != "")
                MessageBox.Show(string.Format("{0}", KiemTra()), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // Đưa giá trị vào DataGridView
                if (dgvDanhSach.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDanhSach.Rows)
                    {
                        if (txtMaSach.Text == dgvDanhSach.Rows[j].Cells[0].Value.ToString())
                        {
                            dgvDanhSach.Rows[j].Cells[4].Value = (Int32.Parse(dgvDanhSach.Rows[j].Cells[4].Value.ToString()) + Int32.Parse(txtSoLuong.Text)).ToString();
                            break;
                        }
                        else if (j == dgvDanhSach.Rows.Count - 1)
                        {
                            dgvDanhSach.Rows.Add();
                            dgvDanhSach.Rows[i].Cells[0].Value = txtMaSach.Text;
                            dgvDanhSach.Rows[i].Cells[1].Value = txtTenSach.Text;
                            dgvDanhSach.Rows[i].Cells[2].Value = txtTheloai.Text;
                            dgvDanhSach.Rows[i].Cells[3].Value = txtTacgia.Text;
                            dgvDanhSach.Rows[i].Cells[4].Value = txtSoLuong.Text;
                            dgvDanhSach.Rows[i].Cells[5].Value = txtGiaNhap.Text;
                            i++;
                            break;
                        }
                        j++;
                    }
                }
                else
                {
                    dgvDanhSach.Rows.Add();
                    dgvDanhSach.Rows[i].Cells[0].Value = txtMaSach.Text;
                    dgvDanhSach.Rows[i].Cells[1].Value = txtTenSach.Text;
                    dgvDanhSach.Rows[i].Cells[2].Value = txtTheloai.Text;
                    dgvDanhSach.Rows[i].Cells[3].Value = txtTacgia.Text;
                    dgvDanhSach.Rows[i].Cells[4].Value = txtSoLuong.Text;
                    dgvDanhSach.Rows[i].Cells[5].Value = txtGiaNhap.Text;
                    i++;
                }
                // Tính tổng tiền
                TongTien();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgvDanhSach.Rows.Count; k++)
            {
                ChiTietPhieuNhapDTO PN = new ChiTietPhieuNhapDTO();
                PN.SoPN = txtSoPN.Text;
                PN.MaSach = dgvDanhSach.Rows[k].Cells[0].Value.ToString();
                PN.SoLuongNhap = int.Parse(dgvDanhSach.Rows[k].Cells[4].Value.ToString());
                PN.GiaNhap = Int64.Parse(dgvDanhSach.Rows[k].Cells[5].Value.ToString());
                if (PhieuNhapBUS.ThemCTPN(PN) == true)
                {
                    // Update tổng tiền.
                    if (PhieuNhapBUS.UpdateTT(txtSoPN.Text, Tien) == false)
                        MessageBox.Show("Cập nhật tổng tiền thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Update số lượng tồn và giá bán.
                    if (SachBUS.UpdateSLTvaGB(dgvDanhSach.Rows[k].Cells[0].Value.ToString(), Int64.Parse(dgvDanhSach.Rows[k].Cells[5].Value.ToString()), int.Parse(dgvDanhSach.Rows[k].Cells[4].Value.ToString())) == false)
                        MessageBox.Show("Cập nhật số lượng tồn và giá bán thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Thêm chi tiết phiếu nhập thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnIn.Enabled = false;
            btnThemSach.Enabled = false;
            // Xuất ra cystal report
            frmXuatPhieuNhap frm = new frmXuatPhieuNhap(txtSoPN.Text);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        void TongTien()
        {
            long TongTien = 0;
            for (int k = 0; k < dgvDanhSach.Rows.Count; k++)
            {
                TongTien = TongTien + (Int64.Parse(dgvDanhSach.Rows[k].Cells[5].Value.ToString()) * Int64.Parse(dgvDanhSach.Rows[k].Cells[4].Value.ToString()));
            }
            txtTongtien.Text = String.Format("{0:0,0}", TongTien);
            Tien = TongTien;
        }

        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TongTien();
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                dgvDanhSach.Rows.RemoveAt(e.RowIndex);
                i--;
                TongTien();
            }
        }
    }
}
