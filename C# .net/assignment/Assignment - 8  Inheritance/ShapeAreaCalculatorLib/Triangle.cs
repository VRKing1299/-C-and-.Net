using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculatorLib
{
    /// <summary>
    /// This class represents a Triangle and inherits from the Shape class.
    /// It stores the base and height of the triangle and provides its own
    /// implementation of the CalculateArea() method to compute the area
    /// using the formula: 0.5 × base × height.
    /// </summary>
    public class Triangle:Shape
    {
        public double basee;
        public double height;

        public Triangle(double b, double h) : base("Triangle")
        {
            basee = b;
            height = h;
        }

        public override double CalculateArea()
        {
            return ((0.5)*basee * height);
        }
    }
}
