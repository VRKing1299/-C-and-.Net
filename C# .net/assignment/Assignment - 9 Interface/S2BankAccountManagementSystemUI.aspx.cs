using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankAccountManagementSystem;

public partial class S2BankAccountManagementSystemUI : System.Web.UI.Page
{
    CurrentAccount a1 = new CurrentAccount(1000, 500);
    SavingAccount a2 = new SavingAccount(500);
    protected void Page_Load(object sender, EventArgs e)
    {
        lblCurrentAccount.Text = "Balance : " + a1.Balance + "  |  " + a1.OverDraftLimit;
        lblSavingAccount.Text = "Balance : " + a2.Balance;

    }

    //btn to deposit in saving account
    protected void btnSavingDeposit_Click(object sender, EventArgs e)
    {
        try
        {
            a2.Deposit(Convert.ToDouble(txtDepositSaving.Text));
            lblResultSaving.Text = "successfully deposited";
        }catch(Exception ex) { }
    }


    //btn to widraw from saving acounts
    protected void btnSavingWidraw_Click(object sender, EventArgs e)
    {
        try
        {
            double result = a2.Widraw(Convert.ToDouble(txtWidrawSaving.Text));
            #region
            if (result == 0)
            {
                lblResultSaving.Text = "widraw un sucessfull";
            }
            else
            {
                lblResultSaving.Text = "successfully widrawn" + txtWidrawSaving.Text;
            }
            #endregion
        }
        catch (Exception ex) { }
    }

    //btn to check balance of current account
    protected void btnSavingCheckBalance_Click(object sender, EventArgs e)
    {
        try
        {
            lblSavingCheckBalance.Text = " " + a2.CheckBalance();
        }catch(Exception ex) { }
    }

    //current account==================================================
    //btn to deposit in current account
    protected void btnCurrentDeposit_Click(object sender, EventArgs e)
    {
        try
        {
            a1.Deposit(Convert.ToDouble(txtDepositCurrent.Text));
            lblResultCurrent.Text = "successfully deposited";
        }catch(Exception ex) { }
    }

    //btn to widraw from current account
    protected void btnCurrentWidraw_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            double result = a1.Widraw(Convert.ToDouble(txtWidrawCurrent.Text));
            if (result == 0)
            {
                lblResultCurrent.Text = "widraw un sucessfull";
            }
            else
            {
                lblResultCurrent.Text = "successfully widrawn" + txtWidrawCurrent.Text;
            }
            #endregion
        }
        catch (Exception ex) { }
    }

    //btn to check current balance
    protected void btnCurrentCheckBalance0_Click(object sender, EventArgs e)
    {
        try
        {
            lblCurrentCheckBalance.Text = " " + a1.CheckBalance();
        }catch(Exception ex) { }
    }
}