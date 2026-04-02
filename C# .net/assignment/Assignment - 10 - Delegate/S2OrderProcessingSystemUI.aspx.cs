using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderProcessingSystemLib;

/// <summary>
/// this class is used to demonstrait the use of the multicast delegate
/// </summary>
public partial class S2OrderProcessingSystemUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //this function process the order and displays the result
    protected void btnPlaceOrder_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            OrderProcess op = new OrderProcess();
            DelegatePlaceOrder delPlaceOrder = new DelegatePlaceOrder(op.GenerateInvoice);//adding a function to a delegate
            lblResult.Text += delPlaceOrder(Convert.ToDouble(txtAmount.Text));

            delPlaceOrder += new DelegatePlaceOrder(op.SendEmailConfirmation);//adding another function to a delegate
            lblResult.Text += delPlaceOrder(Convert.ToDouble(txtAmount.Text));


            delPlaceOrder += new DelegatePlaceOrder(op.UpdateInventory);//adding another function to a delegate
            lblResult.Text += delPlaceOrder(Convert.ToDouble(txtAmount.Text));

            delPlaceOrder += new DelegatePlaceOrder(op.LogOrderActivity);//adding another function to a delegate
            lblResult.Text += delPlaceOrder(Convert.ToDouble(txtAmount.Text));
            #endregion
        }
        catch (Exception ex) { }
    }
}