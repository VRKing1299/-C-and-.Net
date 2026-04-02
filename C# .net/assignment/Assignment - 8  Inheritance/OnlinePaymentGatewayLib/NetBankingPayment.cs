using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePaymentGatewayLib
{
    /// <summary>
    /// this class in child class of payment sysemt simulate the net banking payment gateway
    /// and provides its own implementation/ overrides the ProcessPayment method with additional processing fee of 50
    /// </summary>
    public class NetBankingPayment : PaymentSystem
    {
        public NetBankingPayment(int id, double amount, string date) : base(id, amount, date)
        {

        }


        public override double ProcessPayment()
        {
            #region
            double processingFee = 50;
            return Amount + processingFee;
            #endregion
        }
    }
}
