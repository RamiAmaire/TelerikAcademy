using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ShortToBinary
{
    static string GetBinary(short s)
    {
        string b = String.Empty;
        for (int i = 0; i < 16; i++)
        {
            b = (s >> i & 1) + b;
        }
        return b;
    }
    static void Main()
    {
        Console.Write("Enter number= ");
        short number = Int16.Parse(Console.ReadLine());
        Console.WriteLine(GetBinary(number));
    }
}
