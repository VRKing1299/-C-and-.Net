using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystemDependencyInjectionLib
{

    /// <summary>
    /// credic card class for credt card payments
    /// </summary>
    public class CreditCardPayment:IPayment
    {
        public int Amount { get; }
        //constructor
        public CreditCardPayment(int amount)
        {
            Amount = amount;
        }

        //this is used to genereate the recipt
        public string GenerateRecipt()
        {
            return " Recipt " + Amount;
        }

        //this methd is used to process payment
        public string ProcessPayment()
        {
            return "processing Credit Card payment";
        }

        //this method is used to validate payment
        public string ValidatePayment()
        {
            return " validating Credit Card payment";
        }
    }
}
