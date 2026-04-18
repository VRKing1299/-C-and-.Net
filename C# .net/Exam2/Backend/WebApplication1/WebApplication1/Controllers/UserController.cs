using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Helper;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    /// <summary>
    /// class used to create api for users
    /// </summary>
    public class UserController : ApiController
    {

        //method to get all user data
        [HttpGet]
        public List<User> GetUsers()
        {
            List<User> list = new List<User>();
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "select * from Users";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    #region
                    User user = new User();
                    user.UserId = Convert.ToInt32(rdr["UserId"]);
                    user.UserName = rdr["UserName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.PhoneNo = rdr["PhoneNO"].ToString();
                    user.Password = rdr["UserPassword"].ToString();
                    user.isAdmin = Convert.ToBoolean(rdr["isAdmin"]);
                    #endregion

                    list.Add(user);
                }
                return list;
            }
        }

        //method to add a user
        [HttpPost]
        public string AddUser(User user)
        {
            try
            {
                using(SqlConnection con = DataConnection.GetConnection())
                {
                    con.Open();
                    string query = "insert into Users (UserName, Email, PhoneNo, UserPassword, isAdmin) values (@name, @email, @phno, @pass,@isAdmin )";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name",user.UserName);
                    cmd.Parameters.AddWithValue("@email",user.Email);
                    cmd.Parameters.AddWithValue("@phno",user.PhoneNo);
                    cmd.Parameters.AddWithValue("@pass",user.Password);
                    cmd.Parameters.AddWithValue("@isAdmin",user.isAdmin);

                    int result = cmd.ExecuteNonQuery();

                    return result > 0 ? "User Registered successfully" : "error while registering user";
                }
            }catch(Exception ex)
            {
                return "error adding user";
            }
        }
    }
}
