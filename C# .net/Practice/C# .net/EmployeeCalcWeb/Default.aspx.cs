using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmpLib;

public partial class _Default : System.Web.UI.Page
{///<summary>
        ///this is form wich is used to calculate the net salary of an employee
 ///</summary>
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //button so calculate the net salary
    protected void button_Click(object sender, EventArgs e)
    {
        //int basic, da, pf, hra;
        try
        {
            //makes labels visible
            empId.Visible = true;
            empName.Visible = true;
            empSal.Visible = true;

            //basic = Convert.ToInt16(tbBsal.Text);
            //da = Convert.ToInt16(tbDF.Text);
            //pf = Convert.ToInt16(tbPf.Text);
            //hra = Convert.ToInt16(tbHra.Text);

            empId.Text = txtId.Text;
            empName.Text = txtEname.Text;

            //calling the employee object
            Employee em = new Employee(txtEname.Text, txtId.Text, Convert.ToInt16(txtBsal.Text), Convert.ToInt16(txtHra.Text), Convert.ToInt16(txtDF.Text), Convert.ToInt16(txtPf.Text));

            //displays the net salary
            empSal.Text = Convert.ToString(em.CalcNetSalary());


        }
        //catches the exception
        catch (Exception ex)
        {
            Response.Write("error");

        }
    }
}