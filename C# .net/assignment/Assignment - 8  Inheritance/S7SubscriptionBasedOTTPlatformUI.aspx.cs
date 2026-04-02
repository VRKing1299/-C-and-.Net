using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SubscriptionBasedOTTPlatform;

/// <summary>
/// This is the code-behind class used to simulate a Subscription ott Platform.
/// The user provides Plan details such as username, duration in months, and price.
/// Based on the selected subscription plan type (BasicPlan, FamilyPlan, or PremiumPlan),
/// the corresponding class from SubscriptionBasedOTTPlatform is used to calculate
/// the total subscription price, and the result is displayed.
/// </summary>
public partial class S7SubscriptionBasedOTTPlatformUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //btn cor basic subscription
    protected void btnBasic_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            string user = txtBUser.Text;
            int duration = Convert.ToInt32(txtBDuration.Text);
            double price = Convert.ToDouble(txtBPrice.Text);

            //creating an object
            BasicPlan b = new BasicPlan(user, duration, price);

            // Display calculated result
            lblBasic.Text = "Total Price: ₹" + b.CalculateTotalPrice();\
            #endregion
        }
        catch (Exception ex) { }
    }

    //btn for premium subscription
    protected void btnPremium_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            string user = txtBUser.Text;
            int duration = Convert.ToInt32(txtBDuration.Text);
            double price = Convert.ToDouble(txtBPrice.Text);

            //creating an object
            PremiumPlan p = new PremiumPlan(user, duration, price);

            // Display calculated result
            lblBasic.Text = "Total Price: ₹" + p.CalculateTotalPrice();
            #endregion
        }
        catch(Exception ex) { }
    }


    //btn for family subscription
    protected void btnFamily_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            string user = txtBUser.Text;
            int duration = Convert.ToInt32(txtBDuration.Text);
            double price = Convert.ToDouble(txtBPrice.Text);

            FamilyPlan p = new FamilyPlan(user, duration, price);

            // Display calculated result
            lblBasic.Text = "Total Price: ₹" + p.CalculateTotalPrice();
            #endregion
        }
        catch (Exception ex) { }
    }
}