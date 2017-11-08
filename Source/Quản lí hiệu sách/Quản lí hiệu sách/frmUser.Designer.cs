namespace Quản_lí_hiệu_sách
{
    partial class frmUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUser));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlsHoten = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlsDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theoTênSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theoThểLoạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theoTácGiảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theoNhàXuấtBảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lậpHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thayĐổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsHoten,
            this.tlsDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 674);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1358, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlsHoten
            // 
            this.tlsHoten.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tlsHoten.Name = "tlsHoten";
            this.tlsHoten.Size = new System.Drawing.Size(0, 17);
            // 
            // tlsDate
            // 
            this.tlsDate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tlsDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tlsDate.Name = "tlsDate";
            this.tlsDate.Size = new System.Drawing.Size(4, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.tìmKiếmToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripTextBox1,
            this.đăngXuấtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1358, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theoTênSáchToolStripMenuItem,
            this.theoThểLoạiToolStripMenuItem,
            this.theoTácGiảToolStripMenuItem,
            this.theoNhàXuấtBảnToolStripMenuItem});
            this.tìmKiếmToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tìmKiếmToolStripMenuItem.Image")));
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(93, 31);
            this.tìmKiếmToolStripMenuItem.Text = "Tìm kiếm";
            // 
            // theoTênSáchToolStripMenuItem
            // 
            this.theoTênSáchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("theoTênSáchToolStripMenuItem.Image")));
            this.theoTênSáchToolStripMenuItem.Name = "theoTênSáchToolStripMenuItem";
            this.theoTênSáchToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.theoTênSáchToolStripMenuItem.Text = "Theo tên sách";
            this.theoTênSáchToolStripMenuItem.Click += new System.EventHandler(this.theoTênSáchToolStripMenuItem_Click);
            // 
            // theoThểLoạiToolStripMenuItem
            // 
            this.theoThểLoạiToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("theoThểLoạiToolStripMenuItem.Image")));
            this.theoThểLoạiToolStripMenuItem.Name = "theoThểLoạiToolStripMenuItem";
            this.theoThểLoạiToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.theoThểLoạiToolStripMenuItem.Text = "Theo thể loại";
            this.theoThểLoạiToolStripMenuItem.Click += new System.EventHandler(this.theoThểLoạiToolStripMenuItem_Click);
            // 
            // theoTácGiảToolStripMenuItem
            // 
            this.theoTácGiảToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("theoTácGiảToolStripMenuItem.Image")));
            this.theoTácGiảToolStripMenuItem.Name = "theoTácGiảToolStripMenuItem";
            this.theoTácGiảToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.theoTácGiảToolStripMenuItem.Text = "Theo tác giả";
            this.theoTácGiảToolStripMenuItem.Click += new System.EventHandler(this.theoTácGiảToolStripMenuItem_Click);
            // 
            // theoNhàXuấtBảnToolStripMenuItem
            // 
            this.theoNhàXuấtBảnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("theoNhàXuấtBảnToolStripMenuItem.Image")));
            this.theoNhàXuấtBảnToolStripMenuItem.Name = "theoNhàXuấtBảnToolStripMenuItem";
            this.theoNhàXuấtBảnToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.theoNhàXuấtBảnToolStripMenuItem.Text = "Theo nhà xuất bản";
            this.theoNhàXuấtBảnToolStripMenuItem.Click += new System.EventHandler(this.theoNhàXuấtBảnToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(94, 31);
            this.aboutToolStripMenuItem.Text = "Giới thiệu";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(943, 31);
            this.toolStripTextBox1.Text = "                                                                                 " +
    "                                    ";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("đăngXuấtToolStripMenuItem.Image")));
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(98, 31);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lậpHóaĐơnToolStripMenuItem,
            this.thayĐổiMậtKhẩuToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hệThốngToolStripMenuItem.Image")));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(103, 26);
            this.hệThốngToolStripMenuItem.Text = "Chức năng";
            // 
            // lậpHóaĐơnToolStripMenuItem
            // 
            this.lậpHóaĐơnToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("lậpHóaĐơnToolStripMenuItem.Image")));
            this.lậpHóaĐơnToolStripMenuItem.Name = "lậpHóaĐơnToolStripMenuItem";
            this.lậpHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.lậpHóaĐơnToolStripMenuItem.Text = "Lập hóa đơn";
            this.lậpHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.lậpHóaĐơnToolStripMenuItem_Click);
            // 
            // thayĐổiMậtKhẩuToolStripMenuItem
            // 
            this.thayĐổiMậtKhẩuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thayĐổiMậtKhẩuToolStripMenuItem.Image")));
            this.thayĐổiMậtKhẩuToolStripMenuItem.Name = "thayĐổiMậtKhẩuToolStripMenuItem";
            this.thayĐổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.thayĐổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            this.thayĐổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.thayĐổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1358, 696);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa dơn bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlsHoten;
        private System.Windows.Forms.ToolStripStatusLabel tlsDate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theoTênSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theoThểLoạiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theoTácGiảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theoNhàXuấtBảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lậpHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thayĐổiMậtKhẩuToolStripMenuItem;
    }
}