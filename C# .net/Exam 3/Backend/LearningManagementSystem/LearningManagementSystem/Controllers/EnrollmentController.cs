using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using LearningManagementSystem.HelperMethod;
using LearningManagementSystem.Models;

namespace LearningManagementSystem.Controllers
{
    public class EnrollmentController : ApiController
    {
        [HttpPost]
        public string Checkout(int userId)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();

                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    // 1️⃣ Get cart items (ONLY Cart object data)
                    string cartQuery = "SELECT * FROM Cart WHERE UserId = @UserId";

                    SqlCommand cartCmd = new SqlCommand(cartQuery, con, tran);
                    cartCmd.Parameters.AddWithValue("@UserId", userId);

                    SqlDataReader dr = cartCmd.ExecuteReader();

                    List<Cart> cartItems = new List<Cart>();

                    while (dr.Read())
                    {
                        Cart c = new Cart();
                        c.Id = Convert.ToInt32(dr["Id"]);
                        c.UserId = Convert.ToInt32(dr["UserId"]);
                        c.CourseId = Convert.ToInt32(dr["CourseId"]);

                        cartItems.Add(c);
                    }

                    dr.Close();

                    if (cartItems.Count == 0)
                    {
                        tran.Rollback();
                        return "Cart is empty";
                    }

                    // 2️ Process each cart item
                    foreach (var item in cartItems)
                    {
                        // Fetch current price
                        string priceQuery = "SELECT Price FROM Courses WHERE Id = @CourseId";

                        SqlCommand priceCmd = new SqlCommand(priceQuery, con, tran);
                        priceCmd.Parameters.AddWithValue("@CourseId", item.CourseId);

                        decimal price = Convert.ToDecimal(priceCmd.ExecuteScalar());

                        // 3️ Insert into Enrollment
                        string insertQuery = "INSERT INTO Enrollment (UserId, CourseId, Price, Status)VALUES (@UserId, @CourseId, @Price, @Status)";

                        SqlCommand insertCmd = new SqlCommand(insertQuery, con, tran);

                        insertCmd.Parameters.AddWithValue("@UserId", item.UserId);
                        insertCmd.Parameters.AddWithValue("@CourseId", item.CourseId);
                        insertCmd.Parameters.AddWithValue("@Price", price);
                        insertCmd.Parameters.AddWithValue("@Status", "Paid");

                        insertCmd.ExecuteNonQuery();
                    }

                    // 4️ Clear Cart
                    string deleteQuery = "DELETE FROM Cart WHERE UserId = @UserId";

                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, con, tran);
                    deleteCmd.Parameters.AddWithValue("@UserId", userId);

                    deleteCmd.ExecuteNonQuery();

                    tran.Commit();

                    return "Checkout Successful";
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return "Error: " + ex.Message;
                }
            }
        }


        // GET ENROLLMENTS BY USER
        [HttpGet]
        public List<Enrollment> GetByUser(int userid)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                List<Enrollment> list = new List<Enrollment>();

                string query = "select * from Enrollment where UserId=@UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", userid);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Enrollment e = new Enrollment();

                    e.Id = Convert.ToInt32(dr["Id"]);
                    e.UserId = Convert.ToInt32(dr["UserId"]);
                    e.CourseId = Convert.ToInt32(dr["CourseId"]);
                    e.EnrolledDate = Convert.ToDateTime(dr["EnrolledDate"]);
                    e.Price = Convert.ToInt32(dr["Price"]);
                    list.Add(e);
                }

                return list;
            }
        }
    }
}
