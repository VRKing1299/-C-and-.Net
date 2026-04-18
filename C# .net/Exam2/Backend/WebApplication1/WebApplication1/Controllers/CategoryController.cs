using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// this class is used to create the controller for the category table
    /// </summary>
    public class CategoryController : ApiController
    {
        //method to get all the category in category table
        [HttpGet]
        public List<Category> GetAllCategory()
        {
            try
            {
                using(SqlConnection con = DataConnection.GetConnection())
                {
                    con.Open();
                    string query = "select * from Category";

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    List<Category> list = new List<Category>();
                    while (rdr.Read())
                    {
                        Category category = new Category()
                        {
                            CategoryId = Convert.ToInt32(rdr["CategoryId"]),
                            CategoryName = Convert.ToString(rdr["CategoryName"])
                        };
                        list.Add(category);
                    }
                    return list;
                }
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
