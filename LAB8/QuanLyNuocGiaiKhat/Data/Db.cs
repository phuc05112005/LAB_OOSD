using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNuocGiaiKhat.Data
{
    public static class Db
    {
        // Gán trực tiếp chuỗi kết nối tại đây
        public static string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyNuocGiaiKhat;Integrated Security=True;";

        public static SqlConnection OpenConnection() { var cn = new SqlConnection(ConnectionString); cn.Open(); return cn; }

        public static DataTable Query(string sql, params SqlParameter[] ps) { using (var cn = OpenConnection()) return Query(cn, null, sql, ps); }
        public static DataTable Query(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tx)) using (var da = new SqlDataAdapter(cmd))
            { if (ps != null) cmd.Parameters.AddRange(ps); var dt = new DataTable(); da.Fill(dt); return dt; }
        }
        public static int Execute(string sql, params SqlParameter[] ps) { using (var cn = OpenConnection()) return Execute(cn, null, sql, ps); }
        public static int Execute(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] ps)
        { using (var cmd = new SqlCommand(sql, cn, tx)) { if (ps != null) cmd.Parameters.AddRange(ps); return cmd.ExecuteNonQuery(); } }
        public static object Scalar(string sql, params SqlParameter[] ps) { using (var cn = OpenConnection()) return Scalar(cn, null, sql, ps); }
        public static object Scalar(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] ps)
        { using (var cmd = new SqlCommand(sql, cn, tx)) { if (ps != null) cmd.Parameters.AddRange(ps); return cmd.ExecuteScalar(); } }
    }
}