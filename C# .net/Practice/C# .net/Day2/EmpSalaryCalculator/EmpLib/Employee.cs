using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpLib
{
    /// <summary>
    ///  employee class for employee method and obj
    /// </summary>
    public class Employee
    {
        public int Basic { get; set; }
        public int Hra { get; set; }
        public int Da { get; set; }
        public int Pf { get; set; }

        public string Name { get; set; }
        public string Id { get; set; }
        public string company;


        //constructors of employee class
        public Employee()
        {
            company = "inogic";
        }

        public Employee(string name, string id, int basic ,int hra, int da, int pf)
        {
            this.Name = name;
            this.Id = id;
            this.Salary = basic;
            this.Hra = hra;
            this.Da = da;
            this.Pf = pf;
            company = "Inogic";
        }

        //method to calculate the net salary of the employee
        public int CalcNetSalary()
        {
            return ((Basic + Hra + Da) - Pf);
        }


        //to read and to assign the employee salary
        public int Salary
        {
            get
            {
                return Basic;
            }
            set
            {
                if (value > 0)
                {
                    Basic = value;
                }
                else
                {
                    Basic = 1000;
                }
            }
        }

        public string CompanyName
        {
            get
            {
                return company;
            }
        }

    }
}
