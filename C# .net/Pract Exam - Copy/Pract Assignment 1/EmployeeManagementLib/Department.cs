using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementLib
{
    //delegate with employee object
    public delegate void ProcessDelegate(Employee emp);

    /// <summary>
    /// this class is used to represent department
    /// has a constructor with name parameter and
    /// has a method that takes employee object, delegar to processes employee
    /// </summary>
    public class Department
    {
        private string _name;
        public string Name
        {
            get { return _name; }
        }
        //constuctor with string parameter
        public Department(string name)
        {
            this._name = name;
        }

        //method to process the employees 
        public void ProcessEmployees(ProcessDelegate processDelegate, Employee emp)
        {
            processDelegate(emp);
        }
    }
}
