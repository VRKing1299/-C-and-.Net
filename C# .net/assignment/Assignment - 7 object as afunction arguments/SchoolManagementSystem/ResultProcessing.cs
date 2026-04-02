using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    /// <summary>
    /// this is class used for processing result with method:
    ///  - static AssignGrade that takes the student object and assignes the grade
    /// </summary>
    public class ResultProcessing
    {
        public static void AssignGrade(Student s)
        {
            if (s.Marks >= 75)
            {
                s.Grade = 'A';
            }
            else if (s.Marks >= 60)
            {
                s.Grade = 'B';
            }
            else
            {
                s.Grade = 'C';
            }
        }
    }
}
