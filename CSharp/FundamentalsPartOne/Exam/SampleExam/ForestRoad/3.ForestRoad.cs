using System;

class ForestRoad
{
    static void Main()
    {
        int k=1;
        int n=int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            k--;
            for (int j = k; j < n+k; j++)
            {
                if (j == 0)
                {
                    Console.Write("*");
                }
                if (j!=0)
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
        int q = -1;
        int s = n - 2;
        for (int i = 0; i < n-1; i++)
        {
            q++;
            for (int j = q; j < n+q; j++)
            {
                if (j==s)
                {
                    Console.Write("*");
                }
                if (j!=s)
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}

