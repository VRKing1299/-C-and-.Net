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
using System.Web;
using System.IO;

namespace ToyShopWebAp1.Controllers
{
    /// <summary>
    /// this controller is used to write api for product to perform crud operations
    /// </summary>
    public class ProductController : ApiController
    {
        //this method fetch the list of all the products 
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

                    prodList.Add(product);
                }
                return prodList;
            }
        }

        //this method is used to fetch one proudct using its id
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
        public string AddProduct()
        {
            var request = HttpContext.Current.Request;

            string prodName = request["ProdName"];
            int price = Convert.ToInt32(request["Price"]);
            int stock = Convert.ToInt32(request["StockQuantity"]);
            int categoryId = Convert.ToInt32(request["CategoryId"]);

            var file = request.Files["ImageFile"];

            string fileName = Path.GetFileName(file.FileName);
            string folderPath = HttpContext.Current.Server.MapPath("~/assets/products/"+ fileName);
            //string fullPath = Path.Combine(folderPath, fileName);
            file.SaveAs(folderPath);

            string relativePath = "./assets/products/" + fileName;


            using (SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();

                string query = "insert into Products(ProdName,Price,ImageUrl,StockQuantity,CategoryId) values (@name,@price,@img,@stock,@catID)";
                SqlCommand cmd = new SqlCommand(query, con);
                #region
                cmd.Parameters.AddWithValue("@name", prodName);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@img", relativePath);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@catID", categoryId);
                #endregion

                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "product is inserted successfully" : "Error Inserting Product";
            }
        }
        //[HttpPost]
        //public string AddProduct(Products prod)
        //{
        //    using (SqlConnection con = DataConnection.GetConnection())
        //    {
        //        con.Open();

        //        string query = "insert into Products(ProdName,Price,ImageUrl,StockQuantity,CategoryId) values (@name,@price,@img,@stock,@catID)";
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        #region
        //        cmd.Parameters.AddWithValue("@name",prod.ProdName);
        //        cmd.Parameters.AddWithValue("@price",prod.Price);
        //        cmd.Parameters.AddWithValue("@img",prod.ImageUrl);
        //        cmd.Parameters.AddWithValue("@stock",prod.StockQuantity);
        //        cmd.Parameters.AddWithValue("@catID",prod.CategoryId);
        //        #endregion

        //        int result = cmd.ExecuteNonQuery();
        //        return result>0?"product is inserted successfully":"Error Inserting Product";
        //    }
        //}

        //this metod is used to update the product takes a product object to update the data
        [HttpPut]
        public string UpdateProduct(Products prod)
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
                cmd.Parameters.AddWithValue("@id",prod.ProdId);
                #endregion

                int result = cmd.ExecuteNonQuery();
                return result > 0 ? "product is Updated successfully" : "Error Updated Product";
            }
        }

        //this method is used to delete the product using product id
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
