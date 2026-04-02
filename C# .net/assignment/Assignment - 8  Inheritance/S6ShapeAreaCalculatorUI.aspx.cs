using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShapeAreaCalculatorLib;

/// <summary>
/// This is the code-behind class used to calculate the area of the shape.
/// The user provides shape details such as radius or width and height or base and height.
/// Based on the selected shape type (Circle, rectangle, or triangle shape),
/// the corresponding class from ShapeAreaCalculatorLib is used to calculate
/// the Area, and the result is displayed.
/// </summary>
public partial class S6ShapeAreaCalculatorUI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //area of the circle
    protected void btnCArea_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            double radius = Convert.ToDouble(txtRadius.Text);

            //creating an object
            Circle c = new Circle(radius);

            // Display calculated result
            lblCArea.Text = "Circle Area: " + c.CalculateArea();
            #endregion
        }
        catch(Exception ex) { }
    }

    //area of the Rectangle
    protected void btnRArea_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            double width = Convert.ToDouble(txtRectWidth.Text);
            double height = Convert.ToDouble(txtRectHeigh.Text);

            //creating an object
            Rectangle r = new Rectangle(width, height);

            // Display calculated result
            lblRArea.Text = "Rectangle Area: " + r.CalculateArea();
            #endregion
        } catch(Exception ex) { }
    }

    //area of the triangle
    protected void btnTArea_Click(object sender, EventArgs e)
    {
        try
        {
            #region
            // Get user input from textboxes
            double basee = Convert.ToDouble(txtTriBase.Text);
            double height = Convert.ToDouble(txtTriHeight.Text);

            //creating an object
            Triangle t = new Triangle(basee, height);

            // Display calculated result
            lblTArea.Text = "Triangle Area: " + t.CalculateArea();
            #endregion
        }
        catch(Exception ex) { }
    }
}