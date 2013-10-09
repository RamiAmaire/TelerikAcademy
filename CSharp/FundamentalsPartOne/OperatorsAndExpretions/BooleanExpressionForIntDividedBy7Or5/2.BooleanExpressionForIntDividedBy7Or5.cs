using System;

class BooleanExpressionForIntDividedBy7Or5
{
    static void Main()
    {
        Console.Write("Enter a number= ");
        int b = System.Convert.ToInt32(Console.ReadLine());
        bool a = ((b % 5 == 0) && (b % 7 == 0));
        Console.WriteLine(a);
    }
}
