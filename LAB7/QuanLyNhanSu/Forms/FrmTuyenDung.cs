using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhanSu.Services;
using static QuanLyNhanSu.Forms.FormHelper;

namespace QuanLyNhanSu.Forms
{
    public partial class FrmTuyenDung : Form
    {
        readonly TuyenDungService s = new TuyenDungService();
        readonly DanhMucService dm = new DanhMucService();

        private TabControl tabControl;
        private TextBox txtSoQD, txtDieuKhoan, txtSoHD, txtMaHS, txtBHXH, txtBHYT;
        private ComboBox cboNVTD, cboPBTD, cboNguoiKy, cboNVHD, cboLoaiHD, cboHDBH;
        private NumericUpDown numThang, numLuong, numMucXH, numMucYT;
        private DateTimePicker dtBatDau, dtHDBatDau, dtHDKetThuc, dtThamGia;
        private DataGridView dgvQD, dgvHD;
        private Button btnLapQD, btnKyQD, btnTuChoiQD, btnKyHD, btnKhongDat, btnLapBH, btnDong;

        public FrmTuyenDung() { InitializeComponent(); }

        private void FrmTuyenDung_Load(object a, EventArgs e)
        {
            cboLoaiHD.Items.AddRange(new object[] { "Dài hạn", "Ngắn hạn" }); cboLoaiHD.SelectedIndex = 0;
            Bind(cboPBTD, dm.LayPhongBan(), "TenPB", "MaPB"); Bind(cboNguoiKy, dm.LayNhanVienDangLam(), "Ten", "MaNV");
            dtHDKetThuc.ShowCheckBox = true; dtHDKetThuc.Checked = false; Tai();
        }

        void Tai()
        {
            Bind(cboNVTD, dm.LayNhanVienTheoTrangThai("Thử việc"), "Ten", "MaNV"); Bind(cboNVHD, dm.LayNhanVienTheoTrangThai("Thử việc"), "Ten", "MaNV");
            Bind(cboHDBH, s.LayHopDongDaiHan(), "Ten", "SoHD"); dgvQD.DataSource = s.LayQDTuyenDung(); dgvHD.DataSource = s.LayHopDong();
        }

        private void btnLapQD_Click(object a, EventArgs e)
        {
            if (H(s.LapQDTuyenDung(txtSoQD.Text.Trim(), V(cboNVTD), V(cboPBTD), (int)numThang.Value, dtBatDau.Value, numLuong.Value, txtDieuKhoan.Text.Trim(), V(cboNguoiKy)))) Tai();
        }

