using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class DanhMucService
    {
        public DataTable LayPhongBan() { return Db.Query(@"SELECT p.*,(SELECT COUNT(*) FROM NhanVien n WHERE n.MaPB=p.MaPB) SoNhanVien FROM PhongBan p ORDER BY p.MaPB"); }
        public DataTable LayChucVu() { return Db.Query("SELECT * FROM ChucVu ORDER BY MaCV"); }
        public DataTable LayCaLamViec() { return Db.Query("SELECT * FROM CaLamViec ORDER BY MaCa"); }
        public DataTable LayNhanVien() { return Db.Query("SELECT n.*,p.TenPB FROM NhanVien n JOIN PhongBan p ON p.MaPB=n.MaPB ORDER BY n.MaNV"); }
        public DataTable LayNhanVienTheoTrangThai(string tt) { return Db.Query("SELECT MaNV,HoTen+N' ('+MaNV+')' AS Ten FROM NhanVien WHERE TrangThai=@t ORDER BY MaNV", new SqlParameter("@t", tt)); }
        public DataTable LayNhanVienDangLam() { return Db.Query("SELECT MaNV,HoTen+N' ('+MaNV+')' AS Ten FROM NhanVien WHERE TrangThai<>N'Đã nghỉ' ORDER BY MaNV"); }

        private KetQuaXuLy Chay(string sql, string ok, params SqlParameter[] ps)
        {
            try { Db.Execute(sql, ps); return KetQuaXuLy.Ok(ok); }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return KetQuaXuLy.Fail("Mã hoặc dữ liệu duy nhất (tên, CCCD) đã tồn tại."); }
            catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
        }

        public KetQuaXuLy ThemPhongBan(string ma, string ten, string loai, string moTa)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(loai)) return KetQuaXuLy.Fail("Mã, tên và loại đơn vị không được để trống.");
            return Chay("INSERT INTO PhongBan VALUES(@m,@t,@l,@d)", "Đã thêm phòng ban.", new SqlParameter("@m", ma), new SqlParameter("@t", ten), new SqlParameter("@l", loai), new SqlParameter("@d", (object)moTa ?? DBNull.Value));
        }

        public KetQuaXuLy ThemChucVu(string ma, string ten, string moTa)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten)) return KetQuaXuLy.Fail("Mã và tên chức vụ không được để trống.");
            return Chay("INSERT INTO ChucVu VALUES(@m,@t,@d)", "Đã thêm chức vụ.", new SqlParameter("@m", ma), new SqlParameter("@t", ten), new SqlParameter("@d", (object)moTa ?? DBNull.Value));
        }

        public KetQuaXuLy ThemCa(string ma, string ten, TimeSpan bd, TimeSpan kt)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten)) return KetQuaXuLy.Fail("Thông tin ca chưa đầy đủ.");
            if (kt == bd) return KetQuaXuLy.Fail("Giờ kết thúc phải khác giờ bắt đầu.");
            return Chay("INSERT INTO CaLamViec VALUES(@m,@t,@b,@k)", "Đã thêm ca làm việc.", new SqlParameter("@m", ma), new SqlParameter("@t", ten), new SqlParameter("@b", bd), new SqlParameter("@k", kt));
        }

        public KetQuaXuLy ThemNhanVien(string ma, string ten, DateTime ns, string gt, string cccd, string diaChi, string sdt, string maPB)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(cccd) || string.IsNullOrWhiteSpace(maPB)) return KetQuaXuLy.Fail("Thông tin nhân viên chưa đầy đủ.");
            if (ns.Date > DateTime.Today.AddYears(-18)) return KetQuaXuLy.Fail("Nhân viên phải đủ 18 tuổi.");
            return Chay("INSERT INTO NhanVien VALUES(@m,@t,@ns,@gt,@c,@dc,@s,@pb,N'Thử việc')", "Đã lập hồ sơ nhân viên.",
                new SqlParameter("@m", ma), new SqlParameter("@t", ten), new SqlParameter("@ns", ns.Date), new SqlParameter("@gt", gt), new SqlParameter("@c", cccd),
                new SqlParameter("@dc", (object)diaChi ?? DBNull.Value), new SqlParameter("@s", (object)sdt ?? DBNull.Value), new SqlParameter("@pb", maPB));
        }
    }
}