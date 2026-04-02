using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dictionaryUi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Dictionary<int, string> student = new Dictionary<int, string>()
        {
            {1,"ab" },
            {2,"bc" },
            {3,"cd" },
            {4,"ef" },
            {5,"fj" }
        };


    }
}
