namespace BTL_Nhom7_CNPM.UI
{
    partial class Form_QLHoaDon
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
            this.btn_XoaHD = new System.Windows.Forms.Button();
            this.dgv_cthd = new System.Windows.Forms.DataGridView();
            this.txt_MaHD = new System.Windows.Forms.TextBox();
            this.txt_TongHD = new System.Windows.Forms.TextBox();
            this.txt_NguoiBan = new System.Windows.Forms.TextBox();
            this.txt_timkiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_hoadon = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp_NgayBan = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_InHD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cthd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoadon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_XoaHD
            // 
            this.btn_XoaHD.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.bin__1_;
            this.btn_XoaHD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_XoaHD.Location = new System.Drawing.Point(111, 126);
            this.btn_XoaHD.Name = "btn_XoaHD";
            this.btn_XoaHD.Size = new System.Drawing.Size(159, 60);
            this.btn_XoaHD.TabIndex = 1;
            this.btn_XoaHD.Text = "Xoá hoá đơn";
            this.btn_XoaHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_XoaHD.UseVisualStyleBackColor = true;
            this.btn_XoaHD.Click += new System.EventHandler(this.btn_XoaHD_Click);
            // 
            // dgv_cthd
            // 
            this.dgv_cthd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cthd.Location = new System.Drawing.Point(447, 367);
            this.dgv_cthd.Name = "dgv_cthd";
            this.dgv_cthd.RowHeadersWidth = 62;
            this.dgv_cthd.RowTemplate.Height = 28;
            this.dgv_cthd.Size = new System.Drawing.Size(770, 271);
            this.dgv_cthd.TabIndex = 2;
            // 
            // txt_MaHD
            // 
            this.txt_MaHD.Location = new System.Drawing.Point(120, 30);
            this.txt_MaHD.Name = "txt_MaHD";
            this.txt_MaHD.Size = new System.Drawing.Size(225, 26);
            this.txt_MaHD.TabIndex = 3;
            // 
            // txt_TongHD
            // 
            this.txt_TongHD.Location = new System.Drawing.Point(120, 264);
            this.txt_TongHD.Name = "txt_TongHD";
            this.txt_TongHD.Size = new System.Drawing.Size(225, 26);
            this.txt_TongHD.TabIndex = 4;
            // 
            // txt_NguoiBan
            // 
            this.txt_NguoiBan.Location = new System.Drawing.Point(120, 100);
            this.txt_NguoiBan.Name = "txt_NguoiBan";
            this.txt_NguoiBan.Size = new System.Drawing.Size(225, 26);
            this.txt_NguoiBan.TabIndex = 6;
            // 
            // txt_timkiem
            // 
            this.txt_timkiem.Location = new System.Drawing.Point(762, 38);
            this.txt_timkiem.Name = "txt_timkiem";
            this.txt_timkiem.Size = new System.Drawing.Size(349, 26);
            this.txt_timkiem.TabIndex = 7;
            this.txt_timkiem.TextChanged += new System.EventHandler(this.txt_timkiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(528, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nhập tên hoá đơn cần tìm kiếm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã hoá đơn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Người bán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ngày bán";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tổng tiền";
            // 
            // dgv_hoadon
            // 
            this.dgv_hoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hoadon.Location = new System.Drawing.Point(447, 76);
            this.dgv_hoadon.Name = "dgv_hoadon";
            this.dgv_hoadon.RowHeadersWidth = 62;
            this.dgv_hoadon.RowTemplate.Height = 28;
            this.dgv_hoadon.Size = new System.Drawing.Size(770, 271);
            this.dgv_hoadon.TabIndex = 13;
            this.dgv_hoadon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_hoadon_CellContentClick);
            this.dgv_hoadon.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_hoadon_CellMouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtp_NgayBan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_NguoiBan);
            this.groupBox1.Controls.Add(this.txt_TongHD);
            this.groupBox1.Controls.Add(this.txt_MaHD);
            this.groupBox1.Location = new System.Drawing.Point(34, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 344);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // dtp_NgayBan
            // 
            this.dtp_NgayBan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_NgayBan.Location = new System.Drawing.Point(120, 184);
            this.dtp_NgayBan.Name = "dtp_NgayBan";
            this.dtp_NgayBan.Size = new System.Drawing.Size(225, 26);
            this.dtp_NgayBan.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_XoaHD);
            this.groupBox2.Controls.Add(this.btn_InHD);
            this.groupBox2.Location = new System.Drawing.Point(34, 424);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 214);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btn_InHD
            // 
            this.btn_InHD.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.slip;
            this.btn_InHD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_InHD.Location = new System.Drawing.Point(111, 41);
            this.btn_InHD.Name = "btn_InHD";
            this.btn_InHD.Size = new System.Drawing.Size(159, 60);
            this.btn_InHD.TabIndex = 0;
            this.btn_InHD.Text = "     In hoá đơn";
            this.btn_InHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_InHD.UseVisualStyleBackColor = true;
            this.btn_InHD.Click += new System.EventHandler(this.btn_InHD_Click);
            // 
            // Form_QLHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_hoadon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_timkiem);
            this.Controls.Add(this.dgv_cthd);
            this.Name = "Form_QLHoaDon";
            this.Text = "Quản lý hoá đơn";
            this.Load += new System.EventHandler(this.Form_QLHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cthd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoadon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_InHD;
        private System.Windows.Forms.Button btn_XoaHD;
        private System.Windows.Forms.DataGridView dgv_cthd;
        private System.Windows.Forms.TextBox txt_MaHD;
        private System.Windows.Forms.TextBox txt_TongHD;
        private System.Windows.Forms.TextBox txt_NguoiBan;
        private System.Windows.Forms.TextBox txt_timkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_hoadon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtp_NgayBan;
    }
}