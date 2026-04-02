using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(txtPassword.Text == "admin@1234" && txtUserName.Text== "admin")
        {
            Response.Redirect("http://localhost:60771/Home.aspx");
        }
        else
        {
            Response.Write("Password or id is incorrect ");
        }
    }
}