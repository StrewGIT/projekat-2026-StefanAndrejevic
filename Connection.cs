using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace projekat_2026_StefanAndrejevic
{
    internal class Connection
    {
        public static SqlConnection Connect()
        {
            string cs;
            cs = ConfigurationManager.ConnectionStrings["skola"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}
