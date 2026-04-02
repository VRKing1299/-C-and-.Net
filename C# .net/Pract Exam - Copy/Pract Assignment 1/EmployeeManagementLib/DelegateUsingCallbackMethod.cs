using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeManagementLib
{
    /// <summary>
    /// this class is used to update employee salary
    /// </summary>
    public class DelegateUsingCallbackMethod
    {
        //this method is used to update/ increment the employee salary
        public void UpdatePayroll(Employee employee)
        {
            employee.Salary += 1400;
            HttpContext.Current.Response.Write("The Employee " + employee.FirstName + " " + employee.LastName +
                              "'s salary increased to " + employee.Salary);
        }
    }
}
