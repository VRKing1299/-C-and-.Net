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
    public class PaymentController : ApiController
    {
        // ADD PAYMENT
        [HttpPost]
        [Route("api/Payment/Add")]
        public IHttpActionResult Add(Payment p)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "insert into Payment (UserId,Amount,Method,InvoiceId) values (@UserId,@Amount,@Method,@InvoiceId)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", p.UserId);
                cmd.Parameters.AddWithValue("@Amount", p.Amount);
                cmd.Parameters.AddWithValue("@Method", p.Method);
                cmd.Parameters.AddWithValue("@InvoiceId", p.InvoiceId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return Ok("Inserted");
            }
        }


        // GET PAYMENT BY USER
        [HttpGet]
        [Route("api/Payment/{userid}")]
        public List<Payment> GetByUser(int userid)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                List<Payment> list = new List<Payment>();

                string query = "select * from Payment where UserId=@UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", userid);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Payment p = new Payment();

                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.UserId = Convert.ToInt32(dr["UserId"]);
                    p.Amount = Convert.ToDecimal(dr["Amount"]);
                    p.Method = dr["Method"].ToString();
                    p.PaymentDate = Convert.ToDateTime(dr["PaymentDate"]);
                    p.InvoiceId = Convert.ToInt32(dr["InvoiceId"]);

                    list.Add(p);
                }

                return list;
            }
        }
    }
}
