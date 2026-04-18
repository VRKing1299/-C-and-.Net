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
    public class OrdersController : ApiController
    {
        [HttpPost]
        public string AddOrder(OrderData order)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // 1) checking fo rthe existing quantity of the item if not enough returning string 
                    foreach (OrderItems item in order.OrderItems)
                    {
                        string checkQuery = "select StockQuantity from Products where ProdId = @id";
                        SqlCommand checkCmd = new SqlCommand(checkQuery, con, transaction);
                        checkCmd.Parameters.AddWithValue("@id", item.ProdId);

                        var stock = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (stock < item.Quantity)
                        {
                            throw new Exception( $"Not enough quantity for {item.ProdName}");
                        }

                    }

                    //2) Inseting OrderData 
                    string orderQuery = "insert into Orders (UserId, TotalAmount) OUTPUT INSERTED.OrderId values (@uid, @total)";
                    SqlCommand orderCmd = new SqlCommand(orderQuery, con, transaction);
                    orderCmd.Parameters.AddWithValue("@uid", order.UserId);
                    orderCmd.Parameters.AddWithValue("@total", order.TotalAmount);

                    int orderId = Convert.ToInt32(orderCmd.ExecuteScalar());

                    //3) Inserting the items in orderItems table
                    foreach (OrderItems item in order.OrderItems)
                    {
                        //4) updating the stock of the item
                        string updateStock = "update Products set StockQuantity = StockQuantity - @qty where ProdId=@pid";
                        SqlCommand stockCmd = new SqlCommand(updateStock, con, transaction);
                        stockCmd.Parameters.AddWithValue("@qty", item.Quantity);
                        stockCmd.Parameters.AddWithValue("@pid", item.ProdId);

                        stockCmd.ExecuteNonQuery();

                        string itemQuery= "insert into OrderItems (OrderId, ProdId, Quantity, PriceAtPurchase) values (@oid, @pid, @qty, @price)";
                        SqlCommand itemCmd = new SqlCommand(itemQuery, con, transaction);
                        itemCmd.Parameters.AddWithValue("@oid", orderId);
                        itemCmd.Parameters.AddWithValue("@pid", item.ProdId);
                        itemCmd.Parameters.AddWithValue("@qty", item.Quantity);
                        itemCmd.Parameters.AddWithValue("@price", item.PriceAtPurchase);

                        itemCmd.ExecuteNonQuery();

                        
                    }

                    //5) deleteing the items from cart

                    string clearCart = "delete from CartItems where UserId=@uid";
                    SqlCommand clearCmd = new SqlCommand(clearCart, con, transaction);
                    clearCmd.Parameters.AddWithValue("@uid", order.UserId);
                    clearCmd.ExecuteNonQuery();

                    //commiting the transactions
                    transaction.Commit();

                    return "Order placed successfully";

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return ex.Message;
                }
            }
        }
    }
}
