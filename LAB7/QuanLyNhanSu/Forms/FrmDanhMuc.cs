using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhanSu.Services;
using static QuanLyNhanSu.Forms.FormHelper;

namespace QuanLyNhanSu.Forms
{
    public partial class FrmDanhMuc : Form
    {
        readonly DanhMucService s = new DanhMucService();

        private TabControl tabControl;
        private DataGridView dgvPB, dgvCV, dgvCa, dgvNV;
        private TextBox txtPBMa, txtPBTen, txtPBMoTa, txtCVMa, txtCVTen, txtCVMoTa, txtCaMa, txtCaTen, txtNVMa, txtNVTen, txtNVCCCD, txtNVDiaChi, txtNVSDT;
        private DateTimePicker dtCaBD, dtCaKT, dtNVNgaySinh;
        private ComboBox cboPBLoai, cboNVGioiTinh, cboNVPB;
        private Button btnThemPB, btnThemCV, btnThemCa, btnThemNV, btnDong;

        public FrmDanhMuc() { InitializeComponent(); }

        private void FrmDanhMuc_Load(object a, EventArgs e)
        {
            cboPBLoai.Items.AddRange(new object[] { "Phòng", "Ban", "Phân xưởng" }); cboPBLoai.SelectedIndex = 0;
            cboNVGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" }); cboNVGioiTinh.SelectedIndex = 0;
            Tai();
        }

        void Tai()
        {
            dgvPB.DataSource = s.LayPhongBan(); dgvCV.DataSource = s.LayChucVu(); dgvCa.DataSource = s.LayCaLamViec(); dgvNV.DataSource = s.LayNhanVien();
            Bind(cboNVPB, s.LayPhongBan(), "TenPB", "MaPB");
        }

