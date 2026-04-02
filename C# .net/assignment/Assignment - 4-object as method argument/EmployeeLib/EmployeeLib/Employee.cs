using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    /// <summary>
    /// this class represents the employee with name, position and salary
    ///  - has a method that is used to promote the employee and takes employee object as an input and gives before and after salary as output 
    /// </summary>
    public class Employee
    {

        public string Name { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public const string COMPANY = "Inogic";

        //object constructor
        public Employee(string name, string position, int salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        // method takes and employee object updates the salary and returns before and after salary
        public static void PromoteEmployee(Employee emp, out int beforeSal, out int afterSal)
        {

            beforeSal = emp.Salary;
            emp.Salary = emp.Salary + Convert.ToInt16(emp.Salary * 0.10);//updates teh employee salary with 10% hike
            afterSal = emp.Salary;
        }
    }
}
