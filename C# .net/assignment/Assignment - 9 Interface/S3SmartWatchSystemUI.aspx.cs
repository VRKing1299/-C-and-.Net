using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartWatchSystemLib;

/// <summary>
/// this class demonstraits the use of multiple implementation of Interface
/// </summary>
public partial class S3SmartWatchSystemUI : System.Web.UI.Page
{
    SmartWatch sm = new SmartWatch();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //btn for connecting bluetooth
    protected void btnBluetooth_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Write(sm.ConnectBluetooth());
        }
        catch(Exception ex) { }
    }

    //btn to check steps
    protected void btnSteps_Click(object sender, EventArgs e)
    {
        try
        {
            lblStepCount.Text = sm.CountSteps(120);
        }catch (Exception ex) { }
    }

    // btn for sending notification
    protected void btnNotifications_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Write(sm.SendNotification("this is notification"));
        }catch(Exception ex) { }
    }
}