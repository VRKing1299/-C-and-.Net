using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IcompareVSicomparer;

public partial class comparableANDcomparer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnStudentSort_Click(object sender, EventArgs e)
    {
        Student s1 = new Student(50);
        Student s2 = new Student(55);
        Student s3 = new Student(45);
        Student s4 = new Student(99);
        Student s5 = new Student(43);

        List<Student> ls = new List<Student>() { s1, s2, s3, s4, s5 };
        Response.Write("before sorting : ");
        PrintStudent(ls);

        ls.Sort();
        Response.Write("<br> <br> after Sorting : ");
        PrintStudent(ls);

    }

    //code to print the list of student
    public void PrintStudent(List<Student> ls)
    {
        foreach (Student item in ls)
        {
            Response.Write("" + item.marks + ", ");
        }
    }

    protected void btnSortEmployee_Click(object sender, EventArgs e)
    {
        Employee e1 = new Employee(1, 2000, "abc");
        Employee e2 = new Employee(2, 45000, "jjk");
        Employee e3 = new Employee(3, 2500, "naruto");
        Employee e4 = new Employee(4, 6000, "zebra");
        Employee e5 = new Employee(5, 3400, "truck");

        List<Employee> els = new List<Employee>() { e1, e3, e5, e4, e2 };
        Response.Write("before sorting : <br>");
        PrintEmployee(els);

        els.Sort(new EmployeeIdComparer());
        Response.Write("<br><br>After sorting with id : <br>");
        PrintEmployee(els);

        els.Sort(new EmployeeNameComparer());
        Response.Write("<br><br>After sorting with Name : <br>");
        PrintEmployee(els);

        els.Sort(new EmployeeSalaryCompare());
        Response.Write("<br><br>After sorting with Salary : <br>");
        PrintEmployee(els);

    }

    //code to print the employee
    public void PrintEmployee(List<Employee> ls)
    {
        foreach (Employee item in ls)
        {
            Response.Write("Name : " + item.name + ", ID : "+item.id+", Salary :"+item.salary+"<br>");
        }
    }
}