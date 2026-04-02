using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnDI_Click(object sender, EventArgs e)
    {
        User u1 = new User(1, "aa");
        User u2 = new User(2, "bb");

        Admin a = new Admin(u1);
        a.searchUser(u2);

        lblDi.Text = "Admin Name : " + a.name + "<br> User Searched Name" + a.user.name + " and Id : " + a.user.id;  
    }

    protected void btnInterfaceTest_Click(object sender, EventArgs e)
    {
        V12 eng = new V12();

        lblIt.Text="CC : " + eng.CC +" | " + eng.Start();
    }
}