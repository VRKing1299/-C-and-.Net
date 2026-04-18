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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Youtube y = new Youtube() { Yname = "VR Studeo"};
        Subscribe s1 = new Subscribe() { SName = "chalu pandey" };
        Subscribe s2 = new Subscribe() { SName = "Basundi pandey" };
        y.OnVideoUploadEvent += s1.Notification;
        y.OnVideoUploadEvent += s2.Notification;
        y.UploadVideo("c#");
    }
}