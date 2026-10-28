using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    public class LichHenService
    {
        public DataTable LayLichHen()
        {
            Db.Execute("UPDATE LichHenKham SET TrangThai = N'Quá hạn' WHERE TrangThai = N'Đã hẹn' AND NgayGioHen < CAST(GETDATE() AS date)");
            return Db.Query(@"SELECT l.SoLichHen, l.MaHoSo, b.HoTen, s.HoTen AS BacSi, l.NgayGioHen, l.Quy, l.Nam, l.GhiChu, l.TrangThai 
                              FROM LichHenKham l
                              JOIN HoSoBenhAn h ON h.MaHoSo = l.MaHoSo 
                              JOIN BenhNhan b ON b.MaBN = h.MaBN 
                              JOIN BacSi s ON s.MaBS = l.MaBS 
                              ORDER BY l.NgayGioHen DESC");
        }

        public bool DaDungQuyenLoi(string maHoSo, int quy, int nam)
        {
            var n = Db.Scalar("SELECT COUNT(*) FROM LichHenKham WHERE MaHoSo = @h AND Quy = @q AND Nam = @n AND TrangThai IN (N'Đã hẹn', N'Đã khám')",
                new SqlParameter("@h", maHoSo ?? ""), new SqlParameter("@q", quy), new SqlParameter("@n", nam));
            return Convert.ToInt32(n) > 0;
        }

        public static int QuyCuaNgay(DateTime d) { return (d.Month - 1) / 3 + 1; }

        public KetQuaXuLy DatLich(string soLich, string maHoSo, string maBS, DateTime ngayGio, string ghiChu, string maNVLap)
        {
            if (string.IsNullOrWhiteSpace(soLich) || string.IsNullOrWhiteSpace(maHoSo) || string.IsNullOrWhiteSpace(maBS) || string.IsNullOrWhiteSpace(maNVLap))
                return KetQuaXuLy.Fail("Lịch hẹn chưa đủ thông tin.");
            if (ngayGio <= DateTime.Now)
                return KetQuaXuLy.Fail("Ngày giờ hẹn phải sau thời điểm hiện tại.");
            if (ngayGio.Hour < 7 || ngayGio.Hour >= 17)
                return KetQuaXuLy.Fail("Giờ hẹn phải trong giờ làm việc (07:00 - 17:00).");
            if (!DangKyService.KiemTraHieuLuc(maHoSo, ngayGio))
                return KetQuaXuLy.Fail("Hồ sơ đã hết hạn tại ngày hẹn, hãy gia hạn lệ phí trước.");

            int quy = QuyCuaNgay(ngayGio), nam = ngayGio.Year;
            if (DaDungQuyenLoi(maHoSo, quy, nam))
                return KetQuaXuLy.Fail("Hồ sơ đã có lịch khám định kỳ trong quý " + quy + "/" + nam + ".");

            try
            {
                Db.Execute("INSERT INTO LichHenKham VALUES(@s, @h, @b, @nv, @g, @q, @n, @gc, N'Đã hẹn')",
                    new SqlParameter("@s", soLich), new SqlParameter("@h", maHoSo), new SqlParameter("@b", maBS), new SqlParameter("@nv", maNVLap),
                    new SqlParameter("@g", ngayGio), new SqlParameter("@q", quy), new SqlParameter("@n", nam), new SqlParameter("@gc", Db.N(ghiChu)));
                return KetQuaXuLy.Ok("Đã hẹn khám lúc " + ngayGio.ToString("HH:mm dd/MM/yyyy") + ".");
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return KetQuaXuLy.Fail("Bác sĩ đã có lịch vào giờ này hoặc số lịch hẹn đã tồn tại."); }
            catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
        }

        public KetQuaXuLy HuyLich(string soLich)
        {
            if (string.IsNullOrWhiteSpace(soLich)) return KetQuaXuLy.Fail("Chưa chọn lịch hẹn.");
            int n = Db.Execute("UPDATE LichHenKham SET TrangThai = N'Hủy' WHERE SoLichHen = @s AND TrangThai = N'Đã hẹn'", new SqlParameter("@s", soLich));
            return n == 0 ? KetQuaXuLy.Fail("Chỉ hủy được lịch đang ở trạng thái Đã hẹn.") : KetQuaXuLy.Ok("Đã hủy lịch hẹn; quyền lợi quý được giữ lại.");
        }
    }
}