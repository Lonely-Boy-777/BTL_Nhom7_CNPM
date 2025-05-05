using BTL_Nhom7_CNPM.DatabaseConnect;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace BTL_Nhom7_CNPM.UI
{
    public partial class Form_BaoCaoHetHang : Form
    {
        public Form_BaoCaoHetHang()
        {
            InitializeComponent();
            LoadSanPham(); // Gọi phương thức để tải danh sách sản phẩm vào DataGridView khi form khởi động
        }

        // Phương thức để tải danh sách sản phẩm từ cơ sở dữ liệu vào DataGridView
        private void LoadSanPham()

        {
            txt_giaban.Enabled = false;
            txt_masp.Enabled = false;
            txt_sltonkho.Enabled = false;
            txt_tensp.Enabled = false;  
            SqlConnection connection = null;
            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                connection = ConnectDatabase.GetConnection();
                if (connection == null)
                    return;

                string query = "SELECT MaSP, TenSP, GiaBan, SoLuongTonKho FROM SanPham";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Đưa dữ liệu vào DataGridView
                dgv_sanpham.DataSource = dt;

                // Sau khi gán dữ liệu, thay đổi tiêu đề cột
                dgv_sanpham.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
                dgv_sanpham.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
                dgv_sanpham.Columns["GiaBan"].HeaderText = "Giá Bán";
                dgv_sanpham.Columns["SoLuongTonKho"].HeaderText = "Số Lượng Tồn Kho";
                dgv_sanpham.ReadOnly = true;
                dgv_sanpham.AllowUserToAddRows = false;
                dgv_sanpham.AllowUserToDeleteRows = false;
                dgv_sanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                // Đảm bảo kết nối được đóng
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    ConnectDatabase.CloseConnection(connection);
                }
            }
        }

        // Xử lý sự kiện khi người dùng nhấn vào một dòng trong DataGridView
        private void dgv_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có click vào một dòng hợp lệ không
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin từ dòng đã chọn
                DataGridViewRow row = dgv_sanpham.Rows[e.RowIndex];

                // Đẩy dữ liệu vào các TextBox tương ứng
                txt_masp.Text = row.Cells["MaSP"].Value.ToString();        // Mã sản phẩm
                txt_tensp.Text = row.Cells["TenSP"].Value.ToString();       // Tên sản phẩm
                txt_giaban.Text = row.Cells["GiaBan"].Value.ToString();     // Giá bán
                txt_sltonkho.Text = row.Cells["SoLuongTonKho"].Value.ToString(); // Số lượng tồn kho
            }
        }

        private void btn_kiemtra_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txt_slduoi.Text, out int slDuoi))
            {
                // Kiểm tra xem DataSource có null hay không và có dữ liệu không
                if (dgv_sanpham.DataSource != null)
                {
                    var dataTable = (DataTable)dgv_sanpham.DataSource;

                    // Lọc các sản phẩm có số lượng tồn kho nhỏ hơn giá trị nhập vào
                    var filteredRows = dataTable.AsEnumerable()
                        .Where(row => row.Field<int>("SoLuongTonKho") < slDuoi)
                        .ToList();

                    // Kiểm tra nếu có dữ liệu sau khi lọc
                    if (filteredRows.Any())
                    {
                        dgv_sanpham.DataSource = filteredRows.CopyToDataTable();
                    }
                    else
                    {
                        // Nếu không có dữ liệu, hiển thị thông báo và giữ lại dữ liệu gốc
                        MessageBox.Show($"Không có sản phẩm nào có số lượng tồn kho dưới {slDuoi}.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgv_sanpham.DataSource = dataTable; // Giữ lại bảng dữ liệu gốc
                    }
                }
                else
                {
                    // Nếu không có dữ liệu sản phẩm để kiểm tra, load lại dữ liệu
                    MessageBox.Show("Không có dữ liệu sản phẩm để kiểm tra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadSanPham();  // Đảm bảo dữ liệu gốc được tải lại
                }
            }
            else
            {
                // Nếu không nhập đúng số, sẽ thông báo cho người dùng
                MessageBox.Show("Vui lòng nhập một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Phương thức để xuất danh sách sản phẩm có số lượng dưới ngưỡng ra Excel
        private void btn_In_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo thư mục lưu trữ nếu chưa tồn tại
                string folderPath = @"D:\code\SanPham";
                if (!System.IO.Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }

                // Lấy số lượng dưới ngưỡng từ TextBox
                string slDuoi = txt_slduoi.Text;
                DateTime currentDate = DateTime.Now;

                // Tạo tên file với ngày hiện tại và số lượng dưới ngưỡng
                string fileName = System.IO.Path.Combine(folderPath, $"SanPham_SoLuongDuoi_{slDuoi}_Ngay_{currentDate:yyyyMMdd}.xlsx");

                // Khởi tạo Excel
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = false;
                var workbook = excelApp.Workbooks.Add();
                var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

                // Ghi header
                worksheet.Cells[1, 1] = "Siêu thị mini 7SELL";
                worksheet.Cells[2, 1] = $"Thống kê sản phẩm có số lượng tồn kho dưới {slDuoi}";
                worksheet.Cells[3, 1] = $"Ngày: {currentDate:dd/MM/yyyy}";

                // Ghi tiêu đề cột
                worksheet.Cells[5, 1] = "Mã sản phẩm";
                worksheet.Cells[5, 2] = "Tên sản phẩm";
                worksheet.Cells[5, 3] = "Giá bán";
                worksheet.Cells[5, 4] = "Số lượng tồn kho";

                // Ghi dữ liệu từ DataGridView
                int row = 6;
                foreach (DataGridViewRow dgvRow in dgv_sanpham.Rows)
                {
                    if (int.Parse(dgvRow.Cells["SoLuongTonKho"].Value.ToString()) < int.Parse(slDuoi))
                    {
                        worksheet.Cells[row, 1] = dgvRow.Cells["MaSP"].Value;
                        worksheet.Cells[row, 2] = dgvRow.Cells["TenSP"].Value;
                        worksheet.Cells[row, 3] = dgvRow.Cells["GiaBan"].Value;
                        worksheet.Cells[row, 4] = dgvRow.Cells["SoLuongTonKho"].Value;
                        row++;
                    }
                }

                // Lưu và đóng Excel
                workbook.SaveAs(fileName);
                workbook.Close();
                excelApp.Quit();

                // Giải phóng tài nguyên
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                MessageBox.Show($"Dữ liệu đã được in ra file Excel: {fileName}", "In Báo Cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form_BaoCaoHetHang_Load(object sender, EventArgs e)
        {

        }
    }
}
