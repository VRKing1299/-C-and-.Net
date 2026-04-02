using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyTestLib;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        IClothes pl = new Polo();
        Label1.Text = pl.Color();

        IClothes Hl = new Hoodie();
        Label2.Text = Hl.Color();
    }
}