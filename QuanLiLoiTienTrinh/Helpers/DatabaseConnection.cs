using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace QuanLiLoiTienTrinh.Helpers
{
    static class DatabaseConnection
    {
        private static string connectionString = "";

        static DatabaseConnection()
        {
            try
            {
                // Đọc chuỗi kết nối có tên 'myConnection' từ file App.config
                connectionString = ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString;
            }
            catch (Exception ex)
            {
                // Nếu có lỗi (ví dụ: không tìm thấy App.config hoặc 'myConnection')
                // Bạn có thể dùng MessageBox ở đây để báo lỗi
                throw new Exception("Không tìm thấy chuỗi kết nối 'myConnection' trong App.config.", ex);
            }
        }

        // Phương thức (method) public để cung cấp một kết nối (SqlConnection) mới
        // Bất cứ khi nào cần truy vấn CSDL, ta sẽ gọi hàm này
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể tạo kết nối CSDL từ chuỗi kết nối.", ex);
            }
        }
    }
}
