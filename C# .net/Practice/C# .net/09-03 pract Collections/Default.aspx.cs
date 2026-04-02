using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Func<int, int, int> add = (int a, int b) =>
          {
              return a + b;
          };

        Func<int, int, int> sub = (int a, int b) => a - b;

        Action<string> print = (string str) => Response.Write(str);

        Predicate<int> isPass = (int m) => m > 30;

    }
}