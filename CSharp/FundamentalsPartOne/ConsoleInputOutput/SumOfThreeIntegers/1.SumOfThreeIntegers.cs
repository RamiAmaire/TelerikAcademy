using System;

class SumOfThreeIntegers
{
    static void Main()
    {
        Console.Write("Enter first number= ");
        int n = System.Int32.Parse(Console.ReadLine());
        Console.Write("Enter second number= ");
        int m = System.Int32.Parse(Console.ReadLine());
        Console.Write("Enter third number= ");
        int x = System.Int32.Parse(Console.ReadLine());
        Console.WriteLine(new string('-', 40));
        int sum = n + m + x;
        Console.WriteLine("Sum= " + sum);
    }
}
