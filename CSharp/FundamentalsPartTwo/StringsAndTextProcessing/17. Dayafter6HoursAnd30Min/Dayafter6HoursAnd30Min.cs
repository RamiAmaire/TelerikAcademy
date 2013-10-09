using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

class Program
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg", true);
        Console.WriteLine("Enter date in format : (day.month.year hour:minutes:seconds)");
        string date = Console.ReadLine();
        Console.WriteLine();
        var bg = new CultureInfo("bg");
        string format = "dd/MM/yyyy HH:mm:ss";
        DateTime dateOne = DateTime.ParseExact(date, format, bg);
        dateOne = dateOne.AddHours(06);
        dateOne = dateOne.AddMinutes(30);
        Console.WriteLine("After 6 hours and 30 minutes : {0}", dateOne);
    }
}
