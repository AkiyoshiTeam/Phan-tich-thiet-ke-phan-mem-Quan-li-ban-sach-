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
    public partial class frmXuatHoaDon : Form
    {
        string sohd;
        public frmXuatHoaDon()
        {
            InitializeComponent();
        }
        public frmXuatHoaDon(string soHD)
        {
            InitializeComponent();
            sohd = soHD;
        }

        private void frmXuatHoaDon_Load(object sender, EventArgs e)
        {
            XuatHoaDon report = new XuatHoaDon();
            report.SetDataSource(HoaDonBUS.XuatHoaDon(sohd));
            crvXuatHoaDon.ReportSource = report;
        }
    }
}
