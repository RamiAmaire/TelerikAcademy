using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string day = Convert.ToString(DateTime.Now.AddDays(4).DayOfWeek);
        Console.WriteLine("Today is {0}", day);
        day = Convert.ToString(DateTime.Now.DayOfWeek);
        Console.WriteLine("Just kidding, today is {0}", day);
    }
}
