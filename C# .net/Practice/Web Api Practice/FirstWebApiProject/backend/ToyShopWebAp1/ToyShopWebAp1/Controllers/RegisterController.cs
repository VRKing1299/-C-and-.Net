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
    public class RegisterController : ApiController
    {
        //api to register the user
        Responce responce;
        [HttpPost]
        public Responce AddUser(User user)
        {
            int res = 0;
            using (SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();
                //checking if email exist or not
                string query = "select * from Users where Email=@email";
                SqlCommand emCmd = new SqlCommand(query, con);
                emCmd.Parameters.AddWithValue("@email", user.Email);
                SqlDataReader rd = emCmd.ExecuteReader();
                if (rd.Read())
                {
                    return new Responce() { Success = false, Message = "Email allready exist" };
                }
                rd.Close();

                //checking for existing email and phone no
                query = "select * from Users where PhoneNo=@phno";
                SqlCommand phCmd = new SqlCommand(query, con);
                phCmd.Parameters.AddWithValue("@phno", user.PhoneNo);
                SqlDataReader phRdr = phCmd.ExecuteReader();
                if (phRdr.Read())
                {
                    return new Responce() { Success = false, Message = "PhoneNo: allready exist" };
                }
                phRdr.Close();

                query = "insert into Users values(@name,@email,@phno,@pwd,0)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", user.UserName);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@phno", user.PhoneNo);
                cmd.Parameters.AddWithValue("@pwd", user.Password);

                res = cmd.ExecuteNonQuery();
            }
            return res > 0 ? new Responce() { Success = true, Message = "Successfully Created the account" } : new Responce() { Success = false, Message = "cannot create an account" };
        }
    }
}
