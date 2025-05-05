using System.Windows.Forms;

namespace BTL_Nhom7_CNPM
{
    partial class Form_QLBanHang
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
            this.dgv_sanpham = new System.Windows.Forms.DataGridView();
            this.dgv_cthoadon = new System.Windows.Forms.DataGridView();
            this.txt_TongHD = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_MaHD = new System.Windows.Forms.TextBox();
            this.txt_NguoiBan = new System.Windows.Forms.TextBox();
            this.txt_timkiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_NgayBan = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_xoasp = new System.Windows.Forms.Button();
            this.btn_taohd = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanpham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cthoadon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_sanpham
            // 
            this.dgv_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sanpham.Location = new System.Drawing.Point(456, 55);
            this.dgv_sanpham.Name = "dgv_sanpham";
            this.dgv_sanpham.RowHeadersWidth = 62;
            this.dgv_sanpham.RowTemplate.Height = 28;
            this.dgv_sanpham.Size = new System.Drawing.Size(778, 282);
            this.dgv_sanpham.TabIndex = 0;
            this.dgv_sanpham.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_sanpham_CellMouseDown);
            // 
            // dgv_cthoadon
            // 
            this.dgv_cthoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cthoadon.Location = new System.Drawing.Point(456, 362);
            this.dgv_cthoadon.Name = "dgv_cthoadon";
            this.dgv_cthoadon.RowHeadersWidth = 62;
            this.dgv_cthoadon.RowTemplate.Height = 28;
            this.dgv_cthoadon.Size = new System.Drawing.Size(778, 266);
            this.dgv_cthoadon.TabIndex = 1;
            // 
            // txt_TongHD
            // 
            this.txt_TongHD.Location = new System.Drawing.Point(152, 261);
            this.txt_TongHD.Name = "txt_TongHD";
            this.txt_TongHD.Size = new System.Drawing.Size(230, 26);
            this.txt_TongHD.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 264);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Tổng hoá đơn";
            // 
            // txt_MaHD
            // 
            this.txt_MaHD.Location = new System.Drawing.Point(152, 42);
            this.txt_MaHD.Name = "txt_MaHD";
            this.txt_MaHD.Size = new System.Drawing.Size(230, 26);
            this.txt_MaHD.TabIndex = 19;
            // 
            // txt_NguoiBan
            // 
            this.txt_NguoiBan.Location = new System.Drawing.Point(152, 118);
            this.txt_NguoiBan.Name = "txt_NguoiBan";
            this.txt_NguoiBan.Size = new System.Drawing.Size(230, 26);
            this.txt_NguoiBan.TabIndex = 20;
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(710, 17);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(345, 26);
            this.txt_timkiem.TabIndex = 21;
            this.txt_timkiem.TextChanged += new System.EventHandler(this.txt_timkiem_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Mã hoá đơn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Người bán";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 195);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 20);
            this.label10.TabIndex = 24;
            this.label10.Text = "Ngày bán";
            // 
            // dtp_NgayBan
            // 
            this.dtp_NgayBan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_NgayBan.Location = new System.Drawing.Point(152, 189);
            this.dtp_NgayBan.Name = "dtp_NgayBan";
            this.dtp_NgayBan.Size = new System.Drawing.Size(230, 26);
            this.dtp_NgayBan.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_huy);
            this.groupBox1.Controls.Add(this.btn_xoasp);
            this.groupBox1.Controls.Add(this.btn_taohd);
            this.groupBox1.Controls.Add(this.btn_luu);
            this.groupBox1.Location = new System.Drawing.Point(32, 362);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 266);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // btn_huy
            // 
            this.btn_huy.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.delete_button;
            this.btn_huy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_huy.Location = new System.Drawing.Point(222, 151);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(165, 60);
            this.btn_huy.TabIndex = 3;
            this.btn_huy.Text = "         Huỷ hoá đơn";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_xoasp
            // 
            this.btn_xoasp.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.bin__1_;
            this.btn_xoasp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_xoasp.Location = new System.Drawing.Point(6, 151);
            this.btn_xoasp.Name = "btn_xoasp";
            this.btn_xoasp.Size = new System.Drawing.Size(172, 60);
            this.btn_xoasp.TabIndex = 2;
            this.btn_xoasp.Text = "         Xoá sản phẩm";
            this.btn_xoasp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_xoasp.UseVisualStyleBackColor = true;
            this.btn_xoasp.Click += new System.EventHandler(this.btn_xoasp_Click);
            // 
            // btn_taohd
            // 
            this.btn_taohd.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.plus;
            this.btn_taohd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_taohd.Location = new System.Drawing.Point(6, 62);
            this.btn_taohd.Name = "btn_taohd";
            this.btn_taohd.Size = new System.Drawing.Size(172, 61);
            this.btn_taohd.TabIndex = 0;
            this.btn_taohd.Text = "         Tạo hoá đơn";
            this.btn_taohd.UseVisualStyleBackColor = true;
            this.btn_taohd.Click += new System.EventHandler(this.btn_taohd_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.save;
            this.btn_luu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_luu.Location = new System.Drawing.Point(222, 62);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(165, 61);
            this.btn_luu.TabIndex = 1;
            this.btn_luu.Text = "         Lưu hoá đơn";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(501, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nhập tên sản phẩm cần tìm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtp_NgayBan);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_NguoiBan);
            this.groupBox2.Controls.Add(this.txt_MaHD);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_TongHD);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(26, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 314);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // Form_QLBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_timkiem);
            this.Controls.Add(this.dgv_cthoadon);
            this.Controls.Add(this.dgv_sanpham);
            this.Name = "Form_QLBanHang";
            this.Text = "Bán hàng";
            this.Load += new System.EventHandler(this.Form_QLBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanpham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cthoadon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_sanpham;
        private System.Windows.Forms.DataGridView dgv_cthoadon;
        private System.Windows.Forms.Button btn_taohd;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Button btn_xoasp;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.TextBox txt_TongHD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_MaHD;
        private System.Windows.Forms.TextBox txt_NguoiBan;
        private System.Windows.Forms.TextBox txt_timkiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_NgayBan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}