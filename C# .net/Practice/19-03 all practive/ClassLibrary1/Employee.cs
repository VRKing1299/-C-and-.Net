using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public double Sal { get; }

        public Employee(int id, string name, double sal)
        {
            Id = id;
            Name = name;
            Sal = sal;
        }

        public abstract double CalcSal();
    }

    public class PermentantEmp : Employee
    {
        public PermentantEmp(int id, string name, double sal) : base(id, name, sal)
        {

        }
        public override double CalcSal()
        {
            double totalSal = (Sal * 0.1) + (Sal * 0.2) + Sal;
            return totalSal;
        }
    }

    public class TempEmp : Employee
    {
        public TempEmp(int id, string name, double sal) : base(id, name, sal)
        {

        }
        public override double CalcSal()
        {
            return Sal;
        }
    }
}
