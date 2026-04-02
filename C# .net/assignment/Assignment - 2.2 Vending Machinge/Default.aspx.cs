using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VendingLib;

/// <summary>
/// this class is used to simulate vending machine , on loading of page it displays the list of items available , 
/// it can also carry out basic functionality like:
/// - Displaying the available products in the vending machine.
/// - btnCalcPrice_Click to calculate the price of item based on item number and quantity from user input
/// - btnBuy_Click btn to buy the items if it is available
/// All operations are performed based on user input and are triggered
/// through button click events in the webpage.
/// </summary>
public partial class _Default : System.Web.UI.Page
{

    //create vending machine object to access machine functions
    SmartVendingMachine machine = new SmartVendingMachine();

    protected void Page_Load(object sender, EventArgs e)
    {
        //display list of available products when page loads
        lblProducts.Text = machine.Display();
    }

    //calculate total price based on item number and quantity
    protected void btnCalcPrice_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            //get user input
            int srno = Convert.ToInt32(txtSrNo.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);

            //calculate price using vending machine logic
            int totalPrice = machine.CalcPrice(srno, quantity);

            //check if stock is insufficient
            if (totalPrice == 10000)
            {
                lblResult.Text = "Item Insufficient";
            }
            else
            {
                btnBuy.Visible = true; //show buy button

                //display total price
                lblResult.Text = " | Total Price: ₹" + totalPrice;
            }

            //refresh product list after operation
            lblProducts.Text = machine.Display();
            #endregion
        }
        catch (Exception ex) { }
    }

    //buy the selected product
    protected void btnBuy_Click(object sender, EventArgs e)
    {
        try
        {
            //get user input
            int srno = Convert.ToInt32(txtSrNo.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);

            //calculate price again before purchase
            int totalPrice = machine.CalcPrice(srno, quantity);

            //call buy method to process purchase
            string msg = machine.Buy(srno, totalPrice, quantity);

            //display purchase message
            lblResult.Text += msg;
        }
        catch (Exception ex) { }
    }
}