using BTL_Nhom7_CNPM.DatabaseConnect;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BTL_Nhom7_CNPM.DAO
{
    internal class QLHoaDonDAO
    {
        // Lấy danh sách hóa đơn
        public static DataTable GetHoaDonList()
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = "SELECT * FROM HoaDon";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi
                throw new Exception("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
            }
        }

        // Lấy chi tiết hóa đơn dựa trên mã hóa đơn
        public static DataTable GetChiTietHoaDon(string maHD)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    // Cập nhật câu truy vấn để lấy tên sản phẩm thay vì mã sản phẩm
                    string query = @"
                SELECT 
                    c.MaCTHD, 
                    c.MaHD, 
                    c.MaSP, 
                    s.TenSP,    -- Lấy tên sản phẩm
                    c.SLBan, 
                    c.ThanhTien
                FROM ChiTietHoaDon c
                JOIN SanPham s ON c.MaSP = s.MaSP    -- Kết nối bảng ChiTietHoaDon và SanPham
                WHERE c.MaHD = @MaHD";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@MaHD", maHD);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi
                throw new Exception($"Lỗi khi lấy chi tiết hóa đơn với mã {maHD}: " + ex.Message);
            }
        }


        // Lấy thông tin người bán từ bảng NguoiDung dựa trên MaTK
        public static string GetHoTenNguoiBan(string maTK)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = "SELECT HoTen FROM TaiKhoan WHERE MaTK = @MaTK";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaTK", maTK);
                    return cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi
                throw new Exception($"Lỗi khi lấy thông tin người bán với mã {maTK}: " + ex.Message);
            }
        }

        // Xóa chi tiết hóa đơn
        // Xóa chi tiết hóa đơn và cập nhật số lượng tồn kho
        public static void DeleteChiTietHoaDon(string maHD)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    // Bắt đầu một transaction để đảm bảo tính nhất quán
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Lấy danh sách các sản phẩm trong chi tiết hóa đơn
                        string getChiTietQuery = "SELECT MaSP, SLBan FROM ChiTietHoaDon WHERE MaHD = @MaHD";
                        SqlCommand cmd = new SqlCommand(getChiTietQuery, conn, transaction);
                        cmd.Parameters.AddWithValue("@MaHD", maHD);
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Lưu trữ các cập nhật số lượng
                        List<(string MaSP, int SLBan)> productsToUpdate = new List<(string, int)>();

                        while (reader.Read())
                        {
                            string maSP = reader.GetString(0);
                            int slBan = reader.GetInt32(1);
                            productsToUpdate.Add((maSP, slBan));
                        }
                        reader.Close();

                        // Cập nhật lại số lượng tồn kho cho các sản phẩm đã bán
                        foreach (var product in productsToUpdate)
                        {
                            string updateStockQuery = "UPDATE SanPham SET SoLuongTonKho = SoLuongTonKho + @SLBan WHERE MaSP = @MaSP";
                            SqlCommand updateCmd = new SqlCommand(updateStockQuery, conn, transaction);
                            updateCmd.Parameters.AddWithValue("@SLBan", product.SLBan);
                            updateCmd.Parameters.AddWithValue("@MaSP", product.MaSP);
                            updateCmd.ExecuteNonQuery();
                        }

                        // Sau khi cập nhật số lượng tồn kho, xóa chi tiết hóa đơn
                        string deleteQuery = "DELETE FROM ChiTietHoaDon WHERE MaHD = @MaHD";
                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn, transaction);
                        deleteCmd.Parameters.AddWithValue("@MaHD", maHD);
                        deleteCmd.ExecuteNonQuery();

                        // Commit transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, rollback transaction
                        transaction.Rollback();
                        throw new Exception($"Lỗi khi xóa chi tiết hóa đơn với mã {maHD}: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi
                throw new Exception($"Lỗi khi xóa chi tiết hóa đơn với mã {maHD}: " + ex.Message);
            }
        }


     
        // Xóa hóa đơn và chi tiết hóa đơn
        public static void DeleteHoaDon(string maHD)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    // Bắt đầu một transaction để đảm bảo tính nhất quán
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Xóa chi tiết hóa đơn trước
                        DeleteChiTietHoaDon(maHD);

                        // Sau đó mới xóa hóa đơn chính
                        string query = "DELETE FROM HoaDon WHERE MaHD = @MaHD";
                        SqlCommand cmd = new SqlCommand(query, conn, transaction);
                        cmd.Parameters.AddWithValue("@MaHD", maHD);
                        cmd.ExecuteNonQuery();

                        // Commit transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi, rollback transaction
                        transaction.Rollback();
                        throw new Exception($"Lỗi khi xóa hóa đơn với mã {maHD}: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi
                throw new Exception($"Lỗi khi xóa hóa đơn với mã {maHD}: " + ex.Message);
            }
        }


        // Lấy danh sách hóa đơn với tên người bán
        public static DataTable GetHoaDonListWithSellerName()
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = @"
                        SELECT 
                            HoaDon.MaHD,
                            TaiKhoan.HoTen AS NguoiBan,
                            HoaDon.NgayBan,
                            HoaDon.TongHD
                        FROM HoaDon
                        INNER JOIN TaiKhoan ON HoaDon.MaTK = TaiKhoan.MaTK";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                // Log hoặc thông báo lỗi
                throw new Exception("Lỗi khi lấy danh sách hóa đơn với tên người bán: " + ex.Message);
            }
        }
    }
}