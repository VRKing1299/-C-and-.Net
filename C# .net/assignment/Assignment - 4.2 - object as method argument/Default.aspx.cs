using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLib;

/// <summary>
/// this class creates the object of student using static method of student class and displays the student information
/// </summary>
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // code to create sudent object and display its details
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            //taking user input
            string name = txtName.Text;
            int rollNo = Convert.ToInt16(txtRollno.Text);
            string grade = txtGrade.Text;
            
            //creating student objet
            Student stu = Student.CreateStudent(name, rollNo, grade);

            //display the result
            lblDisplayName.Text = "Name : " + stu.Name;
            lblDisplayGrade.Text = "Grade : " + stu.Grade;
            lblDisplayRollNo.Text = "Rolllno :" + stu.RollNo;
            #endregion
        }
        catch (Exception ex)
        {

        }
    }
}