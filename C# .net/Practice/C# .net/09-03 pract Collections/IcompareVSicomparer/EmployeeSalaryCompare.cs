using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcompareVSicomparer
{
    public class EmployeeSalaryCompare : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.salary - y.salary;
        }
    }
}
