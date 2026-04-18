using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ToyShopWebAp1.Helper
{
    public class DataConnection
    {
        public static SqlConnection GetConnection()
        {
            string str = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            SqlConnection con = new SqlConnection(str);
            return con;
        }
    }
}