using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Linq_pract : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee { Id = 1, Name = "Amit", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Neha", Department = "HR", Salary = 40000 },
            new Employee { Id = 3, Name = "Raj", Department = "IT", Salary = 60000 },
            new Employee { Id = 4, Name = "Priya", Department = "Finance", Salary = 45000 },
            new Employee { Id = 5, Name = "Karan", Department = "IT", Salary = 70000 }
        };
        List<Department> departmentList = new List<Department>()
            {
                new Department { DeptId=101,DeptName="IT"},
                new Department { DeptId=102,DeptName="Finance" },
                new Department { DeptId=103,DeptName="HR" },
            };
        //employee with salary more than 50k
        #region
        Response.Write("employee with salary more than 50k<br>");
        List<Employee> salEmployee = employees.Where(emp => emp.Salary > 50000).ToList();
        foreach (Employee emp in salEmployee)
        {
            Response.Write("ID :" + emp.Id + ", Name : " + emp.Name + ", Salary : " + emp.Salary +", Department : "+ emp.Department+ "<br>");
        }
        Response.Write("<br><br>");
        #endregion

        //employe order by salary name
        #region
        Response.Write("employee sorted by salary <br>");
        List<Employee> empOrderBySal = employees.OrderBy(emp => emp.Salary).ToList();
        foreach(Employee emp in empOrderBySal)
        {
            Response.Write("ID :" + emp.Id + ", Name : " + emp.Name + ", Salary : " + emp.Salary + ", Department : " + emp.Department + "<br>");
        }
        Response.Write("<br><br>");
        #endregion

        //employe order by salary name
        #region
        Response.Write("employee sorted by salary Descending <br>");
        List<Employee> empOrderBySalDesc = employees.OrderByDescending(emp => emp.Salary).ToList();
        foreach (Employee emp in empOrderBySalDesc)
        {
            Response.Write("ID :" + emp.Id + ", Name : " + emp.Name + ", Salary : " + emp.Salary + ", Department : " + emp.Department + "<br>");
        }
        Response.Write("<br><br>");
        #endregion

        //display average of employee salary
        Response.Write("<br>================== avg sal <br> <br>");
        Response.Write(employees.Average(emp => emp.Salary));

        //grouping it by the department name
        #region
        Response.Write("<br><br>================== Group by dept name ============= <br> <br>");
        var empGroupByDept = employees.GroupBy(emp=>emp.Department);
        foreach(var dept in empGroupByDept)
        {
            Response.Write("Department Name : " + dept.Key + "  Emloyee count : " + dept.Count()+"<br>");
            foreach(Employee emp in dept)
            {
                Response.Write("&nbsp; ID :" + emp.Id + ", Name : " + emp.Name + ", Salary : " + emp.Salary + ", Department : " + emp.Department + "<br>");
            }
            Response.Write("<br>");
        }
        #endregion

        //joining two list
        var ls = employees.Join(departmentList,
            emp => emp.Department,
            dept => dept.DeptName,
            (emp, dept) => new {EmpName =emp.Name, DeptId=dept.DeptId,DeptName=dept.DeptName}
            );

        foreach(var empdpt in ls)
        {
            Response.Write(empdpt.EmpName + " | " + empdpt.DeptName + " | " + empdpt.DeptName+"<br>");
        }
    }
}
public class Department
{
    public int DeptId { get; set; }
    public string DeptName { get; set; }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}