using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GetSurfaceByTwoSidesAndAngle
{
    static void Main()
    {
        Console.Write("Vuvedete purva strana= ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Vuvedete vtora strana= ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Vuvedete gradusite na ugulut mejdu tqh= ");
        double y = double.Parse(Console.ReadLine());
        double s = (a * b * Math.Sin(y)) / 2;
        Console.WriteLine("Liceto e = " + s);
    }
}
