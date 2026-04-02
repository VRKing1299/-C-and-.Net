using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceSystemLib
{
    //delegate the store the type of payment method
    public delegate void PaymentDelegate(double amount);

    /// <summary>
    /// OrderProcessing class usded formorder processing
    /// contains a method pay wich uses delegate for processing payment
    /// </summary>
    public class OrderProcessing
    {

        //pay mehtod using delegate and amout to process the payment
        public void Pay(PaymentDelegate pd,double amount)
        {
            pd(amount);//payment processing
        }
    }
}
