using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Text;
using System.Threading.Tasks;
using BTL_Nhom7_CNPM.DAO;
using BTL_Nhom7_CNPM.Model;
using BTL_Nhom7_CNPM.UI;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;  // Dùng cho giải phóng tài nguyên Excel

namespace BTL_Nhom7_CNPM
{
    public partial class Form_QLBanHang : Form
    {
        private string maHD = string.Empty; // Mã hóa đơn cần in
        private HoaDon hoaDon; // Đối tượng chứa thông tin hóa đơn
        private List<ChiTietHoaDon> chiTietHoaDonList; // Danh sách chi tiết hóa đơn
        private List<SanPham> sanPhamList; // Danh sách sản phẩm để tìm kiếm

        public Form_QLBanHang()
        {
            InitializeComponent();
            chiTietHoaDonList = new List<ChiTietHoaDon>(); // Khởi tạo danh sách chi tiết hóa đơn
            dtp_NgayBan.Format = DateTimePickerFormat.Custom;
            dtp_NgayBan.CustomFormat = "dd/MM/yyyy";
        }

        // Load bảng sản phẩm vào DataGridView
        private void Form_QLBanHang_Load(object sender, EventArgs e)
        {
           
        
            LoadSanPham();
            //CapNhatChiTietHoaDonGrid();
            dgv_sanpham.AllowUserToResizeColumns = false;

            dgv_cthoadon.AllowUserToResizeRows = false;
            dgv_sanpham.AllowUserToResizeRows = false;
        }

        // Hàm load sản phẩm vào DataGridView
        private void LoadSanPham()
        {
            sanPhamList = BanHangDAO.LayDanhSachSanPham();
            dgv_sanpham.DataSource = sanPhamList;

            // Hiển thị tên cột tiếng Việt
            dgv_sanpham.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dgv_sanpham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dgv_sanpham.Columns["GiaBan"].HeaderText = "Giá bán";
            dgv_sanpham.Columns["SoLuongTonKho"].HeaderText = "Số lượng tồn kho";

            dgv_sanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Tùy chỉnh kiểu dữ liệu
            dgv_sanpham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgv_sanpham.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            txt_TongHD.Enabled = false;
            txt_MaHD.Enabled = false;
            txt_NguoiBan.Enabled = false;
            btn_huy.Enabled = false;
            btn_luu.Enabled = false;
            dtp_NgayBan.Enabled = false;
        }

        // Tạo mã hóa đơn tự động và lấy tên nhân viên
        private void btn_taohd_Click(object sender, EventArgs e)
        {
            // Tạo mã hóa đơn tự động
            maHD = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");

            // Lấy tên nhân viên từ session
            string tenNhanVien = UserSession.HoTen;
            txt_MaHD.Text = maHD;
            txt_NguoiBan.Text = tenNhanVien;

            // Lấy ngày giờ hệ thống
            dtp_NgayBan.Value = DateTime.Now;
            btn_luu.Enabled = true;
            btn_huy.Enabled = true;
            btn_taohd.Enabled = false;
        }

