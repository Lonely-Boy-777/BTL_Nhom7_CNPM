using BTL_Nhom7_CNPM.DatabaseConnect;
using BTL_Nhom7_CNPM.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace BTL_Nhom7_CNPM.DAO
{
    internal class NhaCungCapDAO
    {
        // Kiểm tra mã NCC có tồn tại không
        public static bool IsMaNCCExists(string maNCC)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = "SELECT COUNT(*) FROM NhaCungCap WHERE MaNCC = @MaNCC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã NCC: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Thêm NCC
        public static void SaveNCC(NhaCungCap ncc)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = "INSERT INTO NhaCungCap (MaNCC, TenNCC, SDTNCC, EmailNCC) VALUES (@MaNCC, @TenNCC, @SDTNCC, @EmailNCC)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", ncc.MaNCC);
                        cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                        cmd.Parameters.AddWithValue("@SDTNCC", ncc.SDTNCC);
                        cmd.Parameters.AddWithValue("@EmailNCC", ncc.EmailNCC);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm Nhà Cung Cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa NCC
        public static void UpdateNCC(NhaCungCap ncc)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = "UPDATE NhaCungCap SET TenNCC = @TenNCC, SDTNCC = @SDTNCC, EmailNCC = @EmailNCC WHERE MaNCC = @MaNCC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNCC", ncc.MaNCC);
                        cmd.Parameters.AddWithValue("@TenNCC", ncc.TenNCC);
                        cmd.Parameters.AddWithValue("@SDTNCC", ncc.SDTNCC);
                        cmd.Parameters.AddWithValue("@EmailNCC", ncc.EmailNCC);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa Nhà Cung Cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa NCC
        // Xóa NCC
        public static void DeleteNCC(string maNCC)
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    // Kiểm tra xem có chi tiết nhập kho nào liên quan đến mã NCC không
                    string checkNhapKhoQuery = "SELECT COUNT(*) FROM NhapKho WHERE MaNCC = @MaNCC";
                    using (SqlCommand checkCmd = new SqlCommand(checkNhapKhoQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@MaNCC", maNCC);
                        int nhapKhoCount = (int)checkCmd.ExecuteScalar();

                        if (nhapKhoCount > 0)
                        {
                            // Lấy danh sách các mã nhập kho liên quan
                            string getNhapKhoQuery = "SELECT MaCTNK FROM NhapKho WHERE MaNCC = @MaNCC";
                            using (SqlCommand getCmd = new SqlCommand(getNhapKhoQuery, conn))
                            {
                                getCmd.Parameters.AddWithValue("@MaNCC", maNCC);
                                SqlDataReader reader = getCmd.ExecuteReader();
                                string nhapKhoList = "";
                                while (reader.Read())
                                {
                                    nhapKhoList += reader["MaCTNK"].ToString() + ", ";
                                }
                                reader.Close();
                                // Xóa dấu phẩy thừa ở cuối chuỗi
                                nhapKhoList = nhapKhoList.TrimEnd(',', ' ');

                                // Thông báo lỗi với các mã nhập kho liên quan
                                MessageBox.Show($"Không thể xóa Nhà Cung Cấp này vì có bản ghi nhập kho liên quan (Mã Nhập Kho: {nhapKhoList}).",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

            
                    

                    // Nếu không có bản ghi nào liên quan trong ChiTietNhapKho hoặc HangHuy, thực hiện xóa NCC
                    string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
              
                        cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa Nhà Cung Cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy Nhà Cung Cấp để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa Nhà Cung Cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Lấy danh sách NCC
        public static List<NhaCungCap> GetNCCList()
        {
            List<NhaCungCap> listNCC = new List<NhaCungCap>();
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = "SELECT * FROM NhaCungCap";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            NhaCungCap ncc = new NhaCungCap
                            {
                                MaNCC = reader["MaNCC"].ToString(),
                                TenNCC = reader["TenNCC"].ToString(),
                                SDTNCC = reader["SDTNCC"].ToString(),
                                EmailNCC = reader["EmailNCC"].ToString()
                            };
                            listNCC.Add(ncc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách Nhà Cung Cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listNCC;
        }

        public static string GetNewMaNCC()
        {
            try
            {
                using (SqlConnection conn = ConnectDatabase.GetConnection())
                {
                    string query = "SELECT TOP 1 MaNCC FROM NhaCungCap ORDER BY MaNCC DESC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            // Lấy phần số của mã NCC và tăng thêm 1
                            string maNCC = result.ToString();
                            int numberPart = int.Parse(maNCC.Substring(3)); // Giả sử mã là "NCC001", "NCC002", ...
                            return "NCC" + (numberPart + 1).ToString("D3"); // D3 để đảm bảo có 3 chữ số
                        }
                        else
                        {
                            return "NCC001"; // Nếu chưa có mã nào, bắt đầu từ NCC001
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã NCC mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
