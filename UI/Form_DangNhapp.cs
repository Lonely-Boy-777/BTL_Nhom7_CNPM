using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BTL_Nhom7_CNPM.DatabaseConnect;
using BTL_Nhom7_CNPM.Model;
using BTL_Nhom7_CNPM.UI;

namespace BTL_Nhom7_CNPM
{
    public partial class Form_DangNhapp : Form
    {
        public Form_DangNhapp()
        {
            InitializeComponent();
            txt_matkhau.UseSystemPasswordChar = true; // Che mật khẩu theo mặc định
        }
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string username = txt_dangnhap.Text.Trim();
            string password = txt_matkhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mã hóa mật khẩu người dùng nhập vào
            string hashedPassword = password;  // Nếu muốn mã hóa, có thể gọi HashPassword()

            TaiKhoan taiKhoan = GetTaiKhoanByCredentials(username, hashedPassword);

            if (taiKhoan != null)
            {
               // MessageBox.Show($"Đăng nhập thành công! Chào mừng {taiKhoan.HoTen}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Lưu thông tin tài khoản vào UserSession
                UserSession.SetUserSession(taiKhoan);  // Lưu thông tin tài khoản vào UserSession

                // Truyền thông tin vào FormHome mà không cần truyền TaiKhoan nữa
                FormHome formHome = new FormHome();  // Không cần truyền đối tượng TaiKhoan
                formHome.Show();
                this.Hide(); // Ẩn form đăng nhập
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Thoát ứng dụng
        }

        private void ckb_hienthi_CheckedChanged(object sender, EventArgs e)
        {
            txt_matkhau.UseSystemPasswordChar = !ckb_hienthi.Checked;
        }

        // Phương thức mã hóa mật khẩu sử dụng SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private TaiKhoan GetTaiKhoanByCredentials(string username, string hashedPassword)
        {
            TaiKhoan taiKhoan = null;

            using (SqlConnection connection = ConnectDatabase.GetConnection())  // Sử dụng kết nối chung
            {
                if (connection == null) // Kiểm tra nếu kết nối không thành công
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                string query = "SELECT MaTK, ChucVu, TenDN, MatKhau, HoTen FROM TaiKhoan WHERE TenDN = @username AND MatKhau = @password";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", hashedPassword);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            taiKhoan = new TaiKhoan
                            {
                                MaTK = reader["MaTK"].ToString(),
                                ChucVu = reader["ChucVu"].ToString(),
                                TenDN = reader["TenDN"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                HoTen = reader["HoTen"].ToString()
                            };
                        }
                    }
                }
            }

            return taiKhoan;
        }

        private void Form_DangNhapp_Load(object sender, EventArgs e)
        {

        }
    }
}
