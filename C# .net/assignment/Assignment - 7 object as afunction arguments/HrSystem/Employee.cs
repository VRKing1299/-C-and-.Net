using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrSystem
{
    //this class simulate the entity of an employee with empid, name and basic salary properties 
    public class Employee
    {
        public int EmpId { get; }
        public string Name { get;}
        public double BasicSal { get; }

        public Employee(int empId, string name, double basicSal)
        {
            EmpId = empId;
            Name = name;
            BasicSal = basicSal;
        }


    }
}
