using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionBasedOTTPlatform
{

    /// <summary>
    /// this class prepresents abstract Subscription class in subscription ott based platform
    /// this class stores the common subscription plan information and requires the implementing class to 
    /// provide its own method for calculating total price
    /// </summary>
    public abstract class Subscription
    {
        public string UserName { get; }
        public int SubscriptionDuration { get; }   // in months
        public double BasePrice { get; }

        public Subscription(string userName, int duration, double basePrice)
        {
            #region
            UserName = userName;
            SubscriptionDuration = duration;
            BasePrice = basePrice;
            #endregion
        }

        public abstract double CalculateTotalPrice();
    }
}
