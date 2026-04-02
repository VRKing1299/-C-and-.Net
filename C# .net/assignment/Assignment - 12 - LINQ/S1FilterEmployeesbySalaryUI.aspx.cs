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
/// such as getting the list of employees whose salary is more than 50k
/// </summary>
public partial class S1FilterEmployeesbySalaryUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //button that finds the employee whose salary is more than 50000 on user click
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //Employee emp = new Employee(12);
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

            //finding the employee whose salary is more than 50000 wing where
            List<Employee> salEmployee = employees.Where(emp => emp.Salary > 50000).ToList();

            //print ing the employee whose salary is more than 50000
            foreach (Employee emp in salEmployee)
            {
                Response.Write("ID :" + emp.Id + ", Name : " + emp.Name + ", Salary : " + emp.Salary + "<br>");
            }
        }catch(Exception ex) { }
    }
}

