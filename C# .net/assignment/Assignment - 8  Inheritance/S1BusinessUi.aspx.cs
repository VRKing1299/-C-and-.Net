using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmployeePayRollLib;

/// <summary>
/// the class S1BusinessUi is used to calculate the salary of an permenant employee and of a temperarry employee based on user input parameter
/// the operations are performed on the buton click
/// </summary>
public partial class S1BusinessUi : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //btn to calculate the salary of the permanant employee
    protected void btnCalcPsal_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt16(txtPid.Text);
            string name = txtPname.Text;
            double sal = Convert.ToDouble(txtPsal.Text);

            //creating an object
            PermanentEmployee pe = new PermanentEmployee(id, name, sal);

            // Display calculated result
            lblPFinalSal.Text = "Final Salary : " + pe.CalculateSalary();
            #endregion
        }
        catch (Exception ex) { }
    }

    //btn to calculate the salary of contract base employee
    protected void btnCalcCsal_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt16(txtCid.Text);
            string name = txtCname.Text;
            double sal = Convert.ToDouble(txtCsal.Text);

            //creating an object
            ContractEmployee ce = new ContractEmployee(id, name, sal);

            // Display calculated result
            lblCFinalsal.Text = "Final Salary : " + ce.CalculateSalary();
            #endregion
        }
        catch (Exception ex) { }
    }
}