using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GenericMethodAndClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        RegistrationDetails<int> s = new RegistrationDetails<int>();
        s.RegDetails = 101234;
        s.Disp();
        RegistrationDetails<bool> s1 = new RegistrationDetails<bool>();
        s1.RegDetails = false;
        Response.Write("<br/>");
        s1.Disp();
    }
}

public class RegistrationDetails<T>
{
    T regDetails;
    public T RegDetails
    {
        get
        {
            return regDetails;
        }
        set
        {
            regDetails = value;
        }
    }

    public void Disp()
    {
        HttpContext.Current.Response.Write(RegDetails);
    }
}