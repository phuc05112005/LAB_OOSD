using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    public class DatPhongService
    {
        // =========================
        // LẤY KHÁCH HÀNG
        // =========================
        public DataTable LayKhach()
        {
            return Db.Query(
                "SELECT * FROM KhachHang ORDER BY HoTen"
            );
        }

        // =========================
        // LẤY PHÒNG
        // =========================
        public DataTable LayPhong()
        {
            return Db.Query(
                @"SELECT p.*, k.TenKhuVuc
                  FROM Phong p
                  JOIN KhuVuc k
                    ON p.MaKhuVuc = k.MaKhuVuc
                  ORDER BY p.SoPhong"
            );
        }

        // =========================
        // LẤY PHIẾU ĐẶT
        // =========================
        public DataTable LayPhieuDat()
        {
            return Db.Query(
                @"SELECT d.*, k.HoTen
                  FROM PhieuDatPhong d
                  JOIN KhachHang k
                    ON d.MaKhach = k.MaKhach
                  ORDER BY d.NgayLap DESC"
            );
        }

        // =========================
        // CHI TIẾT PHIẾU
        // =========================
        public DataTable LayChiTiet(string soPhieu)
        {
            return Db.Query(
                @"SELECT c.*,
                         p.SoNguoiToiDa,
                         p.DonGiaNgay
                  FROM ChiTietDatPhong c
                  JOIN Phong p
                    ON c.SoPhong = p.SoPhong
                  WHERE c.SoPhieuDat = @So",

                new SqlParameter("@So", soPhieu)
            );
        }

        // =========================
        // NGƯỜI LƯU TRÚ
        // =========================
        public DataTable LayNguoiLuuTru(string soPhieu)
        {
            return Db.Query(
                @"SELECT *
                  FROM NguoiLuuTru
                  WHERE SoPhieuDat = @So
                  ORDER BY SoPhong, MaNguoiLT",

                new SqlParameter("@So", soPhieu)
            );
        }

        // =========================
        // THÊM KHÁCH
        // =========================
        public string ThemKhach(
            string ma,
            string ten,
            string cmnd,
            string quocTich,
            string sdt)
        {
            if (string.IsNullOrWhiteSpace(ma) ||
                string.IsNullOrWhiteSpace(ten) ||
                string.IsNullOrWhiteSpace(cmnd) ||
                string.IsNullOrWhiteSpace(quocTich))
            {
                return "Thông tin khách hàng chưa đầy đủ.";
            }

            try
            {
                Db.Execute(
                    @"INSERT INTO KhachHang
                      (
                          MaKhach,
                          HoTen,
                          SoCMND,
                          QuocTich,
                          SoDienThoai
                      )
                      VALUES
                      (
                          @Ma,
                          @Ten,
                          @CMND,
                          @QT,
                          @SDT
                      )",

                    new SqlParameter("@Ma", ma),
                    new SqlParameter("@Ten", ten),
                    new SqlParameter("@CMND", cmnd),
                    new SqlParameter("@QT", quocTich),
                    new SqlParameter("@SDT", sdt)
                );

                return "Đã lưu khách hàng.";
            }
            catch (Exception ex)
            {
                return "Không thể thêm khách hàng.\n" + ex.Message;
            }
        }

        // =========================
        // KIỂM TRA TRÙNG LỊCH
        // =========================
        private bool PhongTrungLich(
            SqlConnection cn,
            SqlTransaction tx,
            string soPhong,
            DateTime ngayNhan,
            DateTime ngayTra)
        {
            SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*)
                  FROM ChiTietDatPhong c
                  JOIN PhieuDatPhong d
                    ON c.SoPhieuDat = d.SoPhieuDat
                  WHERE c.SoPhong = @Phong
                    AND d.TrangThai IN (N'Đã đặt', N'Đang ở')
                    AND @Nhan <= d.NgayTraDuKien
                    AND @Tra >= d.NgayNhan",
                cn,
                tx
            );

            cmd.Parameters.AddWithValue(
                "@Phong",
                soPhong
            );

            cmd.Parameters.AddWithValue(
                "@Nhan",
                ngayNhan.Date
            );

            cmd.Parameters.AddWithValue(
                "@Tra",
                ngayTra.Date
            );

            return Convert.ToInt32(
                cmd.ExecuteScalar()
            ) > 0;
        }

        // =========================
        // TẠO PHIẾU ĐẶT PHÒNG
        // =========================
        public string TaoDatPhong(
            string soPhieu,
            string maKhach,
            string maNV,
            DateTime ngayLap,
            DateTime ngayNhan,
            DateTime ngayTra,
            decimal tienCoc,
            string kenhDat,
            List<PhongDatItem> danhSachPhong)
        {
            if (string.IsNullOrWhiteSpace(soPhieu) ||
                string.IsNullOrWhiteSpace(maKhach) ||
                string.IsNullOrWhiteSpace(maNV) ||
                danhSachPhong == null ||
                danhSachPhong.Count == 0)
            {
                return "Phiếu đặt phòng chưa đủ thông tin.";
            }

            if (ngayTra.Date < ngayNhan.Date)
            {
                return "Ngày trả dự kiến không được trước ngày nhận.";
            }

            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    foreach (PhongDatItem item in danhSachPhong)
                    {
                        SqlCommand cmd = new SqlCommand(
                            @"SELECT SoNguoiToiDa
                              FROM Phong
                              WHERE SoPhong = @Phong",
                            cn,
                            tx
                        );

                        cmd.Parameters.AddWithValue(
                            "@Phong",
                            item.SoPhong
                        );

                        object value =
                            cmd.ExecuteScalar();

                        if (value == null)
                        {
                            return "Không tìm thấy phòng " +
                                   item.SoPhong;
                        }

                        int sucChua =
                            Convert.ToInt32(value);

                        if (item.SoNguoi <= 0 ||
                            item.SoNguoi > sucChua)
                        {
                            return "Số người của phòng " +
                                   item.SoPhong +
                                   " vượt sức chứa.";
                        }

                        if (PhongTrungLich(
                            cn,
                            tx,
                            item.SoPhong,
                            ngayNhan,
                            ngayTra))
                        {
                            return "Phòng " +
                                   item.SoPhong +
                                   " bị trùng lịch đặt.";
                        }
                    }

                    SqlCommand header =
                        new SqlCommand(
                            @"INSERT INTO PhieuDatPhong
                              (
                                  SoPhieuDat,
                                  MaKhach,
                                  MaNVLeTan,
                                  NgayLap,
                                  NgayNhan,
                                  NgayTraDuKien,
                                  TienCoc,
                                  KenhDat,
                                  TrangThai
                              )
                              VALUES
                              (
                                  @So,
                                  @Khach,
                                  @NV,
                                  @Lap,
                                  @Nhan,
                                  @Tra,
                                  @Coc,
                                  @Kenh,
                                  N'Đã đặt'
                              )",
                            cn,
                            tx
                        );

                    header.Parameters.AddWithValue(
                        "@So",
                        soPhieu
                    );

                    header.Parameters.AddWithValue(
                        "@Khach",
                        maKhach
                    );

                    header.Parameters.AddWithValue(
                        "@NV",
                        maNV
                    );

                    header.Parameters.AddWithValue(
                        "@Lap",
                        ngayLap
                    );

                    header.Parameters.AddWithValue(
                        "@Nhan",
                        ngayNhan.Date
                    );

                    header.Parameters.AddWithValue(
                        "@Tra",
                        ngayTra.Date
                    );

                    header.Parameters.AddWithValue(
                        "@Coc",
                        tienCoc
                    );

                    header.Parameters.AddWithValue(
                        "@Kenh",
                        kenhDat
                    );

                    header.ExecuteNonQuery();

                    foreach (PhongDatItem item in danhSachPhong)
                    {
                        SqlCommand detail =
                            new SqlCommand(
                                @"INSERT INTO ChiTietDatPhong
                                  (
                                      SoPhieuDat,
                                      SoPhong,
                                      SoNguoi
                                  )
                                  VALUES
                                  (
                                      @So,
                                      @Phong,
                                      @Nguoi
                                  )",
                                cn,
                                tx
                            );

                        detail.Parameters.AddWithValue(
                            "@So",
                            soPhieu
                        );

                        detail.Parameters.AddWithValue(
                            "@Phong",
                            item.SoPhong
                        );

                        detail.Parameters.AddWithValue(
                            "@Nguoi",
                            item.SoNguoi
                        );

                        detail.ExecuteNonQuery();

                        SqlCommand update =
                            new SqlCommand(
                                @"UPDATE Phong
                                  SET TrangThai = N'Đã đặt'
                                  WHERE SoPhong = @Phong",
                                cn,
                                tx
                            );

                        update.Parameters.AddWithValue(
                            "@Phong",
                            item.SoPhong
                        );

                        update.ExecuteNonQuery();
                    }

                    tx.Commit();

                    return "Đã lập phiếu đặt phòng.";
                }
                catch (Exception ex)
                {
                    try
                    {
                        tx.Rollback();
                    }
                    catch
                    {
                    }

                    return "Không thể lập phiếu đặt phòng.\n"
                           + ex.Message;
                }
            }
        }

        // =========================
        // THÊM NGƯỜI LƯU TRÚ
        // =========================
        public string ThemNguoiLuuTru(
            string soPhieu,
            string soPhong,
            string ten,
            string cmnd,
            string quocTich)
        {
            if (string.IsNullOrWhiteSpace(soPhieu) ||
                string.IsNullOrWhiteSpace(soPhong) ||
                string.IsNullOrWhiteSpace(ten) ||
                string.IsNullOrWhiteSpace(cmnd) ||
                string.IsNullOrWhiteSpace(quocTich))
            {
                return "Thông tin người lưu trú chưa đầy đủ.";
            }

            try
            {
                object maxValue =
                    Db.Scalar(
                        @"SELECT SoNguoi
                          FROM ChiTietDatPhong
                          WHERE SoPhieuDat = @So
                            AND SoPhong = @Phong",

                        new SqlParameter("@So", soPhieu),
                        new SqlParameter("@Phong", soPhong)
                    );

                if (maxValue == null)
                {
                    return "Phòng không thuộc phiếu đặt này.";
                }

                int soNguoiToiDa =
                    Convert.ToInt32(maxValue);

                int daCo =
                    Convert.ToInt32(
                        Db.Scalar(
                            @"SELECT COUNT(*)
                              FROM NguoiLuuTru
                              WHERE SoPhieuDat = @So
                                AND SoPhong = @Phong",

                            new SqlParameter("@So", soPhieu),
                            new SqlParameter("@Phong", soPhong)
                        )
                    );

                if (daCo >= soNguoiToiDa)
                {
                    return "Đã đủ số người đăng ký cho phòng này.";
                }

                Db.Execute(
                    @"INSERT INTO NguoiLuuTru
                      (
                          SoPhieuDat,
                          SoPhong,
                          HoTen,
                          SoCMND,
                          QuocTich
                      )
                      VALUES
                      (
                          @So,
                          @Phong,
                          @Ten,
                          @CMND,
                          @QT
                      )",

                    new SqlParameter("@So", soPhieu),
                    new SqlParameter("@Phong", soPhong),
                    new SqlParameter("@Ten", ten),
                    new SqlParameter("@CMND", cmnd),
                    new SqlParameter("@QT", quocTich)
                );

                return "Đã thêm người lưu trú.";
            }
            catch (Exception ex)
            {
                return "Không thể thêm người lưu trú.\n"
                       + ex.Message;
            }
        }

        // =========================
        // NHẬN PHÒNG
        // =========================
        public string NhanPhong(
            string soPhieu,
            DateTime ngayNhanThucTe)
        {
            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    SqlCommand cmd =
                        new SqlCommand(
                            @"UPDATE PhieuDatPhong
                              SET TrangThai = N'Đang ở',
                                  NgayNhanThucTe = @Ngay
                              WHERE SoPhieuDat = @So
                                AND TrangThai = N'Đã đặt'",
                            cn,
                            tx
                        );

                    cmd.Parameters.AddWithValue(
                        "@Ngay",
                        ngayNhanThucTe
                    );

                    cmd.Parameters.AddWithValue(
                        "@So",
                        soPhieu
                    );

                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        return "Phiếu không ở trạng thái có thể nhận phòng.";
                    }

                    SqlCommand updatePhong =
                        new SqlCommand(
                            @"UPDATE Phong
                              SET TrangThai = N'Đang ở'
                              WHERE SoPhong IN
                              (
                                  SELECT SoPhong
                                  FROM ChiTietDatPhong
                                  WHERE SoPhieuDat = @So
                              )",
                            cn,
                            tx
                        );

                    updatePhong.Parameters.AddWithValue(
                        "@So",
                        soPhieu
                    );

                    updatePhong.ExecuteNonQuery();

                    tx.Commit();

                    return "Đã nhận phòng.";
                }
                catch (Exception ex)
                {
                    try
                    {
                        tx.Rollback();
                    }
                    catch
                    {
                    }

                    return "Không thể nhận phòng.\n"
                           + ex.Message;
                }
            }
        }

        // =========================
        // NO-SHOW
        // =========================
        public string DanhDauNoShow(string soPhieu)
        {
            if (string.IsNullOrWhiteSpace(soPhieu))
            {
                return "Chưa chọn phiếu đặt phòng.";
            }

            try
            {
                Db.Execute(
                    @"UPDATE PhieuDatPhong
                      SET TrangThai = N'No-show'
                      WHERE SoPhieuDat = @So
                        AND TrangThai = N'Đã đặt'",

                    new SqlParameter(
                        "@So",
                        soPhieu
                    )
                );

                Db.Execute(
                    @"UPDATE Phong
                      SET TrangThai = N'Trống'
                      WHERE SoPhong IN
                      (
                          SELECT SoPhong
                          FROM ChiTietDatPhong
                          WHERE SoPhieuDat = @So
                      )",

                    new SqlParameter(
                        "@So",
                        soPhieu
                    )
                );

                return "Đã đánh dấu khách không nhận phòng.";
            }
            catch (Exception ex)
            {
                return "Không thể cập nhật No-show.\n"
                       + ex.Message;
            }
        }
    }
}