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
    /// this class is used to create api for the product 
    /// </summary>
    public class ProductsController : ApiController
    {
        //method to fetch all the product
        [HttpGet]
        public List<Products> GetAllProducts()
        {
            try
            {
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    con.Open();
                    List<Products> list = new List<Products>();

                    string query = "select p.*, c.CategoryName from Products p left outer join Category c on p.CategoryId = c.CategoryId order by p.CategoryId";

                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Products product = new Products()
                        {
                            #region
                            ProdId = Convert.ToInt32(rdr["ProdId"]),
                            ProdName = rdr["ProdName"].ToString(),
                            Price = Convert.ToInt32(rdr["Price"]),
                            ImageUrl = rdr["ImageUrl"].ToString(),
                            StockQuantity = Convert.ToInt32(rdr["StockQuantity"]),
                            CategoryId = Convert.ToInt32(rdr["CategoryId"]),
                            CategoryName = rdr["CategoryName"].ToString()
                            #endregion
                        };
                        list.Add(product);
                    }
                    return list;
                }
            }catch(Exception ex)
            {
                return null;
            }
        }

        //this method is used to fetch one proudct using its id
        [HttpGet]
        [Route("api/Products/product/{id}")]
        public Products GetProduct(int id)
        {
            try
            {
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    con.Open();
                    string query = "select p.*, c.* from Products p left outer join Category c on p.CategoryId = c.CategoryId where p.ProdId=@id ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    SqlDataReader rdr = cmd.ExecuteReader();
                    Products product = null;
                    while (rdr.Read())
                    {
                        product = new Products()
                        {
                            #region
                            ProdId = Convert.ToInt32(rdr["ProdId"]),
                            ProdName = rdr["ProdName"].ToString(),
                            Price = Convert.ToInt32(rdr["Price"]),
                            ImageUrl = rdr["ImageUrl"].ToString(),
                            StockQuantity = Convert.ToInt32(rdr["StockQuantity"]),
                            CategoryId = Convert.ToInt32(rdr["CategoryId"]),
                            CategoryName = rdr["CategoryName"].ToString()
                            #endregion
                        };

                    }
                    return product;
                }
            }catch(Exception ex)
            {
                return null;
            }
        }

        //method to add the product
        [HttpPost]
        public string AddProduct(Products prod)
        {
            try
            {
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    con.Open();

                    string query = "insert into Products(ProdName,Price,ImageUrl,StockQuantity,CategoryId) values (@name,@price,@img,@stock,@catID)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    #region
                    cmd.Parameters.AddWithValue("@name", prod.ProdName);
                    cmd.Parameters.AddWithValue("@price", prod.Price);
                    cmd.Parameters.AddWithValue("@img", prod.ImageUrl);
                    cmd.Parameters.AddWithValue("@stock", prod.StockQuantity);
                    cmd.Parameters.AddWithValue("@catID", prod.CategoryId);
                    #endregion

                    int result = cmd.ExecuteNonQuery();
                    return result > 0 ? "product is inserted successfully" : "Error Inserting Product";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        //this metod is used to update the product takes a product object to update the data
        [HttpPut]
        public string UpdateProduct(Products prod)
        {
            try
            {
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    con.Open();

                    string query = "update Products set ProdName=@name,Price=@price,ImageUrl=@img,StockQuantity=@stock,CategoryId=@catID where ProdId=@id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    #region
                    cmd.Parameters.AddWithValue("@name", prod.ProdName);
                    cmd.Parameters.AddWithValue("@price", prod.Price);
                    cmd.Parameters.AddWithValue("@img", prod.ImageUrl);
                    cmd.Parameters.AddWithValue("@stock", prod.StockQuantity);
                    cmd.Parameters.AddWithValue("@catID", prod.CategoryId);
                    cmd.Parameters.AddWithValue("@id", prod.ProdId);
                    #endregion

                    int result = cmd.ExecuteNonQuery();
                    return result > 0 ? "product is Updated successfully" : "Error Updated Product";
                }
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        //this method is used to delete the product using product id
        [HttpDelete]
        public string DeleteProduct(int id)
        {
            try
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
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
