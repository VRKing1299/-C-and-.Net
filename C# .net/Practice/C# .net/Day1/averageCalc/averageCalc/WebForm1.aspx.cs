using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AvgDll;

namespace averageCalc
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int a, b, c, d;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt16(TextBox1.Text);
                b = Convert.ToInt16(TextBox2.Text);
                c = Convert.ToInt16(TextBox3.Text);

                Class1 z = new Class1();

                d = z.calc(a, b, c);

                Label1.Text = Convert.ToString(d);
            }
            catch(Exception Ex)
            {

            }

        }
    }
}