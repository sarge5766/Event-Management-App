using System.Configuration;
using System.Data.SqlClient;

namespace EventManagement.WebAPI {
    public static class DBHelper {
        public static SqlConnection conn;

        public static SqlConnection Conn() {
           return new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConn"].ToString());
        }
    }
}