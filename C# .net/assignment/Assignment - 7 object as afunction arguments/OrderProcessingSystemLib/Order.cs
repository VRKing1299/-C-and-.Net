using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingSystemLib
{
    /// <summary>
    /// this class simulates the order entity
    /// - with order id, amount and isDiscountApplied ( for discount )
    /// </summary>

    public class Order
    {
        #region
        public int OrderId { get; }
        public double Amount { get; set; }
        public bool IsDiscountApplied = false;

        public Order (int orderId, double amount)
        {
            #region
            OrderId = orderId;
            Amount = amount;
            #endregion
        }
        #endregion
    }
}
