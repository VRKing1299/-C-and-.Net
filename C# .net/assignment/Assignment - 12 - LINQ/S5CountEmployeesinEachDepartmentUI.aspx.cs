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
/// such as grouping employee by deparment and showing how employee count in each department when the button is clicked.
/// </summary>
public partial class S5CountEmployeesinEachDepartmentUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    //grouping employee by deparment and showing how employee count in each department when the button is clicked.
    protected void btnEmployeeInEachDepartment_Click(object sender, EventArgs e)
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

            //sorting it from group by
            var deptEmplist = employees.GroupBy(emp => emp.Dept);
            //var deptList = from emp in employees
            //               group emp by emp.Dept
            //               select emp.count();

            //printing the employee
            foreach (var empDept in deptEmplist)
            {
                Response.Write("Deparment name : " + empDept.Key + ", Count : " + empDept.Count() + "<br>");
            }
        }
        catch (Exception ex) { }
    }
}