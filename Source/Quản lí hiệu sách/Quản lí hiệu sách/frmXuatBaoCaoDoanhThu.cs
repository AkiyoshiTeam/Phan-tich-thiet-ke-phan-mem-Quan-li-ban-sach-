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
    public partial class frmXuatBaoCaoDoanhThu : Form
    {
        DateTime ngay = new DateTime();
        public frmXuatBaoCaoDoanhThu()
        {
            InitializeComponent();
        }
        public frmXuatBaoCaoDoanhThu(DateTime Ngay)
        {
            InitializeComponent();
            ngay = Ngay;
        }

        private void frmXuatBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            BaoCaoDoanhThu report = new BaoCaoDoanhThu();
            report.SetDataSource(SachBUS.BaoCaoDoanhThuS(ngay));
            crvBaoCao.ReportSource = report;
        }
    }
}
