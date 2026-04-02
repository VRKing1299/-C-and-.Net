using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystemLib
{
    /// <summary>
    /// this class simulate the order purchases from the store and inherits ints properties form order class
    /// it overrides the CalculateFinalAmount and returns the final amount without any additional charges
    /// </summary>
    public class StoreOrder:Order
    {
        public StoreOrder(int id, string name , double amount) : base(id, name, amount)
        {

        }

        public override double CalculateFinalAmount()
        {
            return OrderAmount;
        }
    }
}
