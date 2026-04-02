using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystemLib
{
    /// <summary>
    /// this class simulates the online order and inherits the order class and 
    ///  - has a private feild shipping charge that is 100
    ///  - has a constuctor to pass vlaue to teh base class
    ///  - overrides the CalculateFinalAmount method which returns the total amount with shipping charges
    /// </summary>
    public class OnlineOrder:Order
    {
        private double ShippingCharge = 100;

        public OnlineOrder(int orderId, string customerName, double orderAmount)
            : base(orderId, customerName, orderAmount)
        {
        }

        public override double CalculateFinalAmount()
        {
            return OrderAmount + ShippingCharge;
        }
    }
}
