using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePaymentGatewayLib
{
    /// <summary>
    /// this class is child class of paymentsystem class wich simulates the upi payment gateway and
    /// provides ints own implementation for the process paymetnt method
    /// </summary>
    public class UPIPayment : PaymentSystem
    {
        public UPIPayment(int id, double amount, string date) : base(id, amount, date)
        {

        }

        //overriden method
        public override double ProcessPayment()
        {
            return Amount;
        }
    }
}
