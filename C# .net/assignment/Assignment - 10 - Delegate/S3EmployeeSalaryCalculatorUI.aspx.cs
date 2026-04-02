using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//this is  delegate
public delegate string CalculateSalary(double salary);

/// <summary>
/// this class is used to demonstrait the use of delegaate using an anonimus function 
/// </summary>
public partial class S3EmployeeSalaryCalculatorUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCalculateBonus_Click(object sender, EventArgs e)
    {
        try
        {
            //displaying the result
            lblResult.Text = calcSalary(Convert.ToDouble(txtSalary.Text));
        }catch(Exception ex) { }
    }

    //delegate has been assign a block of code directly
    CalculateSalary calcSalary = (double salary) =>
    {
        string str;
        if (salary > 5000)
        {
            str = "salary with 10% bonus : " + (salary * 1.10);
        }
        else
        {
            str = "salary with 5% bonus : " + (salary * 1.05);
        }
        return str;
    };
}