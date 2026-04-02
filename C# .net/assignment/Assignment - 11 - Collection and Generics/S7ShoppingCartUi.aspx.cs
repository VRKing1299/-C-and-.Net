using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// this class is used to process user input from ui
/// it has btnShowCart_Click method which demonstraits the behaviour of cart on user click
/// </summary>
public partial class S7ShoppingCartUi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // simulates the use of cart in an onleine shopping system
    protected void btnShowCart_Click(object sender, EventArgs e)
    {
        //creating list cart
        try
        {
            List<string> cart = new List<string>();

            #region //adding items in cart
            cart.Add("Laptop");
            cart.Add("Mouse");
            cart.Add("Keyboard");
            #endregion

            //printing the cart
            Response.Write("items in cart : ");
            Print(cart);

            //removing the item
            cart.Remove("Mouse");
            Response.Write("after ermoving Mouse : ");
            Print(cart);
        }catch(Exception ex) { }
    }

    #region//method to print the list
    public void Print(List<string> ls)
    {
        foreach (string s in ls)
        {
            Response.Write(s + ", ");
        }
        Response.Write("<br>");
    }
    #endregion
}