        private string QDChon() { return dgvQD.CurrentRow == null ? "" : dgvQD.CurrentRow.Cells["SoQD"].Value.ToString(); }
        private void btnKyQD_Click(object a, EventArgs e) { if (H(s.KyDuyetQD(QDChon(), true))) Tai(); }
        private void btnTuChoiQD_Click(object a, EventArgs e) { if (H(s.KyDuyetQD(QDChon(), false))) Tai(); }
        private void btnKyHD_Click(object a, EventArgs e)
        {
            DateTime? kt = dtHDKetThuc.Checked ? (DateTime?)dtHDKetThuc.Value : null;
            if (H(s.KyHopDong(txtSoHD.Text.Trim(), V(cboNVHD), cboLoaiHD.Text, dtHDBatDau.Value, kt))) Tai();
        }
        private void btnKhongDat_Click(object a, EventArgs e) { if (H(s.DanhGiaThuViec(V(cboNVHD), false))) Tai(); }
        private void btnLapBH_Click(object a, EventArgs e)
        {
            if (H(s.LapHoSoBaoHiem(txtMaHS.Text.Trim(), V(cboHDBH), txtBHXH.Text.Trim(), txtBHYT.Text.Trim(), dtThamGia.Value, numMucXH.Value, numMucYT.Value))) Tai();
        }
        private void btnDong_Click(object a, EventArgs e) { Close(); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(800, 520);
            this.Name = "FrmTuyenDung";
            this.Text = "Tuyển Dụng, Hợp Đồng & Bảo Hiểm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmTuyenDung_Load;

            tabControl = new TabControl { Location = new Point(10, 10), Size = new Size(780, 450) };

            // Tab Quyết Định Tuyển Dụng
            TabPage tabQD = new TabPage("Quyết Định Tuyển Dụng");
            txtSoQD = new TextBox { Location = new Point(80, 12), Size = new Size(100, 20) };
            cboNVTD = new ComboBox { Location = new Point(250, 12), Size = new Size(150, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            cboPBTD = new ComboBox { Location = new Point(470, 12), Size = new Size(140, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            numThang = new NumericUpDown { Location = new Point(80, 42), Size = new Size(60, 20), Minimum = 1, Value = 2 };
            dtBatDau = new DateTimePicker { Location = new Point(230, 42), Size = new Size(110, 20), Format = DateTimePickerFormat.Short };
            numLuong = new NumericUpDown { Location = new Point(430, 42), Size = new Size(120, 20), Maximum = 100000000, Value = 5000000 };
            txtDieuKhoan = new TextBox { Location = new Point(80, 72), Size = new Size(330, 20) };
            cboNguoiKy = new ComboBox { Location = new Point(480, 72), Size = new Size(130, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            btnLapQD = new Button { Text = "Lập QĐ", Location = new Point(620, 10), Size = new Size(130, 38) };
            btnLapQD.Click += btnLapQD_Click;
            btnKyQD = new Button { Text = "Ký Duyệt", Location = new Point(620, 52), Size = new Size(60, 38) };
            btnKyQD.Click += btnKyQD_Click;
            btnTuChoiQD = new Button { Text = "Từ Chối", Location = new Point(690, 52), Size = new Size(60, 38) };
            btnTuChoiQD.Click += btnTuChoiQD_Click;

            dgvQD = new DataGridView { Location = new Point(10, 105), Size = new Size(750, 300), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabQD.Controls.AddRange(new Control[] {
                new Label { Text = "Số QĐ:", Location = new Point(10, 15), AutoSize = true }, txtSoQD,
                new Label { Text = "Thử việc:", Location = new Point(190, 15), AutoSize = true }, cboNVTD,
                new Label { Text = "Phòng ban:", Location = new Point(410, 15), AutoSize = true }, cboPBTD,
                new Label { Text = "Tháng TV:", Location = new Point(10, 45), AutoSize = true }, numThang,
                new Label { Text = "Ngày BĐ:", Location = new Point(170, 45), AutoSize = true }, dtBatDau,
                new Label { Text = "Lương TV:", Location = new Point(360, 45), AutoSize = true }, numLuong,
                new Label { Text = "Điều khoản:", Location = new Point(10, 75), AutoSize = true }, txtDieuKhoan,
                new Label { Text = "Người ký:", Location = new Point(420, 75), AutoSize = true }, cboNguoiKy,
                btnLapQD, btnKyQD, btnTuChoiQD, dgvQD
            });

            // Tab Hợp Đồng
            TabPage tabHD = new TabPage("Hợp Đồng Lao Động");
            txtSoHD = new TextBox { Location = new Point(80, 15), Size = new Size(100, 20) };
            cboNVHD = new ComboBox { Location = new Point(250, 15), Size = new Size(150, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            cboLoaiHD = new ComboBox { Location = new Point(470, 15), Size = new Size(100, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            dtHDBatDau = new DateTimePicker { Location = new Point(80, 50), Size = new Size(110, 20), Format = DateTimePickerFormat.Short };
            dtHDKetThuc = new DateTimePicker { Location = new Point(270, 50), Size = new Size(130, 20), Format = DateTimePickerFormat.Short };
            btnKyHD = new Button { Text = "Ký Hợp Đồng", Location = new Point(420, 47), Size = new Size(110, 28) };
            btnKyHD.Click += btnKyHD_Click;
            btnKhongDat = new Button { Text = "Đánh Giá Không Đạt", Location = new Point(540, 47), Size = new Size(140, 28) };
            btnKhongDat.Click += btnKhongDat_Click;

            dgvHD = new DataGridView { Location = new Point(10, 85), Size = new Size(750, 320), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabHD.Controls.AddRange(new Control[] {
                new Label { Text = "Số HĐ:", Location = new Point(10, 18), AutoSize = true }, txtSoHD,
                new Label { Text = "Nhân viên:", Location = new Point(190, 18), AutoSize = true }, cboNVHD,
                new Label { Text = "Loại HĐ:", Location = new Point(410, 18), AutoSize = true }, cboLoaiHD,
                new Label { Text = "Ngày BĐ:", Location = new Point(10, 53), AutoSize = true }, dtHDBatDau,
                new Label { Text = "Ngày KT:", Location = new Point(200, 53), AutoSize = true }, dtHDKetThuc,
                btnKyHD, btnKhongDat, dgvHD
            });

            // Tab Bảo Hiểm
            TabPage tabBH = new TabPage("Hồ Sơ BHYT - BHXH");
            txtMaHS = new TextBox { Location = new Point(120, 20), Size = new Size(120, 20) };
            cboHDBH = new ComboBox { Location = new Point(120, 55), Size = new Size(250, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            txtBHXH = new TextBox { Location = new Point(120, 90), Size = new Size(180, 20) };
            txtBHYT = new TextBox { Location = new Point(120, 125), Size = new Size(180, 20) };
            dtThamGia = new DateTimePicker { Location = new Point(120, 160), Size = new Size(120, 20), Format = DateTimePickerFormat.Short };
            numMucXH = new NumericUpDown { Location = new Point(120, 195), Size = new Size(80, 20), DecimalPlaces = 3, Increment = 0.005m, Value = 0.08m };
            numMucYT = new NumericUpDown { Location = new Point(120, 230), Size = new Size(80, 20), DecimalPlaces = 3, Increment = 0.005m, Value = 0.015m };
            btnLapBH = new Button { Text = "Lập Hồ Sơ Bảo Hiểm", Location = new Point(120, 270), Size = new Size(180, 35) };
            btnLapBH.Click += btnLapBH_Click;

            tabBH.Controls.AddRange(new Control[] {
                new Label { Text = "Mã hồ sơ BH:", Location = new Point(20, 23), AutoSize = true }, txtMaHS,
                new Label { Text = "Hợp đồng dài hạn:", Location = new Point(20, 58), AutoSize = true }, cboHDBH,
                new Label { Text = "Số sổ BHXH:", Location = new Point(20, 93), AutoSize = true }, txtBHXH,
                new Label { Text = "Số thẻ BHYT:", Location = new Point(20, 128), AutoSize = true }, txtBHYT,
                new Label { Text = "Ngày tham gia:", Location = new Point(20, 163), AutoSize = true }, dtThamGia,
                new Label { Text = "Mức đóng BHXH:", Location = new Point(20, 198), AutoSize = true }, numMucXH,
                new Label { Text = "Mức đóng BHYT:", Location = new Point(20, 233), AutoSize = true }, numMucYT, btnLapBH
            });

            tabControl.TabPages.AddRange(new TabPage[] { tabQD, tabHD, tabBH });
            btnDong = new Button { Text = "Đóng", Location = new Point(700, 475), Size = new Size(90, 30) };
            btnDong.Click += btnDong_Click;

            this.Controls.AddRange(new Control[] { tabControl, btnDong });
            this.ResumeLayout(false);
        }
    }
}