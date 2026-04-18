using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data;
using ToyShopWebAp1.Models;
using System.Data.SqlClient;
using ToyShopWebAp1.Helper;

namespace ToyShopWebAp1.Controllers
{
    public class UserController : ApiController
    {
        string str = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;

        [HttpGet]
        public List<User> GetUsers()
        {
            List<User> list = new List<User>();
            using(SqlConnection con = DataConnection.GetConnection())
            {
                string query = "select * from Users";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    User user = new User();
                    user.UserId = Convert.ToInt32(rdr["UserId"]);
                    user.UserName = rdr["UserName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.PhoneNo = rdr["PhoneNO"].ToString();
                    user.Password = rdr["UserPassword"].ToString();
                    user.isAdmin = Convert.ToBoolean(rdr["isAdmin"]);

                    list.Add(user);
                }
                return list;
            }
        }
    }
}
