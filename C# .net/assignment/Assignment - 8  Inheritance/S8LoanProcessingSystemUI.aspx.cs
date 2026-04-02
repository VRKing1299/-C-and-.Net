using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoanProcessingSystemUI;

/// <summary>
/// This is the code-behind class used to simulate a Loan Processing system.
/// The user provides Loan details such as loan id, customer name, and loan amount.
/// Based on the selected loan type (HomeLoan, CarLoan, or PersonalLoan),
/// the corresponding class is used to calculate the loan interest and display the result.
/// </summary>
public partial class S8LoanProcessingSystemUI : System.Web.UI.Page
{
    // Button click event to calculate Home Loan interest
    protected void btnHomeLoan_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int id = Convert.ToInt32(txtLoanId.Text);
            string name = txtCustomerName.Text;
            double amount = Convert.ToDouble(txtLoanAmount.Text);

            // Create HomeLoan object using base class reference
            Loan loan = new HomeLoan(id, name, amount);

            // Display calculated interest
            lblResult.Text = "Home Loan Interest: ₹" + loan.CalculateInterest();
        }
        catch (Exception ex) { }
    }

    // Button click event to calculate Car Loan interest
    protected void btnCarLoan_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int id = Convert.ToInt32(txtLoanId.Text);
            string name = txtCustomerName.Text;
            double amount = Convert.ToDouble(txtLoanAmount.Text);

            // Create CarLoan object
            Loan loan = new CarLoan(id, name, amount);

            // Display calculated interest
            lblResult.Text = "Car Loan Interest: ₹" + loan.CalculateInterest();
        }
        catch (Exception ex) { }
    }

    // Button click event to calculate Personal Loan interest
    protected void btnPersonalLoan_Click(object sender, EventArgs e)
    {
        try
        {
            // Get user input from textboxes
            int id = Convert.ToInt32(txtLoanId.Text);
            string name = txtCustomerName.Text;
            double amount = Convert.ToDouble(txtLoanAmount.Text);

            // Create PersonalLoan object
            Loan loan = new PersonalLoan(id, name, amount);

            // Display calculated interest
            lblResult.Text = "Personal Loan Interest: ₹" + loan.CalculateInterest();
        }
        catch (Exception ex) { }
    }
}