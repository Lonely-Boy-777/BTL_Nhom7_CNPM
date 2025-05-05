using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using BTL_Nhom7_CNPM.DAO;
using BTL_Nhom7_CNPM.Model;
using BTL_Nhom7_CNPM.DatabaseConnect;
using System.Data.SqlClient;

namespace BTL_Nhom7_CNPM.UI
{
    public partial class Form_QLHoaDon : Form
    {
        private string maHD = "";

        public Form_QLHoaDon()
        {
            InitializeComponent();
            dtp_NgayBan.Format = DateTimePickerFormat.Custom;
            dtp_NgayBan.CustomFormat = "dd/MM/yyyy";
        }

        private void Form_QLHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                // Load danh sách hóa đơn với tên người bán
                dgv_hoadon.DataSource = QLHoaDonDAO.GetHoaDonListWithSellerName();

                // Cấu hình dgv_hoadon
                dgv_hoadon.ReadOnly = true;
                dgv_hoadon.AllowUserToAddRows = false;
                dgv_hoadon.AllowUserToDeleteRows = false;
                dgv_hoadon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Đặt header tiếng Việt cho dgv_hoadon
                dgv_hoadon.Columns["MaHD"].HeaderText = "Mã hoá đơn";
                dgv_hoadon.Columns["NguoiBan"].HeaderText = "Người bán";
                dgv_hoadon.Columns["NgayBan"].HeaderText = "Ngày bán";
                dgv_hoadon.Columns["TongHD"].HeaderText = "Tổng hoá đơn";

