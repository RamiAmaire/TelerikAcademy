using System;

class Sandglass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n / 2 + 1; i++)
        {
            for (int j = 1; j <= n / 2 + 1; j++)
            {
                if (i <= j)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            for (int k = n / 2; k >= 1; k--)
            {
                if (k >= i)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
        for (int i = n / 2; i >= 1; i--)
        {
            for (int j = 1; j <= n / 2 + 1; j++)
            {
                if (j >= i)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            for (int k = n / 2; k >= 1; k--)
            {
                if (k >= i)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}

