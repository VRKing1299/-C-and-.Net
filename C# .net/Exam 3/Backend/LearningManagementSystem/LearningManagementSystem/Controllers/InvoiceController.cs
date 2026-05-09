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
    public class InvoiceController : ApiController
    {
        // CREATE INVOICE
        [HttpPost]
        public string Add(Invoice i)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "insert into Invoice (UserId,TotalAmount) values (@UserId,@TotalAmount)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", i.UserId);
                cmd.Parameters.AddWithValue("@TotalAmount", i.TotalAmount);

                con.Open();
                int res = cmd.ExecuteNonQuery();

                return res>0?"Inserted Successfully":"Error Inserting Data";
            }
        }


        // GET INVOICE BY USER
        [HttpGet]
        [Route("api/Invoice/{userid}")]
        public IHttpActionResult GetByUser(int userid)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                List<Invoice> list = new List<Invoice>();

                string query = "select * from Invoice where UserId=@UserId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", userid);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Invoice i = new Invoice();

                    i.Id = Convert.ToInt32(dr["Id"]);
                    i.UserId = Convert.ToInt32(dr["UserId"]);
                    i.TotalAmount = Convert.ToDecimal(dr["TotalAmount"]);
                    i.InvoiceDate = Convert.ToDateTime(dr["InvoiceDate"]);

                    list.Add(i);
                }

                con.Close();

                return Ok(list);
            }
        }
    }
}
