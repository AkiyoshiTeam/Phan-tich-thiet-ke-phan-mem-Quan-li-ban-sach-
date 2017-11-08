using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Quản_lí_hiệu_sách
{
    public partial class frmLoading : Form
    {
        int i;
        double PhanTram;
        public frmLoading()
        {
            InitializeComponent();
            timer1.Interval = 20;
            progressBar1.Maximum = 100;
            i = 100;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i != 0)
            {
                i--;
                progressBar1.Value++;
                PhanTram = (progressBar1.Value / (double)progressBar1.Maximum) * 100;
                lbPhanTram.Text = PhanTram.ToString() + " %";
            }
            else
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
