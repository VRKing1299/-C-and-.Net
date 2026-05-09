using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using LearningManagementSystem.HelperMethod;
using LearningManagementSystem.Models;

namespace LearningManagementSystem.Controllers
{
    public class UserController : ApiController
    {
        //Method to get all the users
        [HttpGet]
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        UserName = reader["UserName"].ToString(),
                        Email = reader["Email"].ToString(),
                        UserRole = reader["UserRole"].ToString(),
                        UserPassword = reader["UserPassword"].ToString()
                    });
                }

            return users;
        }
        }

        [HttpPost]
        public string AddUser(User user)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "INSERT INTO Users (UserName, Email, UserPassword, UserRole) VALUES (@UserName, @Email, @Password, @Role)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.UserPassword);
                cmd.Parameters.AddWithValue("@Role", user.UserRole);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return "User Registered Successfully";
            }
        }

        [HttpDelete]
        public string DeleteUser(int id)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "DELETE FROM Users WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    return "User Deleted";

                return "User Naot found";
            }
        }
    }
}
