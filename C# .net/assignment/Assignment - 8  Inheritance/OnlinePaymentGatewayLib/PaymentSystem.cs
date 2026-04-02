using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePaymentGatewayLib
{

    /// <summary>
    /// this class prepresents abstract payment class in payment system
    /// this class stores the common payment information and requires the implementing class to 
    /// provide its own method for payment processing
    /// </summary>
    public abstract class PaymentSystem
    {
        public int TransactionId { get; }
        public double Amount { get; }
        public string PaymentDate { get; }

        //public constructor
        public PaymentSystem(int id, double amount, string date)
        {
            #region
            TransactionId = id;
            Amount = amount;
            PaymentDate = date;
            #endregion
        }

        //abstract method to be overriden
        public abstract double ProcessPayment();
    }
}
