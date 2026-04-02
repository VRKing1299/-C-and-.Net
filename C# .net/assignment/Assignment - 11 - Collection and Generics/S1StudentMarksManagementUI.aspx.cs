using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using S1StudentMarksManagementLib;


/// <summary>
/// this class had btnAddStudentDisplayResult_Click method with is activated on user input i.e button click
/// </summary>
public partial class S1StudentMarksManagementUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //method that creates student object and add it to the student list
    protected void btnAddStudentDisplayResult_Click(object sender, EventArgs e)
    {
        try
        {
            //creating student object
            Student s1 = new Student("baghira", 44);
            Student s2 = new Student("popeye", 64);
            Student s3 = new Student("jjk", 96);
            Student s4 = new Student("sasuke", 57);
            Student s5 = new Student("itach", 78);

            //adding student objcets to list using object initializer
            List<Student> studentList = new List<Student>()
            {
                s1,s2,s3,s4,s5
            };

            int highestMarks = 0;// for finding highest marks
            foreach (Student student in studentList)
            {
                #region
                Response.Write(" Name : " + student.Name + ", Marks : " + student.Marks + "<br>");

                //finding the highest marks
                if (highestMarks < student.Marks)
                {
                    highestMarks = student.Marks;
                }
                #endregion
            }

            //printing the highest marks
            Response.Write("highest marks : " + highestMarks);
        }catch(Exception ex) { }
    }
}