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

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if(txtUserName.Text== "admin" && txtPassword.Text== "admin1234!")
            {
                Response.Redirect("http://localhost:58041/Home.aspx");
            }
            else
            {
                Response.Write("Please enter correct password and username");
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}