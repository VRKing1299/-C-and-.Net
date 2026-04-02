using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment12Lib;

/// <summary>
/// Code-behind class for the product sorting page.
/// Handles page events and user interactions,
/// such as find and employee with name stating with A when the button is clicked.
/// </summary>
public partial class S9Get_EmployeesWhoseNameStartswithAUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //this function finds and displays the employee whose name starts whith A
    protected void btnSearchEmpNameStartWithA_Click(object sender, EventArgs e)
    {
        try
        {
            //list with employee object 
            #region
            List<Employee> employeesList = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Amit", Salary=23423},
                new Employee { Id = 2, Name = "Neha", Salary = 60000 },
                new Employee { Id = 3, Name = "Rahul", Salary = 75000 },
                new Employee { Id = 4, Name = "Priya", Salary = 52000},
                new Employee { Id = 5, Name = "Karan", Salary = 48000d}
            };
            #endregion

            //finding employee with name stating with A
            var employee = employeesList.Where(emp => emp.Name.StartsWith("A"));

            //displaying employee name
            if (employee == null)
            {
                Response.Write("connot find employee ");
            }
            else
            {
                foreach (Employee em in employee)
                {
                    Response.Write("Name : " + em.Name + "<br>");
                }
            }
        }
        catch (Exception ex) { }
    }
}