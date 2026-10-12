using System;
using System.Windows.Forms;
using QuanLyCongTyDuLich.BUS;
using QuanLyCongTyDuLich.DTO;

namespace QuanLyCongTyDuLich.GUI
{
    public partial class FormDangKyTourDoan : Form
    {
        private readonly DangKyDoanBUS bus = new DangKyDoanBUS();

        public FormDangKyTourDoan()
        {
            InitializeComponent();
        }

        private void FormDangKyTourDoan_Load(object sender, EventArgs e)
        {
            LoadDataCombobox();
        }

        private void LoadDataCombobox()
        {
            try
            {
                cboChuyenTour.DataSource = bus.GetDanhSachChuyenTour();
                cboChuyenTour.DisplayMember = "TenHienThi";
                cboChuyenTour.ValueMember = "maChuyen";

                cboKhachHang.DataSource = bus.GetDanhSachKhachHang();
                cboKhachHang.DisplayMember = "TenHienThi";
                cboKhachHang.ValueMember = "maKhachHang";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuuDangKy_Click(object sender, EventArgs e)
        {
            if (cboChuyenTour.SelectedValue == null || cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Chuyến tour và Khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DangKyDoanDTO dto = new DangKyDoanDTO
            {
                MaDangKy = "DKD" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                MaChuyen = cboChuyenTour.SelectedValue.ToString(),
                MaKhachHang = cboKhachHang.SelectedValue.ToString(),
                TenDonVi = txtTenDonVi.Text.Trim(),
                TenNguoiDaiDien = txtNguoiDaiDien.Text.Trim(),
                SoDienThoaiLienHe = txtSoDienThoai.Text.Trim(),
                DiaDiemDon = txtDiaDiemDon.Text.Trim(),
                SoLuongKhach = (int)nudSoLuongKhach.Value,
                TongTien = numTongTien.Value,
                TienDatCoc = numTienCoc.Value
            };

            if (bus.DangKyTourDoan(dto, out string errorMsg))
            {
                MessageBox.Show("Đăng ký Tour theo đoàn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Thất bại: " + errorMsg, "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}