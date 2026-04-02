using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inheritace_and_abstract_class_in_csharp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //UpiPayment upi = new UpiPayment(123, 20);
        //CreditCard card = new CreditCard(111, 45);

        //upi.Vaidating();
        //upi.Processing();
        //upi.Pay();
        //Response.Write("<br>" + "<br>");

        //card.Vaidating();
        //card.Processing();
        //card.Pay();


        IPayment p = new Credit();
        p.Pay();
        Response.Write("<br><br>");

        ICard c = new Credit() { amount = 10};
        c.card();
        c.Pay();
        //Response.Write()

        Response.Write("<br><br>");
        CardType ca = new Debit();
        ca.card();
        ca.Pay();
    }
}

public interface IPayment
{
    void Pay();
}
public interface ICard : IPayment
{

    void card();
}

public abstract class CardType : ICard
{
    public void card()
    {
        HttpContext.Current.Response.Write(" Card Payment <br>");
    }

    public abstract void Pay();
}
public class Debit : CardType
{
    public override void Pay()
    {
        HttpContext.Current.Response.Write("Debit card payment<br>");
    }
}
public class Credit : CardType
{
    public double amount;
    public override void Pay()
    {
        HttpContext.Current.Response.Write("Credit card payment");
    }
}
//public abstract  class PaymentType 
//{
//    public double Amount { get; }

//    public PaymentType(double amount)
//    {
//        this.Amount = amount;
//    }
//    public void Pay()
//    {
//        HttpContext.Current.Response.Write("payment done  of rs : " + Amount+"<br>");
//    }

//    public virtual void Vaidating() { }
//    public virtual void Processing() { }
//}

//public class UpiPayment : PaymentType
//{
//    public int Id{get;}
//    public UpiPayment(double amount,int id) : base(amount)
//    {
//        this.Id = id;
//    }
//    public override void Processing()
//    {
//        HttpContext.Current.Response.Write("processing upi payment for id :"+ Id+" of rs "+Amount+ "<br>");
//    }

//    public override void Vaidating()
//    {
//        HttpContext.Current.Response.Write("validating upi payment for id :" + Id + " of rs " + Amount+ "<br>");
//    }
//}

//public class CreditCard : PaymentType
//{
//    public int Id { get; }

//    public CreditCard(double amount, int id) : base(amount)
//    {
//        this.Id = id;
//    }
//    public override void Processing()
//    {
//        HttpContext.Current.Response.Write("processing Credit card payment for id :" + Id + " of rs " + Amount+ "<br>");
//    }

//    public override void Vaidating()
//    {
//        HttpContext.Current.Response.Write("validating credit card payment for id :" + Id + " of rs " + Amount+ "<br>");
//    }
//}

