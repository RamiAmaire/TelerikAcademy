using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class GetMaxMethod
{
    static int GetMax(int number, int numberOne)
    {
        int max = number;
        if (numberOne > number)
        {
            max = numberOne;
        }
        return max;
    }
    static void Main()
    {
        Console.Write("Enter first number= ");
        int firstNum = int.Parse(Console.ReadLine());
        Console.Write("Enter second number= ");
        int secondNum = int.Parse(Console.ReadLine());
        Console.Write("Enter second number= ");
        int thirdNum = int.Parse(Console.ReadLine());
        int max = GetMax(firstNum, thirdNum);
        Console.WriteLine("The biggest number is: {0} ", GetMax(max, thirdNum));
    }
}