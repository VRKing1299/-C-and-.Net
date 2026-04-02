using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLib;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string s = "hellow this is my function";
        s.WebPrint();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Student s = new Student(1, "gg");
        //Student s2 = new Student(2, "hh");

        s.Display();
        //s2.Display();
        Response.Write(s.Add(1, 2));
    }
}

public static class MyExtensionFunc
{
    public static void WebPrint(this string str)
    {
        HttpContext.Current.Response.Write(str);
    }

    public static void Display(this Student s)
    {
        HttpContext.Current.Response.Write("name : "+s.name);
        HttpContext.Current.Response.Write("id : " + s.id);
    }

    public static int Add(this Student s,int a, int b)
    {
        return a + b;
    }

}