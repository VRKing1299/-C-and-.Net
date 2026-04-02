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

    protected void BtnFindGT_Click(object sender, EventArgs e)
    {
        try
        {
            int[] bins = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            foreach (int n in bins)
            {
                if (n == 3)
                {
                    Response.Write("Under Maintenance  <br>");
                    continue;
                }
                else if (n == 7)
                {
                    Response.Write("Golden Ticket");
                    break;
                }
                else
                {
                    Response.Write("seraching bean1 " + n + "<br>");
                }
            }
        }catch(Exception ex)
        {

        }
    }

    protected void BtnAddMArray_Click(object sender, EventArgs e)
    {
        int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 } };
        int total = 0;

        foreach(int i in arr)
        {
            total += i;
        }

        Response.Write(total);
    }

    protected void BtnJackedArray_Click(object sender, EventArgs e)
    {
        int[][] jj = new int[3][];
        jj[0] = new int[] { 1, 2, 3 };
        jj[1] = new int[] { 4, 5, 6 };
        jj[2] = new int[] { 7, 8, 9 };

        for(int i= 0;i<jj.Length;i++)
        {
            for(int j=0; j < jj[i].Length; j++)
            {
                Response.Write(jj[i][j]);
            }
        }
    }
}