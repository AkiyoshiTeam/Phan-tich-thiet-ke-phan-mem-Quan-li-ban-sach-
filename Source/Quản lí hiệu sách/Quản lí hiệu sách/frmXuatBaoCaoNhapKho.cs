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
    public partial class frmXuatBaoCaoNhapKho : Form
    {
        DateTime ngay;
        public frmXuatBaoCaoNhapKho()
        {
            InitializeComponent();
        }
        public frmXuatBaoCaoNhapKho(DateTime Ngay)
        {
            InitializeComponent();
            ngay = Ngay;
        }

        private void frmXuatBaoCaoNhapKho_Load(object sender, EventArgs e)
        {
            BaoCaoNhapKho report = new BaoCaoNhapKho();
            report.SetDataSource(SachBUS.BaoCaoNhapKhoS(ngay));
            crvBaoCaoNhapKho.ReportSource = report;
        }
    }
}
