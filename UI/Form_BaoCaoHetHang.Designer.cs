namespace BTL_Nhom7_CNPM.UI
{
    partial class Form_BaoCaoHetHang
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
            this.txt_slduoi = new System.Windows.Forms.TextBox();
            this.dgv_sanpham = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_In = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_kiemtra = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_sltonkho = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_giaban = new System.Windows.Forms.TextBox();
            this.txt_tensp = new System.Windows.Forms.TextBox();
            this.txt_masp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanpham)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_slduoi
            // 
            this.txt_slduoi.Location = new System.Drawing.Point(146, 267);
            this.txt_slduoi.Name = "txt_slduoi";
            this.txt_slduoi.Size = new System.Drawing.Size(232, 26);
            this.txt_slduoi.TabIndex = 2;
            // 
            // dgv_sanpham
            // 
            this.dgv_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sanpham.Location = new System.Drawing.Point(477, 39);
            this.dgv_sanpham.Name = "dgv_sanpham";
            this.dgv_sanpham.RowHeadersWidth = 62;
            this.dgv_sanpham.RowTemplate.Height = 28;
            this.dgv_sanpham.Size = new System.Drawing.Size(752, 587);
            this.dgv_sanpham.TabIndex = 12;
            this.dgv_sanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sanpham_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "SL còn dưới";
            // 
            // btn_In
            // 
            this.btn_In.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.slip;
            this.btn_In.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_In.Location = new System.Drawing.Point(125, 158);
            this.btn_In.Name = "btn_In";
            this.btn_In.Size = new System.Drawing.Size(163, 60);
            this.btn_In.TabIndex = 9;
            this.btn_In.Text = "       In ra";
            this.btn_In.UseVisualStyleBackColor = true;
            this.btn_In.Click += new System.EventHandler(this.btn_In_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_In);
            this.groupBox2.Controls.Add(this.btn_kiemtra);
            this.groupBox2.Location = new System.Drawing.Point(30, 380);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 246);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng ";
            // 
            // btn_kiemtra
            // 
            this.btn_kiemtra.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.check;
            this.btn_kiemtra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_kiemtra.Location = new System.Drawing.Point(125, 55);
            this.btn_kiemtra.Name = "btn_kiemtra";
            this.btn_kiemtra.Size = new System.Drawing.Size(163, 60);
            this.btn_kiemtra.TabIndex = 5;
            this.btn_kiemtra.Text = "        Kiểm tra";
            this.btn_kiemtra.UseVisualStyleBackColor = true;
            this.btn_kiemtra.Click += new System.EventHandler(this.btn_kiemtra_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_sltonkho);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_giaban);
            this.groupBox1.Controls.Add(this.txt_tensp);
            this.groupBox1.Controls.Add(this.txt_masp);
            this.groupBox1.Controls.Add(this.txt_slduoi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(30, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 311);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // txt_sltonkho
            // 
            this.txt_sltonkho.Location = new System.Drawing.Point(146, 212);
            this.txt_sltonkho.Name = "txt_sltonkho";
            this.txt_sltonkho.Size = new System.Drawing.Size(232, 26);
            this.txt_sltonkho.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Tên sản phẩm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Giá bán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "SL tồn kho";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã sản phẩm";
            // 
            // txt_giaban
            // 
            this.txt_giaban.Location = new System.Drawing.Point(146, 151);
            this.txt_giaban.Name = "txt_giaban";
            this.txt_giaban.Size = new System.Drawing.Size(232, 26);
            this.txt_giaban.TabIndex = 10;
            // 
            // txt_tensp
            // 
            this.txt_tensp.Location = new System.Drawing.Point(146, 94);
            this.txt_tensp.Name = "txt_tensp";
            this.txt_tensp.Size = new System.Drawing.Size(232, 26);
            this.txt_tensp.TabIndex = 9;
            // 
            // txt_masp
            // 
            this.txt_masp.Location = new System.Drawing.Point(146, 35);
            this.txt_masp.Name = "txt_masp";
            this.txt_masp.Size = new System.Drawing.Size(232, 26);
            this.txt_masp.TabIndex = 8;
            // 
            // Form_BaoCaoHetHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.dgv_sanpham);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form_BaoCaoHetHang";
            this.Text = "Thống kê tồn kho";
            this.Load += new System.EventHandler(this.Form_BaoCaoHetHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sanpham)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txt_slduoi;
        private System.Windows.Forms.DataGridView dgv_sanpham;
        private System.Windows.Forms.Button btn_kiemtra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_In;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_tensp;
        private System.Windows.Forms.TextBox txt_masp;
        private System.Windows.Forms.TextBox txt_sltonkho;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_giaban;
    }
}