using BTL_Nhom7_CNPM.DatabaseConnect;
using BTL_Nhom7_CNPM.Model;
using BTL_Nhom7_CNPM.UI;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BTL_Nhom7_CNPM.UI
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            lbl_HoTen.Text = $"Xin chào, {UserSession.HoTen}! ({UserSession.ChucVu})";

            if (UserSession.ChucVu.Trim() == "Nhân viên")
            {
                tool_QL.Visible = false;
                tool_ThongKe.Visible = false;
            }
        }

        private void tool_DangXuat_Click(object sender, EventArgs e)
        {
            // Đăng xuất và xóa thông tin tài khoản trong UserSession
            UserSession.ClearSession();

            // Chuyển về form đăng nhập
            Form_DangNhapp formDangNhap = new Form_DangNhapp();
            formDangNhap.Show();
            this.Close(); // Đóng form hiện tại
        }

        /// <summary>
        /// Mở form nếu chưa được mở, nếu đã mở sẽ đưa form lên phía trước
        /// </summary>
        /// <typeparam name="T">Kiểu của form cần mở</typeparam>
        private void OpenFormIfNotExists<T>() where T : Form, new()
        {
            // Kiểm tra form đã được mở hay chưa
            Form existingForm = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f is T);

            if (existingForm != null)
            {
                // Nếu form đã mở, đưa form lên phía trước
                existingForm.BringToFront();
                existingForm.WindowState = FormWindowState.Normal;
            }
            else
            {
                // Nếu chưa mở, tạo form mới và hiển thị
                T newForm = new T();
                newForm.Show();
            }
        }

        // Các sự kiện mở các form tương ứng khi nhấn vào menu
        private void tool_QLTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenFormIfNotExists<Form_QLTaiKhoan>();
        }

        private void tool_QLNCC_Click(object sender, EventArgs e)
        {
            OpenFormIfNotExists<Form_QLNCC>();
        }

        private void tool_QLSanPham_Click(object sender, EventArgs e)
        {
            OpenFormIfNotExists<Form_QLSanPham>();
        }

        private void tool_QLNhapKho_Click(object sender, EventArgs e)
        {
            OpenFormIfNotExists<FormQLNhapKho>();
        }

        private void tool_QLHangHuy_Click(object sender, EventArgs e)
        {
            OpenFormIfNotExists<Form_HangHuy>();
        }

        private void tool_QLHoaDon_Click(object sender, EventArgs e)
        {
            OpenFormIfNotExists<Form_QLHoaDon>();
        }

        private void tool_BanHang_Click(object sender, EventArgs e)
        {
            OpenFormIfNotExists<Form_QLBanHang>();
        }

        private void tool_ThongKe_Click(object sender, EventArgs e)
        {
           // OpenFormIfNotExists<Form_TKDoanhThu>();
        }

        private void tool_TKDoanhThu_Click(object sender, EventArgs e)
        {
           OpenFormIfNotExists<Form_TKDoanhThu>();
        }

        private void tool_TKSPBan_Click(object sender, EventArgs e)
        {
           // OpenFormIfNotExists<Form_TKSPBan>();
        }

        private void tool_TKNhapHang_Click(object sender, EventArgs e)
        {
            //OpenFormIfNotExists<Form_TKNhapHang>();
        }

        private void tool_TKTonKho_Click(object sender, EventArgs e)
        {
            OpenFormIfNotExists<Form_BaoCaoHetHang>();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormIfNotExists<Form_TK>();
        }
    }
}
