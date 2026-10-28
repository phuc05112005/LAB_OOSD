using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    public class PhieuKhamService
    {
        public DataTable LayLichDaHen(string maHoSo)
        {
            return Db.Query("SELECT SoLichHen, SoLichHen + N' - ' + CONVERT(nvarchar(16), NgayGioHen, 120) AS Ten FROM LichHenKham WHERE MaHoSo = @h AND TrangThai = N'Đã hẹn'", new SqlParameter("@h", maHoSo ?? ""));
        }

        public DataTable LayPhieu(string soPhieu)
        {
            return Db.Query("SELECT * FROM PhieuKham WHERE SoPhieuKham = @p", new SqlParameter("@p", soPhieu ?? ""));
        }

        public DataTable LayTrieuChungCuaPhieu(string soPhieu)
        {
            return Db.Query("SELECT c.MaTC, t.TenTC FROM ChiTietTrieuChung c JOIN TrieuChung t ON t.MaTC = c.MaTC WHERE c.SoPhieuKham = @p ORDER BY c.STT", new SqlParameter("@p", soPhieu ?? ""));
        }

        private static string TrangThai(SqlConnection cn, SqlTransaction tx, string soPhieu)
        {
            return Db.Scalar(cn, tx, "SELECT TrangThai FROM PhieuKham WHERE SoPhieuKham = @p", new SqlParameter("@p", soPhieu ?? "")) as string;
        }

        private static KetQuaXuLy DangNhap(SqlConnection cn, SqlTransaction tx, string soPhieu)
        {
            var tt = TrangThai(cn, tx, soPhieu);
            if (tt == null) return KetQuaXuLy.Fail("Không tìm thấy phiếu khám.");
            return tt == "Đang nhập" ? null : KetQuaXuLy.Fail("Phiếu đã ghi nhận, không được sửa.");
        }

        private static int STT(SqlConnection cn, SqlTransaction tx, string bang, string cot, string ma)
        {
            return Convert.ToInt32(Db.Scalar(cn, tx, "SELECT ISNULL(MAX(STT), 0) + 1 FROM " + bang + " WHERE " + cot + " = @m", new SqlParameter("@m", ma)));
        }

        public KetQuaXuLy TaoPhieuKham(string soPhieu, string maHoSo, string maBS, string maKhoa, DateTime ngayGio, string loai, string soLichHen, string maNVGhi)
        {
            if (string.IsNullOrWhiteSpace(soPhieu) || string.IsNullOrWhiteSpace(maHoSo) || string.IsNullOrWhiteSpace(maBS) || string.IsNullOrWhiteSpace(maKhoa) || string.IsNullOrWhiteSpace(maNVGhi))
                return KetQuaXuLy.Fail("Đầu phiếu khám chưa đủ thông tin.");
            if (loai != "Điều trị" && loai != "Định kỳ")
                return KetQuaXuLy.Fail("Loại khám phải là Điều trị hoặc Định kỳ.");
            if (ngayGio > DateTime.Now)
                return KetQuaXuLy.Fail("Ngày giờ khám không được ở tương lai.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    if (Convert.ToInt32(Db.Scalar(cn, tx, "SELECT COUNT(*) FROM BacSi WHERE MaBS = @b AND MaKhoa = @k", new SqlParameter("@b", maBS), new SqlParameter("@k", maKhoa))) == 0)
                        return KetQuaXuLy.Fail("Bác sĩ không thuộc khoa đã chọn.");

                    if (loai == "Định kỳ")
                    {
                        if (string.IsNullOrWhiteSpace(soLichHen)) return KetQuaXuLy.Fail("Khám định kỳ phải gắn với lịch hẹn.");
                        if (!DangKyService.KiemTraHieuLuc(maHoSo, ngayGio)) return KetQuaXuLy.Fail("Hồ sơ hết hạn, không được hưởng khám định kỳ miễn phí.");
                        if (Db.Execute(cn, tx, "UPDATE LichHenKham SET TrangThai = N'Đã khám' WHERE SoLichHen = @l AND MaHoSo = @h AND TrangThai = N'Đã hẹn'", new SqlParameter("@l", soLichHen), new SqlParameter("@h", maHoSo)) == 0)
                            return KetQuaXuLy.Fail("Lịch hẹn không hợp lệ hoặc đã được sử dụng.");
                    }
                    else soLichHen = null;

                    Db.Execute(cn, tx, @"INSERT INTO PhieuKham(SoPhieuKham, MaHoSo, MaBS, MaKhoa, MaNVGhi, SoLichHen, NgayGioKham, LoaiKham, TrangThai) VALUES(@p, @h, @b, @k, @nv, @l, @g, @t, N'Đang nhập')",
                        new SqlParameter("@p", soPhieu), new SqlParameter("@h", maHoSo), new SqlParameter("@b", maBS), new SqlParameter("@k", maKhoa), new SqlParameter("@nv", maNVGhi),
                        new SqlParameter("@l", Db.N(soLichHen)), new SqlParameter("@g", ngayGio), new SqlParameter("@t", loai));

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã tạo phiếu khám, tiếp tục nhập triệu chứng, toa thuốc, xét nghiệm.");
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return KetQuaXuLy.Fail("Số phiếu khám đã tồn tại."); }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }

        public KetQuaXuLy ThemTrieuChung(string soPhieu, string maTC, string giaTri, string ghiChu)
        {
            if (string.IsNullOrWhiteSpace(maTC) || string.IsNullOrWhiteSpace(giaTri))
                return KetQuaXuLy.Fail("Chưa chọn triệu chứng hoặc chưa nhập giá trị.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var loi = DangNhap(cn, tx, soPhieu); if (loi != null) return loi;
                    Db.Execute(cn, tx, "INSERT INTO ChiTietTrieuChung VALUES(@p, @s, @t, @g, @c)", new SqlParameter("@p", soPhieu), new SqlParameter("@s", STT(cn, tx, "ChiTietTrieuChung", "SoPhieuKham", soPhieu)),
                        new SqlParameter("@t", maTC), new SqlParameter("@g", giaTri), new SqlParameter("@c", Db.N(ghiChu)));
                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã ghi triệu chứng.");
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return KetQuaXuLy.Fail("Triệu chứng này đã có trong phiếu."); }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }

        public KetQuaXuLy LapToaThuoc(string soToa, string soPhieu, DateTime ngayKe, string loiDan)
        {
            if (string.IsNullOrWhiteSpace(soToa)) return KetQuaXuLy.Fail("Chưa nhập số toa.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var loi = DangNhap(cn, tx, soPhieu); if (loi != null) return loi;
                    Db.Execute(cn, tx, "INSERT INTO ToaThuoc VALUES(@t, @p, @n, @l)", new SqlParameter("@t", soToa), new SqlParameter("@p", soPhieu), new SqlParameter("@n", ngayKe.Date), new SqlParameter("@l", Db.N(loiDan)));
                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã lập toa thuốc.");
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return KetQuaXuLy.Fail("Số toa đã tồn tại hoặc phiếu khám đã có toa thuốc."); }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }

        public KetQuaXuLy ThemThuoc(string soToa, string maThuoc, string maTC, int soLuong, string lieuDung, string cachDung, string phanUngPhu)
        {
            if (string.IsNullOrWhiteSpace(soToa) || string.IsNullOrWhiteSpace(maThuoc) || string.IsNullOrWhiteSpace(maTC) || string.IsNullOrWhiteSpace(lieuDung))
                return KetQuaXuLy.Fail("Dòng thuốc chưa đủ thuốc, triệu chứng, liều dùng.");
            if (soLuong <= 0)
                return KetQuaXuLy.Fail("Số lượng phải > 0.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var phieu = Db.Scalar(cn, tx, "SELECT SoPhieuKham FROM ToaThuoc WHERE SoToa = @t", new SqlParameter("@t", soToa)) as string;
                    if (phieu == null) return KetQuaXuLy.Fail("Không tìm thấy toa thuốc.");

                    var loi = DangNhap(cn, tx, phieu); if (loi != null) return loi;

                    if (Convert.ToInt32(Db.Scalar(cn, tx, "SELECT COUNT(*) FROM ChiTietTrieuChung WHERE SoPhieuKham = @p AND MaTC = @t", new SqlParameter("@p", phieu), new SqlParameter("@t", maTC))) == 0)
                        return KetQuaXuLy.Fail("Triệu chứng điều trị phải là triệu chứng đã ghi trong phiếu khám.");

                    Db.Execute(cn, tx, "INSERT INTO ChiTietToaThuoc VALUES(@t, @s, @m, @c, @sl, @l, @cd, @pu)", new SqlParameter("@t", soToa), new SqlParameter("@s", STT(cn, tx, "ChiTietToaThuoc", "SoToa", soToa)),
                        new SqlParameter("@m", maThuoc), new SqlParameter("@c", maTC), new SqlParameter("@sl", soLuong), new SqlParameter("@l", lieuDung), new SqlParameter("@cd", Db.N(cachDung)), new SqlParameter("@pu", Db.N(string.IsNullOrWhiteSpace(phanUngPhu) ? null : phanUngPhu)));

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã thêm thuốc vào toa.");
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return KetQuaXuLy.Fail("Thuốc này đã có trong toa."); }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }

        public KetQuaXuLy ThemXetNghiem(string soPhieu, string maXN, DateTime ngayTH, string ketQua)
        {
            if (string.IsNullOrWhiteSpace(maXN)) return KetQuaXuLy.Fail("Chưa chọn xét nghiệm.");

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var loi = DangNhap(cn, tx, soPhieu); if (loi != null) return loi;
                    Db.Execute(cn, tx, "INSERT INTO ChiTietXetNghiem VALUES(@p, @s, @x, @n, @k)", new SqlParameter("@p", soPhieu), new SqlParameter("@s", STT(cn, tx, "ChiTietXetNghiem", "SoPhieuKham", soPhieu)),
                        new SqlParameter("@x", maXN), new SqlParameter("@n", ngayTH.Date), new SqlParameter("@k", Db.N(ketQua)));
                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã ghi xét nghiệm.");
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return KetQuaXuLy.Fail("Xét nghiệm này đã có trong phiếu."); }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }

        public KetQuaXuLy GhiNhan(string soPhieu, string chanDoan, string dienBien, string hieuQua, DateTime? ngayXuatVien, string soBienLai)
        {
            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var loi = DangNhap(cn, tx, soPhieu); if (loi != null) return loi;
                    var r = Db.Query(cn, tx, "SELECT LoaiKham, NgayGioKham FROM PhieuKham WHERE SoPhieuKham = @p", new SqlParameter("@p", soPhieu)).Rows[0];

                    if (string.IsNullOrWhiteSpace(chanDoan)) return KetQuaXuLy.Fail("Phải ghi chẩn đoán (hoặc kết luận không bệnh / phát hiện mầm bệnh).");

                    if (r["LoaiKham"].ToString() == "Điều trị")
                    {
                        if (ngayXuatVien == null || string.IsNullOrWhiteSpace(soBienLai)) return KetQuaXuLy.Fail("Chưa xuất viện hoặc chưa thanh toán viện phí (thiếu ngày xuất viện / số biên lai).");
                        if (ngayXuatVien.Value.Date < ((DateTime)r["NgayGioKham"]).Date) return KetQuaXuLy.Fail("Ngày xuất viện không được trước ngày khám.");
                    }

                    Db.Execute(cn, tx, @"UPDATE PhieuKham SET ChanDoan = @c, DienBienBenh = @d, HieuQuaDieuTri = @h, NgayXuatVien = @x, SoBienLaiVienPhi = @b, TrangThai = N'Đã ghi nhận' WHERE SoPhieuKham = @p",
                        new SqlParameter("@c", chanDoan), new SqlParameter("@d", Db.N(dienBien)), new SqlParameter("@h", Db.N(hieuQua)),
                        new SqlParameter("@x", ngayXuatVien.HasValue ? (object)ngayXuatVien.Value.Date : DBNull.Value), new SqlParameter("@b", Db.N(string.IsNullOrWhiteSpace(soBienLai) ? null : soBienLai)), new SqlParameter("@p", soPhieu));

                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã ghi nhận phiếu khám vào hồ sơ bệnh án.");
                }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }
    }
}