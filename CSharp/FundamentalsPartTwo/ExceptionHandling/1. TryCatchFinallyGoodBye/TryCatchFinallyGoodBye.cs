using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TryCatchFinallyGoodBye
{
    static void Main()
    {
        try
        {
            Console.Write("Vuvedeto cqlo polojitelno chislo= ");
            int number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                Console.WriteLine("Invalid number");
            }
            else
            {
                Console.WriteLine("Koren kvadraten ot {0} e= {1}", number, Math.Sqrt(number));
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good Bye");
        }
    }
}
