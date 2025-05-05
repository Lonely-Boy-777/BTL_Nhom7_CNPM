using BTL_Nhom7_CNPM.DatabaseConnect;
using BTL_Nhom7_CNPM.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BTL_Nhom7_CNPM.DAO
{
    internal class HangHuyDAO
    {
        // Thêm hàng hủy
        public static bool ThemHangHuy(HangHuy hangHuy)
        {
            try
            {
                using (SqlConnection connection = ConnectDatabase.GetConnection())
                {
                    if (connection == null) return false;

                    string query = "INSERT INTO HangHuy (MaHangHuy, MaSP, MaCTNK, SLHuy, NgayHuy, LyDoHuy) VALUES (@MaHangHuy, @MaSP, @MaCTNK, @SLHuy, @NgayHuy, @LyDoHuy)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaHangHuy", hangHuy.MaHangHuy);
                    cmd.Parameters.AddWithValue("@MaSP", hangHuy.MaSP);
                    cmd.Parameters.AddWithValue("@MaCTNK", hangHuy.MaCTNK);
                    cmd.Parameters.AddWithValue("@SLHuy", hangHuy.SLHuy);
                    cmd.Parameters.AddWithValue("@NgayHuy", hangHuy.NgayHuy);
                    cmd.Parameters.AddWithValue("@LyDoHuy", hangHuy.LyDoHuy);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                // Log hoặc thông báo lỗi SQL
                Console.WriteLine($"Lỗi SQL khi thêm hàng hủy: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi chung
                Console.WriteLine($"Lỗi khi thêm hàng hủy: {ex.Message}");
                return false;
            }
        }

        // Sửa hàng hủy
        public static bool SuaHangHuy(HangHuy hangHuy)
        {
            try
            {
                using (SqlConnection connection = ConnectDatabase.GetConnection())
                {
                    if (connection == null) return false;

                    // Lấy thông tin hàng hủy cũ
                    string selectQuery = "SELECT MaSP, SLHuy FROM HangHuy WHERE MaHangHuy = @MaHangHuy";
                    SqlCommand selectCmd = new SqlCommand(selectQuery, connection);
                    selectCmd.Parameters.AddWithValue("@MaHangHuy", hangHuy.MaHangHuy);

                    SqlDataReader reader = selectCmd.ExecuteReader();
                    if (!reader.Read()) return false; // Không tìm thấy bản ghi
                    string maSPCu = reader["MaSP"].ToString();
                    int slHuyCu = int.Parse(reader["SLHuy"].ToString());
                    reader.Close();

                    // Tính sự chênh lệch số lượng
                    int thayDoiSoLuong = hangHuy.SLHuy - slHuyCu;

                    // Kiểm tra nếu thay đổi số lượng không làm tồn kho âm
                    if (thayDoiSoLuong > 0 && !KiemTraSoLuongSanPham(hangHuy.MaSP, thayDoiSoLuong))
                    {
                        return false; // Không đủ hàng trong kho để giảm
                    }

                    // Cập nhật số lượng tồn kho cho sản phẩm
                    if (!CapNhatSoLuongSanPham(hangHuy.MaSP, -thayDoiSoLuong)) return false;

                    // Cập nhật thông tin hàng hủy
                    string updateQuery = "UPDATE HangHuy SET MaSP = @MaSP, MaCTNK = @MaCTNK, SLHuy = @SLHuy, NgayHuy = @NgayHuy, LyDoHuy = @LyDoHuy WHERE MaHangHuy = @MaHangHuy";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, connection);
                    updateCmd.Parameters.AddWithValue("@MaHangHuy", hangHuy.MaHangHuy);
                    updateCmd.Parameters.AddWithValue("@MaSP", hangHuy.MaSP);
                    updateCmd.Parameters.AddWithValue("@MaCTNK", hangHuy.MaCTNK);
                    updateCmd.Parameters.AddWithValue("@SLHuy", hangHuy.SLHuy);
                    updateCmd.Parameters.AddWithValue("@NgayHuy", hangHuy.NgayHuy);
                    updateCmd.Parameters.AddWithValue("@LyDoHuy", hangHuy.LyDoHuy);

                    return updateCmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                // Log hoặc thông báo lỗi SQL
                Console.WriteLine($"Lỗi SQL khi sửa hàng hủy: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi chung
                Console.WriteLine($"Lỗi khi sửa hàng hủy: {ex.Message}");
                return false;
            }
        }

        // Xóa hàng hủy
        public static bool XoaHangHuy(string maHangHuy)
        {
            try
            {
                using (SqlConnection connection = ConnectDatabase.GetConnection())
                {
                    if (connection == null) return false;

                    // Lấy số lượng và mã sản phẩm trước khi xóa
                    string selectQuery = "SELECT MaSP, SLHuy FROM HangHuy WHERE MaHangHuy = @MaHangHuy";
                    SqlCommand selectCmd = new SqlCommand(selectQuery, connection);
                    selectCmd.Parameters.AddWithValue("@MaHangHuy", maHangHuy);

                    SqlDataReader reader = selectCmd.ExecuteReader();
                    if (!reader.Read()) return false;

                    string maSP = reader["MaSP"].ToString();
                    int slHuy = int.Parse(reader["SLHuy"].ToString());
                    reader.Close();

                    // Xóa bản ghi
                    string deleteQuery = "DELETE FROM HangHuy WHERE MaHangHuy = @MaHangHuy";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
                    deleteCmd.Parameters.AddWithValue("@MaHangHuy", maHangHuy);

                    if (deleteCmd.ExecuteNonQuery() > 0)
                    {
                        return CapNhatSoLuongSanPham(maSP, slHuy); // Cộng lại số lượng
                    }
                    return false;
                }
            }
            catch (SqlException ex)
            {
                // Log hoặc thông báo lỗi SQL
                Console.WriteLine($"Lỗi SQL khi xóa hàng hủy: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi chung
                Console.WriteLine($"Lỗi khi xóa hàng hủy: {ex.Message}");
                return false;
            }
        }

        // Lấy danh sách hàng hủy
        public static List<HangHuy> LayDanhSachHangHuy()
        {
            List<HangHuy> danhSach = new List<HangHuy>();
            try
            {
                using (SqlConnection connection = ConnectDatabase.GetConnection())
                {
                    if (connection == null) return danhSach;

                    string query = "SELECT * FROM HangHuy";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        HangHuy hangHuy = new HangHuy()
                        {
                            MaHangHuy = reader["MaHangHuy"].ToString(),
                            MaSP = reader["MaSP"].ToString(),
                            MaCTNK = reader["MaCTNK"].ToString(),
                            SLHuy = int.Parse(reader["SLHuy"].ToString()),
                            NgayHuy = DateTime.Parse(reader["NgayHuy"].ToString()),
                            LyDoHuy = reader["LyDoHuy"].ToString()
                        };
                        danhSach.Add(hangHuy);
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log hoặc thông báo lỗi SQL
                Console.WriteLine($"Lỗi SQL khi lấy danh sách hàng hủy: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi chung
                Console.WriteLine($"Lỗi khi lấy danh sách hàng hủy: {ex.Message}");
            }
            return danhSach;
        }

        // Cập nhật số lượng sản phẩm
        public static bool CapNhatSoLuongSanPham(string maSP, int soLuongThayDoi)
        {
            try
            {
                using (SqlConnection connection = ConnectDatabase.GetConnection())
                {
                    if (connection == null) return false;

                    string query = "UPDATE SanPham SET SoLuongTonKho = SoLuongTonKho + @SoLuongThayDoi WHERE MaSP = @MaSP";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@SoLuongThayDoi", soLuongThayDoi);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                // Log hoặc thông báo lỗi SQL
                Console.WriteLine($"Lỗi SQL khi cập nhật số lượng sản phẩm: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi chung
                Console.WriteLine($"Lỗi khi cập nhật số lượng sản phẩm: {ex.Message}");
                return false;
            }
        }

        // Kiểm tra số lượng sản phẩm
        public static bool KiemTraSoLuongSanPham(string maSP, int soLuongHuy)
        {
            try
            {
                using (SqlConnection connection = ConnectDatabase.GetConnection())
                {
                    if (connection == null) return false;

                    string query = "SELECT SoLuongTonKho FROM SanPham WHERE MaSP = @MaSP";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaSP", maSP);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int soLuongHienTai = int.Parse(reader["SoLuongTonKho"].ToString());
                        return soLuongHienTai >= soLuongHuy; // Kiểm tra đủ số lượng để hủy không
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log hoặc thông báo lỗi SQL
                Console.WriteLine($"Lỗi SQL khi kiểm tra số lượng sản phẩm: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi chung
                Console.WriteLine($"Lỗi khi kiểm tra số lượng sản phẩm: {ex.Message}");
            }
            return false;
        }
        // Lấy mã hàng hủy mới tự động
        public static string GenerateNewMaHangHuy()
        {
            try
            {
                using (SqlConnection connection = ConnectDatabase.GetConnection())
                {
                    if (connection == null) return "HH001";  // Trả về mã mặc định nếu không kết nối được

                    // Truy vấn lấy mã hàng hủy lớn nhất hiện tại
                    string query = "SELECT TOP 1 MaHangHuy FROM HangHuy ORDER BY MaHangHuy DESC";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string lastMaHangHuy = reader["MaHangHuy"].ToString();
                        reader.Close();

                        // Lấy phần số sau "HH" và tăng lên
                        int newNumber = int.Parse(lastMaHangHuy.Substring(2)) + 1;

                        // Đảm bảo có 3 chữ số cho phần số
                        return "HH" + newNumber.ToString("D3");
                    }
                    else
                    {
                        // Nếu không có mã hàng hủy nào, tạo mã đầu tiên "HH001"
                        return "HH001";
                    }
                }
            }
            catch (Exception ex)
            {
                // Log lỗi
                Console.WriteLine($"Lỗi khi tạo mã hàng hủy: {ex.Message}");
                return "HH001";  // Trả về mã mặc định nếu có lỗi
            }
        }

    }
}
