using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using EShopping.Data;

namespace EShopping.Services
{
    public class KhachHangService
    {
        // ==============================
        // LẤY DANH SÁCH KHÁCH HÀNG
        // ==============================

        public DataTable LayDanhSach()
        {
            return Db.Query(
                @"SELECT
                    MaKH,
                    HoTen,
                    NgaySinh,
                    CMNDPassport,
                    DiaChi,
                    DienThoai,
                    Email,
                    TenDangNhap
                  FROM KhachHang
                  ORDER BY HoTen"
            );
        }


        // ==============================
        // KIỂM TRA TÊN ĐĂNG NHẬP
        // ==============================

        private bool TonTaiTenDangNhap(
            string tenDangNhap)
        {
            DataTable dt = Db.Query(
                @"SELECT TenDangNhap
                  FROM KhachHang
                  WHERE TenDangNhap = @TenDangNhap",

                new SqlParameter(
                    "@TenDangNhap",
                    tenDangNhap
                )
            );

            return dt.Rows.Count > 0;
        }


        // ==============================
        // HASH MẬT KHẨU
        // ==============================

        private string HashMatKhau(
            string matKhau)
        {
            using (SHA256 sha =
                SHA256.Create())
            {
                byte[] bytes =
                    Encoding.UTF8.GetBytes(matKhau);

                byte[] hash =
                    sha.ComputeHash(bytes);

                StringBuilder sb =
                    new StringBuilder();

                foreach (byte b in hash)
                {
                    sb.Append(
                        b.ToString("x2")
                    );
                }

                return sb.ToString();
            }
        }


        // ==============================
        // THÊM KHÁCH HÀNG
        // ==============================

        public string ThemKhachHang(
            string maKH,
            string hoTen,
            DateTime ngaySinh,
            string cmndPassport,
            string diaChi,
            string dienThoai,
            string email,
            string tenDangNhap,
            string matKhau)
        {
            if (string.IsNullOrWhiteSpace(maKH) ||
                string.IsNullOrWhiteSpace(hoTen) ||
                string.IsNullOrWhiteSpace(cmndPassport) ||
                string.IsNullOrWhiteSpace(diaChi) ||
                string.IsNullOrWhiteSpace(dienThoai) ||
                string.IsNullOrWhiteSpace(tenDangNhap) ||
                string.IsNullOrWhiteSpace(matKhau))
            {
                return "Vui lòng nhập đầy đủ thông tin bắt buộc.";
            }

            if (TonTaiTenDangNhap(tenDangNhap))
            {
                return "Tên đăng nhập đã tồn tại.";
            }

            try
            {
                string matKhauHash =
                    HashMatKhau(matKhau);

                Db.Execute(
                    @"INSERT INTO KhachHang
                    (
                        MaKH,
                        HoTen,
                        NgaySinh,
                        CMNDPassport,
                        DiaChi,
                        DienThoai,
                        Email,
                        TenDangNhap,
                        MatKhauHash
                    )
                    VALUES
                    (
                        @MaKH,
                        @HoTen,
                        @NgaySinh,
                        @CMND,
                        @DiaChi,
                        @DienThoai,
                        @Email,
                        @TenDangNhap,
                        @MatKhauHash
                    )",

                    new SqlParameter(
                        "@MaKH",
                        maKH
                    ),

                    new SqlParameter(
                        "@HoTen",
                        hoTen
                    ),

                    new SqlParameter(
                        "@NgaySinh",
                        ngaySinh.Date
                    ),

                    new SqlParameter(
                        "@CMND",
                        cmndPassport
                    ),

                    new SqlParameter(
                        "@DiaChi",
                        diaChi
                    ),

                    new SqlParameter(
                        "@DienThoai",
                        dienThoai
                    ),

                    new SqlParameter(
                        "@Email",
                        string.IsNullOrWhiteSpace(email)
                            ? (object)DBNull.Value
                            : email
                    ),

                    new SqlParameter(
                        "@TenDangNhap",
                        tenDangNhap
                    ),

                    new SqlParameter(
                        "@MatKhauHash",
                        matKhauHash
                    )
                );

                return "Đăng ký khách hàng thành công.";
            }
            catch (Exception ex)
            {
                return "Không thể đăng ký khách hàng.\n"
                       + ex.Message;
            }
        }
    }
}