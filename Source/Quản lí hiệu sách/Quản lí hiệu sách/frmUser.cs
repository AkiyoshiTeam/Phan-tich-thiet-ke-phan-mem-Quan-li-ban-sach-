using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quản_lí_hiệu_sách
{
    public partial class frmUser : Form
    {
        string username = "";
        public frmUser()
        {
            InitializeComponent();
        }
        public frmUser(string Hoten, string USN)
        {
            InitializeComponent();
            tlsDate.Text = DateTime.Now.ToShortDateString();
            tlsHoten.Text = "Họ và tên: " + Hoten;
            tlsHoten.ForeColor = Color.Red;
            username = USN;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void theoTênSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemTheoTenSach frm = new frmTimKiemTheoTenSach();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void theoThểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemTheoTheLoai frm = new frmTimKiemTheoTheLoai();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void theoTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemTheoTacGia frm = new frmTimKiemTheoTacGia();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void theoNhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemTheoNXB frm = new frmTimKiemTheoNXB();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lậpHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void thayĐổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(username);
            frm.ShowDialog();
        }
    }
}
