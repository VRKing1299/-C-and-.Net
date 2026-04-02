using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MydelegatePract;

public partial class delegatesUse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSingleCastDelegate_Click(object sender, EventArgs e)
    {
        Maths mt = new Maths();// create an object of class whose method we want to pass in delegate
        DeleTest dt = new DeleTest();

        MyDelegate m = new MyDelegate(mt.Add);// pass that method inside that delegate
        Response.Write(dt.MyMethod(10, 20, m));

        m += new MyDelegate(mt.sub);

        
        Response.Write(dt.MyMethod(10, 20, m));

    }
}

public class Maths
{
    public int Add(int a , int b)
    {
        return a + b;
    }
    public int sub(int a, int b)
    {
        return a - b;
    }
}