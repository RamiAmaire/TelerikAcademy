using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

class DifferenceBetween2Days
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter dates in format: dd:mm:yyyy");
            Console.Write("Enter first date: ");
            string firstDate = Console.ReadLine();
            Console.Write("Enter second date: ");
            string secondDate = Console.ReadLine();
            IFormatProvider culture = new CultureInfo("bg");
            string format = "dd/mm/yyyy";
            DateTime dateOne = DateTime.ParseExact(firstDate, format, culture);
            DateTime dateTwo = DateTime.ParseExact(secondDate, format, culture);
            int dayOne = dateOne.Day;
            int dayTwo = dateTwo.Day;
            int result;
            if (dayOne > dayTwo)
            {
                result = dayOne - dayTwo;
            }
            else
            {
                result = dayTwo - dayOne;
            }
            Console.WriteLine("Distance : {0}", result);
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid date format !");
            Console.WriteLine("Try like the following example : (27.02.2006)");
            throw;
        }
    }
}
