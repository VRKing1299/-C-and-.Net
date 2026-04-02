using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculatorLib
{
    /// <summary>
    /// This class represents a Rectangle and inherits from the Shape class.
    /// It stores the Width and height of the Rectangle and provides its own
    /// implementation of the CalculateArea() method to compute the area
    /// using the formula: Width × height.
    /// </summary>
    public class Rectangle:Shape
    {
        public double width;
        public double height;

        public Rectangle(double w, double h) : base("Rectangle")
        {
            width = w;
            height = h;
        }

        public override double CalculateArea()
        {
            return (width*height);
        }
    }
}
