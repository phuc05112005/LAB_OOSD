using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using QuanLyKhachSan.Services;

namespace QuanLyKhachSan.Forms
{
    public partial class FrmDatPhong : Form
    {
        private readonly DatPhongService service =
            new DatPhongService();

        private readonly DanhMucService danhMucService =
            new DanhMucService();

        private readonly BindingList<PhongDatItem> phongDaChon =
            new BindingList<PhongDatItem>();

        public FrmDatPhong()
        {
            InitializeComponent();
        }

        // =====================================
        // LOAD FORM
        // =====================================
        private void FrmDatPhong_Load(object sender, EventArgs e)
        {
            // Khách hàng
            cboKhach.DataSource =
                service.LayKhach();

            cboKhach.DisplayMember =
                "HoTen";

            cboKhach.ValueMember =
                "MaKhach";

            // Nhân viên lễ tân
            cboNV.DataSource =
                danhMucService.LayNhanVien();

            cboNV.DisplayMember =
                "HoTen";

            cboNV.ValueMember =
                "MaNV";

            // Kênh đặt
            cboKenh.Items.Clear();

            cboKenh.Items.AddRange(
                new object[]
                {
                    "Điện thoại",
                    "Website",
                    "Trực tiếp"
                }
            );

            if (cboKenh.Items.Count > 0)
            {
                cboKenh.SelectedIndex = 0;
            }

            // Danh sách phòng đang chọn
            dgvChon.DataSource =
                phongDaChon;

            // Load dữ liệu chính
            TaiDuLieu();

            // Hiển thị title cột ngay cả khi chưa chọn phiếu
            dgvCT.DataSource =
                service.LayChiTiet("");

            dgvNguoi.DataSource =
                service.LayNguoiLuuTru("");

            // Tự động chỉnh độ rộng cột
            dgvKhach.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvPhong.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvChon.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvPhieu.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvCT.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvNguoi.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        // =====================================
        // TẢI DỮ LIỆU
        // =====================================
        private void TaiDuLieu()
        {
            dgvKhach.DataSource =
                service.LayKhach();

            dgvPhong.DataSource =
                service.LayPhong();

            dgvPhieu.DataSource =
                service.LayPhieuDat();

            // Reload khách hàng vào ComboBox
            cboKhach.DataSource =
                service.LayKhach();

            cboKhach.DisplayMember =
                "HoTen";

            cboKhach.ValueMember =
                "MaKhach";
        }

        // =====================================
        // LẤY VALUE COMBOBOX
        // =====================================
        private string LayGiaTri(ComboBox cbo)
        {
            if (cbo.SelectedValue == null)
            {
                return "";
            }

            return cbo.SelectedValue.ToString();
        }

        // =====================================
        // THÊM KHÁCH HÀNG
        // =====================================
        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            string message =
                service.ThemKhach(
                    txtMaKH.Text.Trim(),
                    txtTenKH.Text.Trim(),
                    txtCMND.Text.Trim(),
                    txtQT.Text.Trim(),
                    txtSDT.Text.Trim()
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TaiDuLieu();
        }

        // =====================================
        // THÊM PHÒNG VÀO PHIẾU
        // =====================================
        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn phòng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string soPhong =
                Convert.ToString(
                    dgvPhong.CurrentRow
                        .Cells["SoPhong"]
                        .Value
                );

            // Không cho thêm trùng phòng
            foreach (PhongDatItem item in phongDaChon)
            {
                if (item.SoPhong == soPhong)
                {
                    MessageBox.Show(
                        "Phòng này đã được chọn.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }
            }

            int soNguoi =
                (int)numSoNguoi.Value;

            decimal donGia =
                Convert.ToDecimal(
                    dgvPhong.CurrentRow
                        .Cells["DonGiaNgay"]
                        .Value
                );

            PhongDatItem itemMoi =
                new PhongDatItem
                {
                    SoPhong = soPhong,
                    SoNguoi = soNguoi,
                    DonGiaNgay = donGia
                };

            phongDaChon.Add(itemMoi);
        }

        // =====================================
        // BỎ PHÒNG KHỎI PHIẾU
        // =====================================
        private void btnBoPhong_Click(object sender, EventArgs e)
        {
            if (dgvChon.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn phòng cần bỏ.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int index =
                dgvChon.CurrentRow.Index;

            if (index >= 0 &&
                index < phongDaChon.Count)
            {
                phongDaChon.RemoveAt(index);
            }
        }

        // =====================================
        // LẬP PHIẾU ĐẶT PHÒNG
        // =====================================
        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            List<PhongDatItem> danhSach =
                new List<PhongDatItem>(
                    phongDaChon
                );

            string message =
                service.TaoDatPhong(
                    txtSoPhieu.Text.Trim(),
                    LayGiaTri(cboKhach),
                    LayGiaTri(cboNV),
                    dtLap.Value,
                    dtNhan.Value,
                    dtTra.Value,
                    numCoc.Value,
                    cboKenh.Text,
                    danhSach
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            if (message == "Đã lập phiếu đặt phòng.")
            {
                phongDaChon.Clear();
            }

            TaiDuLieu();
        }

        // =====================================
        // CHỌN PHIẾU ĐẶT PHÒNG
        // =====================================
        private void dgvPhieu_SelectionChanged(
            object sender,
            EventArgs e)
        {
            if (dgvPhieu.CurrentRow == null)
            {
                return;
            }

            object value =
                dgvPhieu.CurrentRow
                    .Cells["SoPhieuDat"]
                    .Value;

            if (value == null ||
                value == DBNull.Value)
            {
                return;
            }

            string soPhieu =
                Convert.ToString(value);

            if (string.IsNullOrWhiteSpace(soPhieu))
            {
                return;
            }

            txtPhieuChon.Text =
                soPhieu;

            dgvCT.DataSource =
                service.LayChiTiet(
                    soPhieu
                );

            dgvNguoi.DataSource =
                service.LayNguoiLuuTru(
                    soPhieu
                );
        }

        // =====================================
        // THÊM NGƯỜI LƯU TRÚ
        // =====================================
        private void btnThemNguoi_Click(
            object sender,
            EventArgs e)
        {
            string message =
                service.ThemNguoiLuuTru(
                    txtPhieuChon.Text.Trim(),
                    txtNguoiPhong.Text.Trim(),
                    txtNguoiTen.Text.Trim(),
                    txtNguoiCMND.Text.Trim(),
                    txtNguoiQT.Text.Trim()
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            if (!string.IsNullOrWhiteSpace(
                txtPhieuChon.Text))
            {
                dgvNguoi.DataSource =
                    service.LayNguoiLuuTru(
                        txtPhieuChon.Text.Trim()
                    );
            }
        }

        // =====================================
        // NHẬN PHÒNG
        // =====================================
        private void btnNhanPhong_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtPhieuChon.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn phiếu đặt phòng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Xác nhận nhận phòng cho phiếu này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            string message =
                service.NhanPhong(
                    txtPhieuChon.Text.Trim(),
                    DateTime.Now
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TaiDuLieu();
        }

        // =====================================
        // NO-SHOW
        // =====================================
        private void btnNoShow_Click(
            object sender,
            EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                txtPhieuChon.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn phiếu đặt phòng.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Xác nhận khách không đến nhận phòng?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
            {
                return;
            }

            string message =
                service.DanhDauNoShow(
                    txtPhieuChon.Text.Trim()
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            TaiDuLieu();

            txtPhieuChon.Clear();

            // Trả bảng về trạng thái rỗng nhưng vẫn còn tiêu đề cột
            dgvCT.DataSource =
                service.LayChiTiet("");

            dgvNguoi.DataSource =
                service.LayNguoiLuuTru("");
        }

        private void btnNhanPhong_Click_1(object sender, EventArgs e)
        {

        }
    }
}