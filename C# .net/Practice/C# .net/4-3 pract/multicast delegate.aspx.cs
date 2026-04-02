using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public delegate void CustomDelegate(int a, int b);
public partial class multicast_delegate : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MyMaths mt = new MyMaths();
        CustomDelegate m = new CustomDelegate(mt.Add);
        m += new CustomDelegate(mt.sub);
        m(20, 10);
    }
}

public class MyMaths
{
    public void Add(int a, int b)
    {
        HttpContext.Current.Response.Write(a + b);
    }
    public void sub(int a, int b)
    {
        HttpContext.Current.Response.Write(a - b);
    }
}