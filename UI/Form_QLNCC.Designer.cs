namespace BTL_Nhom7_CNPM
{
    partial class Form_QLNCC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_maNCC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_NCC = new System.Windows.Forms.DataGridView();
            this.txt_tenNCC = new System.Windows.Forms.TextBox();
            this.txt_sdtNCC = new System.Windows.Forms.TextBox();
            this.txt_emailNCC = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_huy = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_nhaplai = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NCC)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_maNCC
            // 
            this.txt_maNCC.Location = new System.Drawing.Point(155, 41);
            this.txt_maNCC.Name = "txt_maNCC";
            this.txt_maNCC.Size = new System.Drawing.Size(258, 26);
            this.txt_maNCC.TabIndex = 0;
            this.txt_maNCC.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã NCC";
            this.label1.UseWaitCursor = true;
            // 
            // dgv_NCC
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_NCC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_NCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_NCC.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_NCC.Location = new System.Drawing.Point(488, 39);
            this.dgv_NCC.Name = "dgv_NCC";
            this.dgv_NCC.RowHeadersWidth = 62;
            this.dgv_NCC.RowTemplate.Height = 28;
            this.dgv_NCC.Size = new System.Drawing.Size(743, 590);
            this.dgv_NCC.TabIndex = 2;
            this.dgv_NCC.UseWaitCursor = true;
            // 
            // txt_tenNCC
            // 
            this.txt_tenNCC.Location = new System.Drawing.Point(155, 122);
            this.txt_tenNCC.Name = "txt_tenNCC";
            this.txt_tenNCC.Size = new System.Drawing.Size(258, 26);
            this.txt_tenNCC.TabIndex = 4;
            this.txt_tenNCC.UseWaitCursor = true;
            // 
            // txt_sdtNCC
            // 
            this.txt_sdtNCC.Location = new System.Drawing.Point(155, 211);
            this.txt_sdtNCC.Name = "txt_sdtNCC";
            this.txt_sdtNCC.Size = new System.Drawing.Size(258, 26);
            this.txt_sdtNCC.TabIndex = 5;
            this.txt_sdtNCC.UseWaitCursor = true;
            // 
            // txt_emailNCC
            // 
            this.txt_emailNCC.Location = new System.Drawing.Point(155, 290);
            this.txt_emailNCC.Name = "txt_emailNCC";
            this.txt_emailNCC.Size = new System.Drawing.Size(258, 26);
            this.txt_emailNCC.TabIndex = 6;
            this.txt_emailNCC.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên NCC";
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "SDT NCC";
            this.label3.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 293);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email NCC";
            this.label4.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_emailNCC);
            this.groupBox1.Controls.Add(this.txt_sdtNCC);
            this.groupBox1.Controls.Add(this.txt_tenNCC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_maNCC);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 335);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            this.groupBox1.UseWaitCursor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_them);
            this.groupBox2.Controls.Add(this.btn_huy);
            this.groupBox2.Controls.Add(this.btn_xoa);
            this.groupBox2.Controls.Add(this.btn_nhaplai);
            this.groupBox2.Controls.Add(this.btn_luu);
            this.groupBox2.Controls.Add(this.btn_sua);
            this.groupBox2.Location = new System.Drawing.Point(16, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 237);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            this.groupBox2.UseWaitCursor = true;
            // 
            // btn_them
            // 
            this.btn_them.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.plus;
            this.btn_them.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_them.Location = new System.Drawing.Point(47, 25);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(136, 58);
            this.btn_them.TabIndex = 0;
            this.btn_them.Text = "       Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.UseWaitCursor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_huy
            // 
            this.btn_huy.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.delete_button;
            this.btn_huy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_huy.Location = new System.Drawing.Point(262, 153);
            this.btn_huy.Name = "btn_huy";
            this.btn_huy.Size = new System.Drawing.Size(136, 58);
            this.btn_huy.TabIndex = 5;
            this.btn_huy.Text = "       Huỷ";
            this.btn_huy.UseVisualStyleBackColor = true;
            this.btn_huy.UseWaitCursor = true;
            this.btn_huy.Click += new System.EventHandler(this.btn_huy_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.bin__1_;
            this.btn_xoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_xoa.Location = new System.Drawing.Point(262, 89);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(136, 58);
            this.btn_xoa.TabIndex = 1;
            this.btn_xoa.Text = "       Xoá";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.UseWaitCursor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_nhaplai
            // 
            this.btn_nhaplai.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.reload__1_;
            this.btn_nhaplai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_nhaplai.Location = new System.Drawing.Point(47, 89);
            this.btn_nhaplai.Name = "btn_nhaplai";
            this.btn_nhaplai.Size = new System.Drawing.Size(136, 58);
            this.btn_nhaplai.TabIndex = 2;
            this.btn_nhaplai.Text = "       Nhập lại";
            this.btn_nhaplai.UseVisualStyleBackColor = true;
            this.btn_nhaplai.UseWaitCursor = true;
            this.btn_nhaplai.Click += new System.EventHandler(this.btn_nhaplai_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.save;
            this.btn_luu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_luu.Location = new System.Drawing.Point(47, 153);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(136, 58);
            this.btn_luu.TabIndex = 4;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.UseWaitCursor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.BackgroundImage = global::BTL_Nhom7_CNPM.Properties.Resources.mechanics;
            this.btn_sua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_sua.Location = new System.Drawing.Point(262, 25);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(136, 58);
            this.btn_sua.TabIndex = 3;
            this.btn_sua.Text = "    Sửa";
            this.btn_sua.UseVisualStyleBackColor = true;
            this.btn_sua.UseWaitCursor = true;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // Form_QLNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv_NCC);
            this.Name = "Form_QLNCC";
            this.Text = "Quản lý nhà cung cấp";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form_QLNCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NCC)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_maNCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_NCC;
        private System.Windows.Forms.TextBox txt_tenNCC;
        private System.Windows.Forms.TextBox txt_sdtNCC;
        private System.Windows.Forms.TextBox txt_emailNCC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
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