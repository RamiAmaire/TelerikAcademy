using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Enter string of maximum 20 characters= ");
        string str = Console.ReadLine();
        if (str.Length > 20)
        {
            Console.WriteLine("Error, string has more then 20 characters !");
            return;
        }
        else
        {
            str = str.PadRight(20, '*');
            Console.WriteLine(str);
        }
    }
}
