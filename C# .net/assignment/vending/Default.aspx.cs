using System;
using VendingLib;

public partial class _Default : System.Web.UI.Page
{
    SmartVendingMachine machine = new SmartVendingMachine();

    protected void Page_Load(object sender, EventArgs e)
    {
            lblProducts.Text = machine.Display();
    }

    protected void btnBuy_Click(object sender, EventArgs e)
    {
        int srno = Convert.ToInt32(txtSrNo.Text);
        int quantity = Convert.ToInt32(txtQuantity.Text);

        int totalPrice = machine.CalcPrice(srno, quantity);

        if (totalPrice == 10000)
        {
            lblResult.Text = "Item Insufficient";
        }
        else
        {
            string msg = machine.Buy(srno, totalPrice, quantity);
            lblResult.Text = msg + " | Total Price: ₹" + totalPrice;
        }

        lblProducts.Text = machine.Display();
    }
}