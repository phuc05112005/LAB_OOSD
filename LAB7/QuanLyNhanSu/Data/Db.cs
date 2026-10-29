using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanSu.Data
{
    public static class Db
    {
        // Chuỗi kết nối trực tiếp đến LocalDB
        public static string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyNhanSu;Integrated Security=True;";

        public static SqlConnection OpenConnection()
        {
            var cn = new SqlConnection(ConnectionString);
            cn.Open();
            return cn;
        }

        public static DataTable Query(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int Execute(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteScalar();
            }
        }

        // Dùng cho xử lý Transaction
        public static object Scalar(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tx))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteScalar();
            }
        }

        public static int Execute(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tx))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteNonQuery();
            }
        }

        public static DataTable Query(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tx))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static decimal Dec(object o)
        {
            return (o == null || o == DBNull.Value) ? 0m : Convert.ToDecimal(o);
        }

        public static void ThemQuyetDinh(SqlConnection cn, SqlTransaction tx, string soQD, string loai,
            DateTime ngayHL, string noiDung, string maNVKy, string maNV, string maPB)
        {
            Execute(cn, tx, @"INSERT INTO QuyetDinh(SoQD,LoaiQD,NgayHieuLuc,NoiDung,MaNVKy,MaNV,MaPB,TrangThai)
                VALUES(@q,@l,@h,@n,@k,@nv,@pb,N'Chờ ký')",
                new SqlParameter("@q", soQD), new SqlParameter("@l", loai), new SqlParameter("@h", ngayHL.Date),
                new SqlParameter("@n", noiDung), new SqlParameter("@k", maNVKy),
                new SqlParameter("@nv", (object)maNV ?? DBNull.Value), new SqlParameter("@pb", (object)maPB ?? DBNull.Value));
        }
    }
}