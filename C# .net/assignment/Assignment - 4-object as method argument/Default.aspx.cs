using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeLib;


/// <summary>
/// this class is used to promote the employee with salary hike 
/// the operation is performed on the button click with the help of employee class and also compares the before and after salary
/// </summary>
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //code to promote the employee object
    protected void btnPromote_Click(object sender, EventArgs e)
    {
        try
        {
            //taking user input
            string name = txtName.Text;
            string pos = txtPosition.Text;
            int sal = Convert.ToInt16(txtSalary.Text);

            Employee emp = new Employee(name, pos, sal);// creating an employee obj

            int beforeSal;//variable to store before salary
            int afterSal;//variable to store after salary

            // method takes and employee object updates the salary and returns before and after salary
            Employee.PromoteEmployee(emp, out beforeSal, out afterSal);

            //displays the result
            lblEmpName.Text = "Name : " + emp.Name;
            lblEmpBeforeSal.Text = "Before Promotion $ " + beforeSal;
            lblAfterSalary.Text = "After Promotion $ " + afterSal;

        }
        catch (Exception ex)
        {
            
        }

    }
}