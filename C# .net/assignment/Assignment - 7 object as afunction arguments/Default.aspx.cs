using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HrSystem;
/// <summary>
/// this class is used to process the salary of an employee using salary processer
/// all operations in this class are done on button click
/// </summary>
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //calculate the salary
    protected void btnCalcNetSal_Click(object sender, EventArgs e)
    {
        Employee emp = new Employee(Convert.ToInt16(txtId.Text), txtName.Text, Convert.ToDouble(txtBaseSalary.Text));
        lblFinalSal.Text = "" + SalaryProcessor.CalculateSalary(emp);
    }
}