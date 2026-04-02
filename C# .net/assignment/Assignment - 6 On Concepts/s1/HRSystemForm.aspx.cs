using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HRSystemLib;

/// <summary>
/// this class is used to create and employee object and display the total number of employee object created 
/// </summary>
public partial class HRSystemForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //button to create employee
    protected void btnCreateEmp_Click(object sender, EventArgs e)
    {
        try
        {
            //creates an employee object 
            Employee emp = new Employee(Convert.ToInt16(txtEmpId.Text), txtEmpName.Text);
            lblEmpCount.Text = "" + Employee.empCount;//displays the employee count
        }catch(Exception ex)
        {

        }
    }
}