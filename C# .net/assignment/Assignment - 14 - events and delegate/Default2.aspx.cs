using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary2;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Employee e1 = new Employee(1, "JoJo", 1000);
        Employee e2 = new Employee(2, "Po", 12000);
        Notifications notify = new Notifications();

        e1.onSalaryIncrement += notify.SendEmail;
        e1.onSalaryIncrement += notify.UpdatePayRoll;
        e1.onSalaryIncrement += notify.GenerateNotificatin;

        e2.onSalaryIncrement += notify.SendEmail;
        e2.onSalaryIncrement += notify.UpdatePayRoll;
        e2.onSalaryIncrement += notify.GenerateNotificatin;

        e1.SalaryIncrement(1000);
        Response.Write("<br>==================================================<br><br>");
        e2.SalaryIncrement(20000);

    }
}