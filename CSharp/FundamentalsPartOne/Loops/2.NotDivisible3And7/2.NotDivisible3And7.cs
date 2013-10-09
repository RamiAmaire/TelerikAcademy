using System;

class NotDivisible3And7
{
    static void Main()
    {
        Console.Write("Enter n= ");
        int n = int.Parse(Console.ReadLine());
        int i;
        for (i = 1; i <= n; i++)
        {
            if ((i % 3 != 0) && (i % 7 != 0))
            {
                Console.WriteLine(i);
            }
        }
    }
}
