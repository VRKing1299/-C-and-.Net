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
    /// <summary>
    /// this api/controller is used to write apis for the user
    /// </summary>
    public class UserController : ApiController
    {
        //method to get the list of of users
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

        //method to get specific user using user id
        [HttpGet]
        [Route("api/user/{id}")]
        public User GetUser(int id)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "select * from Users where UserId=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                User user = new User();
                while (rdr.Read())
                {
                    user.UserId = Convert.ToInt32(rdr["UserId"]);
                    user.UserName = rdr["UserName"].ToString();
                    user.Email = rdr["Email"].ToString();
                    user.PhoneNo = rdr["PhoneNO"].ToString();
                    user.Password = rdr["UserPassword"].ToString();
                    user.isAdmin = Convert.ToBoolean(rdr["isAdmin"]);
                }
                return user;
            }
        }

        //api to register the user/ add the user
        [HttpPost]
        public string AddUser(User user)
        {
            try
            {
                int res = 0;
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    con.Open();
                    string query = "insert into Users values(@name,@email,@phno,@pwd,@isAdmin)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", user.UserName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phno", user.PhoneNo);
                    cmd.Parameters.AddWithValue("@pwd", user.Password);
                    cmd.Parameters.AddWithValue("@isAdmin", user.isAdmin);

                    res = cmd.ExecuteNonQuery();
                }
                return res > 0 ? "Successfully Created the account" : "cannot create an account";
            }catch(SqlException ex)
            {
                return ex.Message;
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        //method to update user details
        [HttpPut]
        public string UpdateUser(User user)
        {
            try
            {
                int res = 0;
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    con.Open();
                    string query = "update Users set UserName=@name , Email=@email, PhoneNo=@phno, isAdmin=@isAdmin where UserId=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", user.UserId);
                    cmd.Parameters.AddWithValue("@name", user.UserName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phno", user.PhoneNo);
                    cmd.Parameters.AddWithValue("@isAdmin", user.isAdmin);

                    res = cmd.ExecuteNonQuery();
                }
                return res > 0 ? "Successfully Updated the account" : "cannot Update an account";
            }catch(SqlException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //method to delete the user using user id
        [HttpDelete]
        public string Delete(int id)
        {
            int res = 0;
            using (SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();
                string query = "delete from Users where UserId=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                res = cmd.ExecuteNonQuery();
            }
            return res > 0 ? "Successfully Deleted the account" : "cannot Deleted an account";
        }
    }
}
