using System.Data;
using System.Data.SqlClient;
using QuanLyThuVien.Data;

namespace QuanLyThuVien.Services
{
    public class SachService
    {
        public DataTable LayDanhSach(string tuKhoa)
        {
            string sql = @"
                SELECT 
                    s.MaDauSach,
                    s.TenSach,
                    s.NamXuatBan,
                    s.SoLuongHienCo,
                    s.MaTheLoai,
                    tl.TenTheLoai,
                    s.MaNhaXuatBan,
                    nxb.DiaChi AS DiaChiNXB,
                    nxb.SoDienThoai AS SDTNXB
                FROM DauSach s
                JOIN TheLoai tl 
                    ON tl.MaTheLoai = s.MaTheLoai
                JOIN NhaXuatBan nxb 
                    ON nxb.MaNhaXuatBan = s.MaNhaXuatBan
                WHERE 
                    (@TuKhoa = ''
                    OR s.MaDauSach LIKE @Like
                    OR s.TenSach LIKE @Like)
                ORDER BY s.MaDauSach";

            string key = (tuKhoa ?? string.Empty).Trim();

            return Db.Query(
                sql,
                new SqlParameter("@TuKhoa", key),
                new SqlParameter("@Like", "%" + key + "%")
            );
        }
    }
}