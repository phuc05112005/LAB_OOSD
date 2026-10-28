using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBenhAn.Services;
using static QuanLyBenhAn.Forms.FormHelper;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmLichHen : Form
    {
        readonly LichHenService s = new LichHenService();
        readonly DangKyService dk = new DangKyService();
        readonly DanhMucService dm = new DanhMucService();

        private TextBox txtSoLich, txtGhiChu;
        private ComboBox cboHoSo, cboBS, cboNguoiLap;
        private DateTimePicker dtNgay, dtGio;
        private Label lblQuyenLoi;
        private DataGridView dgvLich;
        private Button btnDatLich, btnHuy, btnDong;

        public FrmLichHen() { InitializeComponent(); }

        private void FrmLichHen_Load(object a, EventArgs e)
        {
            Bind(cboBS, dm.LayBacSi(), "HoTen", "MaBS");
            Bind(cboNguoiLap, dm.LayNhanVien(), "HoTen", "MaNV");
            Bind(cboHoSo, dk.LayHoSo(), "Ten", "MaHoSo");

            dtGio.Format = DateTimePickerFormat.Time; dtGio.ShowUpDown = true;
            cboHoSo.SelectedIndexChanged += CapNhatQuyenLoi;
            dtNgay.ValueChanged += CapNhatQuyenLoi;

            Tai();
            CapNhatQuyenLoi(null, null);
        }

        void Tai() { dgvLich.DataSource = s.LayLichHen(); }

        private void CapNhatQuyenLoi(object a, EventArgs e)
        {
            if (cboHoSo.SelectedValue == null) return;
            int q = LichHenService.QuyCuaNgay(dtNgay.Value), n = dtNgay.Value.Year;
            lblQuyenLoi.Text = "Quyền lợi quý " + q + "/" + n + ": " + (s.DaDungQuyenLoi(V(cboHoSo), q, n) ? "Đã sử dụng" : "Chưa sử dụng (Miễn phí)");
        }

        private void btnDatLich_Click(object a, EventArgs e)
        {
            var ngayGio = dtNgay.Value.Date + dtGio.Value.TimeOfDay;
            if (H(s.DatLich(txtSoLich.Text.Trim(), V(cboHoSo), V(cboBS), ngayGio, txtGhiChu.Text.Trim(), V(cboNguoiLap)))) { Tai(); CapNhatQuyenLoi(null, null); }
        }

        private void btnHuy_Click(object a, EventArgs e)
        {
            if (dgvLich.CurrentRow != null && H(s.HuyLich(dgvLich.CurrentRow.Cells["SoLichHen"].Value.ToString()))) { Tai(); CapNhatQuyenLoi(null, null); }
        }

        private void btnDong_Click(object a, EventArgs e) { Close(); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(750, 520);
            this.Name = "FrmLichHen";
            this.Text = "Đặt Lịch Hẹn Khám Định Kỳ";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmLichHen_Load;

            txtSoLich = new TextBox { Location = new Point(100, 15), Size = new Size(120, 20) };
            cboHoSo = new ComboBox { Location = new Point(310, 15), Size = new Size(200, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            cboBS = new ComboBox { Location = new Point(100, 45), Size = new Size(180, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            dtNgay = new DateTimePicker { Location = new Point(350, 45), Size = new Size(110, 20), Format = DateTimePickerFormat.Short };
            dtGio = new DateTimePicker { Location = new Point(510, 45), Size = new Size(80, 20) };
            cboNguoiLap = new ComboBox { Location = new Point(100, 75), Size = new Size(180, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            txtGhiChu = new TextBox { Location = new Point(350, 75), Size = new Size(240, 20) };
            lblQuyenLoi = new Label { Location = new Point(100, 108), AutoSize = true, Font = new Font("Arial", 9, FontStyle.Bold), ForeColor = Color.Blue };

            btnDatLich = new Button { Text = "Đặt Lịch Hẹn", Location = new Point(610, 15), Size = new Size(120, 35) };
            btnDatLich.Click += btnDatLich_Click;

            btnHuy = new Button { Text = "Hủy Lịch Chọn", Location = new Point(610, 60), Size = new Size(120, 35) };
            btnHuy.Click += btnHuy_Click;

            dgvLich = new DataGridView { Location = new Point(15, 140), Size = new Size(715, 330), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            btnDong = new Button { Text = "Đóng", Location = new Point(640, 480), Size = new Size(90, 30) };
            btnDong.Click += btnDong_Click;

            this.Controls.AddRange(new Control[] {
                new Label { Text = "Số lịch hẹn:", Location = new Point(15, 18), AutoSize = true }, txtSoLich,
                new Label { Text = "Hồ sơ:", Location = new Point(250, 18), AutoSize = true }, cboHoSo,
                new Label { Text = "Bác sĩ:", Location = new Point(15, 48), AutoSize = true }, cboBS,
                new Label { Text = "Ngày:", Location = new Point(300, 48), AutoSize = true }, dtNgay,
                new Label { Text = "Giờ:", Location = new Point(475, 48), AutoSize = true }, dtGio,
                new Label { Text = "Người lập:", Location = new Point(15, 78), AutoSize = true }, cboNguoiLap,
                new Label { Text = "Ghi chú:", Location = new Point(300, 78), AutoSize = true }, txtGhiChu,
                lblQuyenLoi, btnDatLich, btnHuy, dgvLich, btnDong
            });
            this.ResumeLayout(false);
        }
    }
}