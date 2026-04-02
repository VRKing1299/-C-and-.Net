using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S8E_CommerceOrderManagementLib
{
    /// <summary>
    /// this is order class simulate the order placed in ecommerce website
    /// </summary>
    public class Order
    {
        public int OrderId { get; }
        public string CustomerName { get; }
        public double Amount { get; }

        //constructor for order class
        public Order() { }
        public Order(int id , string name, double amount)
        {
            OrderId = id;
            CustomerName = name;
            Amount = amount;
        }
    }
}
