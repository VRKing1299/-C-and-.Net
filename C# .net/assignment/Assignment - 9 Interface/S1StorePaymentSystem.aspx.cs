using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PaymentSystemLib;


/// <summary>
/// this page is used to process the payments
/// </summary>
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //Upi pament processing
    protected void btnUpi_Click(object sender, EventArgs e)
    {
        try
        {
            IPayment payment = new UPIPayment(Convert.ToInt16(txtAmount.Text));
            lblPaymentProcess.Text = "" + payment.ProcessPayment() + " <br>" + payment.ValidatePayment() + "<br>" + payment.GenerateRecipt();
        }
        catch(Exception ex) { }
    }

    //NetBanking pament processing
    protected void btnNetBanking_Click(object sender, EventArgs e)
    {
        try
        {
            IPayment payment = new NetBankingPayment(Convert.ToInt16(txtAmount.Text));
            lblPaymentProcess.Text = "" + payment.ProcessPayment() + " <br>" + payment.ValidatePayment() + "<br>" + payment.GenerateRecipt();
        }catch(Exception ex) { }
    }

    //CreditCard pament processing
    protected void btnCreditCard_Click(object sender, EventArgs e)
    {
        try
        {
            IPayment payment = new CreditCardPayment(Convert.ToInt16(txtAmount.Text));
            lblPaymentProcess.Text = "" + payment.ProcessPayment() + " <br>" + payment.ValidatePayment() + "<br>" + payment.GenerateRecipt();
        }
        catch(Exception ex) { }
    }
}