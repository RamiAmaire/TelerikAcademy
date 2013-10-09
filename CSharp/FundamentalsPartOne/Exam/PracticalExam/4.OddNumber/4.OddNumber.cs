using System;

class OddNumber
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        long mask = 0;
        for (int i = 0; i < count; i++)
        {
            long number = long.Parse(Console.ReadLine());
            mask ^= number;
        }
        Console.WriteLine(mask);

    }
}

