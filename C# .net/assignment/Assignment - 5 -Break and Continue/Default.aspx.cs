using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


/// <summary>
/// this class is used to dempnstrate the use of continue and brake statements
/// on the bin 3 it returns responce of under mainatinance and is used to find golden ticket at bin 7
/// all the operations are performed on the button click
/// </summary>
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //code to find golden ticket
    protected void btnFindGoldenTicket_Click(object sender, EventArgs e)
    {
        try
        {
            int[] arr = { 1, 4, 2, 3, 8, 5, 6, 7, 9, 10, 33, 12, 22, 45 };//array of bins

            for (int i = 0; i < arr.Length; i++)//iterating over the array
            {
                if (arr[i] == 3)// for maintainance
                {
                    Response.Write("Under Maintainance <br>");
                }
                else if (arr[i] == 7)//for golden ticket
                {
                    Response.Write("golden ticket found");
                    break;
                }
                else
                {
                    Response.Write(arr[i] + "<br>");
                }
            }
        }catch(Exception ex) { }
    }
}