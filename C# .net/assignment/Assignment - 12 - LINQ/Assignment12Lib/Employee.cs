using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment12Lib
{
    /// <summary>
    /// this is employee class with attribute id, name , salary , dept(department name) , deptId
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Dept { get; set; }
        public int DeptId { get; set; }
    }
}
