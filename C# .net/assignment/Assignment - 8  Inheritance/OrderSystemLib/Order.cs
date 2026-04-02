using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystemLib
{

    /// <summary>
    /// Represents a base abstract order in the e-commerce system.
    /// 
    ///  - This class defines the common properties shared by all types
    ///    of orders, including OrderId, CustomerName, and OrderAmount.
    ///  - It also declares the method CalculateFinalAmount(), which must
    ///    be implemented by derived classes to calculate the final payable amount
    /// 
    /// This class serves as the base for specialized order types
    /// like OnlineOrder and StoreOrder.
    /// </summary>
    /// 
    public abstract class Order
    {
        public int OrderId { get; }
        public string CustomerName { get; }
        public double OrderAmount { get; }

        public Order(int id, string name , double amount)
        {
            #region
            OrderId = id;
            CustomerName = name;
            OrderAmount = amount;
            #endregion
        }

        //method to be overridden
        public abstract double CalculateFinalAmount();
    }
}
