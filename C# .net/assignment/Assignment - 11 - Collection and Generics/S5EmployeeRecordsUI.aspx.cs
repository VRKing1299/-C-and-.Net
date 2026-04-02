using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using S5EmployeeRecordsLib;

public partial class S5EmployeeRecordsUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //this class is activated on button click which adds employee to the list and displayes them along with
    //highest salary earning employee
    protected void BtnHighestSalaryEmployee_Click(object sender, EventArgs e)
    {
        try
        {
            #region//creating employee object
            Employee e1 = new Employee(1, "itachi", 2000);
            Employee e2 = new Employee(2, "bluestar", 40000);
            Employee e3 = new Employee(3, "mitsubushi", 3000);
            Employee e4 = new Employee(4, "light", 3500);
            Employee e5 = new Employee(5, "dark", 5000);
            #endregion

            //adding employee to the list
            List<Employee> employeeList = new List<Employee>()
            {
                e1,e2,e3,e4,e5
            };

            //creating variable to store highest salary and employee with highest salary
            double highestSal = 0;
            Employee emp = employeeList[0];

            foreach (Employee em in employeeList)
            {
                #region//printing the employee details
                Response.Write("Id : " + em.EmpId + ", Name : " + em.Name + ", Salary : " + em.Salary + "<br>");
                if (highestSal < em.Salary)//chekcing for salary
                {
                    highestSal = em.Salary;
                    emp = em;
                }
                #endregion
            }

            Response.Write("<br><br>Employee with Highest salary : " + "Id : " + emp.EmpId + ", Name : " + emp.Name + ", Salary : " + emp.Salary + "<br>");
        }catch(Exception ex) { }
    }
}