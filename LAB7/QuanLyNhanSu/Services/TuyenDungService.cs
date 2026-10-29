using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class TuyenDungService
    {
        public DataTable LayQDTuyenDung() { return Db.Query(@"SELECT q.SoQD,n.HoTen,p.TenPB,d.ThoiGianThuViec,d.NgayBatDauThuViec,d.LuongThuViec,q.TrangThai
            FROM QuyetDinh q JOIN QDTuyenDung d ON d.SoQD=q.SoQD JOIN NhanVien n ON n.MaNV=q.MaNV JOIN PhongBan p ON p.MaPB=q.MaPB ORDER BY q.SoQD DESC"); }
        public DataTable LayHopDong() { return Db.Query("SELECT h.*,n.HoTen FROM HopDong h JOIN NhanVien n ON n.MaNV=h.MaNV ORDER BY h.NgayKy DESC"); }
        public DataTable LayHopDongDaiHan() { return Db.Query("SELECT h.SoHD,h.SoHD+N' - '+n.HoTen AS Ten FROM HopDong h JOIN NhanVien n ON n.MaNV=h.MaNV WHERE h.LoaiHD=N'Dài hạn' AND h.TrangThai=N'Hiệu lực' AND NOT EXISTS(SELECT 1 FROM HoSoBaoHiem b WHERE b.SoHD=h.SoHD)"); }

        public KetQuaXuLy LapQDTuyenDung(string soQD, string maNV, string maPB, int thang, DateTime ngayBD, decimal luong, string dieuKhoan, string maNVKy)
        {
            if (string.IsNullOrWhiteSpace(soQD) || string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(maPB) || string.IsNullOrWhiteSpace(maNVKy)) return KetQuaXuLy.Fail("Quyết định tuyển dụng chưa đủ thông tin.");
            if (thang <= 0 || luong < 0) return KetQuaXuLy.Fail("Thời gian thử việc phải > 0 và lương thử việc >= 0.");
            using (var cn = Db.OpenConnection()) using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var tt = Db.Scalar(cn, tx, "SELECT TrangThai FROM NhanVien WHERE MaNV=@m", new SqlParameter("@m", maNV)) as string;
                    if (tt != "Thử việc") return KetQuaXuLy.Fail("Chỉ nhân viên ở trạng thái Thử việc mới được lập quyết định tuyển dụng.");
                    Db.ThemQuyetDinh(cn, tx, soQD, "TD", ngayBD, "Tuyển dụng thử việc " + thang + " tháng", maNVKy, maNV, maPB);
                    Db.Execute(cn, tx, "INSERT INTO QDTuyenDung VALUES(@q,@t,@b,@l,@d)", new SqlParameter("@q", soQD), new SqlParameter("@t", thang),
                        new SqlParameter("@b", ngayBD.Date), new SqlParameter("@l", luong), new SqlParameter("@d", (object)dieuKhoan ?? DBNull.Value));
                    tx.Commit(); return KetQuaXuLy.Ok("Đã lập quyết định tuyển dụng, chờ giám đốc ký.");
                }
                catch (SqlException ex) when (ex.Number == 2627) { return KetQuaXuLy.Fail("Số quyết định đã tồn tại."); }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }

        public KetQuaXuLy KyDuyetQD(string soQD, bool dongY) { return new QuyetDinhService().KyDuyetQD(soQD, dongY); }

        public KetQuaXuLy DanhGiaThuViec(string maNV, bool dat)
        {
            if (string.IsNullOrWhiteSpace(maNV)) return KetQuaXuLy.Fail("Chưa chọn nhân viên.");
            if (dat) return KetQuaXuLy.Ok("Đạt thử việc - tiếp tục ký hợp đồng chính thức.");
            Db.Execute("UPDATE NhanVien SET TrangThai=N'Đã nghỉ' WHERE MaNV=@m AND TrangThai=N'Thử việc'", new SqlParameter("@m", maNV));
            return KetQuaXuLy.Ok("Không đạt - đã chấm dứt thử việc.");
        }

        public KetQuaXuLy KyHopDong(string soHD, string maNV, string loai, DateTime bd, DateTime? kt)
        {
            if (string.IsNullOrWhiteSpace(soHD) || string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(loai)) return KetQuaXuLy.Fail("Hợp đồng chưa đủ thông tin.");
            if (loai == "Ngắn hạn" && kt == null) return KetQuaXuLy.Fail("Hợp đồng ngắn hạn phải có ngày kết thúc.");
            if (kt != null && kt.Value.Date < bd.Date) return KetQuaXuLy.Fail("Ngày kết thúc không được trước ngày bắt đầu.");
            using (var cn = Db.OpenConnection()) using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var tt = Db.Scalar(cn, tx, "SELECT TrangThai FROM NhanVien WHERE MaNV=@m", new SqlParameter("@m", maNV)) as string;
                    if (tt != "Thử việc") return KetQuaXuLy.Fail("Chỉ nhân viên đang thử việc mới ký hợp đồng chính thức.");
                    var qd = Db.Scalar(cn, tx, @"SELECT TOP 1 d.SoQD FROM QDTuyenDung d JOIN QuyetDinh q ON q.SoQD=d.SoQD
                        WHERE q.MaNV=@m AND q.TrangThai=N'Đã ký' AND DATEADD(MONTH,d.ThoiGianThuViec,d.NgayBatDauThuViec)<=@b ORDER BY q.NgayHieuLuc DESC",
                        new SqlParameter("@m", maNV), new SqlParameter("@b", bd.Date)) as string;
                    if (qd == null) return KetQuaXuLy.Fail("Nhân viên chưa hết thời gian thử việc hoặc chưa có quyết định tuyển dụng đã ký.");
                    Db.Execute(cn, tx, "INSERT INTO HopDong VALUES(@h,@m,@q,@l,CAST(GETDATE() AS date),@b,@k,N'Hiệu lực')", new SqlParameter("@h", soHD), new SqlParameter("@m", maNV),
                        new SqlParameter("@q", qd), new SqlParameter("@l", loai), new SqlParameter("@b", bd.Date), new SqlParameter("@k", kt.HasValue ? (object)kt.Value.Date : DBNull.Value));
                    Db.Execute(cn, tx, "UPDATE NhanVien SET TrangThai=N'Chính thức' WHERE MaNV=@m", new SqlParameter("@m", maNV));
                    tx.Commit(); return KetQuaXuLy.Ok("Đã ký hợp đồng chính thức." + (loai == "Dài hạn" ? " Hãy lập hồ sơ BHYT, BHXH." : ""));
                }
                catch (SqlException ex) when (ex.Number == 2627) { return KetQuaXuLy.Fail("Số hợp đồng đã tồn tại."); }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }

        public KetQuaXuLy LapHoSoBaoHiem(string ma, string soHD, string bhxh, string bhyt, DateTime ngay, decimal xh, decimal yt)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(soHD) || string.IsNullOrWhiteSpace(bhxh) || string.IsNullOrWhiteSpace(bhyt)) return KetQuaXuLy.Fail("Hồ sơ bảo hiểm chưa đủ thông tin.");
            if (xh < 0 || yt < 0 || xh > 1 || yt > 1) return KetQuaXuLy.Fail("Mức đóng phải trong khoảng 0 đến 1 (ví dụ 0.08 = 8%).");
            try
            {
                var loai = Db.Scalar("SELECT LoaiHD FROM HopDong WHERE SoHD=@h", new SqlParameter("@h", soHD)) as string;
                if (loai != "Dài hạn") return KetQuaXuLy.Fail("Chỉ hợp đồng dài hạn mới lập hồ sơ BHYT, BHXH.");
                Db.Execute("INSERT INTO HoSoBaoHiem VALUES(@m,@h,@x,@y,@n,@xh,@yt)", new SqlParameter("@m", ma), new SqlParameter("@h", soHD), new SqlParameter("@x", bhxh),
                    new SqlParameter("@y", bhyt), new SqlParameter("@n", ngay.Date), new SqlParameter("@xh", xh), new SqlParameter("@yt", yt));
                return KetQuaXuLy.Ok("Đã lập hồ sơ BHYT, BHXH.");
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return KetQuaXuLy.Fail("Hợp đồng đã có hồ sơ bảo hiểm hoặc mã trùng."); }
            catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
        }
    }
}