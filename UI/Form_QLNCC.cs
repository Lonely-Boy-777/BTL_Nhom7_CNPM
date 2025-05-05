using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL_Nhom7_CNPM.DAO;
using BTL_Nhom7_CNPM.Model;

namespace BTL_Nhom7_CNPM
{
    public partial class Form_QLNCC : Form
    {
        private bool isAdding = false; // Đang ở chế độ thêm
        private bool isEditing = false; // Đang ở chế độ sửa

        public Form_QLNCC()
        {
            InitializeComponent();
            dgv_NCC.CellClick += dgv_NCC_CellClick;

        }

        private void Form_QLNCC_Load(object sender, EventArgs e)
        {
            try
            {
                dgv_NCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadData()
        {
            try
            {
                // Hiển thị trạng thái đang tải dữ liệu (nếu cần)
                dgv_NCC.DataSource = null;
                var data = await Task.Run(() => NhaCungCapDAO.GetNCCList()); // Thao tác lấy dữ liệu bất đồng bộ
                dgv_NCC.DataSource = data;

                dgv_NCC.Columns["MaNCC"].HeaderText = "Mã nhà cung cấp";
                dgv_NCC.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
                dgv_NCC.Columns["SDTNCC"].HeaderText = "Số điện thoại";
                dgv_NCC.Columns["EmailNCC"].HeaderText = "Email";
                ResetForm();
                UpdateButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                isAdding = true;
                isEditing = false;
                EnableFields(true);
                ClearFields();
                UpdateButtonState();
                txt_maNCC.Text = NhaCungCapDAO.GetNewMaNCC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vào chế độ thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn nhập lại toàn bộ dữ liệu?", "Xác nhận nhập lại", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClearFields();
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_maNCC.Text))
                {
                    MessageBox.Show("Vui lòng chọn Nhà cung cấp !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                isEditing = true;
                isAdding = false;
                EnableFields(true);
                UpdateButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vào chế độ sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn lưu thay đổi?", "Xác nhận lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Nội dung hiện tại của btn_luu_Click
                try
                {
                    string maNCC = txt_maNCC.Text.Trim();
                    if (string.IsNullOrEmpty(maNCC))
                    {
                        MessageBox.Show("Mã nhà cung cấp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    NhaCungCap ncc = new NhaCungCap
                    {
                        MaNCC = maNCC,
                        TenNCC = txt_tenNCC.Text.Trim(),
                        SDTNCC = txt_sdtNCC.Text.Trim(),
                        EmailNCC = txt_emailNCC.Text.Trim()
                    };

                    if (isAdding)
                    {
                        if (NhaCungCapDAO.IsMaNCCExists(maNCC))
                        {
                            MessageBox.Show("Mã Nhà Cung Cấp đã tồn tại. Vui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        NhaCungCapDAO.SaveNCC(ncc);
                    }
                    else if (isEditing)
                    {
                        NhaCungCapDAO.UpdateNCC(ncc);
                    }

                    LoadData();
                    ResetForm();
                    MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNCC = txt_maNCC.Text.Trim();
                if (string.IsNullOrEmpty(maNCC))
                {
                    MessageBox.Show("Vui lòng chọn Nhà cung cấp cần xóa từ bảng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa Nhà cung cấp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    NhaCungCapDAO.DeleteNCC(maNCC);
                    LoadData();
                    //  MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_NCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isAdding || isEditing)
                {
                    MessageBox.Show("Vui lòng hoàn tất thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (e.RowIndex >= 0 && e.RowIndex < dgv_NCC.Rows.Count)
                {
                    DataGridViewRow row = dgv_NCC.Rows[e.RowIndex];
                    if (row.Cells["MaNCC"].Value != null)
                    {
                        txt_maNCC.Text = row.Cells["MaNCC"].Value.ToString();
                        txt_tenNCC.Text = row.Cells["TenNCC"].Value.ToString();
                        txt_sdtNCC.Text = row.Cells["SDTNCC"].Value.ToString();
                        txt_emailNCC.Text = row.Cells["EmailNCC"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableFields(bool enable)
        {
            txt_maNCC.Enabled = false;
            txt_tenNCC.Enabled = enable;
            txt_sdtNCC.Enabled = enable;
            txt_emailNCC.Enabled = enable;
        }

        private void ClearFields()
        {
            txt_maNCC.Clear();
            txt_tenNCC.Clear();
            txt_sdtNCC.Clear();
            txt_emailNCC.Clear();
        }

        private void ResetForm()
        {
            ClearFields();
            EnableFields(false);
            isAdding = false;
            isEditing = false;
            UpdateButtonState();
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

        private void btn_huy_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn hủy thao tác?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    LoadData();
                    ResetForm();
                    UpdateButtonState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy thao tác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





    }
}

