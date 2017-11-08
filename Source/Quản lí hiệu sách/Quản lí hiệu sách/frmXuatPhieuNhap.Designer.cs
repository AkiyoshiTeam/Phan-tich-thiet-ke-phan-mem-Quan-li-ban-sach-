namespace Quản_lí_hiệu_sách
{
    partial class frmXuatPhieuNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatPhieuNhap));
            this.crvXuatPhieuNhap = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvXuatPhieuNhap
            // 
            this.crvXuatPhieuNhap.ActiveViewIndex = -1;
            this.crvXuatPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.crvXuatPhieuNhap.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvXuatPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvXuatPhieuNhap.Location = new System.Drawing.Point(0, 0);
            this.crvXuatPhieuNhap.Name = "crvXuatPhieuNhap";
            this.crvXuatPhieuNhap.Size = new System.Drawing.Size(759, 273);
            this.crvXuatPhieuNhap.TabIndex = 0;
            // 
            // frmXuatPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 273);
            this.Controls.Add(this.crvXuatPhieuNhap);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmXuatPhieuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xuất Phiếu Nhập Sách";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXuatPhieuNhap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvXuatPhieuNhap;
    }
}