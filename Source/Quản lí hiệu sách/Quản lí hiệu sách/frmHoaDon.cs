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
using System.IO;
using System.Drawing.Imaging;

namespace Quản_lí_hiệu_sách
{
    public partial class frmHoaDon : Form
    {
        int i;
        long Tien;
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            dtkNgayBan.Value = DateTime.Now;
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.Rows.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLapHoaDonMoi_Click(object sender, EventArgs e)
        {
            i = 0;
            Tien = 0;
            txtTongtien.Text = "0";
            btnGhiHoaDon.Enabled = true;
            btnLapHoaDonMoi.Enabled = false;
            btnThemSach.Enabled = false;
            txtSoHD.Text = HoaDonBUS.GetIDHoaDon();
            txtMaSach.ResetText();
            txtTenSach.ResetText();
            txtGiaBan.ResetText();
            dtkNgayBan.Value = DateTime.Now;
            dgvDanhSach.Rows.Clear();
        }

        private void btnGhiHoaDon_Click(object sender, EventArgs e)
        {
            // Tạo mã vạch QR
            MessagingToolkit.QRCode.Codec.QRCodeEncoder encoder = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
            encoder.QRCodeScale = 3;
            Bitmap bmp = encoder.Encode(txtSoHD.Text);
            // Chuyển hình ảnh ra dạng nhị phân
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            byte[] bmpBytes = ms.GetBuffer();
            bmp.Dispose();
            ms.Close();

            HoaDonDTO HD = new HoaDonDTO();
            HD.SoHD = txtSoHD.Text;
            HD.NgayBan = dtkNgayBan.Value;
            HD.HinhAnh = bmpBytes;
            if(HoaDonBUS.ThemHD(HD)==true)
            {
                btnLapHoaDonMoi.Enabled = true;
                btnThemSach.Enabled = true;
                btnGhiHoaDon.Enabled = false;
                btnInHoaDon.Enabled = true;
            }
            else
                MessageBox.Show("Thêm hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            int j = 0;
            if (txtMaSach.Text == "")
                MessageBox.Show("Mã sách không được để trống.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTenSach.Text != "")
            {
                // Đưa giá trị vào DataGridView
                if (dgvDanhSach.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvDanhSach.Rows)
                    {
                        if (txtMaSach.Text == dgvDanhSach.Rows[j].Cells[0].Value.ToString())
                        {
                            dgvDanhSach.Rows[j].Cells[2].Value = (Int32.Parse(dgvDanhSach.Rows[j].Cells[2].Value.ToString()) + 1).ToString();
                            break;
                        }
                        else if (j == dgvDanhSach.Rows.Count - 1)
                        {
                            dgvDanhSach.Rows.Add();
                            dgvDanhSach.Rows[i].Cells[0].Value = txtMaSach.Text;
                            dgvDanhSach.Rows[i].Cells[1].Value = txtTenSach.Text;
                            dgvDanhSach.Rows[i].Cells[2].Value = txtSoLuong.Text;
                            dgvDanhSach.Rows[i].Cells[3].Value = txtGiaBan.Text;
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
                    dgvDanhSach.Rows[i].Cells[2].Value = txtSoLuong.Text;
                    dgvDanhSach.Rows[i].Cells[3].Value = txtGiaBan.Text;
                    i++;
                }
                // Tính tổng tiền
                TongTien();
            }
        }
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            for (int k = 0; k < dgvDanhSach.Rows.Count; k++)
            {
                ChiTietHoaDonDTO CT = new ChiTietHoaDonDTO();
                CT.SoHD = txtSoHD.Text;
                CT.MaSach = dgvDanhSach.Rows[k].Cells[0].Value.ToString();
                CT.SoLuongBan = int.Parse(dgvDanhSach.Rows[k].Cells[2].Value.ToString());
                CT.GiaBan = Int64.Parse(dgvDanhSach.Rows[k].Cells[3].Value.ToString());
                CT.ThanhTien = Int64.Parse(dgvDanhSach.Rows[k].Cells[3].Value.ToString()) * int.Parse(dgvDanhSach.Rows[k].Cells[2].Value.ToString());
                if (HoaDonBUS.ThemCTHD(CT) == true)
                {
                    // Update tổng tiền.
                    if (HoaDonBUS.UpdateTT(txtSoHD.Text, Tien) == false)
                        MessageBox.Show("Cập nhật tổng tiền thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Update số lượng tồn.
                    if (HoaDonBUS.UpdateSLT(dgvDanhSach.Rows[k].Cells[0].Value.ToString(), int.Parse(dgvDanhSach.Rows[k].Cells[2].Value.ToString())) == false)
                        MessageBox.Show("Cập nhật số lượng tồn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Thêm chi tiết hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnInHoaDon.Enabled = false;
            btnThemSach.Enabled = false;
            // Xuất ra Cystal report
            frmXuatHoaDon frm = new frmXuatHoaDon(txtSoHD.Text);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void txtMaSach_TextChanged(object sender, EventArgs e)
        {
            if (SachBUS.DanhSachSachTheoMa(txtMaSach.Text).Rows.Count > 0)
            {
                foreach (DataRow row in SachBUS.DanhSachSachTheoMa(txtMaSach.Text).Rows)
                {
                    txtTenSach.Text = row["TenSach"].ToString();
                    txtGiaBan.Text = row["GiaBan"].ToString();
                }
            }
            else
            {
                txtTenSach.ResetText();
                txtGiaBan.ResetText();
            }
        }

        private void dgvDanhSach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TongTien();
        }

        void TongTien()
        {
            long TongTien = 0;
            for (int k = 0; k < dgvDanhSach.Rows.Count; k++)
            {
                TongTien = TongTien + (Int64.Parse(dgvDanhSach.Rows[k].Cells[3].Value.ToString()) * Int64.Parse(dgvDanhSach.Rows[k].Cells[2].Value.ToString()));
            }
            txtTongtien.Text = String.Format("{0:0,0}", TongTien);
            Tien = TongTien;
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                dgvDanhSach.Rows.RemoveAt(e.RowIndex);
                i--;
                TongTien();
            }
        }
    }
}
