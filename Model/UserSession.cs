using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_Nhom7_CNPM.Model
{
    public static class UserSession
    {
      
        public static string MaTK { get; set; }
        public static string TenDN { get; set; }
        public static string HoTen { get; set; }
        public static string ChucVu { get; set; }
        public static string MatKhau { get; set; }
        public static void SetUserSession(TaiKhoan taiKhoan)
        {
            MaTK = taiKhoan.MaTK;
            TenDN = taiKhoan.TenDN;
            HoTen = taiKhoan.HoTen;
            ChucVu = taiKhoan.ChucVu;
            MatKhau = taiKhoan.MatKhau;
        }
        public static void ClearSession()
        {
            MaTK = string.Empty;
            TenDN = string.Empty;
            HoTen = string.Empty;
            ChucVu = string.Empty;
            MatKhau = string.Empty;
        }
    }

}
