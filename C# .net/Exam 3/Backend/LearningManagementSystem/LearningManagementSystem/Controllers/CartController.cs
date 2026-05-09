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
    public class CartController : ApiController
    {
        // ADD TO CART
        [HttpPost]
        public string Add(Cart cart)
        {
            
            using (SqlConnection con = DataConnection.GetConnection())
            {

                string query = "insert into Cart (UserId,CourseId) values (@UserId,@CourseId)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", cart.UserId);
                cmd.Parameters.AddWithValue("@CourseId", cart.CourseId);

                con.Open();
                cmd.ExecuteNonQuery();

                return "Added successfully";
            }
        }


        // GET CART BY USER
        [HttpGet]
        //[Route("api/Cart/{userid}")]
        public List<Cart> GetCart(int userid)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                List<Cart> list = new List<Cart>();

                string query = "select * from Cart where UserId=@UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", userid);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Cart c = new Cart();

                    c.Id = Convert.ToInt32(dr["Id"]);
                    c.UserId = Convert.ToInt32(dr["UserId"]);
                    c.CourseId = Convert.ToInt32(dr["CourseId"]);

                    list.Add(c);
                }

                return list;
            }
        }


        // DELETE CART ITEM
        [HttpDelete]
        //[Route("api/Cart/{id}")]
        public string Delete(int id)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "delete from Cart where Id=@Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    return "Deleted Successfully";
                }

                return "NotFound";
            }
        }
    }
}
