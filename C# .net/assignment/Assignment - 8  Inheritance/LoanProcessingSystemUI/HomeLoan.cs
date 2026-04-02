using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessingSystemUI
{
    /// <summary>
    /// this class is child class of Loan class wich represent Home Loan and
    /// provides ints own implementation for the Calculate Interest method with interest rate of 8%
    /// </summary>
    public class HomeLoan : Loan
    {
        public HomeLoan(int loanId, string customerName, double loanAmount)
            : base(loanId, customerName, loanAmount, 0.08)
        {
        }

        public override double CalculateInterest()
        {
            return LoanAmount * InterestRate;
        }
    }
}
