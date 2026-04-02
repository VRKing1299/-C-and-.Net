using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class practDelegates : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}

public delegate bool Check(Student s);
public class Student
{
    public int StudID { get; set; }
    public string StudName { get; set; }
    public int PaidFees { get; set; }
    public string RegNum { get; set; }

    public static void IsElegaible(Check elegible, List<Student> ls)
    {
        foreach(Student s in ls)
        {
            if (elegible(s))
            {
                HttpContext.Current.Response.Write("");
            }
        }
    }
}