using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplicationLib
{

    /// <summary>
    /// this class represents the bank accunt with common bnak name and read only account no and balance
    /// </summary>
    public class Account
    {
        public static string bankName = "HDFC";
        public readonly double accountNo;
        public int Balance { get; set; }

        public Account(double accNo, int balance)
        {
            accountNo = accNo;
            Balance = balance;
        }
    }
}
