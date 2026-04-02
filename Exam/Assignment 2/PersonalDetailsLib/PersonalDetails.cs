using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PersonalDetailsLib
{
    /// <summary>
    /// this class represents personal details
    /// </summary>
    public class PersonalDetails
    {
        #region
        public int Id { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public int Age { get; }
        public string Gender { get; }
        #endregion
        //constructor
        public PersonalDetails(int id, string firstName, string middleName, string lastName, int age, string gender)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Age = age;
            Gender = gender;
        }
        //method to print the details
        public void PrintDetails()
        {
            HttpContext.Current.Response.Write("ID :" + Id + ", First Name : " + FirstName 
                + ", Middle Name : " + MiddleName 
                + ", LastName : " + LastName + ", Age : " + Age + ", Gender : " + Gender);
        }

    }
}
