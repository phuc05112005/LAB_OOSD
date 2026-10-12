using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyCongTyDuLich.DTO;

namespace QuanLyCongTyDuLich.DAL
{
    public class DangKyDoanDAL
    {
        // Lấy danh sách Chuyến tour còn mở bán
        public DataTable GetDanhSachChuyenTour()
        {
            string query = @"SELECT c.maChuyen, t.tenTour + ' (Khởi hành: ' + CONVERT(VARCHAR, c.ngayKhoiHanh, 103) + ')' AS TenHienThi
                             FROM ChuyenKhoiHanh c 
                             JOIN Tour t ON c.maTour = t.maTour
                             WHERE c.trangThai = N'Mở bán'";
            return DatabaseHelper.ExecuteQuery(query);
        }

        // Lấy danh sách Khách hàng
        public DataTable GetDanhSachKhachHang()
        {
            string query = "SELECT maKhachHang, hoTen + ' - ' + soDienThoai AS TenHienThi FROM KhachHang";
            return DatabaseHelper.ExecuteQuery(query);
        }

        // Lưu thông tin Đăng ký Đoàn (Giao dịch 2 bảng DangKy & DangKyDoan)
        public bool ThemDangKyDoan(DangKyDoanDTO dto)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Thêm vào bảng cha DangKy
                    string sqlCha = @"INSERT INTO DangKy (maDangKy, maKhachHang, maChuyen, ngayDangKy, soLuongKhach, tongTien, trangThai) 
                                      VALUES (@maDangKy, @maKhachHang, @maChuyen, GETDATE(), @soLuongKhach, @tongTien, N'Đã cọc')";
                    SqlCommand cmdCha = new SqlCommand(sqlCha, conn, transaction);
                    cmdCha.Parameters.AddWithValue("@maDangKy", dto.MaDangKy);
                    cmdCha.Parameters.AddWithValue("@maKhachHang", dto.MaKhachHang);
                    cmdCha.Parameters.AddWithValue("@maChuyen", dto.MaChuyen);
                    cmdCha.Parameters.AddWithValue("@soLuongKhach", dto.SoLuongKhach);
                    cmdCha.Parameters.AddWithValue("@tongTien", dto.TongTien);
                    cmdCha.ExecuteNonQuery();

                    // 2. Thêm vào bảng con DangKyDoan
                    string sqlCon = @"INSERT INTO DangKyDoan (maDangKy, tenDonViHoacDoan, tenNguoiDaiDien, soDienThoaiLienHe, diaDiemDon, tienDatCoc) 
                                      VALUES (@maDangKy, @tenDonVi, @tenNguoiDaiDien, @sdtLienHe, @diaDiemDon, @tienCoc)";
                    SqlCommand cmdCon = new SqlCommand(sqlCon, conn, transaction);
                    cmdCon.Parameters.AddWithValue("@maDangKy", dto.MaDangKy);
                    cmdCon.Parameters.AddWithValue("@tenDonVi", dto.TenDonVi);
                    cmdCon.Parameters.AddWithValue("@tenNguoiDaiDien", dto.TenNguoiDaiDien);
                    cmdCon.Parameters.AddWithValue("@sdtLienHe", dto.SoDienThoaiLienHe);
                    cmdCon.Parameters.AddWithValue("@diaDiemDon", dto.DiaDiemDon);
                    cmdCon.Parameters.AddWithValue("@tienCoc", dto.TienDatCoc);
                    cmdCon.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Lỗi khi lưu dữ liệu: " + ex.Message);
                }
            }
        }
    }
}