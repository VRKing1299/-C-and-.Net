using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeeManagementSystemLib;

public partial class EmployeeManagementUi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //creating an employee object to store the data
            Employee emp = new Employee();

            // passing salary and employee name and id to the set salary method
            emp.SetSalary(Convert.ToInt32(txtId.Text), txtName.Text, Convert.ToDouble(txtSalary.Text));

            //will calculate the net salary
            emp.CalculateSalary();

            //displaying employee dtails
            lblEmpId.Text = "Employee No : " + emp.EmpNo;
            lblName.Text = "Employee Name : " + emp.EmpName;
            lblGrossSal.Text = "Employee GrossSal : " + emp.GrossSalary;
            lblNetSal.Text = " Employee NetSalary : " + emp.NetSalary;
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}