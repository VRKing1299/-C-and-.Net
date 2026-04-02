using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrderSystemLib;

/// <summary>
/// the class S2EcommerceSystemUi simulated billing system and  
/// is used to perform calculation of total price based on user input
/// the operations are performed based on user input and are executed on button click
///  - buttons are used to calculates the total price and dispays the total price for the purchase
/// </summary>
public partial class S2EcommerceSystemUi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //btn to calculate price from store order
    protected void btnCalcSamount_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt16(txtSid.Text);
            string name = txtSname.Text;
            double sal = Convert.ToDouble(txtSsal.Text);

            //creating an object
            StoreOrder so = new StoreOrder(id, name, sal);

            // Display calculated result
            lblSTotalPrice.Text = "Total Price : " + so.CalculateFinalAmount();
            #endregion
        }
        catch (Exception ex) { }
    }


    //btn to calculte price from online order
    protected void btnCalcOamount_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt16(txtOid.Text);
            string name = txtOname.Text;
            double sal = Convert.ToDouble(txtOsal.Text);

            //creating an object
            OnlineOrder oo = new OnlineOrder(id, name, sal);

            // Display calculated result
            lblOTotalPrice.Text = "Total Price : " + oo.CalculateFinalAmount();
            #endregion
        }
        catch (Exception ex) { }
    }
}