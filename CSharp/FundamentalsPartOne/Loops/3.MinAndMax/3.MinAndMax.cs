using System;

class MinAndMax
{
    static void Main()
    {
        int i;
        int n;
        int max = 0;
        int min = int.MaxValue;
        for (i = 1; i <= 5; i++)
        {
            Console.Write("Enter number {0}= ", i);
            n = int.Parse(Console.ReadLine());
            if (n > max)
            {
                max = n;
            }
            if (n < min)
            {
                min = n;
            }
        }
        Console.WriteLine("Max= " + max);
        Console.WriteLine("Min= " + min);
    }
}

