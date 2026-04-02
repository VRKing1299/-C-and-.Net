using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem
{
    /// <summary>
    /// this is account iterface of account
    /// with one property and 3 methods
    /// </summary>
    public interface IAccount
    {
        double Balance { get;}

        void Deposit(double amount);
        double Widraw(double amount);
        double CheckBalance();
    }
}
