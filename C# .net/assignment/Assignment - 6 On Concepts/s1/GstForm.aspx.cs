using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GSTCalcLib;


/// <summary>
/// this class is used to perform gst calculation on the user input data on button click
/// </summary>
public partial class GstForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //button to calculate the gst
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //calculate the gst and display the result using static method
            lblGst.Text = "" + Gst.CalcGst(Convert.ToInt16(txtValue.Text));
        }catch(Exception ex)
        {

        }
    }
}