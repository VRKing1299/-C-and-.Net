using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DelegateAndEventLib;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Publisher p = new Publisher();
        Subscriber s1 = new Subscriber() { Name = "shivam" };
        Subscriber s2 = new Subscriber() { Name = "raj" };

        p.OnVideoUploadEvent += s1.UploadNotification;
        p.OnVideoUploadEvent += s2.UploadNotification;

        p.OnVideoUpload("C# vid");
    }
}