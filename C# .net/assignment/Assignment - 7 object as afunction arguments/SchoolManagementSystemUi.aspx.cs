using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem;


/// <summary>
/// this class is used to perform the operation on student object to assign grade and display it 
/// all operations are performed on button click
/// </summary>
public partial class SchoolManagementSystemUi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCalcGrade_Click(object sender, EventArgs e)
    {
        Student std = new Student(Convert.ToInt32(txtStudRollNo.Text), txtStudName.Text, Convert.ToDouble(txtStudMarks.Text));
        ResultProcessing.AssignGrade(std);
        lblGrade.Text = "Grade : " + std.Grade;
    }
}