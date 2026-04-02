using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderProcessingSystemLib;


/// <summary>
/// this class is used to process the order and apply the discount over it
/// </summary>
public partial class OrderProcessingSystemUi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //takes the order and applys the discount
    protected void Button1_Click(object sender, EventArgs e)
    {
        #region
        try
        {
            Order ord = new Order(Convert.ToInt16(txtOrderId.Text), Convert.ToDouble(txtOrderAmount.Text));
            lblDiscountMsg.Text = OrderProcesing.ApplyDiscount(ord);
        }
        catch(Exception ex)
        {

        }
        #endregion
    }
}