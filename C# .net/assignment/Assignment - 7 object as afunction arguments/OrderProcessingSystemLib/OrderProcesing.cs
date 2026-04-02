using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingSystemLib
{
    //this class is used to perform the discount operation on the order using order object in static ApplyDiscount function
    public class OrderProcesing
    {
        public static string ApplyDiscount(Order order)
        {
            string str = "";

            if (order.Amount > 5000 && order.IsDiscountApplied == false)
            {
                #region
                order.IsDiscountApplied = true;
                order.Amount = (order.Amount * 0.9);
                str = " Congratulations you get 10% discount, total price is " + order.Amount;
                #endregion
            }
            else
            #region
            {
                str = "add items of rs" + (5000 - order.Amount) + " more to get discunt";
            }
            #endregion

            return str;
        }
    }
}
