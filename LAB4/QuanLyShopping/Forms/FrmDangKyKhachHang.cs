using EShopping.Services;
using System;
using System.Windows.Forms;

namespace QuanLyShopping.Forms
{
    public partial class FrmDangKyKhachHang : Form
    {
        private readonly KhachHangService service =
            new KhachHangService();

        public FrmDangKyKhachHang()
        {
            InitializeComponent();
        }

        // =====================================
        // LOAD FORM
        // =====================================
        private void FrmDangKyKhachHang_Load(
            object sender,
            EventArgs e)
        {
            TaiDuLieu();
        }

        // =====================================
        // TẢI DANH SÁCH KHÁCH HÀNG
        // =====================================
        private void TaiDuLieu()
        {
            dgvKhachHang.DataSource =
                service.LayDanhSach();

            dgvKhachHang.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =====================================
        // ĐĂNG KÝ KHÁCH HÀNG
        // =====================================
        private void btnDangKy_Click(
            object sender,
            EventArgs e)
        {
            string message =
                service.ThemKhachHang(
                    txtMaKH.Text.Trim(),
                    txtHoTen.Text.Trim(),
                    dtNgaySinh.Value,
                    txtCMND.Text.Trim(),
                    txtDiaChi.Text.Trim(),
                    txtDienThoai.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtTenDangNhap.Text.Trim(),
                    txtMatKhau.Text
                );

            MessageBox.Show(
                message,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            if (message == "Đăng ký khách hàng thành công.")
            {
                TaiDuLieu();
                LamMoi();
            }
        }

        // =====================================
        // LÀM MỚI FORM
        // =====================================
        private void btnLamMoi_Click(
            object sender,
            EventArgs e)
        {
            LamMoi();
        }

        private void LamMoi()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();

            dtNgaySinh.Value =
                DateTime.Today;

            txtCMND.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtEmail.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();

            txtMaKH.Focus();
        }

        // =====================================
        // ĐÓNG FORM
        // =====================================
        private void btnDong_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}