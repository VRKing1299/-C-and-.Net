using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingSystemLib
{
    //this is delegaate 
    public delegate string DelegatePlaceOrder(double amount);

    //this is onle shop class
    public class OnlineShop
    {
        //this is place order method which takes order delegate and amount and calls delegate 
        public static string PlaceOrder(DelegatePlaceOrder placeOrder, double amount)
        {
            return placeOrder(amount);
        }
    }
}
