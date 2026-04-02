using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Web page class (Code-behind of ASP.NET page)
public partial class MyEventEg : System.Web.UI.Page
{
    // Runs when the page loads
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Runs when Button1 is clicked on the webpage
    protected void Button1_Click(object sender, EventArgs e)
    {
        // Creating object of Publisher class
        Publisher p = new Publisher();

        // Creating object of Subscriber class
        Subscriber s = new Subscriber();

        // Subscribing Subscriber's Send() method to Publisher's event
        // This means when ProcessComplete event occurs → Send() will execute
        p.ProcessComplete += s.Send;

        // Calling method that raises the event
        p.onNotify();
    }
}


// Subscriber class
// This class listens to the event and performs an action
public class Subscriber
{
    // Event handler method
    // This method runs when the event is triggered
    public void Send()
    {
        // Writing message to browser
        HttpContext.Current.Response.Write("this is the notification");
    }
}


// Publisher class
// This class declares and raises the event
public class Publisher
{
    // Delegate declaration
    // Defines the method signature for event handlers
    public delegate void Notify();

    // Event declaration based on the delegate
    public event Notify ProcessComplete;

    // Method that triggers the event
    public void onNotify()
    {
        // Check if any subscriber is attached
        if (ProcessComplete != null)
        {
            // Raise the event (execute all subscribed methods)
            ProcessComplete();
        }
        else
        {
            // If no subscriber is attached
            HttpContext.Current.Response.Write("handler not attached to event ");
        }
    }
}