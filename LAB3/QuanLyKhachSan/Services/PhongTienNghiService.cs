using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    public class PhongTienNghiService
    {
        // =========================
        // LẤY DỮ LIỆU
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

        public DataTable LayTienNghi()
        {
            return Db.Query(
                @"SELECT t.*, l.TenLoaiTN
                  FROM TienNghi t
                  JOIN LoaiTienNghi l
                    ON t.MaLoaiTN = l.MaLoaiTN
                  ORDER BY t.MaTienNghi"
            );
        }

        public DataTable LayLapDat()
        {
            return Db.Query(
                @"SELECT p.*, l.TenLoaiTN
                  FROM PhieuLapDat p
                  JOIN TienNghi t
                    ON p.MaTienNghi = t.MaTienNghi
                  JOIN LoaiTienNghi l
                    ON t.MaLoaiTN = l.MaLoaiTN
                  ORDER BY p.NgayLap DESC"
            );
        }

        // =========================
        // THÊM PHÒNG
        // =========================

        public string ThemPhong(
            string soPhong,
            string maKhu,
            int soNguoiToiDa,
            decimal donGiaNgay)
        {
            if (string.IsNullOrWhiteSpace(soPhong) ||
                string.IsNullOrWhiteSpace(maKhu) ||
                soNguoiToiDa <= 0 ||
                donGiaNgay < 0)
            {
                return "Thông tin phòng không hợp lệ.";
            }

            try
            {
                Db.Execute(
                    @"INSERT INTO Phong
                      (
                          SoPhong,
                          MaKhuVuc,
                          SoNguoiToiDa,
                          DonGiaNgay,
                          TrangThai
                      )
                      VALUES
                      (
                          @SoPhong,
                          @MaKhu,
                          @SoNguoi,
                          @DonGia,
                          N'Trống'
                      )",

                    new SqlParameter("@SoPhong", soPhong),
                    new SqlParameter("@MaKhu", maKhu),
                    new SqlParameter("@SoNguoi", soNguoiToiDa),
                    new SqlParameter("@DonGia", donGiaNgay)
                );

                return "Đã thêm phòng.";
            }
            catch (Exception ex)
            {
                return "Không thể thêm phòng.\n" + ex.Message;
            }
        }

        // =========================
        // THÊM TIỆN NGHI
        // =========================

        public string ThemTienNghi(
            string maTN,
            string maLoai,
            int soThuTu,
            string tinhTrang)
        {
            if (string.IsNullOrWhiteSpace(maTN) ||
                string.IsNullOrWhiteSpace(maLoai) ||
                soThuTu <= 0)
            {
                return "Thông tin tiện nghi không hợp lệ.";
            }

            try
            {
                Db.Execute(
                    @"INSERT INTO TienNghi
                      (
                          MaTienNghi,
                          MaLoaiTN,
                          SoThuTu,
                          TinhTrangHienTai
                      )
                      VALUES
                      (
                          @Ma,
                          @Loai,
                          @STT,
                          @TinhTrang
                      )",

                    new SqlParameter("@Ma", maTN),
                    new SqlParameter("@Loai", maLoai),
                    new SqlParameter("@STT", soThuTu),
                    new SqlParameter("@TinhTrang", tinhTrang)
                );

                return "Đã thêm tiện nghi.";
            }
            catch (Exception ex)
            {
                return "Không thể thêm tiện nghi.\n" + ex.Message;
            }
        }

        // =========================
        // LẮP ĐẶT / LUÂN CHUYỂN
        // =========================

        public string LapDat(
            string soPhieu,
            string maTienNghi,
            string soPhong,
            DateTime ngayLap,
            string tinhTrang,
            string maNV,
            string ghiChu)
        {
            if (string.IsNullOrWhiteSpace(soPhieu) ||
                string.IsNullOrWhiteSpace(maTienNghi) ||
                string.IsNullOrWhiteSpace(soPhong) ||
                string.IsNullOrWhiteSpace(tinhTrang) ||
                string.IsNullOrWhiteSpace(maNV))
            {
                return "Phiếu lắp đặt chưa đủ thông tin.";
            }

            try
            {
                Db.Execute(
                    @"INSERT INTO PhieuLapDat
                      (
                          SoPhieuLapDat,
                          MaTienNghi,
                          SoPhong,
                          NgayLap,
                          TinhTrang,
                          MaNV,
                          GhiChu
                      )
                      VALUES
                      (
                          @SoPhieu,
                          @MaTN,
                          @SoPhong,
                          @Ngay,
                          @TinhTrang,
                          @MaNV,
                          @GhiChu
                      )",

                    new SqlParameter("@SoPhieu", soPhieu),
                    new SqlParameter("@MaTN", maTienNghi),
                    new SqlParameter("@SoPhong", soPhong),
                    new SqlParameter("@Ngay", ngayLap.Date),
                    new SqlParameter("@TinhTrang", tinhTrang),
                    new SqlParameter("@MaNV", maNV),
                    new SqlParameter("@GhiChu", ghiChu)
                );

                Db.Execute(
                    @"UPDATE TienNghi
                      SET TinhTrangHienTai = @TinhTrang
                      WHERE MaTienNghi = @MaTN",

                    new SqlParameter("@TinhTrang", tinhTrang),
                    new SqlParameter("@MaTN", maTienNghi)
                );

                return "Đã lập phiếu lắp đặt.";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 ||
                    ex.Number == 2601)
                {
                    return "Thiết bị này đã được lắp cho một phòng khác trong ngày đã chọn.";
                }

                return "Không thể lập phiếu lắp đặt.\n" + ex.Message;
            }
            catch (Exception ex)
            {
                return "Không thể lập phiếu lắp đặt.\n" + ex.Message;
            }
        }
    }
}