using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLib
{
    /// <summary>
    /// employee calss to represent the employee 
    /// it has a constructor that takes first name , last name and salary
    /// </summary>
    public class Employee
    {
        public String FirstName { get; }
        public String LastName { get; }
        private double salary;
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        //constructor
        public Employee(string firstName, string lastName, double salary)
        {
            #region
            FirstName = firstName;
            LastName = lastName;
            this.salary = salary;
            #endregion
        }


    }
}
