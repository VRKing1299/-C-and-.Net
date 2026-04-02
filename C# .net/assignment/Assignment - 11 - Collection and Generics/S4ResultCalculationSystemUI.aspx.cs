using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// this class has btnCompareMarks_Click which activaties on the user input i.e button click
/// </summary>
public partial class S4ResultCalculationSystemUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //this method demonstraits the use of generic method
    protected void btnCompareMarks_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Write("marks 40,50 : greater : " + CompareMarks(40, 50) + "<br>");
            Response.Write("marks 40.5,50.5 : greater : " + CompareMarks(40.5, 50.5) + "<br>");
            Response.Write("marks 45.5,55.5 : greater : " + CompareMarks(45.5f, 55.5f) + "<br>");
        } catch(Exception ex) { }
    }

    //this is generic method returns the value of the greater type
    public T CompareMarks<T>(T a, T b) where T : IComparable
    {
        return a.CompareTo(b) >= 0 ? a : b;
    }
}