using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankingApplicationLib;

/// <summary>
/// class used to create bank account and display its details on click
/// </summary>
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCreateAccount_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            //creating an account object based on user input
            Account ac = new Account(Convert.ToDouble(txtAccountNo.Text), Convert.ToInt16(txtBalance));

            //displaying balance and account no
            lblAccountBalance.Text = "" + ac.Balance;
            lblAccountNo.Text = "" + ac.accountNo;
            #endregion
            //ac.accountNo = 123456; gives error if we try to reinitialize the value
        }
        catch (Exception ex)
        {

        }
    }
}