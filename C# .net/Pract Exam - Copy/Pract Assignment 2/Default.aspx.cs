using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PersonalDetailsLib;

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

    protected void btnPersonalDataProcess_Click(object sender, EventArgs e)
    {
        try
        {
            //creating personal details object
            #region
            PersonalDetails person1 = new PersonalDetails(1, "raj", "ram", "roy", 23, "Male");
            PersonalDetails person2 = new PersonalDetails(2, "rahul", "raja", "iyer", 32, "Male");
            PersonalDetails person3 = new PersonalDetails(3, "rani", "kesu", "patel", 22, "Female");
            PersonalDetails person4 = new PersonalDetails(4, "kani", "Karan", "singh", 45, "Female");
            PersonalDetails person5 = new PersonalDetails(5, "parth", "nehul", "parekh", 26, "Male");
            #endregion
            Response.Write("<br>");

            //adding details to the list 
            #region
            List<PersonalDetails> personalDetailsList = new List<PersonalDetails>()
            {
            person1,person2,person3,person4,person5
            };
            #endregion
            Response.Write("<br>");

            //filtering the list based on age greater than35;
            #region
            Response.Write("<br> Filtering based on age > 35<br>");
            //List<PersonalDetails> personalDetailsAgeFilter = personalDetailsList.Where(ps => ps.Age > 35).ToList();
            List<PersonalDetails> personalDetailsAgeFilter = new List<PersonalDetails>();
            foreach(PersonalDetails pd in personalDetailsList)
            {
                if (pd.Age > 35)
                {
                    personalDetailsAgeFilter.Add(pd);
                }
            }
            Print(personalDetailsAgeFilter);
            #endregion
            Response.Write("<br>");

            //sorting list based on name
            #region
            Response.Write("<br> sorting employees based on first name<br>");
            personalDetailsList.Sort(new PersonalDetailsSortByFirstName());

            Print(personalDetailsList);
            #endregion
            Response.Write("<br>");

            //creating new objects of personal details
            #region
            Response.Write("<br> adding one list to another<br>");
            PersonalDetails person6 = new PersonalDetails(6, "raju", "bheem", "bhola", 12, "Male");
            PersonalDetails person7 = new PersonalDetails(7, "chutki", "chacha", "keval", 42, "Female");
            List<PersonalDetails> personalList = new List<PersonalDetails>() { person6, person7 };

            //adding the personalList to personalDetailslist
            personalDetailsList.AddRange(personalList);
            Print(personalDetailsList);

            #endregion
            Response.Write("<br>");

            //Removing all the male emploess from the list
            #region
            Response.Write("<br> removing male employees<br>");
            //personalDetailsList.RemoveAll(ps => ps.Gender == "Male");
            for(int i =0; i < personalDetailsList.Count; i++)
            {
                if(personalDetailsList[i].Gender== "Male")
                {
                    personalDetailsList.RemoveAt(i);
                    i--;
                }
            }
            Print(personalDetailsList);

            #endregion
        }catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}