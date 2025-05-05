using System.Data.SqlClient;
using System;

namespace BTL_Nhom7_CNPM.DatabaseConnect
{
    internal class ConnectDatabase
    {
        private static string connectionString = "Data Source=ADMIN;Initial Catalog=QL_NhaThuoc;Integrated Security=True"; // Chuỗi kết nối chung

        // Phương thức để mở kết nối
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open(); // Mở kết nối
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể kết nối đến cơ sở dữ liệu: " + ex.Message);
                return null; // Nếu kết nối thất bại, trả về null
            }
            return connection;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close(); // Đóng kết nối
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi đóng kết nối: " + ex.Message);
            }
        }
    }
}
