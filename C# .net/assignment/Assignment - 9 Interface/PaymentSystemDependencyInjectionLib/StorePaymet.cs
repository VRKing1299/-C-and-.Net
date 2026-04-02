using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystemDependencyInjectionLib
{
    /// <summary>
    /// this is payment class wich can take payment type using constructor and method and process payment
    /// </summary>
    public class StorePaymet
    {
        IPayment payment;
        public StorePaymet()
        {
        }

        public StorePaymet(IPayment pay)//constructor  injection
        {
            payment = pay;
        }

        public void SetPaymentType(IPayment pay)//method injection
        {
            payment = pay;
        }

        public string ProcssPayment()
        {
            string str;
            str = "Payment Via Store <br>" + payment.ProcessPayment() 
                + " <br>" + payment.ValidatePayment() 
                + "<br>" + payment.GenerateRecipt();

            return str;
        }
    }
}
