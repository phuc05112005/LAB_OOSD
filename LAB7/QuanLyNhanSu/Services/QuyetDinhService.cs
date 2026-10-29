using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class QuyetDinhService
    {
        public KetQuaXuLy KyDuyetQD(string soQD, bool dongY)
        {
            if (string.IsNullOrWhiteSpace(soQD)) return KetQuaXuLy.Fail("Chưa chọn quyết định.");
            using (var cn = Db.OpenConnection()) using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var r = Db.Query(cn, tx, "SELECT LoaiQD,TrangThai,MaNV FROM QuyetDinh WHERE SoQD=@q", new SqlParameter("@q", soQD));
                    if (r.Rows.Count == 0) return KetQuaXuLy.Fail("Không tìm thấy quyết định.");
                    if (r.Rows[0]["TrangThai"].ToString() != "Chờ ký") return KetQuaXuLy.Fail("Quyết định đã được xử lý, không thể thay đổi.");
                    Db.Execute(cn, tx, "UPDATE QuyetDinh SET TrangThai=@t,NgayKy=CASE WHEN @t=N'Đã ký' THEN CAST(GETDATE() AS date) END WHERE SoQD=@q",
                        new SqlParameter("@t", dongY ? "Đã ký" : "Hủy"), new SqlParameter("@q", soQD));
                    tx.Commit(); return KetQuaXuLy.Ok(dongY ? "Giám đốc đã ký quyết định." : "Đã hủy quyết định.");
                }
                catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
            }
        }
    }
}