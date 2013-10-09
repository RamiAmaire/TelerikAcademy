using System;

class MathExpressions
{
    static void Main()
    {
        //Console.Write("Enter N= ");
        double n = double.Parse(Console.ReadLine());
        //Console.Write("Enter M= ");
        double m = double.Parse(Console.ReadLine());
        //Console.Write("Enter P= ");
        double p = double.Parse(Console.ReadLine());
        if ((m == 0) || (p == 0))
        {
            Console.WriteLine("Error ! M or P must be != 0 ");
            return;
        }
        double temp1 = Math.Truncate(m % 180);
        double temp = Math.Sin(temp1);
        double s = 128.523123123;
        double x;
        x = 1 / (m * p);
        double sum = n * n + x + 1337;
        double sum1;
        sum1 = n - (s * p);
        double firstsum;
        firstsum = sum / sum1;
        double totalsum = firstsum + temp;
        Console.WriteLine("{0:F6}", totalsum);  
    }
}

