using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    public class TraCuuService
    {
        public DataTable TimHoSo(string tuKhoa)
        {
            tuKhoa = (tuKhoa ?? "").Trim();
            return Db.Query(@"SELECT h.MaHoSo, b.HoTen, b.NgaySinh, b.GioiTinh, b.DiaChi, b.DienThoai, h.NgayLap, h.NgayHetHan,
                                    CASE WHEN h.NgayHetHan < CAST(GETDATE() AS date) THEN N'Hết hạn' ELSE N'Hiệu lực' END AS TrangThai
                              FROM HoSoBenhAn h JOIN BenhNhan b ON b.MaBN = h.MaBN
                              WHERE h.MaHoSo = @k OR b.DienThoai = @k OR b.HoTen LIKE @l OR CONVERT(varchar(10), b.NgaySinh, 103) = @k 
                              ORDER BY b.HoTen",
                new SqlParameter("@k", tuKhoa), new SqlParameter("@l", "%" + tuKhoa + "%"));
        }

        public DataTable LayLichSuKham(string maHoSo)
        {
            return Db.Query(@"SELECT p.SoPhieuKham, p.NgayGioKham, p.LoaiKham, k.TenKhoa, b.HoTen AS BacSi, p.ChanDoan, p.DienBienBenh, p.HieuQuaDieuTri, p.NgayXuatVien
                              FROM PhieuKham p JOIN BacSi b ON b.MaBS = p.MaBS JOIN Khoa k ON k.MaKhoa = p.MaKhoa
                              WHERE p.MaHoSo = @h AND p.TrangThai = N'Đã ghi nhận' 
                              ORDER BY p.NgayGioKham DESC", new SqlParameter("@h", maHoSo ?? ""));
        }

        public DataTable LayTrieuChung(string soPhieu)
        {
            return Db.Query("SELECT t.TenTC, c.GiaTri, t.DonVi FROM ChiTietTrieuChung c JOIN TrieuChung t ON t.MaTC = c.MaTC WHERE c.SoPhieuKham = @p ORDER BY c.STT", new SqlParameter("@p", soPhieu ?? ""));
        }

        public DataTable LayToaThuoc(string soPhieu)
        {
            return Db.Query(@"SELECT th.TenThuoc, c.SoLuong, c.LieuDung, c.CachDung, t.TenTC AS DieuTriTrieuChung, c.PhanUngPhu 
                              FROM ToaThuoc a JOIN ChiTietToaThuoc c ON c.SoToa = a.SoToa
                              JOIN Thuoc th ON th.MaThuoc = c.MaThuoc 
                              JOIN TrieuChung t ON t.MaTC = c.MaTC 
                              WHERE a.SoPhieuKham = @p ORDER BY c.STT", new SqlParameter("@p", soPhieu ?? ""));
        }

        public DataTable LayXetNghiem(string soPhieu)
        {
            return Db.Query("SELECT x.TenXN, c.NgayThucHien, c.KetQua FROM ChiTietXetNghiem c JOIN XetNghiem x ON x.MaXN = c.MaXN WHERE c.SoPhieuKham = @p ORDER BY c.STT", new SqlParameter("@p", soPhieu ?? ""));
        }
    }
}