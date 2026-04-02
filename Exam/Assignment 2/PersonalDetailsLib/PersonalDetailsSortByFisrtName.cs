using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetailsLib
{/// <summary>
/// this class is used to conmpare the personlal details by first name 
/// </summary>
    public class PersonalDetailsSortByFisrtName : IComparer<PersonalDetails>
    {
        public int Compare(PersonalDetails x, PersonalDetails y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }
}
