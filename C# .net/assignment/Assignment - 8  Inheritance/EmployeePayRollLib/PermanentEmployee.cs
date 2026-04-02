using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollLib
{

    /// <summary>
    /// this class is for Permenant emplayee which extends he Employee abstract class with caculated salary method
    /// overriden wich calculates he salary with hra(20% if salary) allowans and bonus(10% of salary) added to the salary
    /// </summary>
    public class PermanentEmployee:Employee
    {
        public PermanentEmployee(int id, string name, double basicSalary):base(id, name, basicSalary)
        {

        }

        //permanant emp salary calculation logic
        public override double CalculateSalary()
        {
            #region
            double hra = BasicSalary * 0.20;
            double bonus = BasicSalary * 0.10;

            return BasicSalary + hra + bonus;
            #endregion
        }
    }
}
