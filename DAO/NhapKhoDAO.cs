using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using BTL_Nhom7_CNPM.DatabaseConnect;
using BTL_Nhom7_CNPM.Model;

namespace BTL_Nhom7_CNPM.DAO
{
    internal class NhapKhoDAO
    {
        // Kiểm tra mã nhập kho có tồn tại không
        public static bool IsMaCTNKExists(string maCTNK)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection()) // Sử dụng lớp ConnectDatabase để lấy kết nối
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    string query = "SELECT COUNT(*) FROM NhapKho WHERE MaCTNK = @MaCTNK";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaCTNK", maCTNK);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã nhập kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Thêm nhập kho
        public static void SaveNhapKho(NhapKho nhapKho)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Thêm nhập kho
                    string queryNhapKho = "INSERT INTO NhapKho (MaCTNK, MaNCC, MaSP, SLNhap, DonGiaNhap, NSX, HSD) VALUES (@MaCTNK, @MaNCC, @MaSP, @SLNhap, @DonGiaNhap, @NSX, @HSD)";
                    using (SqlCommand cmdNhapKho = new SqlCommand(queryNhapKho, conn))
                    {
                        cmdNhapKho.Parameters.AddWithValue("@MaCTNK", nhapKho.MaCTNK);
                        cmdNhapKho.Parameters.AddWithValue("@MaNCC", nhapKho.MaNCC);
                        cmdNhapKho.Parameters.AddWithValue("@MaSP", nhapKho.MaSP);
                        cmdNhapKho.Parameters.AddWithValue("@SLNhap", nhapKho.SLNhap);
                        cmdNhapKho.Parameters.AddWithValue("@DonGiaNhap", nhapKho.DonGiaNhap);
                        cmdNhapKho.Parameters.AddWithValue("@NSX", nhapKho.NSX);
                        cmdNhapKho.Parameters.AddWithValue("@HSD", nhapKho.HSD);
                        cmdNhapKho.ExecuteNonQuery();
                    }

                    // Cập nhật số lượng tồn kho
                    string queryUpdateSP = "UPDATE SanPham SET SoLuongTonKho = SoLuongTonKho + @SLNhap WHERE MaSP = @MaSP";
                    using (SqlCommand cmdUpdateSP = new SqlCommand(queryUpdateSP, conn))
                    {
                        cmdUpdateSP.Parameters.AddWithValue("@SLNhap", nhapKho.SLNhap);
                        cmdUpdateSP.Parameters.AddWithValue("@MaSP", nhapKho.MaSP);
                        cmdUpdateSP.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhập kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Cập nhật nhập kho
        public static void UpdateNhapKho(NhapKho nhapKho)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy số lượng nhập cũ
                    string queryGetOldSL = "SELECT SLNhap FROM NhapKho WHERE MaCTNK = @MaCTNK";
                    int oldSLNhap = 0;
                    using (SqlCommand cmdGetOldSL = new SqlCommand(queryGetOldSL, conn))
                    {
                        cmdGetOldSL.Parameters.AddWithValue("@MaCTNK", nhapKho.MaCTNK);
                        oldSLNhap = (int)cmdGetOldSL.ExecuteScalar();
                    }

                    // Cập nhật nhập kho
                    string queryUpdateNhapKho = "UPDATE NhapKho SET MaNCC = @MaNCC, MaSP = @MaSP, SLNhap = @SLNhap, DonGiaNhap = @DonGiaNhap, NSX = @NSX, HSD = @HSD WHERE MaCTNK = @MaCTNK";
                    using (SqlCommand cmdUpdateNhapKho = new SqlCommand(queryUpdateNhapKho, conn))
                    {
                        cmdUpdateNhapKho.Parameters.AddWithValue("@MaCTNK", nhapKho.MaCTNK);
                        cmdUpdateNhapKho.Parameters.AddWithValue("@MaNCC", nhapKho.MaNCC);
                        cmdUpdateNhapKho.Parameters.AddWithValue("@MaSP", nhapKho.MaSP);
                        cmdUpdateNhapKho.Parameters.AddWithValue("@SLNhap", nhapKho.SLNhap);
                        cmdUpdateNhapKho.Parameters.AddWithValue("@DonGiaNhap", nhapKho.DonGiaNhap);
                        cmdUpdateNhapKho.Parameters.AddWithValue("@NSX", nhapKho.NSX);
                        cmdUpdateNhapKho.Parameters.AddWithValue("@HSD", nhapKho.HSD);
                        cmdUpdateNhapKho.ExecuteNonQuery();
                    }

                    // Cập nhật số lượng tồn kho
                    int slChange = nhapKho.SLNhap - oldSLNhap;
                    string queryUpdateSP = "UPDATE SanPham SET SoLuongTonKho = SoLuongTonKho + @SLChange WHERE MaSP = @MaSP";
                    using (SqlCommand cmdUpdateSP = new SqlCommand(queryUpdateSP, conn))
                    {
                        cmdUpdateSP.Parameters.AddWithValue("@SLChange", slChange);
                        cmdUpdateSP.Parameters.AddWithValue("@MaSP", nhapKho.MaSP);
                        cmdUpdateSP.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhập kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Xóa nhập kho
        public static void DeleteNhapKho(string maCTNK)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy số lượng nhập và mã sản phẩm trước khi xóa
                    string queryGetSLAndSP = "SELECT SLNhap, MaSP FROM NhapKho WHERE MaCTNK = @MaCTNK";
                    int slNhap = 0;
                    string maSP = string.Empty;
                    using (SqlCommand cmdGetSLAndSP = new SqlCommand(queryGetSLAndSP, conn))
                    {
                        cmdGetSLAndSP.Parameters.AddWithValue("@MaCTNK", maCTNK);
                        using (SqlDataReader reader = cmdGetSLAndSP.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                slNhap = Convert.ToInt32(reader["SLNhap"]);
                                maSP = reader["MaSP"].ToString();
                            }
                        }
                    }

                    // Kiểm tra xem sản phẩm đã được bán hoặc hủy chưa
                    string queryCheckSell = "SELECT MaHD FROM ChiTietHoaDon WHERE MaSP = @MaSP";
                    string soldInvoice = null;
                    using (SqlCommand cmdCheckSell = new SqlCommand(queryCheckSell, conn))
                    {
                        cmdCheckSell.Parameters.AddWithValue("@MaSP", maSP);
                        using (SqlDataReader reader = cmdCheckSell.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                soldInvoice = reader["MaHD"].ToString();
                            }
                        }
                    }

