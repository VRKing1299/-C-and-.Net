using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaCalculatorLib
{

    /// <summary>
    /// This abstract class represents a Shape in the Shape Area Calculator.
    /// It stores the shape name and requires derived classes to implement
    /// the CalculateArea() method to compute the area of the shape.
    public abstract class Shape
    {
        public string ShapeName { get; }

        public Shape(string name)
        {
            ShapeName = name;
        }

        public abstract double CalculateArea();
    }
}
