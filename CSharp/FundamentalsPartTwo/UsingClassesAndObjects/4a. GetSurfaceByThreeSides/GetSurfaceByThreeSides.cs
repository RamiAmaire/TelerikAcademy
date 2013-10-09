using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GetSurfaceByThreeSides
{
    static void Main()
    {
        Console.Write("Vuvedete purva strana= ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Vuvedete vtora strana= ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Vuvedete treta strana= ");
        double c = double.Parse(Console.ReadLine());
        double p = (a + b + c) / 2;
        double temp = p * (p - a) * (p - b) * (p - c);
        double s = Math.Sqrt(temp);
        Console.WriteLine("Liceto e = {0}", s);
    }
}
