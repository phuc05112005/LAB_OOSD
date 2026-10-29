using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyNuocGiaiKhat.Data;
namespace QuanLyNuocGiaiKhat.Services
{
    public class DongDat { public string MaNGK { get; set; } public int SoLuong { get; set; } }
    public class DongGiao { public string MaNGK { get; set; } public int SoLuong { get; set; } public decimal DonGia { get; set; } }

    public class NhapHangService
    {
        static KetQuaXuLy Fail(string m) { return KetQuaXuLy.Fail(m); }
        public DataTable LayNhaCungUng() { return Db.Query("SELECT MaNCU, TenNCU FROM NhaCungUng ORDER BY MaNCU"); }
        public DataTable LayNhanVien() { return Db.Query("SELECT MaNV, HoTen FROM NhanVien ORDER BY MaNV"); }
        public DataTable LayNGKTheoNCU(string maNCU) { return Db.Query("SELECT MaNGK, TenNGK FROM NuocGiaiKhat WHERE MaNCU=@n ORDER BY MaNGK", new SqlParameter("@n", maNCU ?? "")); }
        public DataTable LayDonDatHang()
        {
            return Db.Query(@"SELECT TOP 50 d.SoDDH, n.TenNCU, d.NgayDat, d.NgayNhanDuKien, d.TrangThai,
                (SELECT COUNT(*) FROM PhieuGiaoHang p WHERE p.SoDDH = d.SoDDH) AS SoDotDaGiao
                FROM DonDatHang d JOIN NhaCungUng n ON n.MaNCU = d.MaNCU ORDER BY d.NgayDat DESC");
        }
        public KetQuaXuLy LapDonDatHang(string soDDH, string maNCU, string maNV, DateTime ngayNhanDuKien, List<DongDat> ds)
        {
            if (string.IsNullOrWhiteSpace(soDDH) || string.IsNullOrWhiteSpace(maNCU) || string.IsNullOrWhiteSpace(maNV)) return Fail("Đơn đặt hàng chưa đủ số đơn, nhà cung ứng, nhân viên.");
            if (ds == null || ds.Count == 0) return Fail("Đơn đặt hàng chưa có mặt hàng.");
            if (ngayNhanDuKien.Date < DateTime.Today) return Fail("Ngày nhận dự kiến không được trước ngày đặt.");
            using (var cn = Db.OpenConnection()) using (var tx = cn.BeginTransaction())
            {
                try
                {
                    foreach (var d in ds)
                    {
                        if (d.SoLuong <= 0) return Fail("Số lượng đặt phải > 0.");
                        var ncu = Db.Scalar(cn, tx, "SELECT MaNCU FROM NuocGiaiKhat WHERE MaNGK=@m", new SqlParameter("@m", d.MaNGK)) as string;
                        if (ncu == null) return Fail("Không tìm thấy mặt hàng " + d.MaNGK + ".");
                        if (ncu != maNCU) return Fail("Mặt hàng " + d.MaNGK + " không thuộc nhà cung ứng đã chọn (mỗi NGK chỉ nhập từ một NCU).");
                    }
                    Db.Execute(cn, tx, "INSERT INTO DonDatHang(SoDDH,MaNCU,MaNV,NgayDat,NgayNhanDuKien,TrangThai) VALUES(@s,@c,@n,CAST(GETDATE() AS date),@d,N'Đã đặt')",
                        new SqlParameter("@s", soDDH), new SqlParameter("@c", maNCU), new SqlParameter("@n", maNV), new SqlParameter("@d", ngayNhanDuKien.Date));
                    for (int i = 0; i < ds.Count; i++)
                        Db.Execute(cn, tx, "INSERT INTO ChiTietDonDatHang(SoDDH,STT,MaNGK,SoLuongDat) VALUES(@s,@i,@m,@sl)", new SqlParameter("@s", soDDH), new SqlParameter("@i", i + 1), new SqlParameter("@m", ds[i].MaNGK), new SqlParameter("@sl", ds[i].SoLuong));
                    tx.Commit(); return KetQuaXuLy.Ok("Đã lập đơn đặt hàng " + soDDH + " gửi nhà cung ứng.");
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return Fail("Số đơn đặt hàng đã tồn tại hoặc mặt hàng bị lặp."); }
                catch (Exception ex) { return Fail(ex.Message); }
            }
        }
        public KetQuaXuLy GhiNhanPhieuGiao(string soPhieu, string soDDH, DateTime ngayGiao, List<DongGiao> ds)
        {
            if (string.IsNullOrWhiteSpace(soPhieu) || string.IsNullOrWhiteSpace(soDDH) || ds == null || ds.Count == 0) return Fail("Phiếu giao chưa đủ thông tin.");
            using (var cn = Db.OpenConnection()) using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var tt = Db.Scalar(cn, tx, "SELECT TrangThai FROM DonDatHang WHERE SoDDH=@d", new SqlParameter("@d", soDDH)) as string;
                    if (tt == null) return Fail("Không tìm thấy đơn đặt hàng.");
                    if (tt == "Đã giao đủ") return Fail("Đơn đặt hàng đã được giao đủ.");
                    int dot = Convert.ToInt32(Db.Scalar(cn, tx, "SELECT COUNT(*) FROM PhieuGiaoHang WHERE SoDDH=@d", new SqlParameter("@d", soDDH))) + 1;
                    if (dot > 3) return Fail("Mỗi đơn đặt hàng chỉ được giao tối đa 3 đợt (BR05).");
                    decimal tong = 0;
                    foreach (var d in ds)
                    {
                        if (d.SoLuong <= 0 || d.DonGia < 0) return Fail("Số lượng giao phải > 0 và đơn giá >= 0.");
                        var dat = Db.Scalar(cn, tx, "SELECT SoLuongDat FROM ChiTietDonDatHang WHERE SoDDH=@d AND MaNGK=@m", new SqlParameter("@d", soDDH), new SqlParameter("@m", d.MaNGK));
                        if (dat == null) return Fail("Mặt hàng " + d.MaNGK + " không có trong đơn đặt hàng.");
                        int daGiao = Convert.ToInt32(Db.Scalar(cn, tx, @"SELECT ISNULL(SUM(c.SoLuongGiao),0) FROM ChiTietPhieuGiao c JOIN PhieuGiaoHang p ON p.SoPhieuGiao=c.SoPhieuGiao
                            WHERE p.SoDDH=@d AND c.MaNGK=@m", new SqlParameter("@d", soDDH), new SqlParameter("@m", d.MaNGK)));
                        if (daGiao + d.SoLuong > Convert.ToInt32(dat)) return Fail("Mặt hàng " + d.MaNGK + ": tổng số giao vượt số lượng đặt (" + dat + ") (BR06).");
                        tong += d.SoLuong * d.DonGia;
                    }
                    Db.Execute(cn, tx, "INSERT INTO PhieuGiaoHang(SoPhieuGiao,SoDDH,DotGiao,NgayGiao,SoTienPhaiTra) VALUES(@p,@d,@t,@n,@tien)",
                        new SqlParameter("@p", soPhieu), new SqlParameter("@d", soDDH), new SqlParameter("@t", dot), new SqlParameter("@n", ngayGiao.Date), new SqlParameter("@tien", tong));
                    for (int i = 0; i < ds.Count; i++)
                    {
                        Db.Execute(cn, tx, "INSERT INTO ChiTietPhieuGiao(SoPhieuGiao,STT,MaNGK,SoLuongGiao,DonGiaNhap) VALUES(@p,@i,@m,@sl,@dg)",
                            new SqlParameter("@p", soPhieu), new SqlParameter("@i", i + 1), new SqlParameter("@m", ds[i].MaNGK), new SqlParameter("@sl", ds[i].SoLuong), new SqlParameter("@dg", ds[i].DonGia));
                        Db.Execute(cn, tx, "UPDATE NuocGiaiKhat SET SoLuongTon = SoLuongTon + @sl WHERE MaNGK=@m", new SqlParameter("@sl", ds[i].SoLuong), new SqlParameter("@m", ds[i].MaNGK));
                    }
                    int conThieu = Convert.ToInt32(Db.Scalar(cn, tx, @"SELECT ISNULL(SUM(d.SoLuongDat),0) - ISNULL((SELECT SUM(c.SoLuongGiao) FROM ChiTietPhieuGiao c JOIN PhieuGiaoHang p ON p.SoPhieuGiao=c.SoPhieuGiao WHERE p.SoDDH=@d),0)
                        FROM ChiTietDonDatHang d WHERE d.SoDDH=@d", new SqlParameter("@d", soDDH)));
                    Db.Execute(cn, tx, "UPDATE DonDatHang SET TrangThai=@t WHERE SoDDH=@d", new SqlParameter("@t", conThieu == 0 ? "Đã giao đủ" : "Đang giao"), new SqlParameter("@d", soDDH));
                    tx.Commit(); return KetQuaXuLy.Ok("Đã nhận hàng đợt " + dot + ", tiền phải trả " + tong.ToString("N0") + " đ.");
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return Fail("Số phiếu giao đã tồn tại hoặc đợt giao bị trùng."); }
                catch (Exception ex) { return Fail(ex.Message); }
            }
        }
    }
}
