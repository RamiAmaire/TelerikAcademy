using System;
using System.Numerics;

public class Demo
{
    public static void Main()
    {
        int rowLen = int.Parse(Console.ReadLine());
        BigInteger previous = int.MinValue;
        BigInteger current = 0;
        BigInteger value = 0;

        for (int i = 0; i < rowLen; i++)
        {
            current = int.Parse(Console.ReadLine());
            if (current != previous)
            {
                value += current + 1;
            }
            
            previous = current;
        }

        Console.WriteLine(value + 1);
    }
}

