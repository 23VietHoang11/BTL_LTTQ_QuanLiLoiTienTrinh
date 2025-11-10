using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiLoiTienTrinh.Helpers
{
    public static class UserSession
    {
        public static int UserID { get; set; }
        public static string HoTen { get; set; }
        public static string TenDangNhap { get; set; }

        // 1 = Admin, 2 = QC/Manager, 3 = Operator
        public static int UserRole { get; set; }
    }
}
