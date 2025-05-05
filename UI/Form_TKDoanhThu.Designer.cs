namespace BTL_Nhom7_CNPM.UI
{
    partial class Form_TKDoanhThu
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
            this.dtp_NgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtp_NgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.txt_DoanhThu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_hoadon = new System.Windows.Forms.DataGridView();
            this.btn_kiemtra = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_In = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_DoanhThuBangChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoadon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_NgayBatDau
            // 
            this.dtp_NgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_NgayBatDau.Location = new System.Drawing.Point(157, 38);
            this.dtp_NgayBatDau.Name = "dtp_NgayBatDau";
            this.dtp_NgayBatDau.Size = new System.Drawing.Size(260, 26);
            this.dtp_NgayBatDau.TabIndex = 0;
            this.dtp_NgayBatDau.ValueChanged += new System.EventHandler(this.dtp_NgayBatDau_ValueChanged);
            // 
            // dtp_NgayKetThuc
            // 
            this.dtp_NgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_NgayKetThuc.Location = new System.Drawing.Point(157, 110);
            this.dtp_NgayKetThuc.Name = "dtp_NgayKetThuc";
            this.dtp_NgayKetThuc.Size = new System.Drawing.Size(260, 26);
            this.dtp_NgayKetThuc.TabIndex = 1;
            this.dtp_NgayKetThuc.ValueChanged += new System.EventHandler(this.dtp_NgayKetThuc_ValueChanged);
            // 
            // txt_DoanhThu
            // 
            this.txt_DoanhThu.Location = new System.Drawing.Point(157, 175);
            this.txt_DoanhThu.Name = "txt_DoanhThu";
            this.txt_DoanhThu.Size = new System.Drawing.Size(260, 26);
            this.txt_DoanhThu.TabIndex = 2;
            this.txt_DoanhThu.TextChanged += new System.EventHandler(this.txt_DoanhThu_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ ngày";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgv_hoadon
            // 
            this.dgv_hoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hoadon.Location = new System.Drawing.Point(495, 37);
            this.dgv_hoadon.Name = "dgv_hoadon";
            this.dgv_hoadon.RowHeadersWidth = 62;
            this.dgv_hoadon.RowTemplate.Height = 28;
            this.dgv_hoadon.Size = new System.Drawing.Size(728, 587);
            this.dgv_hoadon.TabIndex = 4;
            this.dgv_hoadon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_hoadon_CellContentClick);
            // 
            // btn_kiemtra
            // 
            this.btn_kiemtra.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.check;
            this.btn_kiemtra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_kiemtra.Location = new System.Drawing.Point(146, 55);
            this.btn_kiemtra.Name = "btn_kiemtra";
            this.btn_kiemtra.Size = new System.Drawing.Size(163, 62);
            this.btn_kiemtra.TabIndex = 5;
            this.btn_kiemtra.Text = "       Kiểm tra";
            this.btn_kiemtra.UseVisualStyleBackColor = true;
            this.btn_kiemtra.Click += new System.EventHandler(this.btn_kiemtra_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng doanh thu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Đến ngày";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btn_In
            // 
            this.btn_In.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.slip;
            this.btn_In.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_In.Location = new System.Drawing.Point(146, 143);
            this.btn_In.Name = "btn_In";
            this.btn_In.Size = new System.Drawing.Size(163, 62);
            this.btn_In.TabIndex = 9;
            this.btn_In.Text = "       In ra";
            this.btn_In.UseVisualStyleBackColor = true;
            this.btn_In.Click += new System.EventHandler(this.btn_In_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_DoanhThuBangChu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_DoanhThu);
            this.groupBox1.Controls.Add(this.dtp_NgayKetThuc);
            this.groupBox1.Controls.Add(this.dtp_NgayBatDau);
            this.groupBox1.Location = new System.Drawing.Point(24, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 330);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txt_DoanhThuBangChu
            // 
            this.txt_DoanhThuBangChu.Location = new System.Drawing.Point(157, 248);
            this.txt_DoanhThuBangChu.Multiline = true;
            this.txt_DoanhThuBangChu.Name = "txt_DoanhThuBangChu";
            this.txt_DoanhThuBangChu.Size = new System.Drawing.Size(260, 52);
            this.txt_DoanhThuBangChu.TabIndex = 10;
            this.txt_DoanhThuBangChu.TextChanged += new System.EventHandler(this.txt_DoanhThuBangChu_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bằng chữ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_In);
            this.groupBox2.Controls.Add(this.btn_kiemtra);
            this.groupBox2.Location = new System.Drawing.Point(24, 396);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 228);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng ";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Form_TKDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_hoadon);
            this.Name = "Form_TKDoanhThu";
            this.Text = "Doanh thu";
            this.Load += new System.EventHandler(this.Form_TKDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoadon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_NgayBatDau;
        private System.Windows.Forms.DateTimePicker dtp_NgayKetThuc;
        private System.Windows.Forms.TextBox txt_DoanhThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_hoadon;
        private System.Windows.Forms.Button btn_kiemtra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_In;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_DoanhThuBangChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}