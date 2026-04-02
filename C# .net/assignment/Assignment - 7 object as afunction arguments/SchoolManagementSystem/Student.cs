using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{

    /// <summary>
    /// this class simulate the student object with rreadonly rollno , name marks and grade property
    /// </summary>
    public class Student
    {
        public readonly int rollNo;
        public string Name { get; }
        public double Marks { get; }
        public char Grade { get; set; }

        public Student(int rollNo, string name, double marks)
        {
            this.rollNo = rollNo;
            Name = name;
            Marks = marks;
        }

    }
}
