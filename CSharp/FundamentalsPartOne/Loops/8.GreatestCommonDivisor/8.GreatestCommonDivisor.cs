using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        Console.Write("Enter first Number= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter second Number= ");
        int m = int.Parse(Console.ReadLine());
        int max=0;
        if (n < m)
        {
            for (int i = 1; i <= n; i++)
            {
                if ((n % i == 0) && (m % i == 0))
                {
                    if (i > max)
                    {
                        max = i;
                    }
                }
            }
        }
        else
        {
            for (int i = 1; i <= m; i++)
            {
                if ((n % i == 0) && (m % i == 0))
                {
                    if (i > max)
                    {
                        max = i;
                    }
                }
            }
        }
        Console.WriteLine("The greatest common divisor is= "+ max);
    }
}

