using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HospitalManagementSystemLib;

/// <summary>
/// This is the code-behind class used to simulate a Hospital Management System.
/// The user provides doctor details such as Id, Name, and Fee.
/// Based on the selected doctor type (General Physician, Surgeon, or Visiting Doctor),
/// the corresponding class from HospitalManagementSystemLib is used to calculate
/// the total consultation fee, and the result is displayed.
/// </summary>
public partial class S5HospitalManagementSystemUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //btn for general physician
    protected void btnGP_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt32(txtGPId.Text);
            string name = txtGPName.Text;
            double fee = Convert.ToDouble(txtGPFee.Text);

            //creating an object
            GeneralPhysician gp = new GeneralPhysician(id, name, fee);

            // Display calculated result
            lblGPResult.Text = "Total Fee: ₹" + gp.CalculateTotalFee();
            #endregion
        }
        catch (Exception ex) { }
    }

    //btn for surgeon
    protected void btnSurgeon_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt32(txtSId.Text);
            string name = txtSName.Text;
            double fee = Convert.ToDouble(txtSFee.Text);

            //creating an object
            Surgeon surgeon = new Surgeon(id, name, fee);

            // Display calculated result
            lblSResult.Text = "Total Fee: ₹" + surgeon.CalculateTotalFee();
            #endregion
        }
        catch (Exception ex) { }
    }

    //btn for visiting doctor
    protected void btnVisiting_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            int id = Convert.ToInt32(txtVId.Text);
            string name = txtVName.Text;
            double fee = Convert.ToDouble(txtVFee.Text);
            double travel = Convert.ToDouble(txtTravel.Text);

            //creating an object
            VisitingDoctor vd = new VisitingDoctor(id, name, fee, travel);

            // Display calculated result
            lblVResult.Text = "Total Fee: ₹" + vd.CalculateTotalFee();
            #endregion
        }
        catch (Exception ex) { }
    }

    protected void txtVId_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtTravel_TextChanged(object sender, EventArgs e)
    {

    }
}