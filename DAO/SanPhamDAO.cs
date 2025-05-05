using BTL_Nhom7_CNPM.DatabaseConnect;
using BTL_Nhom7_CNPM.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace BTL_Nhom7_CNPM.DAO
{
    internal class SanPhamDAO
    {
        public static List<SanPham> GetSanPhamList()
        {
            List<SanPham> listSP = new List<SanPham>();
            using (SqlConnection conn = ConnectDatabase.GetConnection())
            {
                string query = "SELECT * FROM SanPham";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listSP.Add(new SanPham
                    {
                        MaSP = reader["MaSP"].ToString(),
                        TenSP = reader["TenSP"].ToString(),
                        GiaBan = Convert.ToDecimal(reader["GiaBan"]),
                        SoLuongTonKho = Convert.ToInt32(reader["SoLuongTonKho"])
                    });
                }
            }
            return listSP;
        }

        public static bool IsMaSPExists(string maSP)
        {
            using (SqlConnection conn = ConnectDatabase.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM SanPham WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        public static void AddSanPham(SanPham sp)
        {
            using (SqlConnection conn = ConnectDatabase.GetConnection())
            {
                string query = "INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuongTonKho) VALUES (@MaSP, @TenSP, @GiaBan, @SoLuongTonKho)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("@GiaBan", sp.GiaBan);
                cmd.Parameters.AddWithValue("@SoLuongTonKho", sp.SoLuongTonKho);
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateSanPham(SanPham sp)
        {
            using (SqlConnection conn = ConnectDatabase.GetConnection())
            {
                string query = "UPDATE SanPham SET TenSP = @TenSP, GiaBan = @GiaBan, SoLuongTonKho = @SoLuongTonKho WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                cmd.Parameters.AddWithValue("@GiaBan", sp.GiaBan);
                cmd.Parameters.AddWithValue("@SoLuongTonKho", sp.SoLuongTonKho);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteSanPham(string maSP)
        {
            using (SqlConnection conn = ConnectDatabase.GetConnection())
            {
                try
                {
                    // Kiểm tra xem sản phẩm có tồn tại trong các bản ghi liên quan không (hóa đơn)
                    string checkHoaDonQuery = "SELECT MaHD FROM ChiTietHoaDon WHERE MaSP = @MaSP";
                    SqlCommand checkHoaDonCmd = new SqlCommand(checkHoaDonQuery, conn);
                    checkHoaDonCmd.Parameters.AddWithValue("@MaSP", maSP);

                    SqlDataReader reader = checkHoaDonCmd.ExecuteReader();
                    List<string> hoaDonList = new List<string>();

                    // Lấy danh sách mã hóa đơn liên quan đến sản phẩm
                    while (reader.Read())
                    {
                        hoaDonList.Add(reader["MaHD"].ToString());
                    }
                    reader.Close();

                    // Kiểm tra xem sản phẩm có tồn tại trong các bản ghi nhập kho không
                    string checkNhapKhoQuery = "SELECT MaCTNK FROM NhapKho WHERE MaSP = @MaSP";  // Cập nhật truy vấn đúng bảng ChiTietNhapKho
                    SqlCommand checkNhapKhoCmd = new SqlCommand(checkNhapKhoQuery, conn);
                    checkNhapKhoCmd.Parameters.AddWithValue("@MaSP", maSP);

                    SqlDataReader nhapKhoReader = checkNhapKhoCmd.ExecuteReader();
                    List<string> nhapKhoList = new List<string>();

                    // Lấy danh sách mã nhập kho liên quan đến sản phẩm
                    while (nhapKhoReader.Read())
                    {
                        nhapKhoList.Add(nhapKhoReader["MaCTNK"].ToString());
                    }
                    nhapKhoReader.Close();

                    // Kiểm tra và thông báo nếu sản phẩm đã được sử dụng trong các hóa đơn
                    if (hoaDonList.Count > 0 && nhapKhoList.Count > 0)
                    {
                        string hoaDonMessage = "Sản phẩm này đã được sử dụng trong các hóa đơn bán hàng: " + string.Join(", ", hoaDonList) + ". ";
                        string nhapKhoMessage = "Và trong các bản ghi nhập kho: " + string.Join(", ", nhapKhoList) + ". Vui lòng xóa các bản ghi liên quan trước khi xóa sản phẩm.";
                        MessageBox.Show(hoaDonMessage + nhapKhoMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Dừng quá trình xóa sản phẩm
                    }

                    // Kiểm tra và thông báo nếu sản phẩm đã được sử dụng trong các hóa đơn
                    if (hoaDonList.Count > 0)
                    {
                        string hoaDonMessage = "Sản phẩm này đã được sử dụng trong các hóa đơn bán hàng: " + string.Join(", ", hoaDonList) + ". Vui lòng xóa các hóa đơn liên quan trước khi xóa sản phẩm.";
                        MessageBox.Show(hoaDonMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Dừng quá trình xóa sản phẩm
                    }

                    // Kiểm tra và thông báo nếu sản phẩm đã được sử dụng trong các bản ghi nhập kho
                    if (nhapKhoList.Count > 0)
                    {
                        string nhapKhoMessage = "Sản phẩm này đã được sử dụng trong các bản ghi nhập kho: " + string.Join(", ", nhapKhoList) + ". Vui lòng xóa các bản ghi nhập kho liên quan trước khi xóa sản phẩm.";
                        MessageBox.Show(nhapKhoMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Dừng quá trình xóa sản phẩm
                    }

                    // Nếu không có hóa đơn hoặc bản ghi nhập kho liên quan, thực hiện xóa sản phẩm
                    string query = "DELETE FROM SanPham WHERE MaSP = @MaSP";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static string GenerateMaSP()
        {
            string maSP = "SP001"; // Mặc định là SP001 nếu chưa có sản phẩm nào

            using (SqlConnection conn = ConnectDatabase.GetConnection())
            {
                string query = "SELECT TOP 1 MaSP FROM SanPham ORDER BY MaSP DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string lastMaSP = reader["MaSP"].ToString();
                    int lastNumber = int.Parse(lastMaSP.Substring(2)); // Lấy phần số sau "SP"
                    int newNumber = lastNumber + 1;
                    maSP = "SP" + newNumber.ToString("D3"); // Đảm bảo 3 chữ số, ví dụ SP001, SP002,...
                }

                reader.Close();
            }

            return maSP;
        }


    }
}
