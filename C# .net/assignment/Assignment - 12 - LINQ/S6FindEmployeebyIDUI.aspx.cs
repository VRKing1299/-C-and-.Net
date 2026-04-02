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
/// such as finding employee based on id when the button is clicked.
/// </summary>
public partial class S6FindEmployeebyIDUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //this function finding employee based on id and displays it when the button is clicked.
    protected void btnFindEmplyeeById_Click(object sender, EventArgs e)
    {
        try
        {
            //list with employee object
            #region
            List<Employee> employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Amit", Salary=23423},
                new Employee { Id = 2, Name = "Neha", Salary = 60000 },
                new Employee { Id = 3, Name = "Rahul", Salary = 75000 },
                new Employee { Id = 4, Name = "Priya", Salary = 52000},
                new Employee { Id = 5, Name = "Karan", Salary = 48000d}
            };
            #endregion
            //getting an employee with id 3
            int id = 3;
            Employee employee = employees.SingleOrDefault(emp => emp.Id == id);

            //displays messsage based on employee found or not
            if (employee == null)
            {
                Response.Write("cannot find the employee");
            }
            else
            {
                Response.Write("ID :" + employee.Id + ", Name : " + employee.Name + ", Salary : " + employee.Salary + "<br>");
            }
        }catch(Exception ex) { }
    }
}