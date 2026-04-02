using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStoreLib
{
    public static class DataConnection
    {
        //gives data connection 
        public static SqlConnection GetDataConnection()
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            return con;
        }
    }
}
