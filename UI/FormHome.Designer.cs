namespace BTL_Nhom7_CNPM.UI
{
    partial class FormHome
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tool_QL = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_QLTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_QLNCC = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_QLSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_QLNhapKho = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_QLHangHuy = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_QLHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_BanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_ThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_TKDoanhThu = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_TKTonKho = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_DangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbl_HoTen = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_QL,
            this.tool_BanHang,
            this.tool_ThongKe,
            this.tool_DangXuat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1258, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tool_QL
            // 
            this.tool_QL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_QLTaiKhoan,
            this.tool_QLNCC,
            this.tool_QLSanPham,
            this.tool_QLNhapKho,
            this.tool_QLHangHuy,
            this.tool_QLHoaDon});
            this.tool_QL.Name = "tool_QL";
            this.tool_QL.Size = new System.Drawing.Size(89, 29);
            this.tool_QL.Text = "Quản lý";
            // 
            // tool_QLTaiKhoan
            // 
            this.tool_QLTaiKhoan.Name = "tool_QLTaiKhoan";
            this.tool_QLTaiKhoan.Size = new System.Drawing.Size(286, 34);
            this.tool_QLTaiKhoan.Text = "Quản lý tài khoản";
            this.tool_QLTaiKhoan.Click += new System.EventHandler(this.tool_QLTaiKhoan_Click);
            // 
            // tool_QLNCC
            // 
            this.tool_QLNCC.Name = "tool_QLNCC";
            this.tool_QLNCC.Size = new System.Drawing.Size(286, 34);
            this.tool_QLNCC.Text = "Quản lý nhà cung cấp";
            this.tool_QLNCC.Click += new System.EventHandler(this.tool_QLNCC_Click);
            // 
            // tool_QLSanPham
            // 
            this.tool_QLSanPham.Name = "tool_QLSanPham";
            this.tool_QLSanPham.Size = new System.Drawing.Size(286, 34);
            this.tool_QLSanPham.Text = "Quản lý sản phẩm";
            this.tool_QLSanPham.Click += new System.EventHandler(this.tool_QLSanPham_Click);
            // 
            // tool_QLNhapKho
            // 
            this.tool_QLNhapKho.Name = "tool_QLNhapKho";
            this.tool_QLNhapKho.Size = new System.Drawing.Size(286, 34);
            this.tool_QLNhapKho.Text = "Quản  lý nhập kho";
            this.tool_QLNhapKho.Click += new System.EventHandler(this.tool_QLNhapKho_Click);
            // 
            // tool_QLHangHuy
            // 
            this.tool_QLHangHuy.Name = "tool_QLHangHuy";
            this.tool_QLHangHuy.Size = new System.Drawing.Size(286, 34);
            this.tool_QLHangHuy.Text = "Quản lý  hàng huỷ";
            this.tool_QLHangHuy.Click += new System.EventHandler(this.tool_QLHangHuy_Click);
            // 
            // tool_QLHoaDon
            // 
            this.tool_QLHoaDon.Name = "tool_QLHoaDon";
            this.tool_QLHoaDon.Size = new System.Drawing.Size(286, 34);
            this.tool_QLHoaDon.Text = "Quản lý hoá đơn";
            this.tool_QLHoaDon.Click += new System.EventHandler(this.tool_QLHoaDon_Click);
            // 
            // tool_BanHang
            // 
            this.tool_BanHang.Name = "tool_BanHang";
            this.tool_BanHang.Size = new System.Drawing.Size(102, 29);
            this.tool_BanHang.Text = "Bán hàng";
            this.tool_BanHang.Click += new System.EventHandler(this.tool_BanHang_Click);
            // 
            // tool_ThongKe
            // 
            this.tool_ThongKe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_TKDoanhThu,
            this.tool_TKTonKho});
            this.tool_ThongKe.Name = "tool_ThongKe";
            this.tool_ThongKe.Size = new System.Drawing.Size(102, 29);
            this.tool_ThongKe.Text = "Thống kê";
            this.tool_ThongKe.Click += new System.EventHandler(this.tool_ThongKe_Click);
            // 
            // tool_TKDoanhThu
            // 
            this.tool_TKDoanhThu.Name = "tool_TKDoanhThu";
            this.tool_TKDoanhThu.Size = new System.Drawing.Size(270, 34);
            this.tool_TKDoanhThu.Text = "Báo cáo doanh thu";
            this.tool_TKDoanhThu.Click += new System.EventHandler(this.tool_TKDoanhThu_Click);
            // 
            // tool_TKTonKho
            // 
            this.tool_TKTonKho.Name = "tool_TKTonKho";
            this.tool_TKTonKho.Size = new System.Drawing.Size(270, 34);
            this.tool_TKTonKho.Text = "Thống kê tồn kho";
            this.tool_TKTonKho.Click += new System.EventHandler(this.tool_TKTonKho_Click);
            // 
            // tool_DangXuat
            // 
            this.tool_DangXuat.Name = "tool_DangXuat";
            this.tool_DangXuat.Size = new System.Drawing.Size(109, 29);
            this.tool_DangXuat.Text = "Đăng xuất";
            this.tool_DangXuat.Click += new System.EventHandler(this.tool_DangXuat_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lbl_HoTen
            // 
            this.lbl_HoTen.AutoSize = true;
            this.lbl_HoTen.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HoTen.ForeColor = System.Drawing.Color.Red;
            this.lbl_HoTen.Location = new System.Drawing.Point(3, 6);
            this.lbl_HoTen.Name = "lbl_HoTen";
            this.lbl_HoTen.Size = new System.Drawing.Size(60, 21);
            this.lbl_HoTen.TabIndex = 2;
            this.lbl_HoTen.Text = "Họ tên";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_HoTen);
            this.panel1.Location = new System.Drawing.Point(37, 597);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 30);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BTL_Nhom7_CNPM.Properties.Resources.Theme;
            this.pictureBox1.Location = new System.Drawing.Point(0, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1258, 630);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormHome";
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tool_QL;
        private System.Windows.Forms.ToolStripMenuItem tool_QLTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem tool_QLNCC;
        private System.Windows.Forms.ToolStripMenuItem tool_QLSanPham;
        private System.Windows.Forms.ToolStripMenuItem tool_QLNhapKho;
        private System.Windows.Forms.ToolStripMenuItem tool_QLHangHuy;
        private System.Windows.Forms.ToolStripMenuItem tool_QLHoaDon;
        private System.Windows.Forms.ToolStripMenuItem tool_BanHang;
        private System.Windows.Forms.ToolStripMenuItem tool_ThongKe;
        private System.Windows.Forms.ToolStripMenuItem tool_DangXuat;
        private System.Windows.Forms.ToolStripMenuItem tool_TKDoanhThu;
        private System.Windows.Forms.ToolStripMenuItem tool_TKTonKho;
        private System.Windows.Forms.Label lbl_HoTen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}