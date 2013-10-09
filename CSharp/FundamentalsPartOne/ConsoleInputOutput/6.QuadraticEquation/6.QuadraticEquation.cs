using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("Enter a= ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b= ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c= ");
        double c = double.Parse(Console.ReadLine());
        double x1 = 0, x2 = 0;
        if (b == 0)
        {
            if (-(c / a) > 0)
            {
                x1 = Math.Sqrt(-(c / a));
                x2 = -Math.Sqrt(-(c / a));
            }
            else
            {
                Console.WriteLine("Nqma reshenie (-c/a<0)");
            }
        }
        if (c == 0)
        {
            x1 = 0;
            x2 = -(b / a);
        }
        double d;
        d = b * b - 4 * a * c;
        if (d >= 0)
        {
            x1 = (-b + Math.Sqrt(d)) / (2 * a);
            x2 = (-b - Math.Sqrt(d)) / (2 * a);

        }
        Console.WriteLine("x1= {0}" + Environment.NewLine + "x2= {1}", x1, x2);
    }
}

