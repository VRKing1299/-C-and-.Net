using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanModuleLib
{
    /// <summary>
    /// this class is represents the loan module and
    /// - has a static method to calculate the emi using EmiCalc method taking user input amount principal rate and tenure
    /// </summary>
    public class Loan
    {
        //static method to calculate the emi using amount principal rate and tenure(borrow period in months)
        public static double EmiCalc(int amount , double principalRate , int tenure)
        {
            #region
            double rate = principalRate / 100;//converts percent into number

            double emi = (amount * rate * (Power(1 + rate, tenure) / (Power(1 + rate, tenure) - 1)));//formula for calculating emi
            return emi;
            #endregion
        }

        //method to calculate power
        public static double Power(double val1,int val2)
        {
            #region
            for (int i = 0; i< val2; i++)
            {
                val1 += val1;
            }
            return val1;
            #endregion
        }
    }
}
