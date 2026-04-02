using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PaymentSystemDependencyInjectionLib;

/// <summary>
/// this page is used to process the payments using different dependency injection
/// </summary>
public partial class S1PaymentSystemDependencyInjectionUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Upi pament processing
    protected void btnUpi_Click(object sender, EventArgs e)
    {
        try
        {
            StorePaymet st = new StorePaymet(new UPIPayment(Convert.ToInt16(txtAmount.Text)));
            lblPaymentProcess.Text = st.ProcssPayment();
        }catch(Exception ex) { }
    }

    //NetBanking pament processing
    protected void btnNetBanking_Click(object sender, EventArgs e)
    {
        try
        {
            IPayment netBanking = new NetBankingPayment(Convert.ToInt16(txtAmount.Text));
            StorePaymet st = new StorePaymet();
            st.SetPaymentType(netBanking);
            lblPaymentProcess.Text = st.ProcssPayment();
        }catch(Exception ex) { }
    }

    //CreditCard pament processing
    protected void btnCreditCard_Click(object sender, EventArgs e)
    {
        try
        {
            StorePaymet st = new StorePaymet(new CreditCardPayment(Convert.ToInt16(txtAmount.Text)));
            lblPaymentProcess.Text = st.ProcssPayment();
        }catch(Exception ex) { }
    }
}