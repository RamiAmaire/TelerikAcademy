using System;

class Trapezoid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = 2 * n;
        int h = n + 1;
        for (int i = 0; i < h; i++)
        {
            Console.Write(new string('.', n - i));
            for (int j = 0; j < n + i; j++)
            {
                System.Threading.Thread.Sleep(300);
                if ((i == 0) || (i == h - 1))
                {
                    Console.Write("*");
                }
                else
                {
                    if ((j != n + i - 1) && (j != 0))
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}

