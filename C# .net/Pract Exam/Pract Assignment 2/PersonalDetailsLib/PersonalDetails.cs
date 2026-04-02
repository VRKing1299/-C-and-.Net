using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PersonalDetailsLib
{
    /// <summary>
    /// a class representing the personal details
    /// has a parameterized constructor
    /// and a method to print the employee object
    /// </summary>
    public class PersonalDetails
    {
        public int Id { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public int Age { get; }
        public string Gender { get; }

        // parameterized constructor to initialize the objects
        public PersonalDetails(int id, string firstName, string middleName, string lastName, int age, string gender)
        {
            #region
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            #endregion
        }

        //method to print the personal details
        public void PrintDetails()
        {
            HttpContext.Current.Response.Write("ID :" + Id + ", First Name : " + FirstName 
                + ", Middle Name : " + MiddleName 
                + ", LastName : " + LastName + ", Age : " + Age + ", Gender : " + Gender);
        }

    }
}
