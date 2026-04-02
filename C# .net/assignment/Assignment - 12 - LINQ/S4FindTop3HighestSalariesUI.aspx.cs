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
/// such as displaying top 3 highest paid employee when the button is clicked.
/// </summary>
public partial class S4FindTop3HighestSalariesUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //displaying top 3 highest paid employee when the button is clicked.
    protected void btnTop3HighestPaidEmp_Click(object sender, EventArgs e)
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
            //finding top 3 employees based on salary
            List<Employee> top3 = employees.OrderByDescending(emp => emp.Salary).Take(3).ToList();

            //print ing the employee whose salary is more than 50000
            foreach (Employee emp in top3)
            {
                Response.Write("ID :" + emp.Id + ", Name : " + emp.Name + ", Salary : " + emp.Salary + "<br>");
            }
        }catch(Exception ex) { }
    }
}