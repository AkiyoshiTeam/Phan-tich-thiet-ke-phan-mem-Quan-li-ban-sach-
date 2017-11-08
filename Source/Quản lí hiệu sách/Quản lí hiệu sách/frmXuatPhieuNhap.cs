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
    public partial class frmXuatPhieuNhap : Form
    {
        string sopn;
        public frmXuatPhieuNhap()
        {
            InitializeComponent();
        }
        public frmXuatPhieuNhap(string SoPN)
        {
            InitializeComponent();
            sopn = SoPN;
        }

        private void frmXuatPhieuNhap_Load(object sender, EventArgs e)
        {
            PhieuNhapSach report = new PhieuNhapSach();
            report.SetDataSource(PhieuNhapBUS.XuatPhieuNhapSach(sopn));
            crvXuatPhieuNhap.ReportSource = report;
        }
    }
}
