using System;
using System.Windows.Forms;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnTestDB_Click_Click(object sender, EventArgs e)
        {
            try
            {
                using (var cn = Db.OpenConnection())
                {
                    MessageBox.Show(
                        "Kết nối cơ sở dữ liệu thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Kết nối thất bại!\n\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}