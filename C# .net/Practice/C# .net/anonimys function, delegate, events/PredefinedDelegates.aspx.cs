using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Action<string> print = (str) =>
    {
        HttpContext.Current.Response.Write(str);
    };

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Func<int, int, int> add = (a, b) => a + b;
        Func<int, int, int> multiply = (a, b) => a * b;
        Func<int, int, int> sub = new Func<int, int, int>(new Calculations().subtract);
        Predicate<int> isEven = (a) => a % 2 == 0;

        print(""+add(1, 2)+"<br>");
        Response.Write(multiply(1, 2)+"<br>");
        Response.Write(sub(2, 1)+"<br>");

        print("======================================<br>");

        

        print("Action print <br>");
    }
}

public class Calculations
{
    public int subtract(int a , int b)
    {
        return a - b;
    }
}