                    string queryCheckHuy = "SELECT MaHangHuy FROM HangHuy WHERE MaSP = @MaSP";
                    string cancelCode = null;
                    using (SqlCommand cmdCheckHuy = new SqlCommand(queryCheckHuy, conn))
                    {
                        cmdCheckHuy.Parameters.AddWithValue("@MaSP", maSP);
                        using (SqlDataReader reader = cmdCheckHuy.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cancelCode = reader["MaHangHuy"].ToString();
                            }
                        }
                    }

                    // Thông báo tùy thuộc vào tình huống và hiển thị mã hóa đơn hoặc mã hàng hủy nếu có
                    if (soldInvoice != null && cancelCode != null)
                    {
                        MessageBox.Show($"Không thể xóa bản ghi nhập kho này vì sản phẩm có bản ghi hóa đơn bán (Mã hóa đơn: {soldInvoice}) và hủy hàng (Mã hàng hủy: {cancelCode}).",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (soldInvoice != null)
                    {
                        MessageBox.Show($"Không thể xóa bản ghi nhập kho này vì sản phẩm có bản ghi hóa đơn bán (Mã hóa đơn: {soldInvoice}).",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (cancelCode != null)
                    {
                        MessageBox.Show($"Không thể xóa bản ghi nhập kho này vì sản phẩm có bản ghi hủy hàng (Mã hàng hủy: {cancelCode}).",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Xóa nhập kho
                    string queryDeleteNhapKho = "DELETE FROM NhapKho WHERE MaCTNK = @MaCTNK";
                    using (SqlCommand cmdDeleteNhapKho = new SqlCommand(queryDeleteNhapKho, conn))
                    {
                        cmdDeleteNhapKho.Parameters.AddWithValue("@MaCTNK", maCTNK);
                        cmdDeleteNhapKho.ExecuteNonQuery();
                    }

                    // Cập nhật số lượng tồn kho
                    string queryUpdateSP = "UPDATE SanPham SET SoLuongTonKho = SoLuongTonKho - @SLNhap WHERE MaSP = @MaSP";
                    using (SqlCommand cmdUpdateSP = new SqlCommand(queryUpdateSP, conn))
                    {
                        cmdUpdateSP.Parameters.AddWithValue("@SLNhap", slNhap);
                        cmdUpdateSP.Parameters.AddWithValue("@MaSP", maSP);
                        cmdUpdateSP.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhập kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Lấy danh sách nhập kho
        public static List<NhapKho> GetNhapKhoList()
        {
            List<NhapKho> listNhapKho = new List<NhapKho>();
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection()) // Sử dụng lớp ConnectDatabase để lấy kết nối
                {
                    if (conn == null)
                    {
                        MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return listNhapKho;
                    }

                    string query = "SELECT * FROM NhapKho";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NhapKho nhapKho = new NhapKho
                            {
                                MaCTNK = reader["MaCTNK"].ToString(),
                                MaNCC = reader["MaNCC"].ToString(),
                                MaSP = reader["MaSP"].ToString(),
                                SLNhap = Convert.ToInt32(reader["SLNhap"]),
                                DonGiaNhap = Convert.ToDecimal(reader["DonGiaNhap"]),
                                NSX = Convert.ToDateTime(reader["NSX"]),
                                HSD = Convert.ToDateTime(reader["HSD"])
                            };
                            listNhapKho.Add(nhapKho);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách nhập kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listNhapKho;
        }
        public static string GenerateMaCTNK()
        {
            string maCTNK = "CTNK001"; // Mặc định là CTNK001 nếu chưa có nhập kho nào

            using (SqlConnection conn = ConnectDatabase.GetConnection())
            {
                string query = "SELECT TOP 1 MaCTNK FROM NhapKho ORDER BY MaCTNK DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string lastMaCTNK = reader["MaCTNK"].ToString();
                    int lastNumber = int.Parse(lastMaCTNK.Substring(4)); // Chỉnh lại chỉ số sau "CTNK"
                    int newNumber = lastNumber + 1;
                    maCTNK = "CTNK" + newNumber.ToString("D3"); // Đảm bảo là 3 chữ số, ví dụ: CTNK001, CTNK002,...
                }

                reader.Close();
            }

            return maCTNK;
        }

    }
}
