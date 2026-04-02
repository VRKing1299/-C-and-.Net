using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingLib
{

    /// <summary>
    /// this class is used to simulat the bank account
    /// </summary>
    public class Account
    {
        public int AccountNo { get; }
        public string AccountHolderName { get; }
        public double balance;

        public Account(int accountNo, string accountHolderName, double balance)
        {
            AccountNo = accountNo;
            AccountHolderName = accountHolderName;
            this.balance = balance;
        }
    }
}
