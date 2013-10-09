using System;

class SumWithAccurancy
{
    static void Main()
    {
        double s = 1;
        for (double i = 2; i < 27; i++)
        {
            s = 1 + 1 / i - 1 / (i + 1);

        }
        Console.WriteLine("{0:F3}", s);
    }
}
