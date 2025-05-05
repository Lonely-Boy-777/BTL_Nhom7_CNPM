namespace BTL_Nhom7_CNPM.UI
{
    partial class Form_HangHuy
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
            this.dgv_HangHuy = new System.Windows.Forms.DataGridView();
            this.txt_MaHangHuy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_LyDoHuy = new System.Windows.Forms.TextBox();
            this.txt_SLHuy = new System.Windows.Forms.TextBox();
            this.txt_MaCTNK = new System.Windows.Forms.TextBox();
            this.txt_MaSP = new System.Windows.Forms.TextBox();
            this.dtp_NgayHuy = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_nhaplai = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HangHuy)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_HangHuy
            // 
            this.dgv_HangHuy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HangHuy.Location = new System.Drawing.Point(518, 23);
            this.dgv_HangHuy.Name = "dgv_HangHuy";
            this.dgv_HangHuy.RowHeadersWidth = 62;
            this.dgv_HangHuy.RowTemplate.Height = 28;
            this.dgv_HangHuy.Size = new System.Drawing.Size(703, 624);
            this.dgv_HangHuy.TabIndex = 0;
            // 
            // txt_MaHangHuy
            // 
            this.txt_MaHangHuy.Location = new System.Drawing.Point(148, 40);
            this.txt_MaHangHuy.Name = "txt_MaHangHuy";
            this.txt_MaHangHuy.Size = new System.Drawing.Size(277, 26);
            this.txt_MaHangHuy.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã hàng huỷ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mã sản phẩm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mã CTNK";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "SL huỷ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ngày huỷ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Lý do huỷ";
            // 
            // txt_LyDoHuy
            // 
            this.txt_LyDoHuy.Location = new System.Drawing.Point(148, 318);
            this.txt_LyDoHuy.Multiline = true;
            this.txt_LyDoHuy.Name = "txt_LyDoHuy";
            this.txt_LyDoHuy.Size = new System.Drawing.Size(277, 55);
            this.txt_LyDoHuy.TabIndex = 12;
            // 
            // txt_SLHuy
            // 
            this.txt_SLHuy.Location = new System.Drawing.Point(148, 200);
            this.txt_SLHuy.Name = "txt_SLHuy";
            this.txt_SLHuy.Size = new System.Drawing.Size(277, 26);
            this.txt_SLHuy.TabIndex = 14;
            // 
            // txt_MaCTNK
            // 
            this.txt_MaCTNK.Location = new System.Drawing.Point(148, 148);
            this.txt_MaCTNK.Name = "txt_MaCTNK";
            this.txt_MaCTNK.Size = new System.Drawing.Size(277, 26);
            this.txt_MaCTNK.TabIndex = 15;
            // 
            // txt_MaSP
            // 
            this.txt_MaSP.Location = new System.Drawing.Point(148, 90);
            this.txt_MaSP.Name = "txt_MaSP";
            this.txt_MaSP.Size = new System.Drawing.Size(277, 26);
            this.txt_MaSP.TabIndex = 16;
            // 
            // dtp_NgayHuy
            // 
            this.dtp_NgayHuy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_NgayHuy.Location = new System.Drawing.Point(147, 250);
            this.dtp_NgayHuy.Name = "dtp_NgayHuy";
            this.dtp_NgayHuy.Size = new System.Drawing.Size(278, 26);
            this.dtp_NgayHuy.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp_NgayHuy);
            this.groupBox1.Controls.Add(this.txt_MaHangHuy);
            this.groupBox1.Controls.Add(this.txt_MaSP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_MaCTNK);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_SLHuy);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_LyDoHuy);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(49, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 391);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_them);
            this.groupBox2.Controls.Add(this.btn_huy);
            this.groupBox2.Controls.Add(this.btn_xoa);
            this.groupBox2.Controls.Add(this.btn_nhaplai);
            this.groupBox2.Controls.Add(this.btn_luu);
            this.groupBox2.Controls.Add(this.btn_sua);
            this.groupBox2.Location = new System.Drawing.Point(49, 420);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 227);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btn_them
            // 
            this.btn_them.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.plus;
            this.btn_them.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_them.Location = new System.Drawing.Point(46, 25);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(136, 58);
            this.btn_them.TabIndex = 0;
            this.btn_them.Text = "         Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.delete_button;
            this.btn_huy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_huy.Location = new System.Drawing.Point(261, 153);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(136, 58);
            this.btn_huy.TabIndex = 5;
            this.btn_huy.Text = "       Huỷ";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.bin__1_;
            this.btn_xoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_xoa.Location = new System.Drawing.Point(261, 89);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(136, 58);
            this.btn_xoa.TabIndex = 1;
            this.btn_xoa.Text = "       Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_nhaplai
            // 
            this.btn_nhaplai.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.reload__1_;
            this.btn_nhaplai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_nhaplai.Location = new System.Drawing.Point(46, 89);
            this.btn_nhaplai.Name = "btn_nhaplai";
            this.btn_nhaplai.Size = new System.Drawing.Size(136, 58);
            this.btn_nhaplai.TabIndex = 2;
            this.btn_nhaplai.Text = "         Nhập lại";
            this.btn_nhaplai.UseVisualStyleBackColor = true;
            // 
            // btn_luu
            // 
            this.btn_luu.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.save;
            this.btn_luu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_luu.Location = new System.Drawing.Point(46, 153);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(136, 58);
            this.btn_luu.TabIndex = 4;
            this.btn_luu.Text = "       Lưu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.mechanics;
            this.btn_sua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sua.Location = new System.Drawing.Point(261, 25);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(136, 58);
            this.btn_sua.TabIndex = 3;
            this.btn_sua.Text = "      Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // Form_HangHuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_HangHuy);
            this.Name = "Form_HangHuy";
            this.Text = "Quản lý hàng huỷ";
            this.Load += new System.EventHandler(this.Form_HangHuy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HangHuy)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_HangHuy;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_nhaplai;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txt_MaHangHuy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_LyDoHuy;
        private System.Windows.Forms.TextBox txt_SLHuy;
        private System.Windows.Forms.TextBox txt_MaCTNK;
        private System.Windows.Forms.TextBox txt_MaSP;
        private System.Windows.Forms.DateTimePicker dtp_NgayHuy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}