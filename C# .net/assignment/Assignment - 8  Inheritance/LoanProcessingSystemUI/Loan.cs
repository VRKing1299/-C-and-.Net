using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessingSystemUI
{

    /// <summary>
    ///this class prepresents abstract Loan class in Loan Processing system
    /// this class stores the Loan information and requires the implementing class to 
    /// provide its own method for calculating Interest.
    /// </summary>
    public abstract class Loan
    {
        public int LoanId { get; }
        public string CustomerName { get; }
        public double LoanAmount { get; }
        public double InterestRate { get; }

        public Loan(int loanId, string customerName, double loanAmount, double interestRate)
        {
            #region
            LoanId = loanId;
            CustomerName = customerName;
            LoanAmount = loanAmount;
            InterestRate = interestRate;
            #endregion
        }

        public abstract double CalculateInterest();//method to be overriddn
    }
}
