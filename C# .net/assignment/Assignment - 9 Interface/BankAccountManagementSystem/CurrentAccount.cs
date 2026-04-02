using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem
{

    /// <summary>
    /// current bank account class with balance and overdraft
    /// </summary>
    public class CurrentAccount:IAccount
    {
        private double balance;
        private double overDraftLimit;
        public double Balance
        {
            get
            {
                return balance;
            }
        }
        public double OverDraftLimit
        {
            get { return overDraftLimit; }
        }

        //constructor
        public CurrentAccount(double balance, double overDraftLimit)
        {
            this.balance = balance;
            this.overDraftLimit = overDraftLimit;
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
            #region
            if (amount > balance+ overDraftLimit)
            {
                return 0;
            }
            else
            {
                balance -= amount;
                return amount;
            }
            #endregion
        }
    }
}
