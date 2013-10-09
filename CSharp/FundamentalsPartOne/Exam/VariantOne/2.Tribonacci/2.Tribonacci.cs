using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdNumber = BigInteger.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        BigInteger[] trib = new BigInteger[N];
        trib[0] = firstNumber;
        trib[1] = secondNumber;
        trib[2] = thirdNumber;
        for (int i = 3; i < N; i++)
        {
            trib[i] = trib[i - 1] + trib[i - 2] + trib[i - 3];
        }
        Console.WriteLine(trib[N - 1]);
    }
}

