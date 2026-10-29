using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public partial class FrmMain : Form
    {
        private Label lblTitle;
        private Button btnDanhMuc, btnTuyenDung, btnQuyetDinh;
        private Button btnChamCong, btnBangLuong, btnKhenThuong;
        private Button btnThongKe, btnThoat;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void Mo(Form f)
        {
            using (f) f.ShowDialog(this);
        }

        // Chỉ điều hướng 2 nút này
        private void btnDanhMuc_Click(object s, EventArgs e) { Mo(new FrmDanhMuc()); }
        private void btnTuyenDung_Click(object s, EventArgs e) { Mo(new FrmTuyenDung()); }

        // Các nút còn lại chưa cần dùng
        private void ChuaPhatTrien_Click(object s, EventArgs e)
        {
            MessageBox.Show("Chức năng này chưa được khởi tạo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object s, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.ClientSize = new Size(820, 480);
            this.Name = "FrmMain";
            this.Text = "Quản lý nhân sự - Công ty sơn Đông Á";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(235, 240, 248);

            lblTitle = new Label
            {
                Text = "HỆ THỐNG QUẢN LÝ NHÂN SỰ",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(20, 60, 120),
                Location = new Point(0, 30),
                Size = new Size(820, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Font btnFont = new Font("Segoe UI", 11, FontStyle.Regular);
            Size btnSize = new Size(220, 65);
            Color btnBgColor = Color.FromArgb(225, 225, 225);

            // Hàng 1
            btnDanhMuc = new Button { Text = "Danh mục", Location = new Point(45, 100), Size = btnSize, Font = btnFont, BackColor = btnBgColor, FlatStyle = FlatStyle.Flat };
            btnTuyenDung = new Button { Text = "Tuyển dụng - Hợp đồng", Location = new Point(295, 100), Size = btnSize, Font = btnFont, BackColor = btnBgColor, FlatStyle = FlatStyle.Flat };
            btnQuyetDinh = new Button { Text = "Quyết định chức vụ - lương", Location = new Point(545, 100), Size = btnSize, Font = btnFont, BackColor = btnBgColor, FlatStyle = FlatStyle.Flat };

            // Hàng 2
            btnChamCong = new Button { Text = "Chấm công - Phụ trội", Location = new Point(45, 190), Size = btnSize, Font = btnFont, BackColor = btnBgColor, FlatStyle = FlatStyle.Flat };
            btnBangLuong = new Button { Text = "Bảng lương", Location = new Point(295, 190), Size = btnSize, Font = btnFont, BackColor = btnBgColor, FlatStyle = FlatStyle.Flat };
            btnKhenThuong = new Button { Text = "Khen thưởng - Kỷ luật", Location = new Point(545, 190), Size = btnSize, Font = btnFont, BackColor = btnBgColor, FlatStyle = FlatStyle.Flat };

            // Hàng 3
            btnThongKe = new Button { Text = "Thống kê", Location = new Point(45, 280), Size = btnSize, Font = btnFont, BackColor = btnBgColor, FlatStyle = FlatStyle.Flat };
            btnThoat = new Button { Text = "Thoát", Location = new Point(295, 280), Size = btnSize, Font = btnFont, BackColor = btnBgColor, FlatStyle = FlatStyle.Flat };

            // Gán sự kiện
            btnDanhMuc.Click += btnDanhMuc_Click;
            btnTuyenDung.Click += btnTuyenDung_Click;
            btnQuyetDinh.Click += ChuaPhatTrien_Click;
            btnChamCong.Click += ChuaPhatTrien_Click;
            btnBangLuong.Click += ChuaPhatTrien_Click;
            btnKhenThuong.Click += ChuaPhatTrien_Click;
            btnThongKe.Click += ChuaPhatTrien_Click;
            btnThoat.Click += btnThoat_Click;

            this.Controls.AddRange(new Control[] {
                lblTitle, btnDanhMuc, btnTuyenDung, btnQuyetDinh,
                btnChamCong, btnBangLuong, btnKhenThuong, btnThongKe, btnThoat
            });

            this.ResumeLayout(false);
        }
    }
}