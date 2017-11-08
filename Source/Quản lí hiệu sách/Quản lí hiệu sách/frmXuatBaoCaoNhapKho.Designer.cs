namespace Quản_lí_hiệu_sách
{
    partial class frmXuatBaoCaoNhapKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatBaoCaoNhapKho));
            this.crvBaoCaoNhapKho = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvBaoCaoNhapKho
            // 
            this.crvBaoCaoNhapKho.ActiveViewIndex = -1;
            this.crvBaoCaoNhapKho.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.crvBaoCaoNhapKho.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvBaoCaoNhapKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvBaoCaoNhapKho.Location = new System.Drawing.Point(0, 0);
            this.crvBaoCaoNhapKho.Name = "crvBaoCaoNhapKho";
            this.crvBaoCaoNhapKho.Size = new System.Drawing.Size(426, 229);
            this.crvBaoCaoNhapKho.TabIndex = 0;
            // 
            // frmXuatBaoCaoNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 229);
            this.Controls.Add(this.crvBaoCaoNhapKho);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmXuatBaoCaoNhapKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Nhập Kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmXuatBaoCaoNhapKho_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvBaoCaoNhapKho;
    }
}