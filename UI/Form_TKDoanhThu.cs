using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;
using BTL_Nhom7_CNPM.DatabaseConnect;

namespace BTL_Nhom7_CNPM.UI
{
    public partial class Form_TKDoanhThu : Form
    {
        public Form_TKDoanhThu()
        {
            InitializeComponent();
            dtp_NgayBatDau.Format = DateTimePickerFormat.Custom;
            dtp_NgayBatDau.CustomFormat = "dd/MM/yyyy";

            dtp_NgayKetThuc.Format = DateTimePickerFormat.Custom;
            dtp_NgayKetThuc.CustomFormat = "dd/MM/yyyy";
            txt_DoanhThu.Enabled = false;
            txt_DoanhThuBangChu.Enabled = false;
            
        }

        private void btn_kiemtra_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dtp_NgayBatDau.Value;
            DateTime ngayKetThuc = dtp_NgayKetThuc.Value;

            // Lấy danh sách hóa đơn với thông tin họ tên
            System.Data.DataTable dtHoaDon = GetHoaDonData(ngayBatDau, ngayKetThuc);

            // Tính tổng doanh thu
            decimal tongDoanhThu = 0;
            foreach (DataRow row in dtHoaDon.Rows)
            {
                tongDoanhThu += Convert.ToDecimal(row["TongHD"]);
            }

            // Hiển thị tổng doanh thu
            txt_DoanhThu.Text = tongDoanhThu.ToString("N0", CultureInfo.InvariantCulture);
            txt_DoanhThuBangChu.Text = ConvertNumberToText(tongDoanhThu);

            // Hiển thị dữ liệu lên DataGridView
            LoadDataToDataGridView(dtHoaDon);
        }

        private System.Data.DataTable GetHoaDonData(DateTime fromDate, DateTime toDate)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            using (SqlConnection connection = ConnectDatabase.GetConnection())
            {
                if (connection != null)
                {
                    // Kiểm tra nếu khoảng thời gian không hợp lệ thì lấy tất cả hóa đơn
                    string query = @"
            SELECT hd.MaHD, hd.NgayBan, tk.HoTen, hd.TongHD
            FROM HoaDon hd
            INNER JOIN TaiKhoan tk ON hd.MaTK = tk.MaTK";

                    // Nếu người dùng chọn khoảng thời gian thì thêm điều kiện vào query
                    if (fromDate != DateTime.MinValue && toDate != DateTime.MinValue)
                    {
                        query += " WHERE hd.NgayBan >= @FromDate AND hd.NgayBan < DATEADD(day, 1, @ToDate)";
                    }

                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    if (fromDate != DateTime.MinValue && toDate != DateTime.MinValue)
                    {
                        // Cắt bỏ phần giờ để tránh sai lệch
                        da.SelectCommand.Parameters.AddWithValue("@FromDate", fromDate.Date);
                        da.SelectCommand.Parameters.AddWithValue("@ToDate", toDate.Date);
                    }

                    da.Fill(dt);
                }
            }

