using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBenhAn.Services;
using static QuanLyBenhAn.Forms.FormHelper;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmDangKy : Form
    {
        readonly DangKyService s = new DangKyService();
        readonly DanhMucService dm = new DanhMucService();

        private TextBox txtMaBN, txtHoTen, txtDiaChi, txtDienThoai, txtAnh, txtSoPhieuDK;
        private DateTimePicker dtNgaySinh;
        private ComboBox cboGioiTinh, cboNguoiLap, cboPhieuDK, cboNguoiThu, cboHoSoGH, cboNguoiThuGH;
        private TextBox txtSoBienLai, txtSoBienLaiGH;
        private NumericUpDown numLePhi, numLePhiGH;
        private PictureBox picAnh;
        private DataGridView dgvHoSo;
        private Button btnChonAnh, btnDangKy, btnCapHoSo, btnGiaHan, btnDong;

        public FrmDangKy() { InitializeComponent(); }

        private void FrmDangKy_Load(object a, EventArgs e)
        {
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" }); cboGioiTinh.SelectedIndex = 0;
            foreach (var c in new[] { cboNguoiLap, cboNguoiThu, cboNguoiThuGH }) Bind(c, dm.LayNhanVien(), "HoTen", "MaNV");
            Tai();
        }

        void Tai()
        {
            Bind(cboPhieuDK, s.LayPhieuChuaCapHoSo(), "Ten", "SoPhieuDK");
            var hs = s.LayHoSo();
            dgvHoSo.DataSource = hs;
            Bind(cboHoSoGH, s.LayHoSo(), "Ten", "MaHoSo");
        }

        private void btnChonAnh_Click(object a, EventArgs e)
        {
            using (var f = new OpenFileDialog { Filter = "Ảnh|*.jpg;*.jpeg;*.png" })
                if (f.ShowDialog() == DialogResult.OK) { txtAnh.Text = f.FileName; picAnh.ImageLocation = f.FileName; }
        }

        private void btnDangKy_Click(object a, EventArgs e)
        {
            if (H(s.DangKyBenhNhan(txtMaBN.Text.Trim(), txtHoTen.Text.Trim(), dtNgaySinh.Value, cboGioiTinh.Text, txtDiaChi.Text.Trim(), txtDienThoai.Text.Trim(), txtAnh.Text.Trim(), txtSoPhieuDK.Text.Trim(), V(cboNguoiLap)))) Tai();
        }

        private void btnCapHoSo_Click(object a, EventArgs e) { if (H(s.ThuLePhiVaCapHoSo(V(cboPhieuDK), txtSoBienLai.Text.Trim(), numLePhi.Value, V(cboNguoiThu)))) Tai(); }
        private void btnGiaHan_Click(object a, EventArgs e) { if (H(s.GiaHanLePhi(V(cboHoSoGH), txtSoBienLaiGH.Text.Trim(), numLePhiGH.Value, V(cboNguoiThuGH)))) Tai(); }
        private void btnDong_Click(object a, EventArgs e) { Close(); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(780, 560);
            this.Name = "FrmDangKy";
            this.Text = "Đăng Ký Bệnh Nhân & Quản Lý Hồ Sơ";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmDangKy_Load;

            TabControl tab = new TabControl { Location = new Point(10, 10), Size = new Size(760, 500) };

            // Tab Đăng ký
            TabPage tabDK = new TabPage("Đăng Ký Mới");
            txtMaBN = new TextBox { Location = new Point(100, 15), Size = new Size(140, 20) };
            txtHoTen = new TextBox { Location = new Point(340, 15), Size = new Size(180, 20) };
            dtNgaySinh = new DateTimePicker { Location = new Point(100, 45), Size = new Size(140, 20), Format = DateTimePickerFormat.Short };
            cboGioiTinh = new ComboBox { Location = new Point(340, 45), Size = new Size(80, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            txtDienThoai = new TextBox { Location = new Point(500, 45), Size = new Size(120, 20) };
            txtDiaChi = new TextBox { Location = new Point(100, 75), Size = new Size(520, 20) };
            txtSoPhieuDK = new TextBox { Location = new Point(100, 105), Size = new Size(140, 20) };
            cboNguoiLap = new ComboBox { Location = new Point(340, 105), Size = new Size(180, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            txtAnh = new TextBox { Location = new Point(100, 135), Size = new Size(420, 20) };
            btnChonAnh = new Button { Text = "Chọn...", Location = new Point(530, 133), Size = new Size(90, 25) };
            btnChonAnh.Click += btnChonAnh_Click;
            picAnh = new PictureBox { Location = new Point(635, 15), Size = new Size(110, 140), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
            btnDangKy = new Button { Text = "Đăng Ký Bệnh Nhân", Location = new Point(280, 175), Size = new Size(160, 30), Font = new Font("Arial", 9, FontStyle.Bold) };
            btnDangKy.Click += btnDangKy_Click;

            tabDK.Controls.AddRange(new Control[] {
                new Label { Text = "Mã bệnh nhân:", Location = new Point(10, 18), AutoSize = true }, txtMaBN,
                new Label { Text = "Họ và tên:", Location = new Point(260, 18), AutoSize = true }, txtHoTen,
                new Label { Text = "Ngày sinh:", Location = new Point(10, 48), AutoSize = true }, dtNgaySinh,
                new Label { Text = "Giới tính:", Location = new Point(260, 48), AutoSize = true }, cboGioiTinh,
                new Label { Text = "SĐT:", Location = new Point(460, 48), AutoSize = true }, txtDienThoai,
                new Label { Text = "Địa chỉ:", Location = new Point(10, 78), AutoSize = true }, txtDiaChi,
                new Label { Text = "Số phiếu ĐK:", Location = new Point(10, 108), AutoSize = true }, txtSoPhieuDK,
                new Label { Text = "Người lập:", Location = new Point(260, 108), AutoSize = true }, cboNguoiLap,
                new Label { Text = "Đường dẫn ảnh:", Location = new Point(10, 138), AutoSize = true }, txtAnh, btnChonAnh, picAnh, btnDangKy
            });

            // Tab Cấp Hồ sơ
            TabPage tabCap = new TabPage("Cấp Hồ Sơ Lần Đầu");
            cboPhieuDK = new ComboBox { Location = new Point(120, 20), Size = new Size(250, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            txtSoBienLai = new TextBox { Location = new Point(120, 55), Size = new Size(150, 20) };
            numLePhi = new NumericUpDown { Location = new Point(120, 90), Size = new Size(150, 20), Maximum = 10000000, Value = 50000 };
            cboNguoiThu = new ComboBox { Location = new Point(120, 125), Size = new Size(250, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            btnCapHoSo = new Button { Text = "Thu Lệ Phí & Cấp Hồ Sơ", Location = new Point(120, 170), Size = new Size(180, 35) };
            btnCapHoSo.Click += btnCapHoSo_Click;

            tabCap.Controls.AddRange(new Control[] {
                new Label { Text = "Phiếu đăng ký:", Location = new Point(20, 23), AutoSize = true }, cboPhieuDK,
                new Label { Text = "Số biên lai:", Location = new Point(20, 58), AutoSize = true }, txtSoBienLai,
                new Label { Text = "Số tiền lệ phí:", Location = new Point(20, 93), AutoSize = true }, numLePhi,
                new Label { Text = "Người thu:", Location = new Point(20, 128), AutoSize = true }, cboNguoiThu, btnCapHoSo
            });

            // Tab Gia hạn
            TabPage tabGH = new TabPage("Gia Hạn Lệ Phí");
            cboHoSoGH = new ComboBox { Location = new Point(120, 20), Size = new Size(250, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            txtSoBienLaiGH = new TextBox { Location = new Point(120, 55), Size = new Size(150, 20) };
            numLePhiGH = new NumericUpDown { Location = new Point(120, 90), Size = new Size(150, 20), Maximum = 10000000, Value = 50000 };
            cboNguoiThuGH = new ComboBox { Location = new Point(120, 125), Size = new Size(250, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            btnGiaHan = new Button { Text = "Thu Lệ Phí & Gia Hạn", Location = new Point(120, 170), Size = new Size(180, 35) };
            btnGiaHan.Click += btnGiaHan_Click;

            tabGH.Controls.AddRange(new Control[] {
                new Label { Text = "Chọn hồ sơ:", Location = new Point(20, 23), AutoSize = true }, cboHoSoGH,
                new Label { Text = "Số biên lai:", Location = new Point(20, 58), AutoSize = true }, txtSoBienLaiGH,
                new Label { Text = "Số tiền lệ phí:", Location = new Point(20, 93), AutoSize = true }, numLePhiGH,
                new Label { Text = "Người thu:", Location = new Point(20, 128), AutoSize = true }, cboNguoiThuGH, btnGiaHan
            });

            // Tab Danh sách
            TabPage tabDS = new TabPage("Danh Sách Hồ Sơ");
            dgvHoSo = new DataGridView { Location = new Point(10, 10), Size = new Size(730, 440), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabDS.Controls.Add(dgvHoSo);

            tab.TabPages.AddRange(new TabPage[] { tabDK, tabCap, tabGH, tabDS });
            btnDong = new Button { Text = "Đóng", Location = new Point(680, 520), Size = new Size(90, 30) };
            btnDong.Click += btnDong_Click;

            this.Controls.AddRange(new Control[] { tab, btnDong });
            this.ResumeLayout(false);
        }
    }
}