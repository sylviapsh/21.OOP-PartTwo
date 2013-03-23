using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shapes
{
    public abstract class Shape
    {
        //Fields
        private double width;
        private double height;

        //Properties
        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        //Constructor
        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        //Virtual method
        public abstract double CalculateSurface(); //Abstract methods are also virtual
        
    }
}
