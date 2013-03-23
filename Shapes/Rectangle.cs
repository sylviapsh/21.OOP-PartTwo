using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        //Constructor
        public Rectangle(double width, double height) : base(width, height) { }

        public override double CalculateSurface()
        {
            return Height * Width;
        }
    }
}
