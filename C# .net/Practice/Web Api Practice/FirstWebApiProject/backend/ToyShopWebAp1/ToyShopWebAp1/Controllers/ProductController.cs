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
    public class ProductController : ApiController
    {
        //returns all the products data
        [HttpGet]
        public Responce GetAllProducts()
        {
            List<Products> prodList = new List<Products>();
        
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "select p.*, c.CategoryName from Products p left outer join Category c on p.CategoryId = c.CategoryId ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Products product = new Products()
                    {
                        ProdId = Convert.ToInt32(rdr["ProdId"]),
                        ProdName = rdr["ProdName"].ToString(),
                        Price = Convert.ToInt32(rdr["Price"]),
                        ImageUrl = rdr["ImageUrl"].ToString(),
                        StockQuantity = Convert.ToInt32(rdr["StockQuantity"]),
                        CategoryId = Convert.ToInt32(rdr["CategoryId"]),
                        CategoryName = rdr["CategoryName"].ToString()
                    };

                    prodList.Add(product);
                }
                return new Responce() { Success = true, Message = "Data Fetched Successfully", Data = prodList };
            }
        }
    }
}
