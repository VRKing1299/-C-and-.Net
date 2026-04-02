using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionBasedOTTPlatform
{
    /// <summary>
    /// this class is child class of Subscription class wich simulates the Premium subscription plan and
    /// provides ints own implementation for the CalculateTotalPrice() method with additional tax of 18% gst of total amount
    /// </summary>
    public class PremiumPlan : Subscription
    {
        public PremiumPlan(string userName, int duration, double basePrice)
            : base(userName, duration, basePrice)
        {
        }

        public override double CalculateTotalPrice()
        {
            double total = BasePrice * SubscriptionDuration;
            return total + (total * 0.18);
        }
    }
}
