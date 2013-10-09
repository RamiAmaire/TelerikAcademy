using System;

class GreaterOfTwoNumbers
{
    static void Main()
    {
        Console.Write("Enter first number= ");
        int n = System.Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter second number= ");
        int m = System.Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Math.Max(n, m));
    }
}