            return dt;
        }



        private void LoadDataToDataGridView(System.Data.DataTable data)
        {
            dgv_hoadon.DataSource = data;

            // Đặt header
            dgv_hoadon.Columns["MaHD"].HeaderText = "Mã hóa đơn";
            dgv_hoadon.Columns["NgayBan"].HeaderText = "Ngày bán";
            dgv_hoadon.Columns["HoTen"].HeaderText = "Người bán";
            dgv_hoadon.Columns["TongHD"].HeaderText = "Tổng hóa đơn";
            dgv_hoadon.ReadOnly = true;
            dgv_hoadon.AllowUserToAddRows = false;
            dgv_hoadon.AllowUserToDeleteRows = false;
            dgv_hoadon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Định dạng cột
            dgv_hoadon.Columns["TongHD"].DefaultCellStyle.Format = "N0"; // Định dạng số tiền
        }

        private string ConvertNumberToText(decimal number)
        {
            if (number == 0) return "Không đồng";

            string[] numText = { "", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] unit = { "", "nghìn", "triệu", "tỷ" };
            string result = "";
            string numberStr = ((long)number).ToString(); // Chỉ lấy phần nguyên

            int groupCount = 0;
            while (numberStr.Length > 0)
            {
                // Lấy 3 chữ số cuối (nhóm 3 chữ số)
                string group = numberStr.Length >= 3 ? numberStr.Substring(numberStr.Length - 3) : numberStr;
                numberStr = numberStr.Length >= 3 ? numberStr.Substring(0, numberStr.Length - 3) : "";

                // Chuyển nhóm 3 chữ số thành chữ
                string groupText = ConvertGroupToText(group, numText);

                // Thêm đơn vị nghìn, triệu, tỷ
                if (!string.IsNullOrEmpty(groupText))
                {
                    groupText += " " + unit[groupCount];
                }

                // Ghép kết quả
                result = groupText + " " + result;
                groupCount++;
            }

            result = result.Trim() + " đồng";
            result = char.ToUpper(result[0]) + result.Substring(1); // Viết hoa chữ cái đầu
            return result.Trim();
        }

        // Hàm phụ chuyển nhóm 3 chữ số thành chữ
        private string ConvertGroupToText(string group, string[] numText)
        {
            int num = int.Parse(group);
            if (num == 0) return "";

            int hundreds = num / 100;
            int tens = (num % 100) / 10;
            int units = num % 10;

            string text = "";

            if (hundreds > 0)
            {
                text += numText[hundreds] + " trăm";
            }

            if (tens > 0)
            {
                text += " " + (tens == 1 ? "mười" : numText[tens] + " mươi");
            }
            else if (hundreds > 0 && units > 0)
            {
                text += " lẻ"; // "lẻ" chỉ xuất hiện khi có hàng đơn vị không phải 0
            }

            if (units > 0)
            {
                if (tens > 0 && units == 1) text += " mốt"; // Sửa cho đúng khi đơn vị là 1 ở hàng chục
                else if (tens > 0 && units == 5) text += " lăm"; // Sửa cho đúng khi đơn vị là 5 ở hàng chục
                else text += " " + numText[units];
            }

            return text.Trim();
        }



        private void btn_In_Click(object sender, EventArgs e)
        {
            InHoaDonRaExcel();
        }

        private void InHoaDonRaExcel()
        {
            try
            {
                // Tạo thư mục lưu trữ nếu chưa tồn tại
                string folderPath = @"D:\code\DoanhThu";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Lấy ngày bắt đầu và ngày kết thúc từ DateTimePicker
                string ngayBatDau = dtp_NgayBatDau.Value.ToString("yyyyMMdd");
                string ngayKetThuc = dtp_NgayKetThuc.Value.ToString("yyyyMMdd");

                // Tạo tên file kết hợp với ngày bắt đầu và ngày kết thúc
                string fileName = Path.Combine(folderPath, $"DoanhThu_Tu_{ngayBatDau}_Den_{ngayKetThuc}.xlsx");

                // Khởi tạo Excel
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

                // Ghi header
                worksheet.Cells[1, 1] = "Siêu thị mini 7SELL";
                worksheet.Cells[2, 1] = $"Báo cáo doanh thu từ {dtp_NgayBatDau.Value:dd/MM/yyyy} đến {dtp_NgayKetThuc.Value:dd/MM/yyyy}";
                worksheet.Cells[3, 1] = $"Tổng doanh thu: {txt_DoanhThu.Text}";

                // Ghi tiêu đề cột
                worksheet.Cells[5, 1] = "Mã hóa đơn";
                worksheet.Cells[5, 2] = "Ngày bán";
                worksheet.Cells[5, 3] = "Người bán";
                worksheet.Cells[5, 4] = "Tổng hóa đơn";

                // Ghi dữ liệu từ DataGridView
                int row = 6;
                foreach (DataGridViewRow dgvRow in dgv_hoadon.Rows)
                {
                    worksheet.Cells[row, 1] = dgvRow.Cells["MaHD"].Value;
                    worksheet.Cells[row, 2] = dgvRow.Cells["NgayBan"].Value;
                    worksheet.Cells[row, 3] = dgvRow.Cells["HoTen"].Value;
                    worksheet.Cells[row, 4] = dgvRow.Cells["TongHD"].Value;
                    row++;
                }
           
                workbook.SaveAs(fileName);
                workbook.Close();
                excelApp.Quit();

                // Giải phóng tài nguyên
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(excelApp);

                // Thông báo
                MessageBox.Show($"Doanh thu đã được in ra file Excel: {fileName}", "In Báo Cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               //oadDataToDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu báo cáo ra Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_TKDoanhThu_Load(object sender, EventArgs e)
        {

        }

        private void dtp_NgayBatDau_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtp_NgayKetThuc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_DoanhThu_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgv_hoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_DoanhThuBangChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
