using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystemLib
{
    //interface to apply common methods for the payments
    public interface IPayment
    {
        string ValidatePayment();
        string ProcessPayment();
        string GenerateRecipt();
    }
}
