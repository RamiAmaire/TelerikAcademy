using System;
using System.Numerics;

class TrailingZeros
{
    static void Main()
    {
        Console.Write("Enter n= ");
        int n = int.Parse(Console.ReadLine());
        BigInteger sum = 1;
        for (int i = 1; i <= n; i++)
        {
            sum *= i;
        }
        BigInteger b = 1;
        BigInteger temp = 0;
        int br = 0;
        BigInteger a = sum;
        for (int j = 1; j <= n; j++)
        {
            if (a % 10 == 0)
            {
                temp = a;
                b = temp / 10;
                a = b;
                br++;
            }
        }
        Console.WriteLine("N= {0} -> N!= {1} -> {2}", n, sum, br);    
    }
}
