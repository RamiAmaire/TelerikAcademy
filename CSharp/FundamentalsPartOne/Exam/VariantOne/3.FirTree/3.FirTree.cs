using System;

class FirTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            if (i < n)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (i >= j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                for (int k = 1; k < n - 1; k++)
                {
                    if (i > k)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
            }
            else
            {
                for (int j = 1; j <= n * 2 - 3; j++)
                {
                    if (j == n - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}

