using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public double Salary { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}