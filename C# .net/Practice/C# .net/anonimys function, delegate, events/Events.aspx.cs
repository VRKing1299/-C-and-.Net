using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Events : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Publisher p = new Publisher();
        p.ProcessComplete += new Publisher.Notify(new Subscriber().Send);
        p.onNotify(6);
    }
}

public class Subscriber
{
    public void Send()
    {
        HttpContext.Current.Response.Write("this is the notification");
    }
}

public class Publisher
{
    public delegate void Notify();
    public event Notify ProcessComplete;

    public void onNotify(int time)
    {
        if(ProcessComplete != null)
        {
            if (time == 6)
            {
                ProcessComplete();
            }
            else
            {
                HttpContext.Current.Response.Write("This is not right time to notify");
            }
        }
        else
        {
            HttpContext.Current.Response.Write("handler not attached to event ");
        }
    }
}