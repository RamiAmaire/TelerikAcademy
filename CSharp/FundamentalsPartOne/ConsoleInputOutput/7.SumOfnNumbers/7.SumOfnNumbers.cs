using System;

class SumOfnNumbers
{
    static void Main()
    {
        Console.Write("Enter how many numbers= ");
        int n = int.Parse(Console.ReadLine());
        int i;
        int s = 0;
        for (i = 1; i <= n; i++)
        {
            Console.Write("Number {0} = ", i);
            int m = int.Parse(Console.ReadLine());
            s = s + m;
        }
        Console.WriteLine("The sum is = " + s);
    }
}
