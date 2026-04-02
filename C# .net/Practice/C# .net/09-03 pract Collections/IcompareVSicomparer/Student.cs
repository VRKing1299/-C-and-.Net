using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcompareVSicomparer
{
    public class Student : IComparable<Student>
    {
        public int marks;
        public Student(int m)
        {
            marks = m;
        }


        public int CompareTo(Student other)
        {
            return this.marks - other.marks;
        }
    }
}
