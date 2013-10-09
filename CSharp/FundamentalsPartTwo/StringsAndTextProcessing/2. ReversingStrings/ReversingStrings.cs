using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ReversingStrings
{
    static void Main()
    {
        Console.Write("Enter string: ");
        string str = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        for (int i = str.Length - 1; i >= 0; i--)
        {
            result.Append(str[i]);
        }
        Console.WriteLine("{0} -> {1}", str, result);
    }
}
