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
    public class CategoryController : ApiController
    {
        // ADD CATEGORY
        [HttpPost]
        public string Add(Category category)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "insert into Categories (Name) values (@Name)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", category.Name);

                con.Open();
                cmd.ExecuteNonQuery();

                return "Added Successfuly";
            }
        }


        // GET ALL CATEGORIES
        [HttpGet]
        public List<Category> GetCategories()
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                List<Category> list = new List<Category>();

                string query = "select * from Categories";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Category c = new Category();

                    c.Id = Convert.ToInt32(dr["Id"]);
                    c.Name = dr["Name"].ToString();

                    list.Add(c);
                }

                return list;
            }
        }
    }
}
