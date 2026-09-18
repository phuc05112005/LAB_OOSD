using System.Data;
using QuanLyThuVien.Data;

namespace QuanLyThuVien.Services
{
    public class DocGiaService
    {
        public DataTable LayDanhSach()
        {
            return Db.Query(@"
                SELECT 
                    dg.MaDocGia,
                    dg.Ho,
                    dg.Ten,
                    dg.NgaySinh,
                    dg.Phai,
                    dg.SoDienThoai,
                    dg.DiaChi,
                    dg.Email,
                    dg.Anh3x4,
                    t.MaThe,
                    t.NgayCap,
                    t.HanSuDung,
                    t.DaDongLePhi,
                    t.TrangThai
                FROM DocGia dg
                OUTER APPLY
                (
                    SELECT TOP 1 *
                    FROM TheDocGia x
                    WHERE x.MaDocGia = dg.MaDocGia
                    ORDER BY 
                        x.TrangThai DESC,
                        x.HanSuDung DESC
                ) t
                ORDER BY dg.MaDocGia
            ");
        }
    }
}