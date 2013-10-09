using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class IsLeapYear
{
    static void Main()
    {
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());
        string isLeap = Convert.ToString(DateTime.IsLeapYear(year));
        Console.WriteLine("Is year {0} leap ? -> {1}", year, isLeap);
    }
}
