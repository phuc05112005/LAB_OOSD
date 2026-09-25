using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    public class DanhMucService
    {
        // =========================
        // LẤY DỮ LIỆU
        // =========================

        public DataTable LayKhuVuc()
        {
            return Db.Query(
                "SELECT * FROM KhuVuc ORDER BY MaKhuVuc"
            );
        }

        public DataTable LayNhanVien()
        {
            return Db.Query(
                "SELECT * FROM NhanVien ORDER BY MaNV"
            );
        }

        public DataTable LayLoaiTienNghi()
        {
            return Db.Query(
                "SELECT * FROM LoaiTienNghi ORDER BY MaLoaiTN"
            );
        }

        public DataTable LayDichVu()
        {
            return Db.Query(
                "SELECT * FROM DichVu ORDER BY MaDV"
            );
        }

        public DataTable LayQuyDinhDenBu()
        {
            return Db.Query(
                @"SELECT q.MaQuyDinh,
                         q.MaLoaiTN,
                         l.TenLoaiTN,
                         q.MucDoThietHai,
                         q.MucDenBu
                  FROM QuyDinhDenBu q
                  JOIN LoaiTienNghi l
                    ON q.MaLoaiTN = l.MaLoaiTN
                  ORDER BY q.MaQuyDinh"
            );
        }


        // =========================
        // THÊM KHU VỰC
        // =========================

        public string ThemKhu(
            string ma,
            string ten)
        {
            if (string.IsNullOrWhiteSpace(ma) ||
                string.IsNullOrWhiteSpace(ten))
            {
                return "Mã khu vực và tên khu vực không được để trống.";
            }

            try
            {
                Db.Execute(
                    @"INSERT INTO KhuVuc(MaKhuVuc, TenKhuVuc)
                      VALUES(@Ma, @Ten)",

                    new SqlParameter("@Ma", ma),
                    new SqlParameter("@Ten", ten)
                );

                return "Đã thêm khu vực.";
            }
            catch (Exception ex)
            {
                return "Không thể thêm khu vực.\n" + ex.Message;
            }
        }


        // =========================
        // THÊM NHÂN VIÊN
        // =========================

        public string ThemNhanVien(
            string ma,
            string ten,
            string vaiTro,
            string sdt)
        {
            if (string.IsNullOrWhiteSpace(ma) ||
                string.IsNullOrWhiteSpace(ten) ||
                string.IsNullOrWhiteSpace(vaiTro))
            {
                return "Thông tin nhân viên chưa đầy đủ.";
            }

            try
            {
                Db.Execute(
                    @"INSERT INTO NhanVien
                        (MaNV, HoTen, VaiTro, SoDienThoai)
                      VALUES
                        (@Ma, @Ten, @VaiTro, @SDT)",

                    new SqlParameter("@Ma", ma),
                    new SqlParameter("@Ten", ten),
                    new SqlParameter("@VaiTro", vaiTro),
                    new SqlParameter(
                        "@SDT",
                        string.IsNullOrWhiteSpace(sdt)
                            ? (object)DBNull.Value
                            : sdt
                    )
                );

                return "Đã thêm nhân viên.";
            }
            catch (Exception ex)
            {
                return "Không thể thêm nhân viên.\n" + ex.Message;
            }
        }


        // =========================
        // THÊM LOẠI TIỆN NGHI
        // =========================

        public string ThemLoaiTN(
            string ma,
            string ten)
        {
            if (string.IsNullOrWhiteSpace(ma) ||
                string.IsNullOrWhiteSpace(ten))
            {
                return "Thông tin loại tiện nghi chưa đầy đủ.";
            }

            try
            {
                Db.Execute(
                    @"INSERT INTO LoaiTienNghi
                        (MaLoaiTN, TenLoaiTN)
                      VALUES(@Ma, @Ten)",

                    new SqlParameter("@Ma", ma),
                    new SqlParameter("@Ten", ten)
                );

                return "Đã thêm loại tiện nghi.";
            }
            catch (Exception ex)
            {
                return "Không thể thêm loại tiện nghi.\n" + ex.Message;
            }
        }


        // =========================
        // THÊM DỊCH VỤ
        // =========================

        public string ThemDichVu(
            string ma,
            string ten,
            string dvt,
            decimal gia)
        {
            if (string.IsNullOrWhiteSpace(ma) ||
                string.IsNullOrWhiteSpace(ten) ||
                string.IsNullOrWhiteSpace(dvt) ||
                gia < 0)
            {
                return "Thông tin dịch vụ không hợp lệ.";
            }

            try
            {
                Db.Execute(
                    @"INSERT INTO DichVu
                        (MaDV, TenDV, DonViTinh, DonGia)
                      VALUES
                        (@Ma, @Ten, @DVT, @Gia)",

                    new SqlParameter("@Ma", ma),
                    new SqlParameter("@Ten", ten),
                    new SqlParameter("@DVT", dvt),
                    new SqlParameter("@Gia", gia)
                );

                return "Đã thêm dịch vụ.";
            }
            catch (Exception ex)
            {
                return "Không thể thêm dịch vụ.\n" + ex.Message;
            }
        }


        // =========================
        // THÊM QUY ĐỊNH ĐỀN BÙ
        // =========================

        public string ThemQuyDinh(
            string ma,
            string maLoai,
            string mucDo,
            decimal tien)
        {
            if (string.IsNullOrWhiteSpace(ma) ||
                string.IsNullOrWhiteSpace(maLoai) ||
                string.IsNullOrWhiteSpace(mucDo) ||
                tien < 0)
            {
                return "Quy định đền bù không hợp lệ.";
            }

            try
            {
                Db.Execute(
                    @"INSERT INTO QuyDinhDenBu
                        (MaQuyDinh, MaLoaiTN,
                         MucDoThietHai, MucDenBu)
                      VALUES
                        (@Ma, @Loai, @MucDo, @Tien)",

                    new SqlParameter("@Ma", ma),
                    new SqlParameter("@Loai", maLoai),
                    new SqlParameter("@MucDo", mucDo),
                    new SqlParameter("@Tien", tien)
                );

                return "Đã thêm quy định đền bù.";
            }
            catch (Exception ex)
            {
                return "Không thể thêm quy định đền bù.\n" + ex.Message;
            }
        }
    }
}