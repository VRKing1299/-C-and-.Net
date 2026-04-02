using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserLib;

public partial class UserCreateAccountUi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCreateAccount_Click(object sender, EventArgs e)
    {
        string name = txtUserName.Text;
        string pwd = txtPassword.Text;
        string phno = txtPhno.Text;

        string msg = "";

        if (phno == "")
        {
            User us = new User(name, pwd);
            msg = "user created using name and password";
        }else if (name == "")
        {
            double phone = Convert.ToDouble(phno);
            User us = new User(phone,pwd);
            msg = "user created using phone and password";
        }else if (phno != "" && name != "" && pwd != "")
        {
            double phone = Convert.ToDouble(phno);
            User us = new User(name, phone, pwd);
            msg = "user created using name , phone and password";
        }

        lblMsg.Text = msg;
    }
}