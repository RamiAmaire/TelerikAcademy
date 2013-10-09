using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ReverseDigits
{
    static void ReversDigits(string number)
    {
        for (int i = number.Length - 1; i >= 0; i--)
        {
            Console.Write(number[i]);
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Console.Write("Enter number= ");
        string number = Console.ReadLine();
        ReversDigits(number);
    }
}
