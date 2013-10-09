using System;

class NfactAndKFact
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
            Console.WriteLine("Error!");
            return;
        }
        int nfact = 1;
        int i = 1;
        while (i <= n)
        {
            nfact = nfact * i;
            i++;
        }
        int kfact = 1;
        int j = 1;
        while (j <= k)
        {
            kfact = kfact * j;
            j++;
        }
        Console.WriteLine("N!*K!/(N!-K!)= " + (nfact * kfact / (nfact - kfact)));
    }
}

