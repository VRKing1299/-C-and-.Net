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
/// such as displaying unique department name when the button is clicked.
/// </summary>
public partial class S7GetUniqueDepartmentNamesUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //this function is used to displaying unique department name when the button is clicked.
    protected void btnGetUniqueDeptNames_Click(object sender, EventArgs e)
    {
        //list with employee object 
        #region
        List<Employee> employeesList = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Amit", Dept = "IT" },
                new Employee { Id = 2, Name = "Neha", Dept = "Finance" },
                new Employee { Id = 3, Name = "Rahul", Dept = "IT" },
                new Employee { Id = 4, Name = "Priya", Dept = "mkt" },
                new Employee { Id = 5, Name = "Karan", Dept = "IT" }
            };
        #endregion

        //groups employee by the department name and selects department name and display it
        var uniqueDept = employeesList.GroupBy(emp => emp.Dept).Select(group => group.Key);

        //displaying the unique department names
        if(uniqueDept != null)
        {
            Response.Write("following are unique department names");
            foreach (var item in uniqueDept)
            {
                Response.Write(item + "<br>");
            }
        }

    }
}