using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeManagementSystemLib
{
    /// <summary>
    /// class that represent an employee
    /// without constructor 
    /// has a method set salary that takes employee salary and add the salary with calculating its hra ta and da
    /// </summary>
    public class Employee
    {
        private int empNo;
        public int EmpNo
        {
            get { return empNo; }
        }
        private string empName;
        public string EmpName
        {
            get { return empName; }
        }
        private double salary;
        private double Salary {
            get { return salary; }
            set { salary = value; }
        }
        private double hra, ta, da;

        private double pf, tds;
        private double netSalary, grossSalary;
        public double NetSalary
        {
            get { return netSalary; }
        }
        public double GrossSalary
        {
            get { return grossSalary; }
        }
        //calculates gross salary based on salary and hra,ta,da percentage
        public void calcSalary(double salary, double hra, double ta, double da)
        {
            Salary = salary;
            this.hra = salary * hra;
            this.ta = salary * ta;
            this.da = salary * da;
            grossSalary = Salary + hra + ta + da;
        }
        //method to get salry of employee with its id and name and setting the employee no and name
        public void SetSalary(int empNo, string empName, double salary)
        {
            #region
            if (salary < 0)
            {
                throw new Exception("Salary cannot be negative");
            }
            else if (salary < 5000)
            {
                calcSalary(salary, 0.1, 0.05, 0.15);
            }
            else if (salary < 10000)
            {
                calcSalary(salary, 0.15, 0.1, 0.20);
            }
            else if (salary < 15000)
            {
                calcSalary(salary, 0.2, 0.15, 0.25);
            }
            else if (salary < 20000)
            {
                calcSalary(salary, 0.25, 0.2, 0.30);
            }
            else
            {
                calcSalary(salary, 0.3, 0.25, 0.35);
            }

            this.empNo = empNo;
            this.empName = empName;
            #endregion
        }

        //method to calculate the gross salary
        public void CalculateSalary()
        {
            if (Salary > 0)
            {
                pf = grossSalary * 0.1;
                tds = grossSalary * 0.18;
                netSalary = grossSalary - (pf + tds);
                //HttpContext.Current.Response.Write("Net Salary : " + netSalary);
            }
            else
            {
                throw new Exception("Salary is zero");
            }
        }
    }
}
