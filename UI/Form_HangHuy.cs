using System;
using System.Windows.Forms;
using BTL_Nhom7_CNPM.DAO;
using BTL_Nhom7_CNPM.Model;

namespace BTL_Nhom7_CNPM.UI
{
    public partial class Form_HangHuy : Form
    {
        private bool isAdding = false;
        private bool isEditing = false;

        public Form_HangHuy()
        {
            InitializeComponent();
            dgv_HangHuy.CellClick += dgv_HangHuy_CellClick;
            dtp_NgayHuy.Format = DateTimePickerFormat.Custom;
            dtp_NgayHuy.CustomFormat = "dd/MM/yyyy";
        }

        private void Form_HangHuy_Load(object sender, EventArgs e)
        {
            try
            {
               // dgv_HangHuy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                dgv_HangHuy.DataSource = HangHuyDAO.LayDanhSachHangHuy();
                dgv_HangHuy.Columns["MaHangHuy"].HeaderText = "Mã hàng hủy";
                dgv_HangHuy.Columns["MaSP"].HeaderText = "Mã sản phẩm";
                dgv_HangHuy.Columns["MaCTNK"].HeaderText = "Mã nhập kho";
                dgv_HangHuy.Columns["SLHuy"].HeaderText = "Số lượng hủy";
                dgv_HangHuy.Columns["NgayHuy"].HeaderText = "Ngày hủy";
                dgv_HangHuy.Columns["LyDoHuy"].HeaderText = "Lý do hủy";

                ResetForm();
                UpdateButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
           
            isAdding = true;
            isEditing = false;
            EnableFields(true);
            ClearFields();
            UpdateButtonState();
            txt_MaHangHuy.Text = HangHuyDAO.GenerateNewMaHangHuy();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (dgv_HangHuy.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hàng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            isEditing = true;
            EnableFields(true);
            FillFormWithData();
            UpdateButtonState();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn lưu thay đổi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (string.IsNullOrEmpty(txt_MaHangHuy.Text) || string.IsNullOrEmpty(txt_MaSP.Text) || string.IsNullOrEmpty(txt_SLHuy.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int soLuongHuy = int.Parse(txt_SLHuy.Text);
                    if (!HangHuyDAO.KiemTraSoLuongSanPham(txt_MaSP.Text, soLuongHuy))
                    {
                        MessageBox.Show("Số lượng hủy vượt quá số lượng sản phẩm hiện có.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (isAdding)
                    {
                        var hangHuy = new HangHuy
                        {
                            MaHangHuy = HangHuyDAO.GenerateNewMaHangHuy(),
                            MaSP = txt_MaSP.Text,
                            MaCTNK = txt_MaCTNK.Text,
                            SLHuy = soLuongHuy,
                            NgayHuy = dtp_NgayHuy.Value,
                            LyDoHuy = txt_LyDoHuy.Text
                        };

                        HangHuyDAO.ThemHangHuy(hangHuy);
                        HangHuyDAO.CapNhatSoLuongSanPham(txt_MaSP.Text, -soLuongHuy);
                    }
                    else if (isEditing)
                    {
                        var hangHuy = new HangHuy
                        {
                            MaHangHuy = txt_MaHangHuy.Text,
                            MaSP = txt_MaSP.Text,
                            MaCTNK = txt_MaCTNK.Text,
                            SLHuy = soLuongHuy,
                            NgayHuy = dtp_NgayHuy.Value,
                            LyDoHuy = txt_LyDoHuy.Text
                        };

                        HangHuyDAO.SuaHangHuy(hangHuy);
                    }

                    LoadData();
                    ResetForm();
                    UpdateButtonState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                if (dgv_HangHuy.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string maHangHuy = dgv_HangHuy.SelectedRows[0].Cells["MaHangHuy"].Value.ToString();
                    HangHuyDAO.XoaHangHuy(maHangHuy);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_HangHuy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FillFormWithData();
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show("Bạn có chắc chắn muốn hủy thao tác?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                LoadData(); 
                ResetForm();
                UpdateButtonState();
            }
        }

        private void EnableFields(bool enable)
        {
            txt_MaHangHuy.Enabled = false;
            txt_MaSP.Enabled = enable;
            txt_MaCTNK.Enabled = enable;
            txt_SLHuy.Enabled = enable;
            txt_LyDoHuy.Enabled = enable;
            dtp_NgayHuy.Enabled = enable;
        }

        private void ClearFields()
        {
            txt_MaHangHuy.Clear();
            txt_MaSP.Clear();
            txt_MaCTNK.Clear();
            txt_SLHuy.Clear();
            txt_LyDoHuy.Clear();
            dtp_NgayHuy.Value = DateTime.Now;
        }

        private void ResetForm()
        {
            isAdding = false;
            isEditing = false;
            EnableFields(false);
            ClearFields();
        }

        private void UpdateButtonState()
        {
            btn_them.Enabled = !isAdding && !isEditing;
            btn_sua.Enabled = !isAdding && !isEditing;
            btn_xoa.Enabled = !isAdding && !isEditing;
            btn_luu.Enabled = isAdding || isEditing;
            btn_huy.Enabled = isAdding || isEditing;
        }

        private void FillFormWithData()
        {
            if (dgv_HangHuy.SelectedRows.Count > 0)
            {
                var row = dgv_HangHuy.SelectedRows[0];
                txt_MaHangHuy.Text = row.Cells["MaHangHuy"].Value.ToString();
                txt_MaSP.Text = row.Cells["MaSP"].Value.ToString();
                txt_MaCTNK.Text = row.Cells["MaCTNK"].Value.ToString();
                txt_SLHuy.Text = row.Cells["SLHuy"].Value.ToString();
                txt_LyDoHuy.Text = row.Cells["LyDoHuy"].Value.ToString();
                dtp_NgayHuy.Value = (DateTime)row.Cells["NgayHuy"].Value;
            }
        }
    }
}
