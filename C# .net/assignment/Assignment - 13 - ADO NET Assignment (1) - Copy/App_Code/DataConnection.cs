using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BookStoreLib;
/// <summary>
/// Summary description for Class1
/// </summary>
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

