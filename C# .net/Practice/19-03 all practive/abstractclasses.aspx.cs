using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

public partial class abstractclasses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        PermentantEmp pe = new PermentantEmp(1, "JJ", 30000);
        TempEmp te = new TempEmp(2, "bb",45000);

        Response.Write(pe.CalcSal()+"<br>");

        Response.Write(te.CalcSal() + "<br>");

    }
}

