using System;
using System.Data;
using QuanLyCongTyDuLich.DAL;
using QuanLyCongTyDuLich.DTO;

namespace QuanLyCongTyDuLich.BUS
{
    public class DangKyDoanBUS
    {
        private readonly DangKyDoanDAL dal = new DangKyDoanDAL();

        public DataTable GetDanhSachChuyenTour() => dal.GetDanhSachChuyenTour();
        public DataTable GetDanhSachKhachHang() => dal.GetDanhSachKhachHang();

        public bool DangKyTourDoan(DangKyDoanDTO dto, out string error)
        {
            error = string.Empty;

            // Kiểm tra quy tắc nghiệp vụ
            if (dto.SoLuongKhach < 12)
            {
                error = "Đăng ký theo đoàn yêu cầu số lượng khách tối thiểu từ 12 người trở lên!";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.TenDonVi) || string.IsNullOrWhiteSpace(dto.TenNguoiDaiDien))
            {
                error = "Vui lòng nhập đầy đủ Tên đơn vị và Người đại diện!";
                return false;
            }

            if (dto.TienDatCoc <= 0)
            {
                error = "Số tiền đặt cọc phải lớn hơn 0!";
                return false;
            }

            try
            {
                return dal.ThemDangKyDoan(dto);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}