using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementLib;

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

            //entering employees into employee array
            Employee[] employeeArray = { emp1, emp2, emp3 };

            //creating department object
            Department departmentHR = new Department("HR");

            //assigning fuction reference to the delegaete
            ProcessDelegate processDelegate = new ProcessDelegate(new DelegateUsingCallbackMethod().UpdatePayroll);

            //loping over the array to process employees
            foreach (Employee employee in employeeArray)
            {
                departmentHR.ProcessEmployees(processDelegate, employee);
                Response.Write("<br>");
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}
