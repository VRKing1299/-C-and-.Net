using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VehicleTollManagementSystemLib;

/// <summary>
/// this is the code behid the class for the Vehicle Toll Management System UI page
/// this allows the user to calculate the toll for different type of vehicles like car truck and bus
/// the user has to provide carid owner name and base toll amount through ui
/// based on the curresponding vehicle type the  the curresponding classs form the VehicleTollManagementSystemLib will calculate 
/// the total amount and the total amount will be displaye in ui
/// </summary>
public partial class S3VehicleTollManagementSystemUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //btn to calculate car tool
    protected void btnCar_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt32(txtCarId.Text);
            string owner = txtCarOwner.Text;
            double amount = Convert.ToDouble(txtCarAmount.Text);

            //creating an object
            Car car = new Car(id, owner, amount);

            // Display calculated result
            lblCarResult.Text = "Total Toll: ₹" + car.CalculateTotalToll();
            #endregion
        }
        catch (Exception ex) { }
    }

    //btn to calculate car tool
    protected void btnTruck_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt32(txtTruckId.Text);
            string owner = txtTruckOwner.Text;
            double amount = Convert.ToDouble(txtTruckAmount.Text);

            //creating an object
            Truck truck = new Truck(id, owner, amount);

            // Display calculated result
            lblTruckResult.Text = "Total Toll: ₹" + truck.CalculateTotalToll();
            #endregion
        }
        catch(Exception ex) { }
    }

    //btn to calculate car tool
    protected void btnBus_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt32(txtBusId.Text);
            string owner = txtBusOwner.Text;
            double amount = Convert.ToDouble(txtBusAmount.Text);

            //creating an object
            Bus bus = new Bus(id, owner, amount);

            // Display calculated result
            lblBusResult.Text = "Total Toll: ₹" + bus.CalculateTotalToll();
            #endregion
        }
        catch(Exception ex) { }
    }

}