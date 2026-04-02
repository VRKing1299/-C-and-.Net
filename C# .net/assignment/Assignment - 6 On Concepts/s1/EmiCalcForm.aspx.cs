using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoanModuleLib;

/// <summary>
/// this class is used to perform emi calculation based on user input and displayes monthly emi on button click
/// </summary>
public partial class EmiCalcForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //calculates emi based on amount and principle
    protected void btnCaculateEmi_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            //taking user input
            int amount = Convert.ToInt16(txtPrinciapAmount.Text);
            double principalRate = Convert.ToDouble(txtPrincipalRate.Text);
            int time = Convert.ToInt16(txtBorrowTime.Text);

            //calculating emi using sttic emiCalc method and disyplaying the output
            lblEmi.Text = " Your Monthly Emi = " + Loan.EmiCalc(amount, principalRate, time);
            #endregion
        }
        catch (Exception ex)
        {

        }
    }
}