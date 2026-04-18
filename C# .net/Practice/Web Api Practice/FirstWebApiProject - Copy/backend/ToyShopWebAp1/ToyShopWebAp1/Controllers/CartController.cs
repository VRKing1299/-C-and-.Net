using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using ToyShopWebAp1.Models;
using ToyShopWebAp1.Helper;

namespace ToyShopWebAp1.Controllers
{
    public class CartController : ApiController
    {
        //method to get the cart items of user using user id
        [HttpGet]
        public List<Cart> GetCart(int id)
        {
            List<Cart> cartList = new List<Cart>();

            using(SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();
                //query to get the product data
                string query = "select c.CartItemId, c.Quantity , p.ProdId,p.ProdName,p.Price, (p.Price * c.Quantity) as TotalPrice ,p.ImageUrl,p.StockQuantity from CartItems c left outer join Products p on c.ProdId = p.ProdId where c.UserId = @id ";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                //executing the query
                SqlDataReader rdr = cmd.ExecuteReader();

                //adding the cart data to the list
                while (rdr.Read())
                {
                    #region
                    Cart cart = new Cart()
                    {
                        CartItemId = Convert.ToInt32(rdr["CartItemId"]),
                        Quantity = Convert.ToInt32(rdr["Quantity"]),
                        ProdId = Convert.ToInt32(rdr["ProdId"]),
                        ProdName = Convert.ToString(rdr["ProdName"]),
                        Price = Convert.ToDouble(rdr["Price"]),
                        TotalPrice = Convert.ToDouble(rdr["TotalPrice"]),
                        ImageUrl = Convert.ToString(rdr["ImageUrl"]),
                        StockQuantity = Convert.ToInt32(rdr["StockQuantity"])
                    };

                    cartList.Add(cart);
                    #endregion
                }
                rdr.Close();
            }

            return cartList;
        }

        //method to add the product to the cart
        [HttpPost]
        public string AddProductToCart(Cart cart)
        {
            string query = "insert into CartItems (UserId, ProdId, Quantity) values(@userId,@prodId,1)";
            
            using(SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", cart.UserId);
                cmd.Parameters.AddWithValue("@prodId", cart.ProdId);

                int result = cmd.ExecuteNonQuery();

                return result > 0 ? "product added to cart cuccessfully" : "failed to add product";
            }
        }

        //method to update the product quantity
        [HttpPut]
        public string UpdateProduct(Cart cartItem)
        {
            string query = "update CartItems set Quantity=@quantity where CartItemId=@id";

            using(SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@quantity", cartItem.Quantity);
                cmd.Parameters.AddWithValue("@id", cartItem.CartItemId);

                int result = cmd.ExecuteNonQuery();

                return result > 0 ? "product quantity updated successfully" : "failed to update product Quantity";
            }
        }

        //method to delete the product from cart
        [HttpDelete]
        public string DeleteProduct(int cartItemId)
        {
            string query = "delete from CartItems where CartItemId=@id";
            using(SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id",cartItemId);

                int result = cmd.ExecuteNonQuery();

                return result > 0 ? "product removed from cart successfully" : "faild to remove product from cart";
            }
        }
    }
}
