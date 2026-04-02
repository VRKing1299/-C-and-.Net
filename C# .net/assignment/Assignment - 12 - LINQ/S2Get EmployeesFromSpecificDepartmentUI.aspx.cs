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
/// such as finding employees who work in IT department when the button is clicked.
/// </summary>
public partial class S2Get_EmployeesFromSpecificDepartmentUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //finding employees who work in IT department when the button is clicked.s
    protected void btnEmpFromDeptIT_Click(object sender, EventArgs e)
    {
        try
        {
            //list with employee object 
            #region
            List<Employee> employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Amit", Dept = "IT" },
                new Employee { Id = 2, Name = "Neha", Dept = "Finance" },
                new Employee { Id = 3, Name = "Rahul", Dept = "IT" },
                new Employee { Id = 4, Name = "Priya", Dept = "mkt" },
                new Employee { Id = 5, Name = "Karan", Dept = "IT" }
            };
            #endregion

            //finding the employee whose salary is more than 50000 wing where
            List<Employee> itDeptEmplist = employees.Where(emp => emp.Dept == "IT").ToList();

            foreach (Employee emp in itDeptEmplist)
            {
                Response.Write("ID :" + emp.Id + ", Name : " + emp.Name + ", Department : " + emp.Dept + "<br>");
            }
        }
        catch (Exception ex) { }
    }
}

