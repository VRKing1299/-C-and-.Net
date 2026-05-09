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
    public class CourseController : ApiController
    {
        // ADD COURSE
        [HttpPost]
        public string Add(Course course)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "insert into Courses (Title,Description,Price,CategoryId,InstructorId,ImgLink) values (@Title,@Description,@Price,@CategoryId,@InstructorId,@ImgLink)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Title", course.Title);
                cmd.Parameters.AddWithValue("@Description", course.Description);
                cmd.Parameters.AddWithValue("@Price", course.Price);
                cmd.Parameters.AddWithValue("@CategoryId", course.CategoryId);
                cmd.Parameters.AddWithValue("@InstructorId", course.InstructorId);
                cmd.Parameters.AddWithValue("@ImgLink", course.ImgLink);

                con.Open();
                int res = cmd.ExecuteNonQuery();

                return res>0?"Course Added Succesfully":"Failed to add the course";
            }
        }


        // GET ALL COURSES
        [HttpGet]
        public List<Course> GetCourses()
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                List<Course> list = new List<Course>();

                string query = "select * from Courses";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Course c = new Course();

                    c.Id = Convert.ToInt32(dr["Id"]);
                    c.Title = dr["Title"].ToString();
                    c.Description = dr["Description"].ToString();
                    c.Price = Convert.ToDecimal(dr["Price"]);
                    c.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    c.InstructorId = Convert.ToInt32(dr["InstructorId"]);
                    c.ImgLink = Convert.ToString(dr["ImgLink"]);

                    list.Add(c);
                }

                return list;
            }
        }


        // GET COURSE BY ID
        [HttpGet]
        [Route("api/Course/{id}")]
        public Course GetCourse(int id)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "select * from Courses where Id=@Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                Course c = new Course();

                if (dr.Read())
                {
                    c.Id = Convert.ToInt32(dr["Id"]);
                    c.Title = dr["Title"].ToString();
                    c.Description = dr["Description"].ToString();
                    c.Price = Convert.ToDecimal(dr["Price"]);
                    c.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                    c.InstructorId = Convert.ToInt32(dr["InstructorId"]);
                    c.ImgLink = Convert.ToString(dr["ImgLink"]);
                }

                return c;
            }
        }


        // UPDATE COURSE
        [HttpPut]
        public string Update(Course course)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "update Courses set Title=@Title,Description=@Description,Price=@Price,CategoryId=@CategoryId,InstructorId=@InstructorId where Id=@Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", course.Id);
                cmd.Parameters.AddWithValue("@Title", course.Title);
                cmd.Parameters.AddWithValue("@Description", course.Description);
                cmd.Parameters.AddWithValue("@Price", course.Price);
                cmd.Parameters.AddWithValue("@CategoryId", course.CategoryId);
                cmd.Parameters.AddWithValue("@InstructorId", course.InstructorId);

                con.Open();
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    return "Updated Successfully";
                }

                return "Error Updating";
            }
        }


        // DELETE COURSE
        [HttpDelete]
        public string Delete(int id)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "delete from Courses where Id=@Id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                {
                    return "Deleted Successfully";
                }

                return "Error While Deleting";
            }
        }
    }
}
