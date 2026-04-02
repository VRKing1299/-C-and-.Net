using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public delegate int Mydelegate(int a, int b);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Func<int, int, int> Add = (int a, int b) => a + b;
        Response.Write(Add(1, 2));

        Func<int, int, int> Sub = (int a, int b) =>
        {
            return a - b;
        };

        Response.Write(Sub(2, 1));

        Mydelegate d = (int a, int b) => a + b;
        Response.Write(d(2, 1));
    }
}