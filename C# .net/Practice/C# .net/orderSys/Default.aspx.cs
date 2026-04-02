using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderLib;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        Items I1 = new Items("PAV", 30);
        Items I2 = new Items("Bun", 50);

        OrderDetails od = OrderDetails.GetOrder(I2, 10);

        lblName.Text = od.items.name;
        lblTotalPrice.Text = "" + od.TotalPrice;
        lblOrderId.Text = "" + od.orderNum;

    }
}