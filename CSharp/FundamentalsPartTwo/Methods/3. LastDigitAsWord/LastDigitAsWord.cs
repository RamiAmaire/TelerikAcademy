using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LastDigitAsWord
{
    static void GetLastDigit(string number)
    {
        int lastDigit = 0;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            lastDigit = number[i] - '0';
            break;
        }
        switch (lastDigit)
        {
            case 0: Console.WriteLine("Zero"); break;
            case 1: Console.WriteLine("One"); break;
            case 2: Console.WriteLine("Two"); break;
            case 3: Console.WriteLine("Three"); break;
            case 4: Console.WriteLine("Four"); break;
            case 5: Console.WriteLine("Five"); break;
            case 6: Console.WriteLine("Six"); break;
            case 7: Console.WriteLine("Se7en"); break;
            case 8: Console.WriteLine("Eight"); break;
            case 9: Console.WriteLine("Nine"); break;
            default: Console.WriteLine("Error!"); break;
        }
    }
    static void Main()
    {
        Console.Write("Enter number= ");
        string number = Console.ReadLine();
        GetLastDigit(number);
    }
}
