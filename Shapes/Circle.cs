using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        //Constructor
        public Circle(double radius) : base(radius, radius) {}

        public override double CalculateSurface()
        {
            return Math.PI * Width * Width;
        }
    }
}
