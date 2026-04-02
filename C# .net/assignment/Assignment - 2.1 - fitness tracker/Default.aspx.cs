using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserLib;

/// <summary>
/// Code-behind class for the Default.aspx page that demonstrates
/// various functions in a fitness tracking application.
/// Each operation is triggered using button click events.
/// </summary>
public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // calculates final price based on user age and membership
    protected void btnCalcFinalPrice_Click(object sender, EventArgs e)
    {
        // get user input from textboxes
        string userName = txtUserName.Text;
        int age = Convert.ToInt16(txtAge.Text);
        string member = txtMember.Text;

        // create user object
        User us = new User(userName);

        // calculate and display final price
        lblFinalPrice.Text = " Final Price $" + us.CalculateFinalPrice(age, member);
    }

    // runs a plank challenge where time increases by 10 seconds each round
    protected void btnPlankChallenge_Click(object sender, EventArgs e)
    {
        // get user name
        string userName = txtUserName.Text;

        // create user object
        User us = new User(userName);

        // execute plank challenge logic
        us.PlankChallenge();
    }

    // calculates BMI using weight and height
    protected void btnCalcBmi_Click(object sender, EventArgs e)
    {
        // get user input
        string userName = txtUserName.Text;

        // create user object
        User us = new User(userName);

        // get height and weight
        double height = Convert.ToDouble(txtHeight.Text);
        double weight = Convert.ToDouble(txtWeight.Text);

        // calculate and display BMI
        lblBmi.Text = "Your Bmi is " + us.CalculateBMI(weight, height);
    }

    // simulates running laps and provides hydration reminders
    protected void btnRunLaps_Click(object sender, EventArgs e)
    {
        // get user name
        string userName = txtUserName.Text;

        // create user object
        User us = new User(userName);

        // run lap simulation
        us.RunLaps();
    }

    // determines workout type based on intensity level
    protected void btnIntensity_Click(object sender, EventArgs e)
    {
        // get user name
        string userName = txtUserName.Text;

        // create user object
        User us = new User(userName);

        // get intensity level from user
        int intensity = Convert.ToInt16(txtIntensity.Text);

        // determine workout type and display result
        lblIntensity.Text = "Your workout type is " + us.GetWorkoutType(intensity);
    }

    // checks whether the user qualifies for the Pro Medal
    protected void btnProMedalCheck_Click(object sender, EventArgs e)
    {
        // get user name
        string userName = txtUserName.Text;

        // create user object
        User us = new User(userName);

        // get user activity data
        double steps = Convert.ToDouble(txtSteps.Text);
        int days = Convert.ToInt16(txtActiveDays.Text);

        // check medal eligibility
        bool medal = us.UnlockProMedal(steps, days);

        // display result
        if (medal)
        {
            lblProMedalCheck.Text = "Pro Medal";
        }
        else
        {
            lblProMedalCheck.Text = "Locked Pro Medal";
        }
    }
}