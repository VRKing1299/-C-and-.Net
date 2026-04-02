using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dependency_Injection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Ipay c = new Card();
        Ipay u = new Upi();

        //constructor injection
        PaymentProcess payment = new PaymentProcess(c);
        payment.Pay(10);

        //method injection
        PaymentProcess payment2 = new PaymentProcess();
        payment2.PaymentMethod(u);
        payment2.Pay(30);
    }
}

public interface Ipay
{
    void Pay(double amount);
}

public class Card : Ipay
{

    public void Pay(double amount)
    {
        HttpContext.Current.Response.Write("Card Payment : " + amount + "<br>");
    }
}


public class Upi : Ipay
{
    public void Pay(double amount)
    {
        HttpContext.Current.Response.Write("Upi payment : " + amount + "<br>");
    }
}

public class PaymentProcess
{
    Ipay p;
    
    public PaymentProcess() { }
    public PaymentProcess(Ipay p)
    {
        this.p = p;
    }


    public void PaymentMethod(Ipay Pa)
    {
        p = Pa;
    }

    public void Pay(double amount)
    {
        p.Pay(amount);
    }
}