using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClassLibrary2
{
    public class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public double Salary { get; set; }

        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public event EventHandler<SalaryIncerementArgs> onSalaryIncrement;
        
        public void SalaryIncrement(double increment)
        {
            Salary += increment;
            HttpContext.Current.Response.Write("Employee id : " + Id + " Name: " + Name + " has gotton salary increment of rs " +
                increment + " , total salary : " + Salary +"<br>");

            SalaryIncerementArgs args = new SalaryIncerementArgs() { EmpId = Id, EmpName = Name, EmpSalary = Salary, Increment = increment };
            
            if (onSalaryIncrement != null)
            {
                onSalaryIncrement(this, args);
            }
        }


    }

    public class SalaryIncerementArgs : EventArgs
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double EmpSalary { get; set; }
        public double Increment { get; set; }
    }
}

