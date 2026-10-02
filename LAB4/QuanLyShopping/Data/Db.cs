using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EShopping.Data
{
    public static class Db
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager
                    .ConnectionStrings["EShoppingDB"]
                    .ConnectionString;
            }
        }

        public static SqlConnection OpenConnection()
        {
            SqlConnection cn =
                new SqlConnection(ConnectionString);

            cn.Open();

            return cn;
        }

        public static DataTable Query(
            string sql,
            params SqlParameter[] parameters)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public static int Execute(
            string sql,
            params SqlParameter[] parameters)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                return cmd.ExecuteNonQuery();
            }
        }
    }
}