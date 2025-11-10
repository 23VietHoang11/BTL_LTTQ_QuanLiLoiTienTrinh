using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
