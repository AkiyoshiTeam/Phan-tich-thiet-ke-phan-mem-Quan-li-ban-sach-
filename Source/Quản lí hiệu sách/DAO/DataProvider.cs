using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        public static SqlConnection Connection()
        {
            string conStr = ConfigurationManager.ConnectionStrings["HieuSach"].ToString();
            SqlConnection con;
            con = new SqlConnection(conStr);
            con.Open();
            return con;
        }
    }
}
