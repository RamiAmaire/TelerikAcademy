using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GetSurfaceBySideAndAltitude
{
    static void Main()
    {
        Console.Write("Vuvedeto strana= ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Vuvedete visochina= ");
        double h = double.Parse(Console.ReadLine());
        double s = (a * h) / 2;
        Console.WriteLine("Liceto e = " + s);
    }
}
