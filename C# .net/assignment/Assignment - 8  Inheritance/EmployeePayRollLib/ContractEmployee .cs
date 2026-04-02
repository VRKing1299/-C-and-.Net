using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollLib
{
    /// <summary>
    /// this is class for contract base employee wich inherits the Employee class and overrides the abstract method of the employee abstract class;
    /// </summary>
    public class ContractEmployee:Employee
    {
        public ContractEmployee(int id, string name, double basicSalary):base(id, name, basicSalary)
        {

        }

        //tempararry emp salary calculation logic
        public override double CalculateSalary()
        {
            return BasicSalary;
        }
    }
}
