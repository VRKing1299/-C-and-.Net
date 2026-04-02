using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessingSystemUI
{
    /// <summary>
    /// this class is child class of Loan class wich represent Car Loan and
    /// provides ints own implementation for the Calculate Interest method with interest rate of 10%
    /// </summary>
    public class CarLoan : Loan
    {
        public CarLoan(int loanId, string customerName, double loanAmount)
            : base(loanId, customerName, loanAmount, 0.10)
        {
        }

        public override double CalculateInterest()
        {
            return LoanAmount * InterestRate;
        }
    }
}
