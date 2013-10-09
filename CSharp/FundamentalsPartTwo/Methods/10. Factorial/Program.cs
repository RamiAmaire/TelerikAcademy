using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class Program
{
    static BigInteger Fact(int number)
    {
        BigInteger sum = 1;
        for (int i = 1; i <= number; i++)
        {
            sum *= i;
        }
        return sum;
    }
    static void Main()
    {
        for (int i = 1; i <= 100; i++)
        {
            BigInteger result = Fact(i);
            Console.WriteLine("{0}!= {1}", i, result);
        }
    }
}
