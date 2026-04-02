using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderPizzaLib;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        string toppings = txtToppings.Text;
        string quantity = txtQuantity.Text;

        if (toppings == "" && quantity == "" )
        {
            lblOrder.Text= OrderDetails.OrderPizza(name);
        }
        else if (toppings == "")
        {
            lblOrder.Text = OrderDetails.OrderPizza(name,Convert.ToInt16(quantity));
        }
        else if (quantity == "")
        {
            lblOrder.Text = OrderDetails.OrderPizza(name,toppings);
        }
        else if (toppings != "" && quantity != "" && name != "")
        {
            lblOrder.Text = OrderDetails.OrderPizza(name,toppings,Convert.ToInt16(quantity));
        }
    }
}