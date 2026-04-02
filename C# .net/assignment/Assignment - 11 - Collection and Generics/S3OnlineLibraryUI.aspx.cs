using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using S3Online_LibraryLib;

public partial class S3OnlineLibraryUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void btnAddAndDisplayItem_Click(object sender, EventArgs e)
    {
        try
        {
            //creates and objecto of book id
            Library<int> BookId = new Library<int>();
            Library<string> BookName = new Library<string>();


            Response.Write(BookId.AddItem(101) + "<br>");
            Response.Write(BookId.DisplayItem(101) + "<br>");
            Response.Write("<br> ============================ <br> <br> ");
            Response.Write(BookName.AddItem("C# Notes For Professionals ") + "<br>");
            Response.Write(BookName.DisplayItem("C# Notes For Professionals ") + "<br>");
        }
        catch (Exception) { }
    }
}