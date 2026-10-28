using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    public class DanhMucService
    {
        public DataTable LayKhoa() { return Db.Query("SELECT * FROM Khoa ORDER BY MaKhoa"); }
        public DataTable LayBacSi() { return Db.Query("SELECT b.*, k.TenKhoa FROM BacSi b JOIN Khoa k ON k.MaKhoa = b.MaKhoa ORDER BY b.MaBS"); }
        public DataTable LayBacSiTheoKhoa(string maKhoa) { return Db.Query("SELECT MaBS, HoTen FROM BacSi WHERE MaKhoa = @k ORDER BY HoTen", new SqlParameter("@k", maKhoa ?? "")); }
        public DataTable LayNhanVien() { return Db.Query("SELECT * FROM NhanVien ORDER BY MaNV"); }
        public DataTable LayTrieuChung() { return Db.Query("SELECT * FROM TrieuChung ORDER BY MaTC"); }
        public DataTable LayThuoc() { return Db.Query("SELECT * FROM Thuoc ORDER BY MaThuoc"); }
        public DataTable LayXetNghiem() { return Db.Query("SELECT * FROM XetNghiem ORDER BY MaXN"); }

        private KetQuaXuLy Chay(string sql, string ok, params SqlParameter[] ps)
        {
            try
            {
                Db.Execute(sql, ps);
                return KetQuaXuLy.Ok(ok);
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                return KetQuaXuLy.Fail("Mã hoặc tên đã tồn tại.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }

        private static bool Trong(params string[] a)
        {
            foreach (var x in a)
                if (string.IsNullOrWhiteSpace(x)) return true;
            return false;
        }

        public KetQuaXuLy ThemKhoa(string ma, string ten)
        {
            if (Trong(ma, ten)) return KetQuaXuLy.Fail("Mã và tên khoa không được để trống.");
            return Chay("INSERT INTO Khoa VALUES(@m, @t)", "Đã thêm khoa.", new SqlParameter("@m", ma), new SqlParameter("@t", ten));
        }

        public KetQuaXuLy ThemBacSi(string ma, string ten, string chuyenMon, string dt, string maKhoa)
        {
            if (Trong(ma, ten, maKhoa)) return KetQuaXuLy.Fail("Thông tin bác sĩ chưa đầy đủ.");
            return Chay("INSERT INTO BacSi VALUES(@m, @t, @c, @d, @k)", "Đã thêm bác sĩ.", new SqlParameter("@m", ma), new SqlParameter("@t", ten), new SqlParameter("@c", Db.N(chuyenMon)), new SqlParameter("@d", Db.N(dt)), new SqlParameter("@k", maKhoa));
        }

        public KetQuaXuLy ThemNhanVien(string ma, string ten, string chucDanh, string dt)
        {
            if (Trong(ma, ten, chucDanh)) return KetQuaXuLy.Fail("Thông tin nhân viên chưa đầy đủ.");
            return Chay("INSERT INTO NhanVien VALUES(@m, @t, @c, @d)", "Đã thêm nhân viên.", new SqlParameter("@m", ma), new SqlParameter("@t", ten), new SqlParameter("@c", chucDanh), new SqlParameter("@d", Db.N(dt)));
        }

        public KetQuaXuLy ThemTrieuChung(string ma, string ten, string donVi)
        {
            if (Trong(ma, ten)) return KetQuaXuLy.Fail("Mã và tên triệu chứng không được để trống.");
            return Chay("INSERT INTO TrieuChung VALUES(@m, @t, @d)", "Đã thêm triệu chứng.", new SqlParameter("@m", ma), new SqlParameter("@t", ten), new SqlParameter("@d", Db.N(donVi)));
        }

        public KetQuaXuLy ThemThuoc(string ma, string ten, string dvt)
        {
            if (Trong(ma, ten, dvt)) return KetQuaXuLy.Fail("Thông tin thuốc chưa đầy đủ.");
            return Chay("INSERT INTO Thuoc VALUES(@m, @t, @d)", "Đã thêm thuốc.", new SqlParameter("@m", ma), new SqlParameter("@t", ten), new SqlParameter("@d", dvt));
        }

        public KetQuaXuLy ThemXetNghiem(string ma, string ten, string moTa)
        {
            if (Trong(ma, ten)) return KetQuaXuLy.Fail("Mã và tên xét nghiệm không được để trống.");
            return Chay("INSERT INTO XetNghiem VALUES(@m, @t, @d)", "Đã thêm xét nghiệm.", new SqlParameter("@m", ma), new SqlParameter("@t", ten), new SqlParameter("@d", Db.N(moTa)));
        }
    }
}