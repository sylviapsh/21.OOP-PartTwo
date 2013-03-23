using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class TestShapesProgram
    {
        static void Main()
        {
            //Create some shapes
            Shape[] shapes = {
                                 new Triangle(12,6),
                                 new Rectangle(30,2),
                                 new Circle(15)
                             };

            foreach (var shape in shapes)
            {
                Console.WriteLine("The {0}'s surface is: {1:F2}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
