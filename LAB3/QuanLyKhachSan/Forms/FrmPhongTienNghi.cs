using System;
using System.Windows.Forms;
using QuanLyKhachSan.Services;

namespace QuanLyKhachSan.Forms
{
    public partial class FrmPhongTienNghi : Form
    {
        private readonly PhongTienNghiService service =
            new PhongTienNghiService();

        private readonly DanhMucService danhMucService =
            new DanhMucService();

        public FrmPhongTienNghi()
        {
            InitializeComponent();
        }

        // =========================
        // FORM LOAD
        // =========================
        private void FrmPhongTienNghi_Load(object sender, EventArgs e)
        {
            // Khu vực cho phòng
            cboKhu.DataSource =
                danhMucService.LayKhuVuc();

            cboKhu.DisplayMember =
                "TenKhuVuc";

            cboKhu.ValueMember =
                "MaKhuVuc";


            // Loại tiện nghi
            cboLoai.DataSource =
                danhMucService.LayLoaiTienNghi();

            cboLoai.DisplayMember =
                "TenLoaiTN";

            cboLoai.ValueMember =
                "MaLoaiTN";


            // Tiện nghi dùng khi lập phiếu
            cboTN.DataSource =
                service.LayTienNghi();

            cboTN.DisplayMember =
                "MaTienNghi";

            cboTN.ValueMember =
                "MaTienNghi";


            // Phòng dùng khi lập phiếu
            cboPhong.DataSource =
                service.LayPhong();

            cboPhong.DisplayMember =
                "SoPhong";

            cboPhong.ValueMember =
                "SoPhong";


            // Nhân viên
            cboNV.DataSource =
                danhMucService.LayNhanVien();

            cboNV.DisplayMember =
                "HoTen";

            cboNV.ValueMember =
                "MaNV";


            TaiDuLieu();
        }

        // =========================
        // TẢI DỮ LIỆU
        // =========================
        private void TaiDuLieu()
        {
            dgvPhong.DataSource =
                service.LayPhong();

            dgvTN.DataSource =
                service.LayTienNghi();

            dgvLD.DataSource =
                service.LayLapDat();
        }

        // =========================
        // LẤY VALUE COMBOBOX
        // =========================
        private string LayGiaTri(ComboBox cbo)
        {
            if (cbo.SelectedValue == null)
            {
                return "";
            }

            return cbo.SelectedValue.ToString();
        }

        // =========================
        // THÊM PHÒNG
        // =========================
        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            string message =
                service.ThemPhong(
                    txtPhong.Text.Trim(),
                    LayGiaTri(cboKhu),
                    (int)numMax.Value,
                    numGia.Value
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TaiDuLieu();

            // Reload phòng cho ComboBox lắp đặt
            cboPhong.DataSource =
                service.LayPhong();

            cboPhong.DisplayMember =
                "SoPhong";

            cboPhong.ValueMember =
                "SoPhong";
        }

        // =========================
        // THÊM TIỆN NGHI
        // =========================
        private void btnThemTN_Click(object sender, EventArgs e)
        {
            string message =
                service.ThemTienNghi(
                    txtMaTN.Text.Trim(),
                    LayGiaTri(cboLoai),
                    (int)numSTT.Value,
                    txtTinhTrang.Text.Trim()
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TaiDuLieu();

            // Reload tiện nghi cho ComboBox lắp đặt
            cboTN.DataSource =
                service.LayTienNghi();

            cboTN.DisplayMember =
                "MaTienNghi";

            cboTN.ValueMember =
                "MaTienNghi";
        }

        // =========================
        // LẬP PHIẾU LẮP ĐẶT
        // =========================
        private void btnLapDat_Click(object sender, EventArgs e)
        {
            string message =
                service.LapDat(
                    txtSoLD.Text.Trim(),
                    LayGiaTri(cboTN),
                    LayGiaTri(cboPhong),
                    dtNgay.Value,
                    txtTTLD.Text.Trim(),
                    LayGiaTri(cboNV),
                    txtGhiChu.Text.Trim()
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TaiDuLieu();

            // Load lại tiện nghi vì tình trạng có thể đã thay đổi
            cboTN.DataSource =
                service.LayTienNghi();

            cboTN.DisplayMember =
                "MaTienNghi";

            cboTN.ValueMember =
                "MaTienNghi";
        }

        // =========================
        // ĐÓNG FORM
        // =========================
        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}