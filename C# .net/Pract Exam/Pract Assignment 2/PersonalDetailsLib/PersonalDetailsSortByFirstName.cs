using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetailsLib
{
    /// <summary>
    /// class will be used to sort the personal details list by the first name
    /// </summary>
    public class PersonalDetailsSortByFirstName : IComparer<PersonalDetails>
    {
        //method to compare the values
        public int Compare(PersonalDetails x, PersonalDetails y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }
}
