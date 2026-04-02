using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLib
{

    /// <summary>
    /// this class represents the student and has properties name, rollno , grade 
    ///  - has a private constructor
    ///  - static method tha creates and returns a new object of the student class using private constructor
    /// </summary>
    public class Student
    {
        
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string Grade { get; set; }

        //private constructor so object cannot be created directly
        private Student(string name, int rollNo, string grade)
        {
            Name = name;
            RollNo = rollNo;
            Grade = grade;
        }

        //method creates a student object and returns the student object 
        public static Student CreateStudent(string name, int rollNo, string grade)
        {
            return new Student(name, rollNo, grade);
        }
    }
}
