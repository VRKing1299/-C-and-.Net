using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollLib
{

    /// <summary>
    /// this is basic abstract class employee wich contains employee id , name  and basic salary
    /// it also has an abstract method for calculating the salary which an extended/inheritaded concrete class should override f
    /// </summary>
    public abstract class Employee
    {
        public int EmployeeId { get; }
        public string EmployeeName { get; }
        public double BasicSalary { get; }

        public Employee(int id, string name, double basicSalary)
        {
            #region
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = basicSalary;
            #endregion
        }

        public abstract double CalculateSalary();
    }
}
