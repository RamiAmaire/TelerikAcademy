using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Globalization;

class ExtractAllDatesInCanFormat
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("kn", true);
        string format = @"(\d{1,2})\.(\d{1,2})\.(\d{4})";
        Console.Write("Enter text : ");
        string input = Console.ReadLine();
        MatchCollection matches = Regex.Matches(input, format, RegexOptions.IgnoreCase);
        Console.WriteLine("Days: ");
        foreach (var item in matches)
        {
            Console.WriteLine(item);
        }
    }
}
