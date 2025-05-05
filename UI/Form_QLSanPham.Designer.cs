namespace BTL_Nhom7_CNPM
{
    partial class Form_QLSanPham
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_maSP = new System.Windows.Forms.TextBox();
            this.dgv_sanpham = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_tenSP = new System.Windows.Forms.TextBox();
            this.txt_giaban = new System.Windows.Forms.TextBox();
            this.txt_tonkho = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_nhaplai = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanpham)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sản phẩm";
            // 
            // txt_maSP
            // 
            this.txt_maSP.Location = new System.Drawing.Point(134, 51);
            this.txt_maSP.Name = "txt_maSP";
            this.txt_maSP.Size = new System.Drawing.Size(263, 26);
            this.txt_maSP.TabIndex = 1;
            // 
            // dgv_sanpham
            // 
            this.dgv_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sanpham.Location = new System.Drawing.Point(485, 38);
            this.dgv_sanpham.Name = "dgv_sanpham";
            this.dgv_sanpham.RowHeadersWidth = 62;
            this.dgv_sanpham.RowTemplate.Height = 28;
            this.dgv_sanpham.Size = new System.Drawing.Size(745, 581);
            this.dgv_sanpham.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Giá bán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "SL tồn kho";
            // 
            // txt_tenSP
            // 
            this.txt_tenSP.Location = new System.Drawing.Point(134, 130);
            this.txt_tenSP.Name = "txt_tenSP";
            this.txt_tenSP.Size = new System.Drawing.Size(263, 26);
            this.txt_tenSP.TabIndex = 8;
            // 
            // txt_giaban
            // 
            this.txt_giaban.Location = new System.Drawing.Point(134, 203);
            this.txt_giaban.Name = "txt_giaban";
            this.txt_giaban.Size = new System.Drawing.Size(263, 26);
            this.txt_giaban.TabIndex = 9;
            // 
            // txt_tonkho
            // 
            this.txt_tonkho.Location = new System.Drawing.Point(134, 274);
            this.txt_tonkho.Name = "txt_tonkho";
            this.txt_tonkho.Size = new System.Drawing.Size(263, 26);
            this.txt_tonkho.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_maSP);
            this.groupBox1.Controls.Add(this.txt_tonkho);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_giaban);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_tenSP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(29, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 348);
            this.groupBox1.TabIndex = 21;
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
            this.groupBox2.Location = new System.Drawing.Point(29, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 227);
            this.groupBox2.TabIndex = 20;
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
            this.btn_them.Text = "        Thêm";
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
            this.btn_nhaplai.Click += new System.EventHandler(this.btn_nhaplai_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.save;
            this.btn_luu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_luu.Location = new System.Drawing.Point(46, 153);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(136, 58);
            this.btn_luu.TabIndex = 4;
            this.btn_luu.Text = "      Lưu";
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
            // Form_QLSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_sanpham);
            this.Name = "Form_QLSanPham";
            this.Text = "Quản lý sản phẩm";
            this.Load += new System.EventHandler(this.Form_QLSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanpham)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_maSP;
        private System.Windows.Forms.DataGridView dgv_sanpham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_tenSP;
        private System.Windows.Forms.TextBox txt_giaban;
        private System.Windows.Forms.TextBox txt_tonkho;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.Button btn_huy;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_nhaplai;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_sua;
    }
}