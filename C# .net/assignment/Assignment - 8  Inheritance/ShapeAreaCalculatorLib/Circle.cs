using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculatorLib
{
    /// <summary>
    /// This class represents a Circle and inherits from the Shape class.
    /// It stores the radius of the Circle and provides its own
    /// implementation of the CalculateArea() method to compute the area
    /// using the formula: 3.14*(radius * radius).
    /// </summary>
    public class Circle:Shape
    {
        public double radius;

        public Circle (double r) : base("Circle")
        {
            radius = r;
        }

        public override double CalculateArea()
        {
            return (3.14*(radius*radius));
        }
    }
}
