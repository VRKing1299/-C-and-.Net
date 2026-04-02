using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonalDetailsLib;
/// <summary>
/// this class has methods tha runs based on user inputs
/// </summary>
public partial class _Default : System.Web.UI.Page
{
    //method to print the list 
    #region
    public void Print (List<PersonalDetails> ls)
    {
        foreach (PersonalDetails ps in ls)
        {
            ps.PrintDetails();
            Response.Write("<br>");
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            //creating personal details object
            #region
            PersonalDetails p1 = new PersonalDetails(1, "raj", "ram", "roy", 23, "Male");
            PersonalDetails p2 = new PersonalDetails(2, "rahul", "raja", "iyer", 32, "Male");
            PersonalDetails p3 = new PersonalDetails(3, "rani", "kesu", "patel", 22, "Female");
            PersonalDetails p4 = new PersonalDetails(4, "kani", "Karan", "singh", 45, "Female");
            PersonalDetails p5 = new PersonalDetails(5, "parth", "nehul", "parekh", 26, "Male");
            #endregion
            Response.Write("<br>");

            //adding details to the list 
            #region
            List<PersonalDetails> personalDetailsList = new List<PersonalDetails>()
            {
            p1,p2,p3,p4,p5
            };
            #endregion
            Response.Write("<br>");

            //filtering the list based on age greater than35;
            #region
            Response.Write("<br> Filtering based on age > 35");
            List<PersonalDetails> personalDetailsAgeFilter = personalDetailsList.Where(ps => ps.Age > 35).ToList();
            Print(personalDetailsAgeFilter);
            #endregion
            Response.Write("<br>");

            //sorting list based on name
            #region
            Response.Write("<br> sorting employees based on first name");
            personalDetailsList.Sort(new PersonalDetailsSortByFisrtName());

            Print(personalDetailsList);
            #endregion
            Response.Write("<br>");

            //creating new objects of personal details
            #region
            Response.Write("<br> adding one list to another");
            PersonalDetails p6 = new PersonalDetails(6, "raju", "bheem", "bhola", 12, "Male");
            PersonalDetails p7 = new PersonalDetails(7, "chutki", "chacha", "keval", 42, "Female");
            List<PersonalDetails> personalList = new List<PersonalDetails>() { p6, p7 };

            //adding the personalList to personalDetailslist
            personalDetailsList.AddRange(personalList);
            Print(personalDetailsList);

            #endregion
            Response.Write("<br>");

            //Removing all the male emploess from the list
            #region
            Response.Write("<br> removing male employees");
            personalDetailsList.RemoveAll(ps => ps.Gender == "Male");
            Print(personalDetailsList);
            #endregion
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}