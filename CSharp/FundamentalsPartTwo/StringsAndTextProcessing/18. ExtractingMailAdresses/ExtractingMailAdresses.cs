using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class ExtractingMailAdresses
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, @"([a-z0-9_\.-]{2,50})@([\da-z\.-]+)\.([a-z\.]{2,6})");
        Console.WriteLine("Mails: ");
        foreach (var item in matches)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
}
