using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ToyShopWebAp1.Models;
using ToyShopWebAp1.Helper;

namespace ToyShopWebAp1.Controllers
{
    //public class LoginController : ApiController
    //{
    //    string str = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
    //    [HttpPost]
    //    public User GetUser(User login)
    //    {
    //        string query = "select * from Users where Email=@email and UserPassword=@pwd";
    //        using(SqlConnection con = new SqlConnection(str))
    //        {
    //            SqlCommand cmd = new SqlCommand(query, con);
    //            cmd.Parameters.AddWithValue("@email", login.Email);
    //            cmd.Parameters.AddWithValue("@pwd", login.Password);
    //            con.Open();
    //            SqlDataReader rdr = cmd.ExecuteReader();
    //            User user = null;
    //            while (rdr.Read())
    //            {
    //                user = new User();
    //                user.UserId = Convert.ToInt32(rdr["UserId"]);
    //                user.UserName = rdr["UserName"].ToString();
    //                user.Email = rdr["Email"].ToString();
    //                user.PhoneNo = rdr["PhoneNO"].ToString();
    //                //user.Password = rdr["UserPassword"].ToString();
    //                user.isAdmin = Convert.ToBoolean(rdr["isAdmin"]);
    //            }
    //            return user;
    //        }
    //    }
    //}

    public class LoginController : ApiController
    {
        //api to get the user data from password and email id
        [HttpPost]
        public Responce GetUser(User login)
        {
            string query = "select * from Users where Email=@email and UserPassword=@pwd";
            using (SqlConnection con = DataConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@email", login.Email);
                cmd.Parameters.AddWithValue("@pwd", login.Password);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                Responce responce = new Responce();
                User user = null;
                if (rdr.Read())
                {
                    user = new User();
                    user.UserId = Convert.ToInt32(rdr["UserId"]);
                    user.UserName = rdr["UserName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.PhoneNo = rdr["PhoneNO"].ToString();
                    //user.Password = rdr["UserPassword"].ToString();
                    user.isAdmin = Convert.ToBoolean(rdr["isAdmin"]);

                    responce.Success = true;
                    responce.Message = "logged in successfully";
                    responce.Data = user;
                    return responce;
                }
                else
                {
                    responce.Success = false;
                    responce.Message = "Invalid username or password";
                    return responce;
                }
            }
        }
    }
}
