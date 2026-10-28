using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyBenhAn.Services;
using static QuanLyBenhAn.Forms.FormHelper;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmDanhMuc : Form
    {
        readonly DanhMucService s = new DanhMucService();

        private TabControl tabControl;
        private Button btnDong;

        private DataGridView dgvKhoa, dgvBS, dgvNV, dgvTC, dgvThuoc, dgvXN;
        private TextBox txtKhoaMa, txtKhoaTen;
        private TextBox txtBSMa, txtBSTen, txtBSChuyenMon, txtBSDT;
        private TextBox txtNVMa, txtNVTen, txtNVChucDanh, txtNVDT;
        private TextBox txtTCMa, txtTCTen, txtTCDonVi;
        private TextBox txtThuocMa, txtThuocTen, txtThuocDVT;
        private TextBox txtXNMa, txtXNTen, txtXNMoTa;
        private ComboBox cboBSKhoa;
        private Button btnThemKhoa, btnThemBS, btnThemNV, btnThemTC, btnThemThuoc, btnThemXN;

        public FrmDanhMuc() { InitializeComponent(); }

        private void FrmDanhMuc_Load(object a, EventArgs e) { Tai(); }

        void Tai()
        {
            dgvKhoa.DataSource = s.LayKhoa();
            dgvBS.DataSource = s.LayBacSi();
            dgvNV.DataSource = s.LayNhanVien();
            dgvTC.DataSource = s.LayTrieuChung();
            dgvThuoc.DataSource = s.LayThuoc();
            dgvXN.DataSource = s.LayXetNghiem();
            Bind(cboBSKhoa, s.LayKhoa(), "TenKhoa", "MaKhoa");
        }

        private void btnThemKhoa_Click(object a, EventArgs e) { if (H(s.ThemKhoa(txtKhoaMa.Text.Trim(), txtKhoaTen.Text.Trim()))) Tai(); }
        private void btnThemBS_Click(object a, EventArgs e) { if (H(s.ThemBacSi(txtBSMa.Text.Trim(), txtBSTen.Text.Trim(), txtBSChuyenMon.Text.Trim(), txtBSDT.Text.Trim(), V(cboBSKhoa)))) Tai(); }
        private void btnThemNV_Click(object a, EventArgs e) { if (H(s.ThemNhanVien(txtNVMa.Text.Trim(), txtNVTen.Text.Trim(), txtNVChucDanh.Text.Trim(), txtNVDT.Text.Trim()))) Tai(); }
        private void btnThemTC_Click(object a, EventArgs e) { if (H(s.ThemTrieuChung(txtTCMa.Text.Trim(), txtTCTen.Text.Trim(), txtTCDonVi.Text.Trim()))) Tai(); }
        private void btnThemThuoc_Click(object a, EventArgs e) { if (H(s.ThemThuoc(txtThuocMa.Text.Trim(), txtThuocTen.Text.Trim(), txtThuocDVT.Text.Trim()))) Tai(); }
        private void btnThemXN_Click(object a, EventArgs e) { if (H(s.ThemXetNghiem(txtXNMa.Text.Trim(), txtXNTen.Text.Trim(), txtXNMoTa.Text.Trim()))) Tai(); }
        private void btnDong_Click(object a, EventArgs e) { Close(); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(700, 500);
            this.Name = "FrmDanhMuc";
            this.Text = "Quản Lý Danh Mục";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmDanhMuc_Load;

            btnDong = new Button { Text = "Đóng", Location = new Point(590, 460), Size = new Size(90, 30) };
            btnDong.Click += btnDong_Click;
            tabControl = new TabControl { Location = new Point(10, 10), Size = new Size(670, 440) };

            // Tab Khoa
            TabPage tabKhoa = new TabPage("Khoa");
            txtKhoaMa = new TextBox { Location = new Point(80, 15), Size = new Size(120, 20) };
            txtKhoaTen = new TextBox { Location = new Point(280, 15), Size = new Size(180, 20) };
            btnThemKhoa = new Button { Text = "Thêm Khoa", Location = new Point(480, 13), Size = new Size(90, 25) };
            btnThemKhoa.Click += btnThemKhoa_Click;
            dgvKhoa = new DataGridView { Location = new Point(10, 50), Size = new Size(640, 340), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabKhoa.Controls.AddRange(new Control[] { new Label { Text = "Mã khoa:", Location = new Point(10, 18), AutoSize = true }, txtKhoaMa, new Label { Text = "Tên khoa:", Location = new Point(210, 18), AutoSize = true }, txtKhoaTen, btnThemKhoa, dgvKhoa });

            // Tab Bác sĩ
            TabPage tabBS = new TabPage("Bác Sĩ");
            txtBSMa = new TextBox { Location = new Point(60, 10), Size = new Size(80, 20) };
            txtBSTen = new TextBox { Location = new Point(190, 10), Size = new Size(120, 20) };
            txtBSChuyenMon = new TextBox { Location = new Point(390, 10), Size = new Size(100, 20) };
            txtBSDT = new TextBox { Location = new Point(530, 10), Size = new Size(100, 20) };
            cboBSKhoa = new ComboBox { Location = new Point(60, 40), Size = new Size(150, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            btnThemBS = new Button { Text = "Thêm BS", Location = new Point(230, 38), Size = new Size(100, 25) };
            btnThemBS.Click += btnThemBS_Click;
            dgvBS = new DataGridView { Location = new Point(10, 75), Size = new Size(640, 315), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabBS.Controls.AddRange(new Control[] { new Label { Text = "Mã BS:", Location = new Point(10, 13), AutoSize = true }, txtBSMa, new Label { Text = "Tên BS:", Location = new Point(145, 13), AutoSize = true }, txtBSTen, new Label { Text = "Chuyên môn:", Location = new Point(315, 13), AutoSize = true }, txtBSChuyenMon, new Label { Text = "SĐT:", Location = new Point(495, 13), AutoSize = true }, txtBSDT, new Label { Text = "Khoa:", Location = new Point(10, 43), AutoSize = true }, cboBSKhoa, btnThemBS, dgvBS });

            // Tab Nhân viên
            TabPage tabNV = new TabPage("Nhân Viên");
            txtNVMa = new TextBox { Location = new Point(60, 15), Size = new Size(80, 20) };
            txtNVTen = new TextBox { Location = new Point(190, 15), Size = new Size(120, 20) };
            txtNVChucDanh = new TextBox { Location = new Point(380, 15), Size = new Size(100, 20) };
            txtNVDT = new TextBox { Location = new Point(530, 15), Size = new Size(100, 20) };
            btnThemNV = new Button { Text = "Thêm NV", Location = new Point(530, 40), Size = new Size(100, 25) };
            btnThemNV.Click += btnThemNV_Click;
            dgvNV = new DataGridView { Location = new Point(10, 75), Size = new Size(640, 315), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabNV.Controls.AddRange(new Control[] { new Label { Text = "Mã NV:", Location = new Point(10, 18), AutoSize = true }, txtNVMa, new Label { Text = "Tên NV:", Location = new Point(145, 18), AutoSize = true }, txtNVTen, new Label { Text = "Chức danh:", Location = new Point(315, 18), AutoSize = true }, txtNVChucDanh, new Label { Text = "SĐT:", Location = new Point(490, 18), AutoSize = true }, txtNVDT, btnThemNV, dgvNV });

            // Tab Triệu chứng
            TabPage tabTC = new TabPage("Triệu Chứng");
            txtTCMa = new TextBox { Location = new Point(60, 15), Size = new Size(80, 20) };
            txtTCTen = new TextBox { Location = new Point(200, 15), Size = new Size(150, 20) };
            txtTCDonVi = new TextBox { Location = new Point(410, 15), Size = new Size(100, 20) };
            btnThemTC = new Button { Text = "Thêm TC", Location = new Point(520, 13), Size = new Size(90, 25) };
            btnThemTC.Click += btnThemTC_Click;
            dgvTC = new DataGridView { Location = new Point(10, 50), Size = new Size(640, 340), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabTC.Controls.AddRange(new Control[] { new Label { Text = "Mã TC:", Location = new Point(10, 18), AutoSize = true }, txtTCMa, new Label { Text = "Tên TC:", Location = new Point(150, 18), AutoSize = true }, txtTCTen, new Label { Text = "Đơn vị:", Location = new Point(360, 18), AutoSize = true }, txtTCDonVi, btnThemTC, dgvTC });

            // Tab Thuốc
            TabPage tabThuoc = new TabPage("Thuốc");
            txtThuocMa = new TextBox { Location = new Point(70, 15), Size = new Size(80, 20) };
            txtThuocTen = new TextBox { Location = new Point(210, 15), Size = new Size(150, 20) };
            txtThuocDVT = new TextBox { Location = new Point(410, 15), Size = new Size(80, 20) };
            btnThemThuoc = new Button { Text = "Thêm Thuốc", Location = new Point(510, 13), Size = new Size(100, 25) };
            btnThemThuoc.Click += btnThemThuoc_Click;
            dgvThuoc = new DataGridView { Location = new Point(10, 50), Size = new Size(640, 340), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabThuoc.Controls.AddRange(new Control[] { new Label { Text = "Mã Thuốc:", Location = new Point(10, 18), AutoSize = true }, txtThuocMa, new Label { Text = "Tên Thuốc:", Location = new Point(155, 18), AutoSize = true }, txtThuocTen, new Label { Text = "ĐVT:", Location = new Point(370, 18), AutoSize = true }, txtThuocDVT, btnThemThuoc, dgvThuoc });

            // Tab Xét nghiệm
            TabPage tabXN = new TabPage("Xét Nghiệm");
            txtXNMa = new TextBox { Location = new Point(60, 15), Size = new Size(80, 20) };
            txtXNTen = new TextBox { Location = new Point(200, 15), Size = new Size(150, 20) };
            txtXNMoTa = new TextBox { Location = new Point(410, 15), Size = new Size(120, 20) };
            btnThemXN = new Button { Text = "Thêm XN", Location = new Point(540, 13), Size = new Size(90, 25) };
            btnThemXN.Click += btnThemXN_Click;
            dgvXN = new DataGridView { Location = new Point(10, 50), Size = new Size(640, 340), AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };
            tabXN.Controls.AddRange(new Control[] { new Label { Text = "Mã XN:", Location = new Point(10, 18), AutoSize = true }, txtXNMa, new Label { Text = "Tên XN:", Location = new Point(150, 18), AutoSize = true }, txtXNTen, new Label { Text = "Mô tả:", Location = new Point(360, 18), AutoSize = true }, txtXNMoTa, btnThemXN, dgvXN });

            tabControl.TabPages.AddRange(new TabPage[] { tabKhoa, tabBS, tabNV, tabTC, tabThuoc, tabXN });
            this.Controls.AddRange(new Control[] { tabControl, btnDong });
            this.ResumeLayout(false);
        }
    }
}