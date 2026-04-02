using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePaymentGatewayLib
{
    /// <summary>
    /// this class in child class of payment sysemt simulate the credit card payment gateway
    /// and provides its own implementation/ overrides the ProcessPayment method with additional processing fee of 2 percent of total amount
    /// </summary>
    public class CreditCardPayment : PaymentSystem
    {
        public CreditCardPayment(int id, double amount, string date) : base(id, amount, date)
        {

        }


        public override double ProcessPayment()
        {
            #region
            double processingFee = Amount * 0.02;
            return Amount + processingFee;
            #endregion
        }
    }
}
