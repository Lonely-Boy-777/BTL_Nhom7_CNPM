using System;
using System.Windows.Forms;
using BTL_Nhom7_CNPM.DAO;
using BTL_Nhom7_CNPM.Model;

namespace BTL_Nhom7_CNPM.UI
{
    public partial class FormQLNhapKho : Form
    {
        private bool isAdding = false;
        private bool isEditing = false;

        public FormQLNhapKho()
        {
            InitializeComponent();
            dtp_NSX.Format = DateTimePickerFormat.Custom;
            dtp_NSX.CustomFormat = "dd/MM/yyyy";
            dtp_HSD.Format = DateTimePickerFormat.Custom;
            dtp_HSD.CustomFormat = "dd/MM/yyyy";
            dgv_CTNK.CellClick += dgv_CTNK_CellClick;
        }

        private void FormQLNhapKho_Load(object sender, EventArgs e)
        {
            try
            {
                dgv_CTNK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                dgv_CTNK.DataSource = NhapKhoDAO.GetNhapKhoList();
                dgv_CTNK.Columns["MaCTNK"].HeaderText = "Mã nhập kho";
                dgv_CTNK.Columns["MaNCC"].HeaderText = "Mã NCC";
                dgv_CTNK.Columns["MaSP"].HeaderText = "Mã SP";
                dgv_CTNK.Columns["SLNhap"].HeaderText = "Số lượng nhập";
                dgv_CTNK.Columns["DonGiaNhap"].HeaderText = "Đơn giá nhập";
                dgv_CTNK.Columns["NSX"].HeaderText = "Ngày sản xuất";
                dgv_CTNK.Columns["HSD"].HeaderText = "Hạn sử dụng";
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
                txt_MaCTNK.Text = NhapKhoDAO.GenerateMaCTNK();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vào chế độ thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_CTNK.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chưa chọn nhập kho để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                isAdding = false;
                isEditing = true;
                EnableFields(true);
                FillFormWithData();
                UpdateButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vào chế độ sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                string maCTNK = txt_MaCTNK.Text.Trim();

                if (isAdding)
                 {
                     maCTNK = NhapKhoDAO.GenerateMaCTNK();
                     txt_MaCTNK.Text = maCTNK; 
                 }
                // Hiển thị hộp thoại xác nhận
                var result = MessageBox.Show("Bạn có chắc chắn muốn lưu dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (isAdding)
                    {
                        if (string.IsNullOrEmpty(txt_MaCTNK.Text) || string.IsNullOrEmpty(txt_MaNCC.Text))
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (NhapKhoDAO.IsMaCTNKExists(txt_MaCTNK.Text))
                        {
                            MessageBox.Show("Mã nhập kho đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var nhapKho = new NhapKho
                        {
                           
                             MaCTNK = txt_MaCTNK.Text,
                            MaNCC = txt_MaNCC.Text,
                            MaSP = txt_MaSP.Text,
                            SLNhap = int.Parse(txt_SoLuong.Text),
                            DonGiaNhap = decimal.Parse(txt_DonGiaNhap.Text),
                            NSX = dtp_NSX.Value,
                            HSD = dtp_HSD.Value
                        };

                        NhapKhoDAO.SaveNhapKho(nhapKho);
                        LoadData();
                        ResetForm();
                    }
                    else if (isEditing)
                    {
                        var nhapKho = new NhapKho
                        {
                            MaCTNK = txt_MaCTNK.Text,
                            MaNCC = txt_MaNCC.Text,
                            MaSP = txt_MaSP.Text,
                            SLNhap = int.Parse(txt_SoLuong.Text),
                            DonGiaNhap = decimal.Parse(txt_DonGiaNhap.Text),
                            NSX = dtp_NSX.Value,
                            HSD = dtp_HSD.Value
                        };

                        NhapKhoDAO.UpdateNhapKho(nhapKho);
                        LoadData();
                        ResetForm();
                    }

                    EnableFields(false);
                    UpdateButtonState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            
            try

            {
                if (dgv_CTNK.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Chưa chọn nhập kho để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị hộp thoại xác nhận
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var maCTNK = dgv_CTNK.SelectedRows[0].Cells["MaCTNK"].Value.ToString();
                    NhapKhoDAO.DeleteNhapKho(maCTNK);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgv_CTNK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isAdding || isEditing)
                {
                    MessageBox.Show("Vui lòng hoàn tất thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (e.RowIndex >= 0)
                {
                    var row = dgv_CTNK.Rows[e.RowIndex];
                    txt_MaCTNK.Text = row.Cells["MaCTNK"].Value.ToString();
                    txt_MaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                    txt_MaSP.Text = row.Cells["MaSP"].Value.ToString();
                    txt_SoLuong.Text = row.Cells["SLNhap"].Value.ToString();
                    txt_DonGiaNhap.Text = row.Cells["DonGiaNhap"].Value.ToString();
                    dtp_NSX.Value = (DateTime)row.Cells["NSX"].Value;
                    dtp_HSD.Value = (DateTime)row.Cells["HSD"].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableFields(bool enable)
        {
            txt_MaCTNK.Enabled = false;
            txt_MaNCC.Enabled = enable;
            txt_MaSP.Enabled = enable;
            txt_SoLuong.Enabled = enable;
            txt_DonGiaNhap.Enabled = enable;
            dtp_NSX.Enabled = enable;
            dtp_HSD.Enabled = enable;
        }

        private void ClearFields()
        {
            txt_MaCTNK.Clear();
            txt_MaNCC.Clear();
            txt_MaSP.Clear();
            txt_SoLuong.Clear();
            txt_DonGiaNhap.Clear();
            dtp_NSX.Value = DateTime.Now;
            dtp_HSD.Value = DateTime.Now;
        }

        private void ResetForm()
        {
            isAdding = false;
            isEditing = false;
            EnableFields(false);
            ClearFields();
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

        private void FillFormWithData()
        {
            if (dgv_CTNK.SelectedRows.Count > 0)
            {
                var row = dgv_CTNK.SelectedRows[0];
                txt_MaCTNK.Text = row.Cells["MaCTNK"].Value.ToString();
                txt_MaNCC.Text = row.Cells["MaNCC"].Value.ToString();
                txt_MaSP.Text = row.Cells["MaSP"].Value.ToString();
                txt_SoLuong.Text = row.Cells["SLNhap"].Value.ToString();
                txt_DonGiaNhap.Text = row.Cells["DonGiaNhap"].Value.ToString();
                dtp_NSX.Value = (DateTime)row.Cells["NSX"].Value;
                dtp_HSD.Value = (DateTime)row.Cells["HSD"].Value;
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận
                var result = MessageBox.Show("Bạn có chắc chắn muốn hủy thao tác?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetForm();
                    LoadData();
                    UpdateButtonState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hủy thao tác: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    

        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị hộp thoại xác nhận
                var result = MessageBox.Show("Bạn có chắc chắn muốn nhập lại dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nhập lại dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
    }
}
