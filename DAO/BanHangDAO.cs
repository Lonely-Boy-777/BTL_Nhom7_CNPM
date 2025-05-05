using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BTL_Nhom7_CNPM.Model;
using BTL_Nhom7_CNPM.DatabaseConnect;

namespace BTL_Nhom7_CNPM.DAO
{
    internal class BanHangDAO
    {
        public static List<SanPham> LayDanhSachSanPham()
        {
            List<SanPham> sanPhamList = new List<SanPham>();
            string query = "SELECT * FROM SanPham";

            SqlConnection connection = ConnectDatabase.GetConnection();

            try
            {
                if (connection != null)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var sanPham = new SanPham
                        {
                            MaSP = reader["MaSP"].ToString(),
                            TenSP = reader["TenSP"].ToString(),
                            GiaBan = Convert.ToDecimal(reader["GiaBan"]),
                            SoLuongTonKho = Convert.ToInt32(reader["SoLuongTonKho"])
                        };
                        sanPhamList.Add(sanPham);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return sanPhamList;
        }

        // Lưu hóa đơn
        public static void LuuHoaDon(HoaDon hoaDon)
        {
            string query = "INSERT INTO HoaDon (MaHD, MaTK, NgayBan, TongHD) VALUES (@MaHD, @MaTK, @NgayBan, @TongHD)";

            SqlConnection connection = ConnectDatabase.GetConnection();

            try
            {
                if (connection != null)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHD", hoaDon.MaHD);
                    command.Parameters.AddWithValue("@MaTK", hoaDon.MaTK);
                    command.Parameters.AddWithValue("@NgayBan", hoaDon.NgayBan);
                    command.Parameters.AddWithValue("@TongHD", hoaDon.TongHD);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lưu hóa đơn: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void LuuChiTietHoaDon(ChiTietHoaDon chiTiet)
        {
            string query = "INSERT INTO ChiTietHoaDon (MaCTHD, MaHD, MaSP, SLBan, ThanhTien) VALUES (@MaCTHD, @MaHD, @MaSP, @SLBan, @ThanhTien)";

            SqlConnection connection = ConnectDatabase.GetConnection();
            try
            {
                if (connection != null)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaCTHD", chiTiet.MaCTHD);
                    command.Parameters.AddWithValue("@MaHD", chiTiet.MaHD);
                    command.Parameters.AddWithValue("@MaSP", chiTiet.MaSP);
                    command.Parameters.AddWithValue("@SLBan", chiTiet.SLBan);
                    command.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lưu chi tiết hóa đơn: " + ex.Message);
                throw;  // Để có thể xử lý ngoại lệ ở các nơi gọi phương thức này
            }
            finally
            {
                connection.Close();
            }
        }

        public static void CapNhatSoLuongTonKho(string maSP, int soLuongBan)
        {
            string query = "UPDATE SanPham SET SoLuongTonKho = SoLuongTonKho - @SoLuongBan WHERE MaSP = @MaSP";

            SqlConnection connection = ConnectDatabase.GetConnection();

            try
            {
                if (connection != null)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SoLuongBan", soLuongBan);
                    command.Parameters.AddWithValue("@MaSP", maSP);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        Console.WriteLine($"Không tìm thấy sản phẩm {maSP} hoặc không đủ tồn kho.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật tồn kho: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        // Lấy thông tin sản phẩm từ mã sản phẩm
        public static SanPham LayThongTinSanPham(string maSP)
        {
            SanPham sanPham = null;
            string query = "SELECT * FROM SanPham WHERE MaSP = @MaSP";

            SqlConnection connection = ConnectDatabase.GetConnection();

            try
            {
                if (connection != null)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaSP", maSP);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        sanPham = new SanPham
                        {
                            MaSP = reader["MaSP"].ToString(),
                            TenSP = reader["TenSP"].ToString(),
                            GiaBan = Convert.ToDecimal(reader["GiaBan"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông tin sản phẩm: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return sanPham;
        }
    }
}
