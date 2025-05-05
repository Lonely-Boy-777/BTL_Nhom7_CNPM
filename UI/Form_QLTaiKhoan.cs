using BTL_Nhom7_CNPM.DAO;
using BTL_Nhom7_CNPM.Model;
using System;
using System.Windows.Forms;

namespace BTL_Nhom7_CNPM
{
    public partial class Form_QLTaiKhoan : Form
    {
        private bool isAdding = false; // Đang ở chế độ thêm
        private bool isEditing = false; // Đang ở chế độ sửa

        public Form_QLTaiKhoan()
        {
            InitializeComponent();
            dgv_taikhoan.CellClick += dgv_taikhoan_CellClick;
        }

        private void Form_QLTaiKhoan_Load(object sender, EventArgs e)
        {
            cbb_chucvu.Items.Add("Nhân viên");
            cbb_chucvu.Items.Add("Quản lý");
            cbb_chucvu.DropDownStyle = ComboBoxStyle.DropDownList; // Ngăn nhập từ bàn phím

            LoadData();
        }

        private void LoadData()
        {
            dgv_taikhoan.DataSource = TaiKhoanDAO.GetListTaiKhoan();
            dgv_taikhoan.Columns["MaTK"].HeaderText = "Mã tài khoản";
            dgv_taikhoan.Columns["ChucVu"].HeaderText = "Chức vụ";
            dgv_taikhoan.Columns["TenDN"].HeaderText = "Tên đăng nhập";
            dgv_taikhoan.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dgv_taikhoan.Columns["HoTen"].HeaderText = "Họ tên";
            ResetForm();
            UpdateButtonState();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            isAdding = true;
            isEditing = false;
            EnableFields(true);
            ClearFields();
            UpdateButtonState();
            txt_matk.Text = TaiKhoanDAO.GenerateMaTK();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_matk.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;
            isAdding = false;
            EnableFields(true);
            UpdateButtonState();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string maTK = txt_matk.Text.Trim();
            if (string.IsNullOrEmpty(maTK))
            {
                MessageBox.Show("Mã tài khoản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbb_chucvu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chức vụ hợp lệ (Nhân viên hoặc Quản lý).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn lưu thông tin này?", "Xác nhận lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                TaiKhoan taiKhoan = new TaiKhoan
                {
                    MaTK = maTK,
                    ChucVu = cbb_chucvu.Text.Trim(),
                    TenDN = txt_tenDN.Text.Trim(),
                    MatKhau = txt_matkhau.Text.Trim(),
                    HoTen = txt_hoten.Text.Trim()
                };

                if (isAdding)
                {
                    if (TaiKhoanDAO.IsTenDNExists(taiKhoan.TenDN))
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    TaiKhoanDAO.SaveTaiKhoan(taiKhoan);
                }
                else if (isEditing)
                {
                    TaiKhoanDAO.UpdateTaiKhoan(taiKhoan);
                }

                LoadData();
                ResetForm();
                MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string maTK = txt_matk.Text.Trim();
            if (string.IsNullOrEmpty(maTK))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nếu tài khoản đang đăng nhập là tài khoản cần xóa
            if (maTK == UserSession.MaTK)
            {
                MessageBox.Show("Không thể xóa tài khoản của chính bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TaiKhoanDAO.DeleteTaiKhoan(maTK);
                LoadData();
            }
        }



        private void dgv_taikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isAdding || isEditing)
                {
                    MessageBox.Show("Vui lòng hoàn tất thao tác trước khi chọn dòng mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (e.RowIndex >= 0 && e.RowIndex < dgv_taikhoan.Rows.Count)
                {
                    DataGridViewRow row = dgv_taikhoan.Rows[e.RowIndex];
                    if (row.Cells["MaTK"].Value != null)
                    {
                        txt_matk.Text = row.Cells["MaTK"].Value.ToString();
                        cbb_chucvu.Text = row.Cells["ChucVu"].Value.ToString();
                        txt_tenDN.Text = row.Cells["TenDN"].Value.ToString();
                        txt_matkhau.Text = row.Cells["MatKhau"].Value.ToString();
                        txt_hoten.Text = row.Cells["HoTen"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ResetForm()
        {
            txt_matk.Clear();
            cbb_chucvu.SelectedIndex = -1;
            txt_tenDN.Clear();
            txt_matkhau.Clear();
            txt_hoten.Clear();
            isAdding = false;
            isEditing = false;
            EnableFields(false);
            UpdateButtonState();
        }

        private void ClearFields()
        {
            txt_matk.Clear();
            cbb_chucvu.SelectedIndex = -1;
            txt_tenDN.Clear();
            txt_matkhau.Clear();
            txt_hoten.Clear();
        }

        private void EnableFields(bool enable)
        {
            txt_matk.Enabled = false;
            cbb_chucvu.Enabled = enable;
            txt_tenDN.Enabled = enable;
            txt_matkhau.Enabled = enable;
            txt_hoten.Enabled = enable;
        }

        private void UpdateButtonState()
        {
            if (!isAdding && !isEditing)
            {
                btn_them.Enabled = true;
                btn_sua.Enabled = true;
                btn_xoa.Enabled = true;
                btn_luu.Enabled = false;
                btn_huy.Enabled = false;
            }
            else
            {
                btn_them.Enabled = false;
                btn_sua.Enabled = false;
                btn_xoa.Enabled = false;
                btn_luu.Enabled = true;
                btn_huy.Enabled = true;
            }
        }

        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn nhập lại thông tin không?", "Xác nhận nhập lại", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                ClearFields();
            }
        }


        private void btn_huy_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn hủy thao tác?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    ResetForm();
                    UpdateButtonState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy thao tác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
    }
}
