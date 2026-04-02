using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystemLib
{
    /// <summary>
    /// this class simulated the employee class with shared emplyee count that increases on each object creation of employee
    /// the class has properties : empid and name
    /// </summary>
    public class Employee
    {
        public static int empCount = 0;
        public int EmpId { get; set; }
        public string Name { get; set; }

        //employee constructor using id and name and increases employee count
        public Employee(int id, string name)
        {
            EmpId = id;
            Name = name;
            empCount++;
        }
    }
}
