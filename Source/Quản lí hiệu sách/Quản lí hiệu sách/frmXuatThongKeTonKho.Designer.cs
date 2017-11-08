namespace Quản_lí_hiệu_sách
{
    partial class frmXuatThongKeTonKho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatThongKeTonKho));
            this.crvThongKe = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvThongKe
            // 
            this.crvThongKe.ActiveViewIndex = -1;
            this.crvThongKe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.crvThongKe.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvThongKe.Location = new System.Drawing.Point(0, 0);
            this.crvThongKe.Name = "crvThongKe";
            this.crvThongKe.Size = new System.Drawing.Size(657, 270);
            this.crvThongKe.TabIndex = 0;
            // 
            // frmXuatThongKeTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 270);
            this.Controls.Add(this.crvThongKe);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmXuatThongKeTonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống Kê Số Lượng Tồn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXuatThongKeTonKho_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvThongKe;
    }
}