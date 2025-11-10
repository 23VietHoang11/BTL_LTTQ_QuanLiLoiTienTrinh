using QuanLiLoiTienTrinh.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiLoiTienTrinh
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            string exePath = Application.StartupPath;

            string gifFileName = "logo2.gif";
            string gifPath = Path.Combine(exePath, "Assets", "logo2.gif");

            try
            {
                if (File.Exists(gifPath))
                {
                    picAnimation.Image = Image.FromFile(gifPath);
                    picAnimation.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy ảnh GIF tại: {gifPath}", "Lỗi Tải GIF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải GIF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            string tenDangNhap = txtTDN.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            // Kiểm tra Tên đăng nhập
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTDN.Focus(); 
                return; 
            }

            // Kiểm tra Mật khẩu
            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus(); 
                return;
            }

           
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT UserID, HoTen, UserRole FROM NguoiDung WHERE TenDangNhap = @username AND MatKhau = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Truyền tham số
                        cmd.Parameters.AddWithValue("@username", tenDangNhap);
                        cmd.Parameters.AddWithValue("@password", matKhau);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows) // Nếu tìm thấy (đăng nhập thành công)
                            {
                                reader.Read(); // Đọc dòng dữ liệu đầu tiên

                                // Lưu thông tin người dùng vào lớp UserSession tĩnh
                                UserSession.UserID = Convert.ToInt32(reader["UserID"]);
                                UserSession.HoTen = reader["HoTen"].ToString();
                                UserSession.UserRole = Convert.ToInt32(reader["UserRole"]);
                                UserSession.TenDangNhap = tenDangNhap;

                                this.DialogResult = DialogResult.OK;
                                this.Close(); // Đóng form login
                            }
                            else 
                            {
                                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối hoặc truy vấn CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
