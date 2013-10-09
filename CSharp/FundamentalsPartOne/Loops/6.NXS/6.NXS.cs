using System;
class NXS
{
        static void Main()
    {
        Console.Write("Enter n= ");
        double n = double.Parse(Console.ReadLine());
        Console.Write("Enter x= ");
        double x = double.Parse(Console.ReadLine());
        double up = 1;
        double down = 1;
        double S = 1;
        double temp = 0;
        for (double i = 1; i <= n; i++)
        {
            up *= i;
            down *= x;
            temp = temp + (up / down);
            S = 1 + temp;
        }
        Console.WriteLine("S= " + S);
    }
}
