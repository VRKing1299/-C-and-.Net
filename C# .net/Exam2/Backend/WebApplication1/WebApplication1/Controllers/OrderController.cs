using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// this class is used to create opi for orders data
    /// </summary>
    public class OrderController : ApiController
    {
        //this method is used to get order by order id
        [HttpGet]
        public List<Order> GetOrderData(int id)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();
                List<Order> listOrderData = new List<Order>();
                try
                {
                    //fetching the orders of the user using user id
                    string fetchQuery = "select * from Orders where OrderId=@uid ";
                    SqlCommand fetchCmd = new SqlCommand(fetchQuery, con);
                    fetchCmd.Parameters.AddWithValue("@uid", id);

                    SqlDataReader rdr = fetchCmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        List<OrderItems> listItems = new List<OrderItems>();
                        Order orders = new Order()
                        {
                            #region
                            OrderId = Convert.ToInt32(rdr["OrderId"]),
                            OrderDate = Convert.ToDateTime(rdr["OrderDate"]),
                            TotalAmount = Convert.ToInt32(rdr["TotalAmount"]),
                            #endregion
                        };

                        //fetching orderitems based on order id
                        string fetchOrderItems = "select oi.*, p.ProdName from OrderItems oi inner join Products p on p.ProdId = oi.ProdId where oi.OrderId = @oid";
                        SqlCommand fetchItems = new SqlCommand(fetchOrderItems, con);
                        fetchItems.Parameters.AddWithValue("@oid", orders.OrderId);

                        SqlDataReader itemsRdr = fetchItems.ExecuteReader();
                        while (itemsRdr.Read())
                        {
                            OrderItems oi = new OrderItems()
                            {
                                #region
                                OrderItemsId = Convert.ToInt32(itemsRdr["OrderItemId"]),
                                OrderId = Convert.ToInt32(itemsRdr["OrderId"]),
                                ProdId = Convert.ToInt32(itemsRdr["ProdId"]),
                                ProdName = Convert.ToString(itemsRdr["ProdName"]),
                                Quantity = Convert.ToInt32(itemsRdr["Quantity"]),
                                PriceAtPurchase = Convert.ToInt32(itemsRdr["PriceAtPurchase"])
                                #endregion
                            };

                            listItems.Add(oi);
                        }
                        orders.OrderItems = listItems;
                        listOrderData.Add(orders);
                    }
                    return listOrderData;
                }
                catch (Exception ex)
                {
                    return listOrderData;
                    //throw new Exception(ex.Message);
                }
            }
        }

        //this method is used to get all the orders
        [HttpGet]
        [Route("api/Order/getAllOrders")]
        public List<Order> GetAllOrderData()
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();
                List<Order> listOrderData = new List<Order>();
                try
                {
                    //fetching the orders of the user using user id
                    string fetchQuery = "select * from Orders order by OrderId desc";
                    SqlCommand fetchCmd = new SqlCommand(fetchQuery, con);

                    SqlDataReader rdr = fetchCmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        List<OrderItems> listItems = new List<OrderItems>();
                        Order orders = new Order()
                        {
                            #region
                            OrderId = Convert.ToInt32(rdr["OrderId"]),
                            OrderDate = Convert.ToDateTime(rdr["OrderDate"]),
                            TotalAmount = Convert.ToInt32(rdr["TotalAmount"]),
                            #endregion
                        };

                        //fetching orderitems based on order id
                        string fetchOrderItems = "select oi.*, p.ProdName from OrderItems oi inner join Products p on p.ProdId = oi.ProdId where oi.OrderId = @oid";
                        SqlCommand fetchItems = new SqlCommand(fetchOrderItems, con);
                        fetchItems.Parameters.AddWithValue("@oid", orders.OrderId);

                        SqlDataReader itemsRdr = fetchItems.ExecuteReader();
                        while (itemsRdr.Read())
                        {
                            OrderItems oi = new OrderItems()
                            {
                                #region
                                OrderItemsId = Convert.ToInt32(itemsRdr["OrderItemId"]),
                                OrderId = Convert.ToInt32(itemsRdr["OrderId"]),
                                ProdId = Convert.ToInt32(itemsRdr["ProdId"]),
                                ProdName = Convert.ToString(itemsRdr["ProdName"]),
                                Quantity = Convert.ToInt32(itemsRdr["Quantity"]),
                                PriceAtPurchase = Convert.ToInt32(itemsRdr["PriceAtPurchase"])
                                #endregion
                            };

                            listItems.Add(oi);
                        }
                        orders.OrderItems = listItems;
                        listOrderData.Add(orders);
                    }
                    return listOrderData;
                }
                catch (Exception ex)
                {
                    return listOrderData;
                    //throw new Exception(ex.Message);
                }
            }
        }


        //method used to place an order
        [HttpPost]
        public int AddOrder(Order order)
        {
            using (SqlConnection con = DataConnection.GetConnection())
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();//if error happens we can roll back

                try
                {

                    //1) Inseting OrderData 
                    string orderQuery = "insert into Orders (UserId, TotalAmount) OUTPUT INSERTED.OrderId values (@uid, @total)";
                    SqlCommand orderCmd = new SqlCommand(orderQuery, con, transaction);
                    orderCmd.Parameters.AddWithValue("@uid", order.UserId);
                    orderCmd.Parameters.AddWithValue("@total", order.TotalAmount);

                    int orderId = Convert.ToInt32(orderCmd.ExecuteScalar());

                    //2) Inserting the items in orderItems table using order id
                    foreach (OrderItems item in order.OrderItems)
                    {
                        string itemQuery = "insert into OrderItems (OrderId, ProdId, Quantity, PriceAtPurchase) values (@oid, @pid, @qty, @price)";
                        #region
                        SqlCommand itemCmd = new SqlCommand(itemQuery, con, transaction);
                        itemCmd.Parameters.AddWithValue("@oid", orderId);
                        itemCmd.Parameters.AddWithValue("@pid", item.ProdId);
                        itemCmd.Parameters.AddWithValue("@qty", item.Quantity);
                        itemCmd.Parameters.AddWithValue("@price", item.PriceAtPurchase);
                        #endregion

                        itemCmd.ExecuteNonQuery();

                        //3) updating the stock of the item
                        #region
                        string updateStock = "update Products set StockQuantity = StockQuantity - @qty where ProdId=@pid";
                        SqlCommand stockCmd = new SqlCommand(updateStock, con, transaction);
                        stockCmd.Parameters.AddWithValue("@qty", item.Quantity);
                        stockCmd.Parameters.AddWithValue("@pid", item.ProdId);
                        #endregion

                        stockCmd.ExecuteNonQuery();


                    }

                    //4) deleteing the items from cart
                    #region
                    string clearCart = "delete from CartItems where UserId=@uid";
                    SqlCommand clearCmd = new SqlCommand(clearCart, con, transaction);
                    clearCmd.Parameters.AddWithValue("@uid", order.UserId);
                    clearCmd.ExecuteNonQuery();
                    #endregion

                    //commiting the transactions
                    transaction.Commit();

                    return orderId;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();//rollback if error
                    return 0;
                }
            }
        }
    }
}
