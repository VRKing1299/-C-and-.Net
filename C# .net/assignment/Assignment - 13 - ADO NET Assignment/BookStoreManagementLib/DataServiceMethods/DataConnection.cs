using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStoreManagementLib.DataServiceMethods
{
    /// <summary>
    /// static class used for helper method of getting the data connection to coller
    /// </summary>
    public static class DataConnection
    {
        //method that forms the connection returns the connection object 
        public static SqlConnection GetDataConnection()
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            return con;
        }
    }
}
