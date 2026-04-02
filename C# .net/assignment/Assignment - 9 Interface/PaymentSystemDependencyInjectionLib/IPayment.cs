using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystemDependencyInjectionLib
{
    /// <summary>
    /// interface to apply common methods for the payments
    /// </summary>
    public interface IPayment
    {
        string ValidatePayment();
        string ProcessPayment();
        string GenerateRecipt();
    }
}