                // Khóa TextBox và dgv_cthd
                txt_MaHD.Enabled = false;
                txt_NguoiBan.Enabled = false;
                dtp_NgayBan.Enabled = false;
                txt_TongHD.Enabled = false;
                dgv_cthd.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_hoadon_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
                {
                    dgv_hoadon.ClearSelection();
                    dgv_hoadon.Rows[e.RowIndex].Selected = true;

                    // Lấy thông tin hóa đơn từ các cột đã cập nhật sau tìm kiếm
                    maHD = dgv_hoadon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
                    string NguoiBan = dgv_hoadon.Rows[e.RowIndex].Cells["NguoiBan"].Value.ToString();
                    DateTime ngayBan = Convert.ToDateTime(dgv_hoadon.Rows[e.RowIndex].Cells["NgayBan"].Value);
                    decimal tongHD = Convert.ToDecimal(dgv_hoadon.Rows[e.RowIndex].Cells["TongHD"].Value);

                    // Đẩy thông tin lên TextBox
                    txt_MaHD.Text = maHD;
                    txt_NguoiBan.Text = NguoiBan;
                    dtp_NgayBan.Value = ngayBan;
                    txt_TongHD.Text = tongHD.ToString();

                    // Hiển thị chi tiết hóa đơn
                    dgv_cthd.DataSource = QLHoaDonDAO.GetChiTietHoaDon(maHD);
                    dgv_cthd.Enabled = true;

                    // Cấu hình dgv_cthd
                    dgv_cthd.ReadOnly = true;
                    dgv_cthd.AllowUserToAddRows = false;
                    dgv_cthd.AllowUserToDeleteRows = false;
                    //  dgv_cthd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_cthd.Columns["MaCTHD"].HeaderText = "Mã CTHD";
                    dgv_cthd.Columns["MaHD"].HeaderText = "Mã HD";
                    dgv_cthd.Columns["MaSP"].HeaderText = "Mã SP";
                    dgv_cthd.Columns["TenSP"].HeaderText = "Tên SP";
                    dgv_cthd.Columns["SLBan"].HeaderText = "Số lượng bán";
                    dgv_cthd.Columns["ThanhTien"].HeaderText = "Thành tiền";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_XoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu không có hóa đơn được chọn
                if (string.IsNullOrEmpty(maHD))
                {
                    MessageBox.Show("Vui lòng chọn một hóa đơn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị hộp thoại xác nhận
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa hóa đơn {maHD} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    // Xóa chi tiết hóa đơn và hóa đơn
                    QLHoaDonDAO.DeleteChiTietHoaDon(maHD);
                    QLHoaDonDAO.DeleteHoaDon(maHD);

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Hóa đơn đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới dữ liệu hóa đơn
                    dgv_hoadon.DataSource = QLHoaDonDAO.GetHoaDonListWithSellerName();

                    // Làm rỗng các trường thông tin và vô hiệu hóa chi tiết hóa đơn
                    maHD = "";
                    txt_MaHD.Text = "";
                    txt_NguoiBan.Text = "";
                    dtp_NgayBan.Value = DateTime.Now; // Hoặc giá trị mặc định
                    txt_TongHD.Text = "";
                    dgv_cthd.DataSource = null;
                    dgv_cthd.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_InHD_Click(object sender, EventArgs e)
        {
            try
            {
                InHoaDonRaExcel();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InHoaDonRaExcel()
        {
            try
            {
                string NguoiBan = txt_NguoiBan.Text;

                string folderPath = @"D:\code\hoadon";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = Path.Combine(folderPath, $"HoaDon_{maHD}.xlsx");

                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

                worksheet.Cells[1, 1] = "Siêu thị mini 7SELL";
                worksheet.Cells[2, 1] = $"Mã hóa đơn: {maHD}";
                worksheet.Cells[3, 1] = $"Người bán: {NguoiBan}";
                worksheet.Cells[4, 1] = $"Ngày in hóa đơn: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                worksheet.Cells[6, 1] = "Chi tiết hóa đơn:";
                worksheet.Cells[7, 1] = "Mã sản phẩm";
                worksheet.Cells[7, 2] = "Tên sản phẩm";
                worksheet.Cells[7, 3] = "Số lượng";
                worksheet.Cells[7, 4] = "Đơn giá";
                worksheet.Cells[7, 5] = "Thành tiền";

                int row = 8;
                decimal tongHoaDon = 0;
                foreach (DataGridViewRow dgvRow in dgv_cthd.Rows)
                {
                    string maSP = dgvRow.Cells["MaSP"].Value.ToString();
                    var sanPham = BanHangDAO.LayThongTinSanPham(maSP);
                    decimal giaBan = sanPham?.GiaBan ?? 0;

                    worksheet.Cells[row, 1] = maSP;
                    worksheet.Cells[row, 2] = sanPham?.TenSP;
                    worksheet.Cells[row, 3] = dgvRow.Cells["SLBan"].Value.ToString();
                    worksheet.Cells[row, 4] = giaBan.ToString("N0");
                    worksheet.Cells[row, 5] = dgvRow.Cells["ThanhTien"].Value.ToString();

                    tongHoaDon += Convert.ToDecimal(dgvRow.Cells["ThanhTien"].Value);
                    row++;
                }

                worksheet.Cells[row, 4] = "Tổng hóa đơn:";
                worksheet.Cells[row, 5] = tongHoaDon;

                // Thêm tổng hóa đơn bằng chữ
                string tongBangChu = ConvertNumberToText(tongHoaDon);
                worksheet.Cells[row + 1, 4] = "Bằng chữ:";
                worksheet.Cells[row + 1, 5] = tongBangChu;

                workbook.SaveAs(fileName);
                workbook.Close();
                excelApp.Quit();

                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(excelApp);

                MessageBox.Show($"Hóa đơn đã được in ra file Excel: {fileName}", "In hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu hóa đơn ra Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txt_timkiem.Text.Trim(); // Lấy giá trị người dùng nhập vào

            if (string.IsNullOrEmpty(searchTerm)) // Nếu không có gì được nhập thì hiển thị tất cả hóa đơn
            {
                // Lấy tất cả hóa đơn khi không có tìm kiếm
                dgv_hoadon.DataSource = QLHoaDonDAO.GetHoaDonListWithSellerName();
            }
            else
            {
                // Tìm kiếm theo mã hóa đơn
                dgv_hoadon.DataSource = SearchHoaDonByMaHD(searchTerm);
            }
        }
        private System.Data.DataTable SearchHoaDonByMaHD(string maHD)
        {
            using (SqlConnection conn = ConnectDatabase.GetConnection())
            {
                string query = @"
            SELECT h.MaHD, n.HoTen AS NguoiBan, h.NgayBan, h.TongHD
            FROM HoaDon h
            JOIN TaiKhoan n ON h.MaTK = n.MaTK
            WHERE h.MaHD LIKE @MaHD";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@MaHD", "%" + maHD + "%");

                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        private string ConvertNumberToText(decimal number)
        {
            if (number == 0) return "Không đồng";

            string[] units = { "", "mươi", "trăm", "nghìn", "triệu", "tỷ" };
            string[] digits = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

            string result = "";
            string numberString = number.ToString("F0"); // Chuyển số thành chuỗi không phần thập phân
            int length = numberString.Length;

            bool isPreviousZero = false; // Theo dõi chữ số trước đó có phải 0 không

            for (int i = 0; i < length; i++)
            {
                int currentDigit = int.Parse(numberString[i].ToString());
                int position = length - i - 1; // Vị trí từ hàng đơn vị trở lên

                if (currentDigit == 0)
                {
                    isPreviousZero = true;
                    if (position % 3 == 0 && i > 0) // Xử lý "nghìn", "triệu", "tỷ"
                    {
                        if (!result.EndsWith("nghìn ") && !result.EndsWith("triệu ") && !result.EndsWith("tỷ "))
                        {
                            result += units[position / 3 + 2] + " ";
                        }
                    }
                    continue;
                }

                if (position % 3 == 1) // Hàng chục
                {
                    if (currentDigit == 1) // Nếu là "mười"
                    {
                        result += "mười ";
                    }
                    else
                    {
                        result += digits[currentDigit] + " " + units[1] + " ";
                    }
                }
                else if (position % 3 == 0 && position > 0) // Hàng nghìn, triệu, tỷ
                {
                    result += digits[currentDigit] + " " + units[position % 3] + " ";
                    result += units[position / 3 + 2] + " ";
                }
                else // Các trường hợp khác
                {
                    if (currentDigit == 5 && position % 3 == 1 && isPreviousZero)
                    {
                        result += "lăm ";
                    }
                    else
                    {
                        result += digits[currentDigit] + " " + units[position % 3] + " ";
                    }
                }

                isPreviousZero = false;
            }

            // Thêm khoảng trắng trước "đồng" và loại bỏ khoảng trắng thừa
            return result.Trim() + " đồng";
        }


        private void dgv_hoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}