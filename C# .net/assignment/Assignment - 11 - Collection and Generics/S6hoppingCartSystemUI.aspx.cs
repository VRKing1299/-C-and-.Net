using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// this class is used to process user input from ui
/// it has btnShoppingCartBehaviour_Click method which demonstraits the behaviour of cart on user click
/// </summary>
public partial class S6hoppingCartSystemUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //this button demonstraits the behaviour of cart on user click
    protected void btnShoppingCartBehaviour_Click(object sender, EventArgs e)
    {
        try
        {
            //creating list cart
            List<string> cart = new List<string>();

            #region//adding items in cart
            cart.Add("onion");
            cart.Add("cupboard");
            cart.Add("House");
            cart.Add("BMV M4");
            #endregion

            //printing the cart
            Response.Write("items in cart : ");
            Print(cart);

            //removing the item
            cart.Remove("onion");
            Response.Write("after ermoving onion : ");
            Print(cart);

            //checking if item House exist in list or not 
            Response.Write("checking if House exist : " + cart.Exists(n => n == "House"));
        }catch(Exception ex) { }
    }

    #region//method to print the list
    public void Print(List<string> ls)
    {
        foreach(string s in ls)
        {
            Response.Write(s + ", ");
        }
        Response.Write("<br>");
    }
    #endregion
}