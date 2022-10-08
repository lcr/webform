using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataAccess
{
    public class DB_Help
    {
        public SqlConnection conn;

        [Obsolete]
        public DB_Help()
        {
            conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["conn"]);
        }
        public DataSet getdsbysql(string sql)
        {
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
                dap.Fill(ds);
                dap.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        public int ExeSql(string sql)
        {
            int i;
            try
            {
                conn.Open();
                SqlCommand com = new SqlCommand(sql, conn);
                i = com.ExecuteNonQuery();
                com.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            if (i > 0)
                return 1;
            else
                return 0;
        }
    }
}
