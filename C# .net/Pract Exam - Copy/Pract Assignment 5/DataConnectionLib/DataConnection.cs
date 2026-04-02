using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataConnectionLib
{
    /// <summary>
    /// this class is used for fetching connection string from configuration manager and creating
    /// the connection object and returning it 
    /// </summary>
    public class DataConnection
    {
        public static SqlConnection GetDataConnection()
        {
            string strCon = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            SqlConnection con = new SqlConnection(strCon);
            return con;

        }
    }
}
