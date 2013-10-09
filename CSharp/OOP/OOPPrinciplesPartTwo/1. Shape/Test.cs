using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Test
{
    static void Main()
    {
        List<Shape> listOfShapes = new List<Shape>()
            {
                new Triangle(3,5),
                new Rectangle(10,8),
                new Circle(2,4),
            };
        foreach (var shape in listOfShapes)
        {
            Console.WriteLine("{0} \n Width {1} \n Height {2} \n Surface = {3}  ", shape.GetType(),shape.Width,shape.Height,shape.CalculateSurface());
        }
    }
}
