using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingLib
{

    /// <summary>
    /// this class simulates the methdos the bank use to transfer the amount from one bank account to another using 
    /// static TransferAmount method that takes the object of bank account sender and reciver and amount to transfer
    /// </summary>
    public class BankMethods
    {
        public static string TransferAmount(Account senderAcc, Account reciverAcc, double amount)
        {
            #region
            string str;
            if (amount <= 0)
            {
                str = "amount cannot be negative or zero";
            }
            else if (senderAcc.balance < amount)
            {
                str = "insufficient balance";
            }
            else
            {
                senderAcc.balance -= amount;
                reciverAcc.balance += amount;

                str = " Rs " + amount + " sent from  " + senderAcc.AccountHolderName + " to " + reciverAcc.AccountHolderName;

            }
            return str;
            #endregion
        }
    }
}
