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
/// such as displays employee name with department name when the button is clicked.
/// </summary>
public partial class S10JoinTwoCollectionsUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //this function shows employee name with department name on button click
    protected void btnEmpNameAndDeptName_Click(object sender, EventArgs e)
    {
        try
        {
            //list with employee object 
            #region
            List<Employee> employeesList = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Amit", DeptId=101},
                new Employee { Id = 2, Name = "Neha", DeptId = 102 },
                new Employee { Id = 3, Name = "Rahul", DeptId = 102 },
                new Employee { Id = 4, Name = "Priya", DeptId = 101},
                new Employee { Id = 5, Name = "Karan", DeptId = 103}
            };
            #endregion

            //list with employee object 
            #region
            List<Department> departmentList = new List<Department>()
            {
                new Department { DeptId=101,DeptName="IT"},
                new Department { DeptId=102,DeptName="Finance" },
                new Department { DeptId=103,DeptName="MKT" },
            };
            #endregion
            // joints two list using deptId in employee object and deptId in department Object and returns the Employee name and
            // department name
            var ls = employeesList.Join(departmentList,//second list
                                        emp => emp.DeptId, // id from emp
                                        dpt => dpt.DeptId, // id from dpt
                                        (emp, dpt) => new {EmpName = emp.Name, DeptName = dpt.DeptName }//how result should be stored
                                        );

            //displaying the employee name along with their department name
            foreach (var empDpt in ls)
            {
                Response.Write("Employee name : " + empDpt.EmpName + " | Department Name : " + empDpt.DeptName+"<br>");
            }
        }
        catch (Exception ex) { }
    }
}