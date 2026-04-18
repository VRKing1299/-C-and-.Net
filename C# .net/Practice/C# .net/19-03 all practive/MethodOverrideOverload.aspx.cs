using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MethodOverrideOverload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Calc(1, 2);
        Calc(5.5, 4.5);
        Calc(1.2f, 3.4f);

        Response.Write("<br><br>Method overriding");
        GrandParent gp = new GrandParent();
        gp.Display();

        GrandParent gpP = new Parent();
        gpP.Display();

        GrandParent c2 = new Child2();
        c2.Display();

    }

    public void Calc(int a, int b)
    {
        Response.Write("int : " + (a + b) + "<br>");
    }
    public void Calc(double a, double b)
    {
        Response.Write("double  : " + (a + b) + "<br>");
    }
    public void Calc(float a, float b)
    {
        Response.Write("float : " + (a + b) + "<br>");
    }
}


//override
public class GrandParent
{
    public virtual void Display()
    {
        HttpContext.Current.Response.Write("A<br>");
    }
}
public class Parent : GrandParent
{
    public sealed override void Display()
    {
        HttpContext.Current.Response.Write("override b <br>");
    }
}
public class Child1 : Parent
{
    //caannot overrid public override void Display() { }
}
public class Child2 : GrandParent
{
    public override void Display()
    {
        HttpContext.Current.Response.Write("Child2");
    }
}