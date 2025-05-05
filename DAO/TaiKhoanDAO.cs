using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using BTL_Nhom7_CNPM.Model;
using BTL_Nhom7_CNPM.DatabaseConnect;

namespace BTL_Nhom7_CNPM.DAO
{
    internal class TaiKhoanDAO
    {
        // Lấy danh sách tài khoản
        public static List<TaiKhoan> GetListTaiKhoan()
        {
            List<TaiKhoan> listTaiKhoan = new List<TaiKhoan>();
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = "SELECT * FROM TaiKhoan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            TaiKhoan taiKhoan = new TaiKhoan
                            {
                                MaTK = reader["MaTK"].ToString(),
                                ChucVu = reader["ChucVu"].ToString(),
                                TenDN = reader["TenDN"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                HoTen = reader["HoTen"].ToString()
                            };
                            listTaiKhoan.Add(taiKhoan);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listTaiKhoan;
        }

        // Kiểm tra tên đăng nhập có tồn tại không
        public static bool IsTenDNExists(string tenDN)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDN = @TenDN";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDN", tenDN);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra tên đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Thêm tài khoản
        public static void SaveTaiKhoan(TaiKhoan taiKhoan)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = "INSERT INTO TaiKhoan (MaTK, ChucVu, TenDN, MatKhau, HoTen) VALUES (@MaTK, @ChucVu, @TenDN, @MatKhau, @HoTen)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTK", taiKhoan.MaTK);
                        cmd.Parameters.AddWithValue("@ChucVu", taiKhoan.ChucVu);
                        cmd.Parameters.AddWithValue("@TenDN", taiKhoan.TenDN);
                        cmd.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                        cmd.Parameters.AddWithValue("@HoTen", taiKhoan.HoTen);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cập nhật tài khoản
        public static void UpdateTaiKhoan(TaiKhoan taiKhoan)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = "UPDATE TaiKhoan SET ChucVu = @ChucVu, TenDN = @TenDN, MatKhau = @MatKhau, HoTen = @HoTen WHERE MaTK = @MaTK";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaTK", taiKhoan.MaTK);
                        cmd.Parameters.AddWithValue("@ChucVu", taiKhoan.ChucVu);
                        cmd.Parameters.AddWithValue("@TenDN", taiKhoan.TenDN);
                        cmd.Parameters.AddWithValue("@MatKhau", taiKhoan.MatKhau);
                        cmd.Parameters.AddWithValue("@HoTen", taiKhoan.HoTen);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa tài khoản
        public static void DeleteTaiKhoan(string maTK)
        {
            SqlConnection conn = ConnectDatabase.GetConnection();
            try
            {
                if (conn != null)
                {
                    // Kiểm tra xem tài khoản có hóa đơn liên quan không
                    string checkHoaDonQuery = "SELECT COUNT(*) FROM HoaDon WHERE MaTK = @MaTK";
                    SqlCommand checkHoaDonCmd = new SqlCommand(checkHoaDonQuery, conn);
                    checkHoaDonCmd.Parameters.AddWithValue("@MaTK", maTK);

                    int hoaDonCount = (int)checkHoaDonCmd.ExecuteScalar();

                    // Nếu có hóa đơn liên quan, hiển thị thông báo và dừng quá trình xóa
                    if (hoaDonCount > 0)
                    {
                        MessageBox.Show("Tài khoản này có các bản ghi bán hàng liên quan. Vui lòng xóa các hóa đơn trước khi xóa tài khoản.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Dừng quá trình xóa tài khoản
                    }

                    // Nếu không có hóa đơn, thực hiện xóa tài khoản
                    string deleteTaiKhoanQuery = "DELETE FROM TaiKhoan WHERE MaTK = @MaTK";
                    SqlCommand deleteTaiKhoanCmd = new SqlCommand(deleteTaiKhoanQuery, conn);
                    deleteTaiKhoanCmd.Parameters.AddWithValue("@MaTK", maTK);

                    int rowsAffected = deleteTaiKhoanCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        // Hàm tạo mã tài khoản tự động
        public static string GenerateMaTK()
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    // Truy vấn để lấy mã tài khoản lớn nhất
                    string query = "SELECT MAX(CAST(SUBSTRING(MaTK, 3, LEN(MaTK) - 2) AS INT)) FROM TaiKhoan WHERE MaTK LIKE 'TK%'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            // Nếu có mã tài khoản, cộng thêm 1
                            int maxMaTK = Convert.ToInt32(result);
                            return "TK" + (maxMaTK + 1).ToString("D3"); // Định dạng "TK001", "TK002", ...
                        }
                        else
                        {
                            // Nếu chưa có mã tài khoản nào, bắt đầu từ "TK001"
                            return "TK001";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}
