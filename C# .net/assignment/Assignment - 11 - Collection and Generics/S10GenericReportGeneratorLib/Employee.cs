using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10GenericReportGeneratorLib
{
    /// <summary>
    /// this class simulates the Employee entity with toString method overriden for printing details of object
    /// </summary>
    public class Employee
    {
        public int Id { get;}
        public string Name { get;}

        //public constructor
        public Employee (int id,string name)
        {
            Id = id;
            Name = name;
        }

        //overriding to string method to print the details of object
        public override string ToString()
        {
            return "Employee Id: "+Id+", Name: "+Name;
        }
    }
}
