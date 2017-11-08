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
    public partial class frmXuatThongKeTonKho : Form
    {
        public frmXuatThongKeTonKho()
        {
            InitializeComponent();
        }

        private void frmXuatThongKeTonKho_Load(object sender, EventArgs e)
        {
            ThongKeTonKho report = new ThongKeTonKho();
            report.SetDataSource(SachBUS.ThongKeTonKho());
            crvThongKe.ReportSource = report;
        }
    }
}
