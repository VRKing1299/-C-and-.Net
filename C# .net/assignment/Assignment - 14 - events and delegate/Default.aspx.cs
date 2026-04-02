using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Student s1 = new Student(1, "ZoroJiro");
        Student s2 = new Student(2, "Tanjiro");
        DiscountService ds = new DiscountService();
        s1.OnFeePaymentEvent+= ds.Pay;
        s2.OnFeePaymentEvent += ds.Pay;

        s1.Pay(50000);
        Response.Write("<br>");

        s2.Pay(30000);

    }
}