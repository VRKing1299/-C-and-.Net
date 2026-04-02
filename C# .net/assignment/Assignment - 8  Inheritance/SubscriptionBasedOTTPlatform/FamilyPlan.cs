using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionBasedOTTPlatform
{
    /// <summary>
    /// this class is child class of Subscription class wich simulates the Family` subscription plan and
    /// provides ints own implementation for the CalculateTotalPrice() method with additional of 30% price of total amount
    /// </summary>
    public class FamilyPlan : Subscription
    {
        public FamilyPlan(string userName, int duration, double basePrice)
            : base(userName, duration, basePrice)
        {
        }

        public override double CalculateTotalPrice()
        {
            double total = BasePrice * SubscriptionDuration;
            return total + (total * 0.30);
        }
    }
}
