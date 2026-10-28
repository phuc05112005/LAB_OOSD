using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmMain : Form
    {
        private Button btnDanhMuc, btnDangKy, btnLichHen, btnPhieuKham, btnTraCuu, btnThongKe, btnThoat;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void Mo(Form f) { using (f) f.ShowDialog(this); }
        private void btnDanhMuc_Click(object s, EventArgs e) { Mo(new FrmDanhMuc()); }
        private void btnDangKy_Click(object s, EventArgs e) { Mo(new FrmDangKy()); }
        private void btnLichHen_Click(object s, EventArgs e) { Mo(new FrmLichHen()); }
        private void btnPhieuKham_Click(object s, EventArgs e) { Mo(new FrmPhieuKham()); }
        private void btnTraCuu_Click(object s, EventArgs e) { Mo(new FrmTraCuu()); }
        private void btnThongKe_Click(object s, EventArgs e) { Mo(new FrmThongKe()); }
        private void btnThoat_Click(object s, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Close();
        }
        private void FrmMain_Load(object sender, EventArgs e) { }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(420, 440);
            this.Name = "FrmMain";
            this.Text = "Hệ Thống Quản Lý Bệnh Án";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmMain_Load;

            Label lblTitle = new Label { Text = "QUẢN LÝ BỆNH ÁN", Font = new Font("Arial", 16, FontStyle.Bold), Location = new Point(100, 20), AutoSize = true, ForeColor = Color.DarkBlue };

            btnDanhMuc = new Button { Text = "1. Quản Lý Danh Mục", Location = new Point(60, 65), Size = new Size(300, 40), Font = new Font("Arial", 10) };
            btnDangKy = new Button { Text = "2. Đăng Ký & Cấp Hồ Sơ", Location = new Point(60, 115), Size = new Size(300, 40), Font = new Font("Arial", 10) };
            btnLichHen = new Button { Text = "3. Đặt Lịch Hẹn Khám", Location = new Point(60, 165), Size = new Size(300, 40), Font = new Font("Arial", 10) };
            btnPhieuKham = new Button { Text = "4. Lập & Ghi Nhận Phếu Khám", Location = new Point(60, 215), Size = new Size(300, 40), Font = new Font("Arial", 10) };
            btnTraCuu = new Button { Text = "5. Tra Cứu Hồ Sơ & Lịch Sử", Location = new Point(60, 265), Size = new Size(300, 40), Font = new Font("Arial", 10) };
            btnThongKe = new Button { Text = "6. Báo Cáo Thống Kê", Location = new Point(60, 315), Size = new Size(300, 40), Font = new Font("Arial", 10) };
            btnThoat = new Button { Text = "7. Thoát Hệ Thống", Location = new Point(60, 370), Size = new Size(300, 40), Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = Color.Red };

            btnDanhMuc.Click += btnDanhMuc_Click;
            btnDangKy.Click += btnDangKy_Click;
            btnLichHen.Click += btnLichHen_Click;
            btnPhieuKham.Click += btnPhieuKham_Click;
            btnTraCuu.Click += btnTraCuu_Click;
            btnThongKe.Click += btnThongKe_Click;
            btnThoat.Click += btnThoat_Click;

            this.Controls.AddRange(new Control[] { lblTitle, btnDanhMuc, btnDangKy, btnLichHen, btnPhieuKham, btnTraCuu, btnThongKe, btnThoat });
            this.ResumeLayout(false);
        }
    }
}