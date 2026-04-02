using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessingSystemUI
{
    /// <summary>
    /// this class is child class of Loan class wich represent Personal Loan and
    /// provides ints own implementation for the Calculate Interest method with interest rate of 12%
    /// </summary>
    public class PersonalLoan : Loan
    {
        public PersonalLoan(int loanId, string customerName, double loanAmount)
            : base(loanId, customerName, loanAmount, 0.12)
        {
        }

        public override double CalculateInterest()//overrriden method
        {
            return LoanAmount * InterestRate;
        }
    }
}
