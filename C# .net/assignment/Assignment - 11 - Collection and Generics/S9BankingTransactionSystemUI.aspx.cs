using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class S9BankingTransactionSystemUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBankAccountSystemDemo_Click(object sender, EventArgs e)
    {
        try
        {
            Dictionary<int, string> accounts = new Dictionary<int, string>();

            #region// Add accounts (checking before adding)
            AddAccount(accounts, 101, "amul");
            AddAccount(accounts, 102, "priyanka");
            AddAccount(accounts, 103, "amitabhBachan");
            AddAccount(accounts, 104, "Katrina");
            AddAccount(accounts, 105, "Virat");
            #endregion

            // Display all accounts
            Console.WriteLine("All Bank Accounts:");
            foreach (KeyValuePair<int, string> acc in accounts)
            {
                Response.Write("account number: " + acc.Key + " | holder Name: " + acc.Value + "<br>");
            }

            #region// Search account
            int searchAccount = 103;

            if (accounts.ContainsKey(searchAccount))
            {
                Response.Write("account found:");
                Response.Write("Account Number: " + searchAccount + " | Holder Name: " + accounts[searchAccount]);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
            #endregion
        }catch(Exception ex) { }
    }

    //method to add account to dictionary 
    #region
    static void AddAccount(Dictionary<int, string> accounts, int accNo, string name)
    {
        if (!accounts.ContainsKey(accNo))
        {
            accounts.Add(accNo, name);
        }
        else
        {
            Console.WriteLine("account already exists.");
        }
    }
    #endregion
}