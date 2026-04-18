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
        public List<Products> GetAllProducts()
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
                return prodList;
            }
        }

        [HttpGet]
        [Route("api/product/{id}")]
        public Products GetProduct(int id)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                string query = "select p.*, c.* from Products p left outer join Category c on p.CategoryId = c.CategoryId where p.ProdId=@id ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                Products product=null;
                while (rdr.Read())
                {
                    product = new Products()
                    {
                        ProdId = Convert.ToInt32(rdr["ProdId"]),
                        ProdName = rdr["ProdName"].ToString(),
                        Price = Convert.ToInt32(rdr["Price"]),
                        ImageUrl = rdr["ImageUrl"].ToString(),
                        StockQuantity = Convert.ToInt32(rdr["StockQuantity"]),
                        CategoryId = Convert.ToInt32(rdr["CategoryId"]),
                        CategoryName = rdr["CategoryName"].ToString()
                    };

                }
                return product;
            }
        }

        //method to add the product
        [HttpPost]
        public string AddProduct(Products prod)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();

                string query = "insert into Products(ProdName,Price,ImageUrl,StockQuantity,CategoryId) values (@name,@price,@img,@stock,@catID)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name",prod.ProdName);
                cmd.Parameters.AddWithValue("@price",prod.Price);
                cmd.Parameters.AddWithValue("@img",prod.ImageUrl);
                cmd.Parameters.AddWithValue("@stock",prod.StockQuantity);
                cmd.Parameters.AddWithValue("@catID",prod.CategoryId);
                
                int result = cmd.ExecuteNonQuery();
                return result>0?"product is inserted successfully":"Error Inserting Product";
            }
        }

        [HttpPut]
        public string UpdateProduct(Products prod)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();

                string query = "update Products set ProdName=@name,Price=@price,ImageUrl=@img,StockQuantity=@stock,CategoryId=@catID where ProdId=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", prod.ProdName);
                cmd.Parameters.AddWithValue("@price", prod.Price);
                cmd.Parameters.AddWithValue("@img", prod.ImageUrl);
                cmd.Parameters.AddWithValue("@stock", prod.StockQuantity);
                cmd.Parameters.AddWithValue("@catID", prod.CategoryId);
                cmd.Parameters.AddWithValue("@id",prod.ProdId);

                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "product is Updated successfully" : "Error Updated Product";
            }
        }


        [HttpDelete]
        public string DeleteProduct(int id)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();

                string query = "delete from Products where ProdId=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "product is Deleted successfully" : "Error Deleted Product";
            }
        }


    }
}
