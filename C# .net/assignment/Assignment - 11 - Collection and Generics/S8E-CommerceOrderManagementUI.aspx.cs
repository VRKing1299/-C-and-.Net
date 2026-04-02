using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using S8E_CommerceOrderManagementLib;
/// <summary>
/// this class is used to process user input from ui
/// it has btnOnlineEcommetceMgtDemo_Click method which demonstraits the behaviour of orderlist on user click
/// </summary>
public partial class S8E_CommerceOrderManagementUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //this method which demonstraits the behaviour of orderlist on user click
    protected void btnOnlineEcommetceMgtDemo_Click(object sender, EventArgs e)
    {
        try
        {
            List<Order> orderList = new List<Order>()
            {
            #region
                new Order(1,"chandni",12),
                new Order(2,"chatni",50),
                new Order(3,"drJatka",20),
                new Order(4,"Kaliya",45)
            #endregion
            };
            Response.Write("Displaying all prders :<br>");
            Print(orderList);

            #region //code to find the order with highest amount
            double amount = 0;
            Order ord = new Order();
            foreach (Order o in orderList)
            {
                if (o.Amount > amount)
                {
                    amount = o.Amount;
                    ord = o;
                }
            }
            Response.Write("order with highest amount is : Id : " + ord.OrderId + ", Name : " + ord.CustomerName + ", amount : " + ord.Amount + "<br>");
            #endregion

            //deleting the order item from list using order id 
            int orderId = 3;
            orderList.RemoveAll(o => o.OrderId == orderId);
            Response.Write("<br><br> after removing order with order id :" + orderId + "<br>");
            Print(orderList);   
        }catch(Exception ex) { }

    }

    #region//method to print the list
    public void Print(List<Order> ls)
    {
        foreach (Order o in ls)
        {
            Response.Write("Id : " + o.OrderId + ", Name : "+ o.CustomerName+", amount : "+o.Amount+"<br>");
        }
        Response.Write("<br>");
    }
    #endregion
}