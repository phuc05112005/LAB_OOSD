using System;
using System.Windows.Forms;
using static QuanLyNuocGiaiKhat.Forms.UiHelper;
namespace QuanLyNuocGiaiKhat.Forms
{
    public class FrmMain : Form
    {
        public FrmMain()
        {
            Text = "Quản lý cửa hàng nước giải khát"; Width = 460; Height = 260; StartPosition = FormStartPosition.CenterScreen;
            var tt = Lb(this, "HỆ THỐNG QUẢN LÝ CỬA HÀNG NƯỚC GIẢI KHÁT", 25, 25); tt.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            var b1 = Add(this, new Button { Text = "Bán hàng - Hóa đơn" }, 40, 80, 170, 50);
            var b2 = Add(this, new Button { Text = "Nhập hàng - Đơn đặt hàng" }, 230, 80, 170, 50);
            var b3 = Add(this, new Button { Text = "Thoát" }, 135, 150, 170, 40);
            b1.Click += (a, e) => { using (var f = new FrmBanHang()) f.ShowDialog(this); };
            b2.Click += (a, e) => { using (var f = new FrmDonDatHang()) f.ShowDialog(this); };
            b3.Click += (a, e) => { if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Close(); };
        }
    }
}
