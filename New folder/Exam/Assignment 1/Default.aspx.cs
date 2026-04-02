using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementLib;
/// <summary>
/// this class has methods that operate based on user iput and page load
/// </summary>
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnUpdateEmpSal_Click(object sender, EventArgs e)
    {
        try
        {
            //creating employee object
            #region
            Employee emp1 = new Employee("Ancy", "Martin", 7000);
            Employee emp2 = new Employee("Jessy", "Paniker", 7000);
            Employee emp3 = new Employee("Jijo", "Vargise", 9000);
            #endregion

            //entering employees into employee list
            List<Employee> empList = new List<Employee>() { emp1, emp2, emp3 };

            //creating department object
            Department dept = new Department("HR");

            //assigning fuction reference to the delegaete
            ProcessDelegate pd = new ProcessDelegate(new DelegateUsingCallbackMethod().UpdatePayroll);

            //loping over the list to process employees
            foreach (Employee emp in empList)
            { 
                dept.ProcessEmployees(pd, emp);
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}
