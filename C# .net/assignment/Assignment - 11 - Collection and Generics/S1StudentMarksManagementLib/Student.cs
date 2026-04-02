using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1StudentMarksManagementLib
{
    /// <summary>
    /// creating a student class with student object
    /// class has two felds i.e marks and name and has one constructor
    /// </summary>
    public class Student
    {
        public int Marks { get; }
        public string Name { get; }

        //constructor with name and marks are parameter
        public Student (string name, int marks)
        {
            Name = name;
            Marks = marks;
        }
    }
}
