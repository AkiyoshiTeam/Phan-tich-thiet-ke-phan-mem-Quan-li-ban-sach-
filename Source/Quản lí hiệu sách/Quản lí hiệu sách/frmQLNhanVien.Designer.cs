namespace Quản_lí_hiệu_sách
{
    partial class frmQLNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLNhanVien));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSua = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnThoat = new System.Windows.Forms.ToolStripButton();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnThem,
            this.toolStripSeparator1,
            this.tsbtnXoa,
            this.toolStripSeparator2,
            this.tsbtnSua,
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.tsbtnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1350, 72);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnThem
            // 
            this.tsbtnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tsbtnThem.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnThem.Image")));
            this.tsbtnThem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnThem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnThem.Name = "tsbtnThem";
            this.tsbtnThem.Size = new System.Drawing.Size(74, 69);
            this.tsbtnThem.Text = "Thêm NV";
            this.tsbtnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnThem.Click += new System.EventHandler(this.tsbtnThem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 72);
            // 
            // tsbtnXoa
            // 
            this.tsbtnXoa.Enabled = false;
            this.tsbtnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tsbtnXoa.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnXoa.Image")));
            this.tsbtnXoa.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnXoa.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnXoa.Name = "tsbtnXoa";
            this.tsbtnXoa.Size = new System.Drawing.Size(66, 69);
            this.tsbtnXoa.Text = "Xóa NV";
            this.tsbtnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnXoa.Click += new System.EventHandler(this.tsbtnXoa_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 72);
            // 
            // tsbtnSua
            // 
            this.tsbtnSua.Enabled = false;
            this.tsbtnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tsbtnSua.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSua.Image")));
            this.tsbtnSua.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnSua.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSua.Name = "tsbtnSua";
            this.tsbtnSua.Size = new System.Drawing.Size(68, 69);
            this.tsbtnSua.Text = "Cập nhật";
            this.tsbtnSua.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbtnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSua.Click += new System.EventHandler(this.tsbtnSua_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 69);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 72);
            // 
            // tsbtnThoat
            // 
            this.tsbtnThoat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tsbtnThoat.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnThoat.Image")));
            this.tsbtnThoat.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tsbtnThoat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnThoat.Name = "tsbtnThoat";
            this.tsbtnThoat.Size = new System.Drawing.Size(72, 69);
            this.tsbtnThoat.Text = "   Thoát   ";
            this.tsbtnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnThoat.Click += new System.EventHandler(this.tsbtnThoat_Click);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSach.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDanhSach.Location = new System.Drawing.Point(0, 75);
            this.dgvDanhSach.MultiSelect = false;
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSach.Size = new System.Drawing.Size(1350, 621);
            this.dgvDanhSach.TabIndex = 6;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            this.dgvDanhSach.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDanhSach_CellFormatting);
            this.dgvDanhSach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDanhSach_KeyDown);
            this.dgvDanhSach.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvDanhSach_KeyUp);
            // 
            // frmQLNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 696);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Nhân Viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQLNhanVien_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnThem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnSua;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbtnThoat;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}