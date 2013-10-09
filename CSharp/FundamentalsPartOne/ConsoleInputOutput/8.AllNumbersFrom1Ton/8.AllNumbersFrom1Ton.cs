using System;

class AllNumbersFrom1Ton
{
    static void Main()
    {
        Console.Write("Enter a number= ");
        int n = int.Parse(Console.ReadLine());
        int i;
        Console.WriteLine("All numbers 1-n: ");
        for (i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}
