using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5EmployeeRecordsLib
{
    /// <summary>
    /// this is employee class with simulate the employee entity with empid name and salary feilds
    /// </summary>
    public class Employee
    {
        public int EmpId { get; }
        public string Name { get; }
        public double Salary { get;}

        //this is constructor wich takes 3 arguments that is id name and salary
        public Employee(int id, string name, double salary)
        {
            EmpId = id;
            Name = name;
            Salary = salary;
        }
    }
}
