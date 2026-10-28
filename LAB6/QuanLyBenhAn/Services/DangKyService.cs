using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    public class DangKyService
    {
        public DataTable LayPhieuChuaCapHoSo()
        {
            return Db.Query(@"SELECT d.SoPhieuDK, d.SoPhieuDK + N' - ' + b.HoTen AS Ten 
                              FROM PhieuDangKy d JOIN BenhNhan b ON b.MaBN = d.MaBN
                              WHERE NOT EXISTS(SELECT 1 FROM HoSoBenhAn h WHERE h.SoPhieuDK = d.SoPhieuDK) 
                              ORDER BY d.NgayDangKy");
        }

        public DataTable LayHoSo()
        {
            CapNhatTrangThaiHetHan();
            return Db.Query(@"SELECT h.MaHoSo, h.MaHoSo + N' - ' + b.HoTen AS Ten, b.HoTen, b.DienThoai, h.NgayLap, h.NgayHetHan, h.TrangThai 
                              FROM HoSoBenhAn h JOIN BenhNhan b ON b.MaBN = h.MaBN ORDER BY h.MaHoSo");
        }

        public void CapNhatTrangThaiHetHan()
        {
            Db.Execute(@"UPDATE HoSoBenhAn SET TrangThai = CASE WHEN NgayHetHan < CAST(GETDATE() AS date) THEN N'Hết hạn' ELSE N'Hiệu lực' END");
        }

        public static bool KiemTraHieuLuc(string maHoSo, DateTime ngay)
        {
            var n = Db.Scalar("SELECT COUNT(*) FROM HoSoBenhAn WHERE MaHoSo = @m AND NgayLap <= @d AND NgayHetHan >= @d", new SqlParameter("@m", maHoSo ?? ""), new SqlParameter("@d", ngay.Date));
            return Convert.ToInt32(n) > 0;
        }

        public KetQuaXuLy DangKyBenhNhan(string maBN, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string dienThoai, string anh, string soPhieuDK, string maNVLap)
        {
            if (string.IsNullOrWhiteSpace(maBN) || string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(dienThoai) || string.IsNullOrWhiteSpace(soPhieuDK) || string.IsNullOrWhiteSpace(maNVLap))
                return KetQuaXuLy.Fail("Phiếu đăng ký chưa đủ họ tên, địa chỉ, ngày sinh, điện thoại.");
            if (ngaySinh.Date >= DateTime.Today)
                return KetQuaXuLy.Fail("Ngày sinh phải trước ngày hôm nay.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    Db.Execute(cn, tx, "INSERT INTO BenhNhan VALUES(@m, @t, @ns, @gt, @dc, @dt)",
                        new SqlParameter("@m", maBN), new SqlParameter("@t", hoTen), new SqlParameter("@ns", ngaySinh.Date),
                        new SqlParameter("@gt", gioiTinh), new SqlParameter("@dc", diaChi), new SqlParameter("@dt", dienThoai));

                    Db.Execute(cn, tx, "INSERT INTO PhieuDangKy VALUES(@p, @m, @nv, CAST(GETDATE() AS date), @a)",
                        new SqlParameter("@p", soPhieuDK), new SqlParameter("@m", maBN), new SqlParameter("@nv", maNVLap),
                        new SqlParameter("@a", Db.N(string.IsNullOrWhiteSpace(anh) ? null : anh)));

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã lập phiếu đăng ký " + soPhieuDK + ". Thu lệ phí để cấp hồ sơ.");
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return KetQuaXuLy.Fail("Mã bệnh nhân hoặc số phiếu đăng ký đã tồn tại."); }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }

        public KetQuaXuLy ThuLePhiVaCapHoSo(string soPhieuDK, string soBienLai, decimal soTien, string maNVThu)
        {
            if (string.IsNullOrWhiteSpace(soPhieuDK) || string.IsNullOrWhiteSpace(soBienLai) || string.IsNullOrWhiteSpace(maNVThu))
                return KetQuaXuLy.Fail("Thiếu phiếu đăng ký, số biên lai hoặc người thu.");
            if (soTien <= 0)
                return KetQuaXuLy.Fail("Lệ phí phải > 0.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var bn = Db.Scalar(cn, tx, "SELECT MaBN FROM PhieuDangKy WHERE SoPhieuDK = @p", new SqlParameter("@p", soPhieuDK)) as string;
                    if (bn == null) return KetQuaXuLy.Fail("Không tìm thấy phiếu đăng ký.");

                    if (Convert.ToInt32(Db.Scalar(cn, tx, "SELECT COUNT(*) FROM HoSoBenhAn WHERE SoPhieuDK = @p OR MaBN = @b", new SqlParameter("@p", soPhieuDK), new SqlParameter("@b", bn))) > 0)
                        return KetQuaXuLy.Fail("Bệnh nhân này đã có hồ sơ bệnh án.");

                    int stt = Convert.ToInt32(Db.Scalar(cn, tx, "SELECT COUNT(*) + 1 FROM HoSoBenhAn WHERE YEAR(NgayLap) = YEAR(GETDATE())"));
                    string maHoSo = "HS" + DateTime.Today.Year + "-" + stt.ToString("D4");
                    DateTime hom = DateTime.Today, het = hom.AddYears(1);

                    Db.Execute(cn, tx, "INSERT INTO HoSoBenhAn VALUES(@h, @b, @p, @l, @x, N'Hiệu lực')",
                        new SqlParameter("@h", maHoSo), new SqlParameter("@b", bn), new SqlParameter("@p", soPhieuDK), new SqlParameter("@l", hom), new SqlParameter("@x", het));

                    Db.Execute(cn, tx, "INSERT INTO BienLaiLePhi VALUES(@s, @h, @nv, @l, @t, @d, @tien)",
                        new SqlParameter("@s", soBienLai), new SqlParameter("@h", maHoSo), new SqlParameter("@nv", maNVThu),
                        new SqlParameter("@l", hom), new SqlParameter("@t", hom), new SqlParameter("@d", het), new SqlParameter("@tien", soTien));

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã cấp hồ sơ " + maHoSo + ", hạn dùng đến " + het.ToString("dd/MM/yyyy") + ".");
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return KetQuaXuLy.Fail("Số biên lai đã tồn tại."); }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }

        public KetQuaXuLy GiaHanLePhi(string maHoSo, string soBienLai, decimal soTien, string maNVThu)
        {
            if (string.IsNullOrWhiteSpace(maHoSo) || string.IsNullOrWhiteSpace(soBienLai) || string.IsNullOrWhiteSpace(maNVThu))
                return KetQuaXuLy.Fail("Thiếu hồ sơ, số biên lai hoặc người thu.");
            if (soTien <= 0)
                return KetQuaXuLy.Fail("Lệ phí phải > 0.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var o = Db.Scalar(cn, tx, "SELECT NgayHetHan FROM HoSoBenhAn WHERE MaHoSo = @h", new SqlParameter("@h", maHoSo));
                    if (o == null) return KetQuaXuLy.Fail("Không tìm thấy hồ sơ.");

                    DateTime cu = (DateTime)o, tu = cu >= DateTime.Today ? cu : DateTime.Today, den = tu.AddYears(1);
                    Db.Execute(cn, tx, "INSERT INTO BienLaiLePhi VALUES(@s, @h, @nv, CAST(GETDATE() AS date), @t, @d, @tien)",
                        new SqlParameter("@s", soBienLai), new SqlParameter("@h", maHoSo), new SqlParameter("@nv", maNVThu),
                        new SqlParameter("@t", tu), new SqlParameter("@d", den), new SqlParameter("@tien", soTien));

                    Db.Execute(cn, tx, "UPDATE HoSoBenhAn SET NgayHetHan = @d, TrangThai = N'Hiệu lực' WHERE MaHoSo = @h",
                        new SqlParameter("@d", den), new SqlParameter("@h", maHoSo));

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã gia hạn, hạn dùng mới " + den.ToString("dd/MM/yyyy") + ".");
                }
                catch (SqlException ex) when (ex.Number == 2627) { return KetQuaXuLy.Fail("Số biên lai đã tồn tại."); }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }
    }
}