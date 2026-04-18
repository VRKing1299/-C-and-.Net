using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Delegatae : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //this is single cast delegate
        PaymentType pt = new PaymentType();
        Mydele dele = new Mydele(pt.Upi);
        PaymentSystem ps = new PaymentSystem();

        ps.Display(dele, 100);

        Mydele dele2 = new Mydele(pt.Card);
        ps.Display(dele2, 230);

        Mydele dele3 = new Mydele(pt.NetBanking);
        ps.Display(dele3, 340);

        Response.Write("<br><br>======================== multicast delegate ==========================<br>");

        Mydele d = pt.Card;
        d += pt.Upi;
        d += pt.NetBanking;
        d(20);


        Response.Write("<br><br>======================== delegate anonymus and expression  ==========================<br>");
        //anonymus function delegate
        MyDel1 sub = delegate (int a, int b) {
            Response.Write("sub : "+(a-b)+"<br>");
        };
        sub(20 ,10);
        //lambda expression delegate
        MyDel1 add = (int a, int b) =>
        {
            Response.Write("add : "+(a + b));
        };
        add(10, 20);
    }
}

public delegate void Mydele(double amout);
public delegate void MyDel1(int x, int y);

public class PaymentSystem
{
    public void Display(Mydele d , double amount)
    {
        d(amount);
    }
}

public class PaymentType
{
    public void Upi(double amount)
    {
        HttpContext.Current.Response.Write("This is upi payment " + amount + "<br>");
    }
    public void Card(double amount)
    {
        HttpContext.Current.Response.Write("This is card payment " + amount + "<br>");
    }
    public void NetBanking(double amount)
    {
        HttpContext.Current.Response.Write("This is Net Banking payment " + amount + "<br>");
    }
}