using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBenhAn.Services;
using static QuanLyBenhAn.Forms.FormHelper;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmPhieuKham : Form
    {
        readonly PhieuKhamService s = new PhieuKhamService();
        readonly DangKyService dk = new DangKyService();
        readonly DanhMucService dm = new DanhMucService();

        private TextBox txtSoPhieu, txtGiaTri, txtSoToa, txtLoiDan, txtLieuDung, txtCachDung, txtPhanUng, txtKetQuaXN, txtChanDoan, txtDienBien, txtHieuQua, txtBienLai;
        private ComboBox cboHoSo, cboKhoa, cboBS, cboLoai, cboLichHen, cboNguoiGhi, cboTC, cboThuoc, cboTCToa, cboXN;
        private DateTimePicker dtNgayGio, dtNgayKe, dtNgayXN, dtXuatVien;
        private CheckBox chkXuatVien;
        private NumericUpDown numSoLuong;
        private DataGridView dgvTC;
        private TabControl tabCT;
        private Button btnTaoPhieu, btnThemTC, btnLapToa, btnThemThuoc, btnThemXN, btnGhiNhan, btnDong;

        public FrmPhieuKham() { InitializeComponent(); }

        private void FrmPhieuKham_Load(object a, EventArgs e)
        {
            cboLoai.Items.AddRange(new object[] { "Điều trị", "Định kỳ" }); cboLoai.SelectedIndex = 0;
            Bind(cboHoSo, dk.LayHoSo(), "Ten", "MaHoSo");
            Bind(cboKhoa, dm.LayKhoa(), "TenKhoa", "MaKhoa");
            Bind(cboNguoiGhi, dm.LayNhanVien(), "HoTen", "MaNV");
            Bind(cboTC, dm.LayTrieuChung(), "TenTC", "MaTC");
            Bind(cboThuoc, dm.LayThuoc(), "TenThuoc", "MaThuoc");
            Bind(cboXN, dm.LayXetNghiem(), "TenXN", "MaXN");

            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            cboLoai.SelectedIndexChanged += cboLoai_SelectedIndexChanged;

            cboKhoa_SelectedIndexChanged(null, null);
            cboLoai_SelectedIndexChanged(null, null);
            tabCT.Enabled = false;
        }

        private void cboKhoa_SelectedIndexChanged(object a, EventArgs e) { Bind(cboBS, dm.LayBacSiTheoKhoa(V(cboKhoa)), "HoTen", "MaBS"); }
        private void cboLoai_SelectedIndexChanged(object a, EventArgs e)
        {
            cboLichHen.Enabled = cboLoai.Text == "Định kỳ";
            if (cboLichHen.Enabled) Bind(cboLichHen, s.LayLichDaHen(V(cboHoSo)), "Ten", "SoLichHen");
        }

        private void btnTaoPhieu_Click(object a, EventArgs e)
        {
            string lich = cboLoai.Text == "Định kỳ" ? V(cboLichHen) : null;
            if (H(s.TaoPhieuKham(txtSoPhieu.Text.Trim(), V(cboHoSo), V(cboBS), V(cboKhoa), dtNgayGio.Value, cboLoai.Text, lich, V(cboNguoiGhi)))) tabCT.Enabled = true;
        }

        void NapTrieuChungPhieu()
        {
            Bind(cboTCToa, s.LayTrieuChungCuaPhieu(txtSoPhieu.Text.Trim()), "TenTC", "MaTC");
            dgvTC.DataSource = s.LayTrieuChungCuaPhieu(txtSoPhieu.Text.Trim());
        }

        private void btnThemTC_Click(object a, EventArgs e) { if (H(s.ThemTrieuChung(txtSoPhieu.Text.Trim(), V(cboTC), txtGiaTri.Text.Trim(), null))) NapTrieuChungPhieu(); }
        private void btnLapToa_Click(object a, EventArgs e) { H(s.LapToaThuoc(txtSoToa.Text.Trim(), txtSoPhieu.Text.Trim(), dtNgayKe.Value, txtLoiDan.Text.Trim())); }
        private void btnThemThuoc_Click(object a, EventArgs e)
        { H(s.ThemThuoc(txtSoToa.Text.Trim(), V(cboThuoc), V(cboTCToa), (int)numSoLuong.Value, txtLieuDung.Text.Trim(), txtCachDung.Text.Trim(), txtPhanUng.Text.Trim())); }
        private void btnThemXN_Click(object a, EventArgs e) { H(s.ThemXetNghiem(txtSoPhieu.Text.Trim(), V(cboXN), dtNgayXN.Value, txtKetQuaXN.Text.Trim())); }
        private void btnGhiNhan_Click(object a, EventArgs e)
        {
            DateTime? xv = chkXuatVien.Checked ? (DateTime?)dtXuatVien.Value : null;
            if (H(s.GhiNhan(txtSoPhieu.Text.Trim(), txtChanDoan.Text.Trim(), txtDienBien.Text.Trim(), txtHieuQua.Text.Trim(), xv, txtBienLai.Text.Trim()))) tabCT.Enabled = false;
        }

        private void btnDong_Click(object a, EventArgs e) { Close(); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(820, 620);
            this.Name = "FrmPhieuKham";
            this.Text = "Lập Phiếu Khám Bệnh Án";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmPhieuKham_Load;

            txtSoPhieu = new TextBox { Location = new Point(90, 15), Size = new Size(110, 20) };
            cboHoSo = new ComboBox { Location = new Point(270, 15), Size = new Size(180, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            cboKhoa = new ComboBox { Location = new Point(510, 15), Size = new Size(140, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            cboBS = new ComboBox { Location = new Point(90, 45), Size = new Size(150, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            dtNgayGio = new DateTimePicker { Location = new Point(310, 45), Size = new Size(140, 20), CustomFormat = "dd/MM/yyyy HH:mm", Format = DateTimePickerFormat.Custom };
            cboLoai = new ComboBox { Location = new Point(510, 45), Size = new Size(90, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            cboLichHen = new ComboBox { Location = new Point(90, 75), Size = new Size(200, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            cboNguoiGhi = new ComboBox { Location = new Point(380, 75), Size = new Size(150, 21), DropDownStyle = ComboBoxStyle.DropDownList };

            btnTaoPhieu = new Button { Text = "Tạo Phiếu Khám", Location = new Point(660, 15), Size = new Size(135, 50), Font = new Font("Arial", 9, FontStyle.Bold) };
            btnTaoPhieu.Click += btnTaoPhieu_Click;

            tabCT = new TabControl { Location = new Point(15, 115), Size = new Size(780, 450) };

            // 1. Triệu chứng
            TabPage t1 = new TabPage("Triệu Chứng");
            cboTC = new ComboBox { Location = new Point(90, 15), Size = new Size(160, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            txtGiaTri = new TextBox { Location = new Point(320, 15), Size = new Size(120, 20) };
            btnThemTC = new Button { Text = "Thêm TC", Location = new Point(460, 13), Size = new Size(90, 25) };
            btnThemTC.Click += btnThemTC_Click;
            dgvTC = new DataGridView { Location = new Point(10, 50), Size = new Size(750, 360), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            t1.Controls.AddRange(new Control[] { new Label { Text = "Triệu chứng:", Location = new Point(10, 18), AutoSize = true }, cboTC, new Label { Text = "Giá trị/Mô tả:", Location = new Point(260, 18), AutoSize = true }, txtGiaTri, btnThemTC, dgvTC });

            // 2. Toa thuốc
            TabPage t2 = new TabPage("Toa Thuốc");
            txtSoToa = new TextBox { Location = new Point(80, 15), Size = new Size(100, 20) };
            dtNgayKe = new DateTimePicker { Location = new Point(250, 15), Size = new Size(110, 20), Format = DateTimePickerFormat.Short };
            txtLoiDan = new TextBox { Location = new Point(420, 15), Size = new Size(200, 20) };
            btnLapToa = new Button { Text = "Lập Toa", Location = new Point(630, 13), Size = new Size(90, 25) };
            btnLapToa.Click += btnLapToa_Click;
            cboThuoc = new ComboBox { Location = new Point(80, 55), Size = new Size(160, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            cboTCToa = new ComboBox { Location = new Point(340, 55), Size = new Size(160, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            numSoLuong = new NumericUpDown { Location = new Point(570, 55), Size = new Size(60, 20), Minimum = 1, Value = 1 };
            txtLieuDung = new TextBox { Location = new Point(80, 90), Size = new Size(160, 20) };
            txtCachDung = new TextBox { Location = new Point(340, 90), Size = new Size(160, 20) };
            txtPhanUng = new TextBox { Location = new Point(570, 90), Size = new Size(150, 20) };
            btnThemThuoc = new Button { Text = "Thêm Thuốc Về Toa", Location = new Point(80, 125), Size = new Size(150, 30) };
            btnThemThuoc.Click += btnThemThuoc_Click;
            t2.Controls.AddRange(new Control[] {
                new Label { Text = "Số toa:", Location = new Point(10, 18), AutoSize = true }, txtSoToa,
                new Label { Text = "Ngày kê:", Location = new Point(195, 18), AutoSize = true }, dtNgayKe,
                new Label { Text = "Lời dặn:", Location = new Point(370, 18), AutoSize = true }, txtLoiDan, btnLapToa,
                new Label { Text = "Chọn thuốc:", Location = new Point(10, 58), AutoSize = true }, cboThuoc,
                new Label { Text = "Điều trị TC:", Location = new Point(265, 58), AutoSize = true }, cboTCToa,
                new Label { Text = "Số lượng:", Location = new Point(510, 58), AutoSize = true }, numSoLuong,
                new Label { Text = "Liều dùng:", Location = new Point(10, 93), AutoSize = true }, txtLieuDung,
                new Label { Text = "Cách dùng:", Location = new Point(265, 93), AutoSize = true }, txtCachDung,
                new Label { Text = "Phản ứng:", Location = new Point(510, 93), AutoSize = true }, txtPhanUng, btnThemThuoc
            });

            // 3. Xét nghiệm
            TabPage t3 = new TabPage("Xét Nghiệm");
            cboXN = new ComboBox { Location = new Point(90, 15), Size = new Size(180, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            dtNgayXN = new DateTimePicker { Location = new Point(350, 15), Size = new Size(110, 20), Format = DateTimePickerFormat.Short };
            txtKetQuaXN = new TextBox { Location = new Point(90, 50), Size = new Size(370, 20) };
            btnThemXN = new Button { Text = "Thêm Xét Nghiệm", Location = new Point(480, 48), Size = new Size(130, 25) };
            btnThemXN.Click += btnThemXN_Click;
            t3.Controls.AddRange(new Control[] {
                new Label { Text = "Xét nghiệm:", Location = new Point(10, 18), AutoSize = true }, cboXN,
                new Label { Text = "Ngày thực hiện:", Location = new Point(280, 18), AutoSize = true }, dtNgayXN,
                new Label { Text = "Kết quả:", Location = new Point(10, 53), AutoSize = true }, txtKetQuaXN, btnThemXN
            });

            // 4. Ghi nhận
            TabPage t4 = new TabPage("Ghi Nhận Khám & Xuất Viện");
            txtChanDoan = new TextBox { Location = new Point(100, 15), Size = new Size(400, 20) };
            txtDienBien = new TextBox { Location = new Point(100, 50), Size = new Size(400, 20) };
            txtHieuQua = new TextBox { Location = new Point(100, 85), Size = new Size(400, 20) };
            chkXuatVien = new CheckBox { Text = "Xuất viện", Location = new Point(100, 120), AutoSize = true };
            dtXuatVien = new DateTimePicker { Location = new Point(260, 120), Size = new Size(120, 20), Format = DateTimePickerFormat.Short };
            txtBienLai = new TextBox { Location = new Point(100, 155), Size = new Size(150, 20) };
            btnGhiNhan = new Button { Text = "Ghi Nhận Phiếu Khám Vào Hồ Sơ", Location = new Point(100, 200), Size = new Size(230, 35), Font = new Font("Arial", 9, FontStyle.Bold) };
            btnGhiNhan.Click += btnGhiNhan_Click;
            t4.Controls.AddRange(new Control[] {
                new Label { Text = "Chẩn đoán:", Location = new Point(10, 18), AutoSize = true }, txtChanDoan,
                new Label { Text = "Diễn biến bệnh:", Location = new Point(10, 53), AutoSize = true }, txtDienBien,
                new Label { Text = "Hiệu quả điều trị:", Location = new Point(10, 88), AutoSize = true }, txtHieuQua,
                chkXuatVien, new Label { Text = "Ngày xuất viện:", Location = new Point(180, 122), AutoSize = true }, dtXuatVien,
                new Label { Text = "Số biên lai VP:", Location = new Point(10, 158), AutoSize = true }, txtBienLai, btnGhiNhan
            });

            tabCT.TabPages.AddRange(new TabPage[] { t1, t2, t3, t4 });
            btnDong = new Button { Text = "Đóng", Location = new Point(705, 575), Size = new Size(90, 30) };
            btnDong.Click += btnDong_Click;

            this.Controls.AddRange(new Control[] {
                new Label { Text = "Số phiếu khám:", Location = new Point(10, 18), AutoSize = true }, txtSoPhieu,
                new Label { Text = "Hồ sơ:", Location = new Point(220, 18), AutoSize = true }, cboHoSo,
                new Label { Text = "Khoa:", Location = new Point(470, 18), AutoSize = true }, cboKhoa,
                new Label { Text = "Bác sĩ:", Location = new Point(10, 48), AutoSize = true }, cboBS,
                new Label { Text = "Ngày giờ:", Location = new Point(250, 48), AutoSize = true }, dtNgayGio,
                new Label { Text = "Loại khám:", Location = new Point(450, 48), AutoSize = true }, cboLoai,
                new Label { Text = "Lịch hẹn:", Location = new Point(10, 78), AutoSize = true }, cboLichHen,
                new Label { Text = "Người ghi:", Location = new Point(310, 78), AutoSize = true }, cboNguoiGhi,
                btnTaoPhieu, tabCT, btnDong
            });
            this.ResumeLayout(false);
        }
    }
}