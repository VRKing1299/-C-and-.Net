using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCalc_Click(object sender, EventArgs e)
    {
        double[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        lblAvg.Text=""+ Calculations.Average(arr);
    }

    internal class Calculations
    {
        public static double AddAll(double[] arr)
        {
            double total = 0;
            foreach (double i in arr)
            {
                total += i;
            }
            return total;
        }

        public static double Average(double[] arr)
        {
            return (AddAll(arr) / arr.Length);
        }

        public static void AddOne(ref int a)
        {
            a++;
        }
    }

    protected void btnAddOne_Click(object sender, EventArgs e)
    {
        int a = 0;
        Calculations.AddOne(ref a);
        lblAddOne.Text ="" +a;
    }
}