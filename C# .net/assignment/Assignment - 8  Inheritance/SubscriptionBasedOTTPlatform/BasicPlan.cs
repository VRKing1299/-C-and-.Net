using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionBasedOTTPlatform
{
    /// <summary>
    /// this class is child class of Subscription class wich simulates the Basic subscription plan and
    /// provides ints own implementation for the CalculateTotalPrice() method without additional amount
    /// </summary>

    public class BasicPlan : Subscription
    {
        public BasicPlan(string userName, int duration, double basePrice)
            : base(userName, duration, basePrice)
        {
        }

        public override double CalculateTotalPrice()
        {
            return BasePrice * SubscriptionDuration;
        }
    }
}
