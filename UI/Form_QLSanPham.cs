using System;
using System.Windows.Forms;
using BTL_Nhom7_CNPM.DAO;
using BTL_Nhom7_CNPM.Model;

namespace BTL_Nhom7_CNPM
{
    public partial class Form_QLSanPham : Form
    {
        private bool isAdding = false;
        private bool isEditing = false;

        public Form_QLSanPham()
        {
            InitializeComponent();
            dgv_sanpham.CellClick += dgv_sanpham_CellClick;
        }

        private void Form_QLSanPham_Load(object sender, EventArgs e)
        {
            try
            {
                dgv_sanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                dgv_sanpham.DataSource = SanPhamDAO.GetSanPhamList();
                dgv_sanpham.Columns["MaSP"].HeaderText = "Mã sản phẩm";
                dgv_sanpham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
                dgv_sanpham.Columns["GiaBan"].HeaderText = "Giá bán";
                dgv_sanpham.Columns["SoLuongTonKho"].HeaderText = "Tồn kho";
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

            isAdding = true;
            isEditing = false;
            EnableFields(true);
            ClearFields();
            UpdateButtonState();
            txt_maSP.Text = SanPhamDAO.GenerateMaSP();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_maSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;
            isAdding = false;
            EnableFields(true);
            UpdateButtonState();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string maSP = txt_maSP.Text.Trim();

            // Nếu đang thêm sản phẩm mới, tự động tạo mã SP
            if (isAdding)
            {
                maSP = SanPhamDAO.GenerateMaSP(); // Gọi hàm tạo mã SP tự động
                txt_maSP.Text = maSP; // Hiển thị mã SP trong ô nhập liệu
            }

            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Mã sản phẩm không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn lưu thay đổi này?", "Xác nhận lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                SanPham sp = new SanPham
                {
                    MaSP = maSP,
                    TenSP = txt_tenSP.Text.Trim(),
                    GiaBan = decimal.TryParse(txt_giaban.Text.Trim(), out decimal giaBan) ? giaBan : 0,
                    SoLuongTonKho = int.TryParse(txt_tonkho.Text.Trim(), out int tonKho) ? tonKho : 0
                };

                try
                {
                    if (isAdding)
                    {
                        if (SanPhamDAO.IsMaSPExists(maSP))
                        {
                            MessageBox.Show("Mã sản phẩm đã tồn tại. Vui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        SanPhamDAO.AddSanPham(sp);
                    }
                    else if (isEditing)
                    {
                        SanPhamDAO.UpdateSanPham(sp);
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
            string maSP = txt_maSP.Text.Trim();
            if (string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa từ bảng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    SanPhamDAO.DeleteSanPham(maSP);
                    LoadData();
                   // MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isAdding || isEditing)
            {
                MessageBox.Show("Vui lòng hoàn tất thao tác trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.RowIndex >= 0 && e.RowIndex < dgv_sanpham.Rows.Count)
            {
                DataGridViewRow row = dgv_sanpham.Rows[e.RowIndex];
                txt_maSP.Text = row.Cells["MaSP"].Value?.ToString();
                txt_tenSP.Text = row.Cells["TenSP"].Value?.ToString();
                txt_giaban.Text = row.Cells["GiaBan"].Value?.ToString();
                txt_tonkho.Text = row.Cells["SoLuongTonKho"].Value?.ToString();
            }
        }

        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn nhập lại thông tin?", "Xác nhận nhập lại", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                ClearFields();
            }
        }


        private void btn_huy_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn hủy thay đổi?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                LoadData();
                ResetForm();
            }
        }


        private void EnableFields(bool enable)
        {
            txt_maSP.Enabled = false;
            txt_tenSP.Enabled = enable;
            txt_giaban.Enabled = enable;
            txt_tonkho.Enabled = false;
        }

        private void ClearFields()
        {
            txt_maSP.Clear();
            txt_tenSP.Clear();
            txt_giaban.Clear();
            txt_tonkho.Clear();
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
            btn_them.Enabled = !isAdding && !isEditing;
            btn_sua.Enabled = !isAdding && !isEditing;
            btn_xoa.Enabled = !isAdding && !isEditing;
            btn_luu.Enabled = isAdding || isEditing;
            btn_huy.Enabled = isAdding || isEditing;
        }

     
    }
}
