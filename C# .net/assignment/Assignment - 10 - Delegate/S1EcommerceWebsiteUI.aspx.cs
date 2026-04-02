using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EcommerceSystemLib;

/// <summary>
/// Code-behind class used to simulate an E-commerce payment system.
/// The user enters the payment amount and selects a payment method
/// (UPI, Credit Card, or Net Banking).
/// 
/// Based on the selected button, a delegate is created that points to
/// the corresponding payment method. The delegate is then passed to
/// the OrderProcessing class which executes the payment.
/// </summary>
public partial class S1EcommerceWebsiteUI : System.Web.UI.Page
{
    //object containing different payment methods
    PaymentMethods pm = new PaymentMethods();

    //object responsible for processing payment using delegate
    OrderProcessing o = new OrderProcessing();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //button click event for UPI payment
    protected void btnBuyUPI_Click(object sender, EventArgs e)
    {
        try
        {
            //create delegate pointing to UPI payment method
            PaymentDelegate p = new PaymentDelegate(pm.UPI);

            //process payment using delegate and amount from textbox
            o.Pay(p, Convert.ToDouble(txtamount.Text));
        }catch(Exception ex) { }
    }

    //button click event for Credit Card payment
    protected void btnCreditCardPayment_Click(object sender, EventArgs e)
    {
        try
        {
            //create delegate pointing to Credit Card payment method
            PaymentDelegate p = new PaymentDelegate(pm.CreditCard);

            //process payment
            o.Pay(p, Convert.ToDouble(txtamount.Text));
        }catch(Exception ex) { }
    }

    //button click event for Net Banking payment
    protected void btnNetBanking_Click(object sender, EventArgs e)
    {
        try
        {
            //create delegate pointing to Net Banking payment method
            PaymentDelegate p = new PaymentDelegate(pm.NetBanking);

            //process payment
            o.Pay(p, Convert.ToDouble(txtamount.Text));
        }catch(Exception ex) { }
    }
}

//class that contains different payment method implementations
public class PaymentMethods
{
    //method to simulate credit card payment
    public void CreditCard(double amount)
    {
        HttpContext.Current.Response.Write("credit card payment : " + amount);
    }

    //method to simulate UPI payment
    public void UPI(double amount)
    {
        HttpContext.Current.Response.Write("Upi payment : " + amount);
    }

    //method to simulate net banking payment
    public void NetBanking(double amount)
    {
        HttpContext.Current.Response.Write("NetBanking payment : " + amount);
    }
}