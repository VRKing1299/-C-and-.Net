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
/// such as displaying salary of employees when the button is clicked.
/// </summary>
public partial class S8CalculateAverageSalaryUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //this function is used to displaying salary of employees when the button is clicked.
    protected void btnCalcAvgSalary_Click(object sender, EventArgs e)
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

            //calculating average salary and displaying it
            double avg = employeesList.Average(emp => emp.Salary);
            Response.Write("Average salary of all employyee is : "+avg);
        }
        catch (Exception ex) { }
    }
}