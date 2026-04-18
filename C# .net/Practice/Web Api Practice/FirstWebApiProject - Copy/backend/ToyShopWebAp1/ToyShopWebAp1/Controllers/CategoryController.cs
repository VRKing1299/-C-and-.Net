using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToyShopWebAp1.Models;
using ToyShopWebAp1.Helper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ToyShopWebAp1.Controllers
{
    public class CategoryController : ApiController
    {
        //method to get all the category
        [HttpGet]
        public List<Category> GetCategory()
        {
            List<Category> categoryList = new List<Category>();

            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "select * from Category order by CategoryId";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //reading the data
                while (rdr.Read())
                {
                    Category category = new Category()
                    {
                        CategoryId = Convert.ToInt32(rdr["CategoryId"]),
                        CategoryName = rdr["CategoryName"].ToString()
                    };
                    categoryList.Add(category);
                }
                return categoryList;
            }
        }

        //method to get all the category
        [HttpGet]
        [Route("api/GetOneCategory/{id}")]
        public Category GetOneCategory(int id)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "select * from Category where CategoryId=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                Category category = null;
                //reading the data
                while (rdr.Read())
                {
                    category = new Category()
                    {
                        CategoryId = Convert.ToInt32(rdr["CategoryId"]),
                        CategoryName = rdr["CategoryName"].ToString()
                    };
                }
                return category;
            }
        }

        //method to add the data in the category
        [HttpPost]
        public string AddCategory(Category cat)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "insert into Category(CategoryName) values (@name)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", cat.CategoryName);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result>0?"Category inserted successfully":"Error Inserting Category";
            }
        }

        //method to update the data from the category
        [HttpPut]
        public string UpdateCategory(Category cat)
        {

            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "update Category set CategoryName=@name where CategoryId=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", cat.CategoryId);
                cmd.Parameters.AddWithValue("@name", cat.CategoryName);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "Category Updated successfully" : "Error Updating Category";
            }
        }

        //method to update the data from the category
        [HttpDelete]
        public string DeleteCategory(int id)
        {

            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "delete from Category where CategoryId=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "Category Deleted successfully" : "Error Deleting Category";
            }
        }
    }
}
