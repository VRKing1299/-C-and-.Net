using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankingLib;

/// <summary>
/// this class simulate the bank application
/// - has a function to transfer the amount from one user to another and display the remaining balance
/// </summary>
public partial class BankingApplicationUi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //transfers the money from one user to another
    protected void btnTransferAmount_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            Account U1 = new Account(Convert.ToInt32(txtAccNoU1.Text), txtNameU1.Text, Convert.ToDouble(txtBalanceU1.Text));
            Account U2 = new Account(Convert.ToInt32(txtAccNoU2.Text), txtNameU2.Text, Convert.ToDouble(txtBalanceU2.Text));

            lblMsg.Text = BankMethods.TransferAmount(U1, U2, Convert.ToDouble(txtTransferAmount.Text));

            lblremainingBalanceU1.Text = " Remaining balance of User 1 : " + U1.balance;
            lblremainingBalanceU2.Text = " Remaining balance of User 2 : " + U2.balance;
            #endregion
        }
        catch (Exception ex)
        {

        }
    }
}