        private void btnThemPB_Click(object a, EventArgs e) { if (H(s.ThemPhongBan(txtPBMa.Text.Trim(), txtPBTen.Text.Trim(), cboPBLoai.Text, txtPBMoTa.Text.Trim()))) Tai(); }
        private void btnThemCV_Click(object a, EventArgs e) { if (H(s.ThemChucVu(txtCVMa.Text.Trim(), txtCVTen.Text.Trim(), txtCVMoTa.Text.Trim()))) Tai(); }
        private void btnThemCa_Click(object a, EventArgs e) { if (H(s.ThemCa(txtCaMa.Text.Trim(), txtCaTen.Text.Trim(), dtCaBD.Value.TimeOfDay, dtCaKT.Value.TimeOfDay))) Tai(); }
        private void btnThemNV_Click(object a, EventArgs e)
        {
            if (H(s.ThemNhanVien(txtNVMa.Text.Trim(), txtNVTen.Text.Trim(), dtNVNgaySinh.Value, cboNVGioiTinh.Text, txtNVCCCD.Text.Trim(), txtNVDiaChi.Text.Trim(), txtNVSDT.Text.Trim(), V(cboNVPB)))) Tai();
        }
        private void btnDong_Click(object a, EventArgs e) { Close(); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(800, 520);
            this.Name = "FrmDanhMuc";
            this.Text = "Quản Lý Danh Mục & Hồ Sơ Nhân Viên";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmDanhMuc_Load;

            tabControl = new TabControl { Location = new Point(10, 10), Size = new Size(780, 450) };

            // Tab Phòng Ban
            TabPage tabPB = new TabPage("Phòng Ban");
            txtPBMa = new TextBox { Location = new Point(80, 15), Size = new Size(100, 20) };
            txtPBTen = new TextBox { Location = new Point(250, 15), Size = new Size(150, 20) };
            cboPBLoai = new ComboBox { Location = new Point(460, 15), Size = new Size(100, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            txtPBMoTa = new TextBox { Location = new Point(80, 45), Size = new Size(480, 20) };
            btnThemPB = new Button { Text = "Thêm PB", Location = new Point(580, 13), Size = new Size(90, 52) };
            btnThemPB.Click += btnThemPB_Click;
            dgvPB = new DataGridView { Location = new Point(10, 80), Size = new Size(750, 330), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabPB.Controls.AddRange(new Control[] {
                new Label { Text = "Mã PB:", Location = new Point(10, 18), AutoSize = true }, txtPBMa,
                new Label { Text = "Tên PB:", Location = new Point(190, 18), AutoSize = true }, txtPBTen,
                new Label { Text = "Loại:", Location = new Point(410, 18), AutoSize = true }, cboPBLoai,
                new Label { Text = "Mô tả:", Location = new Point(10, 48), AutoSize = true }, txtPBMoTa, btnThemPB, dgvPB
            });

            // Tab Chức Vụ
            TabPage tabCV = new TabPage("Chức Vụ");
            txtCVMa = new TextBox { Location = new Point(80, 15), Size = new Size(100, 20) };
            txtCVTen = new TextBox { Location = new Point(250, 15), Size = new Size(150, 20) };
            txtCVMoTa = new TextBox { Location = new Point(470, 15), Size = new Size(180, 20) };
            btnThemCV = new Button { Text = "Thêm CV", Location = new Point(660, 13), Size = new Size(90, 25) };
            btnThemCV.Click += btnThemCV_Click;
            dgvCV = new DataGridView { Location = new Point(10, 50), Size = new Size(750, 360), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabCV.Controls.AddRange(new Control[] {
                new Label { Text = "Mã CV:", Location = new Point(10, 18), AutoSize = true }, txtCVMa,
                new Label { Text = "Tên CV:", Location = new Point(190, 18), AutoSize = true }, txtCVTen,
                new Label { Text = "Mô tả:", Location = new Point(410, 18), AutoSize = true }, txtCVMoTa, btnThemCV, dgvCV
            });

            // Tab Ca Làm Việc
            TabPage tabCa = new TabPage("Ca Làm Việc");
            txtCaMa = new TextBox { Location = new Point(70, 15), Size = new Size(80, 20) };
            txtCaTen = new TextBox { Location = new Point(210, 15), Size = new Size(120, 20) };
            dtCaBD = new DateTimePicker { Location = new Point(400, 15), Size = new Size(80, 20), Format = DateTimePickerFormat.Time, ShowUpDown = true };
            dtCaKT = new DateTimePicker { Location = new Point(560, 15), Size = new Size(80, 20), Format = DateTimePickerFormat.Time, ShowUpDown = true };
            btnThemCa = new Button { Text = "Thêm Ca", Location = new Point(660, 13), Size = new Size(90, 25) };
            btnThemCa.Click += btnThemCa_Click;
            dgvCa = new DataGridView { Location = new Point(10, 50), Size = new Size(750, 360), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabCa.Controls.AddRange(new Control[] {
                new Label { Text = "Mã Ca:", Location = new Point(10, 18), AutoSize = true }, txtCaMa,
                new Label { Text = "Tên Ca:", Location = new Point(160, 18), AutoSize = true }, txtCaTen,
                new Label { Text = "Bắt đầu:", Location = new Point(340, 18), AutoSize = true }, dtCaBD,
                new Label { Text = "Kết thúc:", Location = new Point(500, 18), AutoSize = true }, dtCaKT, btnThemCa, dgvCa
            });

            // Tab Nhân Viên
            TabPage tabNV = new TabPage("Hồ Sơ Nhân Viên");
            txtNVMa = new TextBox { Location = new Point(60, 12), Size = new Size(80, 20) };
            txtNVTen = new TextBox { Location = new Point(190, 12), Size = new Size(140, 20) };
            dtNVNgaySinh = new DateTimePicker { Location = new Point(410, 12), Size = new Size(110, 20), Format = DateTimePickerFormat.Short };
            cboNVGioiTinh = new ComboBox { Location = new Point(590, 12), Size = new Size(70, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            txtNVCCCD = new TextBox { Location = new Point(60, 42), Size = new Size(120, 20) };
            txtNVSDT = new TextBox { Location = new Point(230, 42), Size = new Size(100, 20) };
            cboNVPB = new ComboBox { Location = new Point(410, 42), Size = new Size(140, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            txtNVDiaChi = new TextBox { Location = new Point(60, 72), Size = new Size(490, 20) };
            btnThemNV = new Button { Text = "Lập Hồ Sơ", Location = new Point(580, 40), Size = new Size(90, 52) };
            btnThemNV.Click += btnThemNV_Click;
            dgvNV = new DataGridView { Location = new Point(10, 105), Size = new Size(750, 300), ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabNV.Controls.AddRange(new Control[] {
                new Label { Text = "Mã NV:", Location = new Point(10, 15), AutoSize = true }, txtNVMa,
                new Label { Text = "Họ tên:", Location = new Point(145, 15), AutoSize = true }, txtNVTen,
                new Label { Text = "Ngày sinh:", Location = new Point(340, 15), AutoSize = true }, dtNVNgaySinh,
                new Label { Text = "Phái:", Location = new Point(550, 15), AutoSize = true }, cboNVGioiTinh,
                new Label { Text = "CCCD:", Location = new Point(10, 45), AutoSize = true }, txtNVCCCD,
                new Label { Text = "SĐT:", Location = new Point(190, 45), AutoSize = true }, txtNVSDT,
                new Label { Text = "Phòng ban:", Location = new Point(340, 45), AutoSize = true }, cboNVPB,
                new Label { Text = "Địa chỉ:", Location = new Point(10, 75), AutoSize = true }, txtNVDiaChi, btnThemNV, dgvNV
            });

            tabControl.TabPages.AddRange(new TabPage[] { tabPB, tabCV, tabCa, tabNV });
            btnDong = new Button { Text = "Đóng", Location = new Point(700, 475), Size = new Size(90, 30) };
            btnDong.Click += btnDong_Click;

            this.Controls.AddRange(new Control[] { tabControl, btnDong });
            this.ResumeLayout(false);
        }
    }
}