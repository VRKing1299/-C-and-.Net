using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VendingLib;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //code to load the products in the machine
        try
        {
            SmartVendingMachine vm = new SmartVendingMachine();
            string products = vm.Display();

            Response.Write(products);
        }
        catch (Exception ex)
        {

        }

    }

    //code to calculate the price according to the product srno in array
    protected void btnCalcPrice_Click(object sender, EventArgs e)
    {
        try
        {
            SmartVendingMachine vm = new SmartVendingMachine();
            int srno = Convert.ToInt16(txtSrno.Text);
            int quantity = Convert.ToInt16(txtQuantity.Text);
            int totalPrice = vm.CalcPrice(srno, quantity);
            lblTotalPrice.Text = Convert.ToString(totalPrice);
            if(totalPrice != 10000)
            {
                btnBuy.Visible = true;
            }
        }catch(Exception ex)
        {

        }
    }

    //code to buy the product
    protected void btnBuy_Click(object sender, EventArgs e)
    {
        try
        {
            SmartVendingMachine vm = new SmartVendingMachine();
            int srno = Convert.ToInt16(txtSrno.Text);
            int quantity = Convert.ToInt16(txtQuantity.Text);
            int totalPrice = Convert.ToInt16(lblTotalPrice.Text);
            lblBuyMsg.Text =  vm.Buy(srno,totalPrice,quantity);

        }
        catch(Exception ex)
        {

        }
    }
}