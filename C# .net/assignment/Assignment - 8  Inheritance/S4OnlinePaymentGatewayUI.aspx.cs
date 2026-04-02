using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlinePaymentGatewayLib;

/// <summary>
/// thi is the code behid the class to simulate the payment gateway system
/// user needs to provide id amount to be bayed and date for the transaction to proceed
/// the transaction like credit card, upi or net banking payment type will be selected by the user on button click
/// the transaction will be performed using the currosponding class present inside the OnlinePaymentGatewayLib and the result will be displayed
/// </summary>
public partial class S4OnlinePaymentGatewayUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //btn for credit card payment oprtions
    protected void btnPayCreditCard_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt32(txtId.Text);
            double amount = Convert.ToDouble(txtAmount.Text);
            string date = txtDate.Text;

            //creating an object
            CreditCardPayment payment = new CreditCardPayment(id, amount, date);

            // Display calculated result
            lblResult.Text = "Credit Card Payment Successful. Final Amount: ₹"
                             + payment.ProcessPayment();
            #endregion
        }
        catch (Exception ex) { }
    }

    //btn for net banking options
    protected void btnPayNetBanking_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt32(txtId.Text);
            double amount = Convert.ToDouble(txtAmount.Text);
            string date = txtDate.Text;

            //creating an object
            NetBankingPayment payment = new NetBankingPayment(id, amount, date);

            // Display calculated result
            lblResult.Text = "Net Banking Payment Successful. Final Amount: ₹"
                             + payment.ProcessPayment();
            #endregion
        }
        catch(Exception ex) { }
    }

    //btn for UPI payment options
    protected void btnPayUPI_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt32(txtId.Text);
            double amount = Convert.ToDouble(txtAmount.Text);
            string date = txtDate.Text;

            //creating an object
            UPIPayment payment = new UPIPayment(id, amount, date);

            // Display calculated result
            lblResult.Text = "UPI Payment Successful. Final Amount: ₹"
                             + payment.ProcessPayment();
            #endregion
        }
        catch(Exception ex) { }
    }
}