        // Thêm sản phẩm vào chi tiết hóa đơn từ DataGridView sản phẩm
        private void dgv_sanpham_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Tạo hóa đơn trước khi thêm sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (e.RowIndex >= 0)  // Kiểm tra nếu là hàng hợp lệ
            {
                if (e.Button == MouseButtons.Right)  // Kiểm tra nếu người dùng nhấn chuột phải
                {
                    int rowIndex = e.RowIndex;
                    string maSP = dgv_sanpham.Rows[rowIndex].Cells["MaSP"].Value.ToString();
                    string tenSP = dgv_sanpham.Rows[rowIndex].Cells["TenSP"].Value.ToString();
                    decimal giaBan = Convert.ToDecimal(dgv_sanpham.Rows[rowIndex].Cells["GiaBan"].Value);
                    int soLuongTon = Convert.ToInt32(dgv_sanpham.Rows[rowIndex].Cells["SoLuongTonKho"].Value);

                    // Mở hộp thoại nhập số lượng bán cho sản phẩm
                    string input = Microsoft.VisualBasic.Interaction.InputBox(
                        $"Nhập số lượng bán cho: {tenSP}",
                        "Nhập Số Lượng",
                        "1"
                    );

                    if (int.TryParse(input, out int soLuong) && soLuong > 0 && soLuong <= soLuongTon)
                    {
                        // Kiểm tra nếu sản phẩm đã tồn tại trong danh sách chi tiết hóa đơn
                        var existingProduct = chiTietHoaDonList.FirstOrDefault(ct => ct.MaSP == maSP);
                        if (existingProduct != null)
                        {
                            // Cập nhật số lượng bán và thành tiền cho sản phẩm đã có trong chi tiết hóa đơn
                            existingProduct.SLBan += soLuong;
                            existingProduct.ThanhTien = existingProduct.SLBan * giaBan;
                        }
                        else
                        {
                            // Tạo chi tiết hóa đơn mới cho sản phẩm chưa có trong danh sách
                            var chiTiet = new ChiTietHoaDon
                            {
                                MaCTHD = "CTHD" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                                MaHD = maHD,
                                MaSP = maSP,
                                SLBan = soLuong,
                                ThanhTien = soLuong * giaBan
                            };

                            chiTietHoaDonList.Add(chiTiet);
                        }

                        // Cập nhật DataGridView chi tiết hóa đơn
                        CapNhatChiTietHoaDonGrid();

                        // Cập nhật tổng tiền hóa đơn
                        decimal tongHD = chiTietHoaDonList.Sum(ct => ct.ThanhTien);
                        txt_TongHD.Text = tongHD.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập số lượng hợp lệ.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có dòng hợp lệ được chọn.");
            }
        }


        // Cập nhật DataGridView chi tiết hóa đơn
        private void CapNhatChiTietHoaDonGrid()
        {
            dgv_cthoadon.DataSource = null;
            dgv_cthoadon.DataSource = chiTietHoaDonList;

            // Cập nhật tiêu đề cột
            dgv_cthoadon.Columns["MaCTHD"].HeaderText = "Mã CTHD";
            dgv_cthoadon.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            dgv_cthoadon.Columns["SLBan"].HeaderText = "Số lượng bán";
            dgv_cthoadon.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgv_cthoadon.Columns["MaHD"].HeaderText = "Mã hoá đơn";
            // Cập nhật tổng tiền hóa đơn
            decimal tongHD = chiTietHoaDonList.Sum(ct => ct.ThanhTien);
            txt_TongHD.Text = tongHD.ToString();
        }


        // Hàm lưu hóa đơn và chi tiết hóa đơn vào cơ sở dữ liệu
        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có chi tiết hóa đơn không
                if (!chiTietHoaDonList.Any())
                {
                    MessageBox.Show("Hóa đơn chưa có sản phẩm nào. Vui lòng thêm sản phẩm trước khi lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lưu hóa đơn vào bảng HoaDon
                hoaDon = new HoaDon
                {
                    MaHD = maHD,
                    MaTK = UserSession.MaTK,
                    NgayBan = dtp_NgayBan.Value,
                    TongHD = Convert.ToDecimal(txt_TongHD.Text)
                };
                BanHangDAO.LuuHoaDon(hoaDon);

                // Lưu chi tiết hóa đơn vào bảng ChiTietHoaDon và cập nhật tồn kho
                foreach (var chiTiet in chiTietHoaDonList)
                {
                    BanHangDAO.LuuChiTietHoaDon(chiTiet);

                    // Cập nhật số lượng tồn kho của sản phẩm
                    BanHangDAO.CapNhatSoLuongTonKho(chiTiet.MaSP, chiTiet.SLBan);
                }

                // Thông báo lưu thành công
                MessageBox.Show("Hóa đơn đã được lưu thành công!");


                // In hóa đơn nếu cần
                var confirmResult = MessageBox.Show("Bạn có muốn in ra hoá đơn không ?", "Xác nhận nhập lại", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    InHoaDonRaExcel();
                }

                // Xoá các trường dữ liệu và làm mới DataGridView
                
                ResetForm();
                btn_taohd.Enabled = Enabled;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu hóa đơn: {ex.Message}");
            }
        }


        // Hàm hủy thao tác
        private void btn_huy_Click(object sender, EventArgs e)
        {
            ResetForm();
            LoadSanPham();
            btn_taohd.Enabled = Enabled;
           
            dgv_cthoadon.AllowUserToResizeRows = false;
            dgv_sanpham.AllowUserToResizeRows = false;

        }

        // Reset form sau khi lưu hoặc hủy
        private void ResetForm()
        {
            // Xóa các trường nhập liệu
            txt_MaHD.Clear();
            txt_NguoiBan.Clear();
            txt_TongHD.Clear();

            // Làm trống danh sách chi tiết hóa đơn
            chiTietHoaDonList.Clear();
            dgv_cthoadon.DataSource = null;

            // Xóa mã hóa đơn cũ
            maHD = string.Empty;

            // Vô hiệu hóa các nút và trường liên quan
            btn_huy.Enabled = false;
            btn_luu.Enabled = false;
            txt_TongHD.Enabled = false;
            txt_MaHD.Enabled = false;
            txt_NguoiBan.Enabled = false;

            // Load lại danh sách sản phẩm
            LoadSanPham();
            txt_MaHD.Clear();
            txt_NguoiBan.Clear();
            txt_TongHD.Clear();
            chiTietHoaDonList.Clear();
            dgv_cthoadon.DataSource = null;

            LoadSanPham();
        }

        // In hóa đơn ra file Excel
        private void InHoaDonRaExcel()
        {
            try
            {
                // Lấy tên người bán từ session
                string tenNguoiBan = UserSession.HoTen;

                // Đường dẫn lưu tệp cố định
                string folderPath = @"D:\code\hoadon";

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Tên file với đường dẫn cố định
                string fileName = Path.Combine(folderPath, $"HoaDon_{maHD}.xlsx");

                // Tạo ứng dụng Excel mới
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;

                // Tạo workbook và worksheet
                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

                // Thêm thông tin cơ bản của hóa đơn
                worksheet.Cells[1, 1] = "Siêu thị mini 7SELL";
                worksheet.Cells[2, 1] = $"Mã hóa đơn: {maHD}";
                worksheet.Cells[3, 1] = $"Người bán: {tenNguoiBan}";
                worksheet.Cells[4, 1] = $"Ngày in hóa đơn: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
                worksheet.Cells[6, 1] = "Chi tiết hóa đơn:";

                // Đặt tiêu đề cho các cột
                worksheet.Cells[7, 1] = "Mã sản phẩm";
                worksheet.Cells[7, 2] = "Tên sản phẩm";
                worksheet.Cells[7, 3] = "Số lượng";
                worksheet.Cells[7, 4] = "Đơn giá";
                worksheet.Cells[7, 5] = "Thành tiền";

                // Đổ dữ liệu từ HoaDon và ChiTietHoaDon vào Excel
                int row = 8;
                decimal tongHoaDon = 0;
                foreach (var chiTiet in chiTietHoaDonList)
                {
                    var sanPham = BanHangDAO.LayThongTinSanPham(chiTiet.MaSP);
                    worksheet.Cells[row, 1] = chiTiet.MaSP;
                    worksheet.Cells[row, 2] = sanPham.TenSP;
                    worksheet.Cells[row, 3] = chiTiet.SLBan;
                    worksheet.Cells[row, 4] = sanPham.GiaBan;
                    worksheet.Cells[row, 5] = chiTiet.ThanhTien;
                    tongHoaDon += chiTiet.ThanhTien;
                    row++;
                }

                // Thêm tổng hóa đơn
                worksheet.Cells[row, 4] = "Tổng hóa đơn:";
                worksheet.Cells[row, 5] = tongHoaDon;
                string tongBangChu = ConvertNumberToText(tongHoaDon);
                worksheet.Cells[row + 1, 4] = "Bằng chữ:";
                worksheet.Cells[row + 1, 5] = tongBangChu;

                // Lưu file Excel vào vị trí đã chọn
                workbook.SaveAs(fileName);
                workbook.Close();
                excelApp.Quit();

                // Giải phóng tài nguyên
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(excelApp);
                GC.Collect();

                MessageBox.Show($"Hóa đơn đã được in ra file Excel: {fileName}", "In hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in hóa đơn ra Excel: {ex.Message}");
            }
        }


        private void btn_xoasp_Click(object sender, EventArgs e)
        {
            if (dgv_cthoadon.CurrentRow != null)
            {
               // string tenSP = dgv_cthoadon.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
                // Hiển thị hộp thoại xác nhận xóa
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này khỏi hóa đơn?",
                                                    "Xác nhận xóa",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    int rowIndex = dgv_cthoadon.CurrentCell.RowIndex;
                    chiTietHoaDonList.RemoveAt(rowIndex);

                    // Cập nhật lại DataGridView chi tiết hóa đơn
                    dgv_cthoadon.DataSource = null;
                    dgv_cthoadon.DataSource = chiTietHoaDonList;

                    // Thiết lập lại tiêu đề cột
                    dgv_cthoadon.Columns["MaCTHD"].HeaderText = "Mã CTHD";
                    dgv_cthoadon.Columns["MaSP"].HeaderText = "Mã sản phẩm";
                    dgv_cthoadon.Columns["SLBan"].HeaderText = "Số lượng bán";
                    dgv_cthoadon.Columns["ThanhTien"].HeaderText = "Thành tiền";
                    dgv_cthoadon.Columns["MaHD"].HeaderText = "Mã hóa đơn";

                    // Cập nhật tổng tiền hóa đơn
                    decimal tongHD = chiTietHoaDonList.Sum(ct => ct.ThanhTien);
                    txt_TongHD.Text = tongHD.ToString();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
            }
        }



        private void txt_timkiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txt_timkiem.Text.Trim().ToLower();

            var filteredList = BanHangDAO.LayDanhSachSanPham()
                .Where(sp => sp.TenSP.ToLower().Contains(keyword))
                .ToList();

            dgv_sanpham.DataSource = filteredList;
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

    }
}
