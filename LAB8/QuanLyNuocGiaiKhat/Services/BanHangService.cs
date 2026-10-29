using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using QuanLyNuocGiaiKhat.Data;
namespace QuanLyNuocGiaiKhat.Services
{
    public class DongHang { public string MaNGK { get; set; } public int SoLuong { get; set; } }

    public class BanHangService
    {
        static KetQuaXuLy Fail(string m) { return KetQuaXuLy.Fail(m); }
        public DataTable LayKhachHang() { return Db.Query("SELECT MaKH, HoTen + N' (' + LoaiKH + N')' AS Ten FROM KhachHang ORDER BY MaKH"); }
        public DataTable LayNhanVien() { return Db.Query("SELECT MaNV, HoTen FROM NhanVien ORDER BY MaNV"); }
        public DataTable LayNuocGiaiKhat() { return Db.Query("SELECT MaNGK, TenNGK, DonViTinh, DonGiaBan, SoLuongTon FROM NuocGiaiKhat ORDER BY MaNGK"); }
        public int LayTon(string maNGK)
        {
            var o = Db.Scalar("SELECT SoLuongTon FROM NuocGiaiKhat WHERE MaNGK=@m", new SqlParameter("@m", maNGK ?? ""));
            return o == null ? 0 : Convert.ToInt32(o);
        }
        public DataTable LayHoaDon()
        {
            return Db.Query(@"SELECT TOP 50 h.SoHD, k.HoTen AS KhachHang, h.NgayLap, h.TongTien, h.HinhThucTT, h.TrangThaiGiao
                FROM HoaDon h JOIN KhachHang k ON k.MaKH = h.MaKH ORDER BY h.NgayLap DESC");
        }
        public DataTable LayPhieuHenChuaGiao()
        { return Db.Query("SELECT SoPhieuHen, SoHD, NgayHen FROM PhieuHenGiao WHERE TrangThai = N'Chưa giao' ORDER BY NgayHen"); }

        public KetQuaXuLy LapHoaDon(string soHD, string maKH, string maNV, List<DongHang> ds, bool traCham,
            decimal soTienNo, DateTime ngayDuKienTra, string lyDoNo, DateTime ngayHen)
        {
            if (string.IsNullOrWhiteSpace(soHD) || string.IsNullOrWhiteSpace(maKH) || string.IsNullOrWhiteSpace(maNV)) return Fail("Hóa đơn chưa đủ số hóa đơn, khách hàng, nhân viên.");
            if (ds == null || ds.Count == 0) return Fail("Hóa đơn chưa có mặt hàng.");
            if (ds.Select(x => x.MaNGK).Distinct().Count() != ds.Count) return Fail("Mỗi mặt hàng chỉ được xuất hiện một lần trong hóa đơn.");
            using (var cn = Db.OpenConnection()) using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var loai = Db.Scalar(cn, tx, "SELECT LoaiKH FROM KhachHang WHERE MaKH=@k", new SqlParameter("@k", maKH)) as string;
                    if (loai == null) return Fail("Không tìm thấy khách hàng.");
                    bool quen = loai == "Khách quen";
                    if (traCham && !quen) return Fail("Chỉ khách quen mới được trả chậm (BR10).");

                    var gia = new List<decimal>(); var giaoNgay = new List<int>(); bool thieu = false; decimal tong = 0;
                    foreach (var d in ds)
                    {
                        if (d.SoLuong <= 0) return Fail("Số lượng phải > 0.");
                        var r = Db.Query(cn, tx, "SELECT DonGiaBan, SoLuongTon FROM NuocGiaiKhat WHERE MaNGK=@m", new SqlParameter("@m", d.MaNGK));
                        if (r.Rows.Count == 0) return Fail("Không tìm thấy mặt hàng " + d.MaNGK + ".");
                        decimal dg = Convert.ToDecimal(r.Rows[0]["DonGiaBan"]); int ton = Convert.ToInt32(r.Rows[0]["SoLuongTon"]);
                        int gn = Math.Min(d.SoLuong, ton); if (gn < d.SoLuong) thieu = true;
                        gia.Add(dg); giaoNgay.Add(gn); tong += dg * d.SoLuong;
                    }
                    if (thieu && !quen) return Fail("Khách vãng lai chỉ được mua số lượng đang có trong kho (BR09).");
                    if (thieu && ngayHen.Date <= DateTime.Today) return Fail("Thiếu hàng: phải chọn ngày hẹn giao sau ngày hôm nay.");
                    if (traCham)
                    {
                        if (soTienNo <= 0 || soTienNo > tong) return Fail("Số tiền nợ phải > 0 và không vượt tổng tiền hóa đơn (BR12).");
                        if (ngayDuKienTra.Date < DateTime.Today) return Fail("Ngày dự kiến trả không được trước ngày lập phiếu.");
                        if (string.IsNullOrWhiteSpace(lyDoNo)) return Fail("Phải ghi lý do nợ.");
                    }
                    Db.Execute(cn, tx, @"INSERT INTO HoaDon(SoHD,MaKH,MaNV,NgayLap,TongTien,HinhThucTT,TrangThaiGiao) VALUES(@s,@k,@n,GETDATE(),@t,@h,@g)",
                        new SqlParameter("@s", soHD), new SqlParameter("@k", maKH), new SqlParameter("@n", maNV), new SqlParameter("@t", tong),
                        new SqlParameter("@h", traCham ? "Trả chậm" : "Trả ngay"), new SqlParameter("@g", thieu ? "Giao nhiều đợt" : "Đã giao"));
                    for (int i = 0; i < ds.Count; i++)
                    {
                        Db.Execute(cn, tx, "INSERT INTO ChiTietHoaDon(SoHD,STT,MaNGK,SoLuong,DonGia,SoLuongGiaoNgay) VALUES(@s,@i,@m,@sl,@dg,@gn)",
                            new SqlParameter("@s", soHD), new SqlParameter("@i", i + 1), new SqlParameter("@m", ds[i].MaNGK), new SqlParameter("@sl", ds[i].SoLuong),
                            new SqlParameter("@dg", gia[i]), new SqlParameter("@gn", giaoNgay[i]));
                        if (giaoNgay[i] > 0 && Db.Execute(cn, tx, "UPDATE NuocGiaiKhat SET SoLuongTon = SoLuongTon - @sl WHERE MaNGK=@m AND SoLuongTon >= @sl",
                            new SqlParameter("@sl", giaoNgay[i]), new SqlParameter("@m", ds[i].MaNGK)) == 0)
                            return Fail("Tồn kho vừa thay đổi, không đủ hàng cho " + ds[i].MaNGK + ".");
                    }
                    if (thieu)
                    {
                        string ph = "PH-" + soHD;
                        Db.Execute(cn, tx, "INSERT INTO PhieuHenGiao(SoPhieuHen,SoHD,NgayHen,TrangThai) VALUES(@p,@s,@n,N'Chưa giao')", new SqlParameter("@p", ph), new SqlParameter("@s", soHD), new SqlParameter("@n", ngayHen.Date));
                        int stt = 0;
                        for (int i = 0; i < ds.Count; i++)
                        {
                            int con = ds[i].SoLuong - giaoNgay[i];
                            if (con > 0) Db.Execute(cn, tx, "INSERT INTO ChiTietPhieuHen(SoPhieuHen,STT,MaNGK,SoLuong) VALUES(@p,@i,@m,@sl)", new SqlParameter("@p", ph), new SqlParameter("@i", ++stt), new SqlParameter("@m", ds[i].MaNGK), new SqlParameter("@sl", con));
                        }
                    }
                    if (traCham)
                        Db.Execute(cn, tx, @"INSERT INTO PhieuGhiNo(SoPhieuNo,SoHD,MaKH,MaNV,NgayLap,SoTienNo,NgayDuKienTra,LyDoNo,TrangThai) VALUES(@p,@s,@k,@n,CAST(GETDATE() AS date),@t,@d,@l,N'Chưa trả')",
                            new SqlParameter("@p", "GN-" + soHD), new SqlParameter("@s", soHD), new SqlParameter("@k", maKH), new SqlParameter("@n", maNV),
                            new SqlParameter("@t", soTienNo), new SqlParameter("@d", ngayDuKienTra.Date), new SqlParameter("@l", lyDoNo));
                    tx.Commit();
                    return KetQuaXuLy.Ok("Đã lập hóa đơn " + soHD + ", tổng tiền " + tong.ToString("N0") + " đ" + (thieu ? "; phần còn thiếu hẹn giao ngày " + ngayHen.ToString("dd/MM/yyyy") : "") + (traCham ? "; đã lập phiếu ghi nợ." : "."));
                }
                catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) { return Fail("Số hóa đơn đã tồn tại."); }
                catch (Exception ex) { return Fail(ex.Message); }
            }
        }

        // BR13: giao các mặt hàng còn thiếu theo phiếu hẹn khi kho đã đủ hàng
        public KetQuaXuLy GiaoHangTheoPhieuHen(string soPhieuHen)
        {
            if (string.IsNullOrWhiteSpace(soPhieuHen)) return Fail("Chưa chọn phiếu hẹn.");
            using (var cn = Db.OpenConnection()) using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var h = Db.Query(cn, tx, "SELECT SoHD, TrangThai FROM PhieuHenGiao WHERE SoPhieuHen=@p", new SqlParameter("@p", soPhieuHen));
                    if (h.Rows.Count == 0) return Fail("Không tìm thấy phiếu hẹn.");
                    if (h.Rows[0]["TrangThai"].ToString() != "Chưa giao") return Fail("Phiếu hẹn đã được giao.");
                    var ct = Db.Query(cn, tx, "SELECT MaNGK, SoLuong FROM ChiTietPhieuHen WHERE SoPhieuHen=@p ORDER BY STT", new SqlParameter("@p", soPhieuHen));
                    foreach (DataRow r in ct.Rows)
                        if (Db.Execute(cn, tx, "UPDATE NuocGiaiKhat SET SoLuongTon = SoLuongTon - @sl WHERE MaNGK=@m AND SoLuongTon >= @sl",
                            new SqlParameter("@sl", Convert.ToInt32(r["SoLuong"])), new SqlParameter("@m", r["MaNGK"].ToString())) == 0)
                            return Fail("Chưa đủ tồn kho để giao mặt hàng " + r["MaNGK"] + ".");
                    Db.Execute(cn, tx, "UPDATE PhieuHenGiao SET TrangThai=N'Đã giao' WHERE SoPhieuHen=@p", new SqlParameter("@p", soPhieuHen));
                    string soHD = h.Rows[0]["SoHD"].ToString();
                    int conLai = Convert.ToInt32(Db.Scalar(cn, tx, "SELECT COUNT(*) FROM PhieuHenGiao WHERE SoHD=@s AND TrangThai=N'Chưa giao'", new SqlParameter("@s", soHD)));
                    if (conLai == 0) Db.Execute(cn, tx, "UPDATE HoaDon SET TrangThaiGiao=N'Đã giao' WHERE SoHD=@s", new SqlParameter("@s", soHD));
                    tx.Commit(); return KetQuaXuLy.Ok("Đã giao hàng theo phiếu hẹn " + soPhieuHen + ".");
                }
                catch (Exception ex) { return Fail(ex.Message); }
            }
        }
    }
}
