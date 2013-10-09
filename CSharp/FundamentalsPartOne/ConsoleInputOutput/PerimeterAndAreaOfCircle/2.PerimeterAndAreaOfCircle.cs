using System;

class PerimeterAndAreaOfCircle
{
    static void Main()
    {
        Console.Write("Vuvedete radius= ");
        int r = System.Int32.Parse(Console.ReadLine());
        double p; //perimetur
        p = 2 * Math.PI * r;
        Console.WriteLine("Perimeturut e = " + p);
        double S; //lice
        S = Math.PI * (r * r);
        Console.WriteLine("Liceto e = " + S);
    }
}
