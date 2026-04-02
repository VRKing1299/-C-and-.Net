using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Arrays : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //array constructor
        //int[,] array2d = new int[4, 3];

        int[,] array2d = { { 1, 2, 3 }, { 4, 5, 6 }, {7,8,9 }, {10,11 ,12 } };

        foreach (int arr in array2d)
        {
            Response.Write(arr + "<br>");
        }
        Response.Write("<br><br>==================================");

        for (int i=0; i < array2d.GetLength(0); i++)
        {
            for(int j = 0; j < array2d.GetLength(1); j++)
            {
                Response.Write(array2d[i, j] + "&nbsp;");
            }
            Response.Write("<br>");
        }

        Response.Write("<br><br>==================================");
        //=============================================================================================
        //jacked array created using constructor
        //int[][] arr = new int[][]
        //{
        //    new int[] {1, 2},
        //    new int[] {3, 4, 5},
        //    new int[] {6}
        //};

        int[][] jackedArray = new int[3][];
        jackedArray[0] = new int[] { 1, 2, 3, 4 };
        jackedArray[1] = new int[3];
        jackedArray[2] = new int[4] { 8, 9, 10, 11 };

        for(int i = 0; i < jackedArray.Length; i++)
        {
            for (int j = 0; j < jackedArray[i].Length; j++)
            {
                Response.Write(jackedArray[i][j] + "&nbsp");
            }
            Response.Write("<br>");
        }
        Response.Write("<br><br>==================================");

        foreach(int[]arr in jackedArray)
        {
            foreach(int i in arr)
            {
                Response.Write(i + "&nbsp;");
            }
            Response.Write("<br>");
        }

    }
}