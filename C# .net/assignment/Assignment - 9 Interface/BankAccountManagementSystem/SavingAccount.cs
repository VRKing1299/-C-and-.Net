using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem
{

    /// <summary>
    /// Saving bank account class with its functionlality
    /// </summary>
    public class SavingAccount : IAccount
    {
        private double balance;
        public double Balance
        {
            get
            {
                return balance;
            }
        }

        //constructor
        public SavingAccount(double balance)
        {
            this.balance = balance;
        }


        // returns the current balance
        public double CheckBalance()
        {
            return Balance;
        }
        //method to deposit the amount to the Account
        public void Deposit(double amount)
        {
            balance += amount;
        }

        //method to widraw the amout with validation check
        public double Widraw(double amount)
        {
            if (amount > balance)
            {
                return 0;
            }
            else
            {
                balance -= amount;
                return amount;
            }
        }
    }
}
