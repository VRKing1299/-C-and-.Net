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
    /// this class is used to create the controller for the cart
    /// </summary>
    public class CartController : ApiController
    {
        //method to get all the cart items of a user
        [HttpGet]
        public List<Cart> GetCartItems(int id)
        {
            try
            {
                List<Cart> list = new List<Cart>();
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    con.Open();
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
                        #endregion

                        list.Add(cart);
                    }
                    return list;
                }
            }catch(Exception ex)
            {
                return null;
            }
        }

        //method to add the product to the cart
        [HttpPost]
        public string AddCartItem(Cart cart)
        {
            try
            {
                string query = "insert into CartItems (UserId, ProdId, Quantity) values(@userId,@prodId,1)";

                using (SqlConnection con = DataConnection.GetConnection())
                {
                    #region
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@userId", cart.UserId);
                    cmd.Parameters.AddWithValue("@prodId", cart.ProdId);

                    int result = cmd.ExecuteNonQuery();

                    return result > 0 ? "product added to cart" : "failed to add product";
                    #endregion
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        //method to update the existing product quantity
        [HttpPut]
        public string UpdateProduct(Cart cartItem)
        {
            try
            {
                string query = "update CartItems set Quantity=@quantity where CartItemId=@id";

                using (SqlConnection con = DataConnection.GetConnection())
                {
                    #region
                    con.Open();

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@quantity", cartItem.Quantity);
                    cmd.Parameters.AddWithValue("@id", cartItem.CartItemId);

                    int result = cmd.ExecuteNonQuery();

                    return result > 0 ? "product quantity updated" : "failed to update product Quantity";
                    #endregion
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        //method to delete the product from cart
        [HttpDelete]
        public string DeleteProduct(int cartItemId)
        {
            try
            {
                string query = "delete from CartItems where CartItemId=@id";
                using (SqlConnection con = DataConnection.GetConnection())
                {
                    #region
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", cartItemId);

                    int result = cmd.ExecuteNonQuery();

                    return result > 0 ? "product removed from cart " : "faild to remove product from cart";
                    #endregion
                }
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
