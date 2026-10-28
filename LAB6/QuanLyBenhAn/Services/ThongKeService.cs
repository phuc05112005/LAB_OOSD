using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    public class ThongKeService
    {
        public DataTable TongHop(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT
                (SELECT COUNT(*) FROM HoSoBenhAn WHERE NgayLap BETWEEN @t AND @d) AS HoSoMoi,
                (SELECT ISNULL(SUM(SoTien), 0) FROM BienLaiLePhi WHERE NgayDong BETWEEN @t AND @d) AS TongLePhi,
                (SELECT COUNT(*) FROM PhieuKham WHERE TrangThai = N'Đã ghi nhận' AND CAST(NgayGioKham AS date) BETWEEN @t AND @d) AS LuotKham,
                (SELECT COUNT(*) FROM PhieuKham WHERE TrangThai = N'Đã ghi nhận' AND LoaiKham = N'Định kỳ' AND CAST(NgayGioKham AS date) BETWEEN @t AND @d) AS KhamDinhKy,
                (SELECT COUNT(*) FROM HoSoBenhAn WHERE NgayHetHan < CAST(GETDATE() AS date)) AS HoSoHetHan",
                new SqlParameter("@t", tu.Date), new SqlParameter("@d", den.Date));
        }

        public DataTable LuotKhamTheoKhoa(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT k.TenKhoa, b.HoTen AS BacSi, COUNT(*) AS SoLuot,
                                     SUM(CASE WHEN p.LoaiKham = N'Định kỳ' THEN 1 ELSE 0 END) AS KhamDinhKy,
                                     SUM(CASE WHEN p.HieuQuaDieuTri IS NOT NULL THEN 1 ELSE 0 END) AS CoDanhGiaHieuQua
                              FROM PhieuKham p JOIN BacSi b ON b.MaBS = p.MaBS JOIN Khoa k ON k.MaKhoa = p.MaKhoa
                              WHERE p.TrangThai = N'Đã ghi nhận' AND CAST(p.NgayGioKham AS date) BETWEEN @t AND @d 
                              GROUP BY k.TenKhoa, b.HoTen ORDER BY SoLuot DESC",
                new SqlParameter("@t", tu.Date), new SqlParameter("@d", den.Date));
        }

        public DataTable KhamDinhKyTheoQuy(int nam)
        {
            return Db.Query(@"SELECT Quy, COUNT(*) AS SoLichHen,
                                     SUM(CASE WHEN TrangThai = N'Đã khám' THEN 1 ELSE 0 END) AS DaKham,
                                     SUM(CASE WHEN TrangThai = N'Hủy' THEN 1 ELSE 0 END) AS Huy,
                                     SUM(CASE WHEN TrangThai = N'Quá hạn' THEN 1 ELSE 0 END) AS QuaHan
                              FROM LichHenKham WHERE Nam = @n GROUP BY Quy ORDER BY Quy", new SqlParameter("@n", nam));
        }

        public DataTable HoSoSapHetHan(int soNgay)
        {
            return Db.Query(@"SELECT h.MaHoSo, b.HoTen, b.DienThoai, h.NgayHetHan, DATEDIFF(day, CAST(GETDATE() AS date), h.NgayHetHan) AS ConLaiNgay
                              FROM HoSoBenhAn h JOIN BenhNhan b ON b.MaBN = h.MaBN 
                              WHERE h.NgayHetHan <= DATEADD(day, @n, CAST(GETDATE() AS date)) 
                              ORDER BY h.NgayHetHan", new SqlParameter("@n", soNgay));
        }
    }
}