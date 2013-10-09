using System;

class NumbersFrom1toN
{
    static void Main()
    {
        Console.Write("Enter n= ");
        int n = int.Parse(Console.ReadLine());
        int i;
        Console.WriteLine("Numbers from 1-n : ");
        for (i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}

