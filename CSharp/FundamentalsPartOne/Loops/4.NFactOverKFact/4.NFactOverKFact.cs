using System;

class NFactOverKFact
{
    static void Main()
    {
        int n;
        Console.Write("Enter n= ");
        n = int.Parse(Console.ReadLine());
        int k;
        Console.Write("Enter k= ");
        k = int.Parse(Console.ReadLine());
        if ((k < 1) || (k > n))
        {
            Console.WriteLine("Error");
        }
        int i, j;
        double s = 1;
        double s1 = 1;
        for (i = 1; i <= n; i++)
        {
            s = s * i;
        }
        for (j = 1; j <= k; j++)
        {
            s1 = s1 * j;
        }
        Console.WriteLine("N!/K!= " + s / s1);
    }
}

