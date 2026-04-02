using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem
{
    /// <summary>
    /// this class is used to process the salary of the employee using
    ///  - static method CalculateSalary that takes employee object and updates its netsalary
    /// </summary>
    public class SalaryProcessor
    {
        public static double CalculateSalary(Employee emp)
        {
            double hra = 0.20 * emp.BasicSal;
            double tax = 0.10 * emp.BasicSal;
            double netSalary = emp.BasicSal + hra - tax;

            return netSalary;
        }
    }
}
