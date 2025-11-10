using QuanLiLoiTienTrinh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QuanLiLoTienTrinh
{
    static class Program
    {
        /// <summary>
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Tạo một đối tượng của frmLogin
            frmLogin loginForm = new frmLogin();

            // 2. Hiển thị loginForm dưới dạng Dialog (hộp thoại)
            // Code sẽ tạm dừng ở đây cho đến khi frmLogin bị đóng
            DialogResult result = loginForm.ShowDialog();

            // 3. Kiểm tra kết quả sau khi frmLogin bị đóng
            if (result == DialogResult.OK)
            {
                Application.Run(new frmMain());
            }

            // 4. Nếu đăng nhập KHÔNG thành công (ví dụ: nhấn Thoát, nhấn dấu X)
            // thì hàm Main() sẽ kết thúc và ứng dụng tự động đóng lại.
        }
    }
}