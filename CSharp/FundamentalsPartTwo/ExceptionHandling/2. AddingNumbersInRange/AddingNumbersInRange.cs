using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AddingNumbersInRange
{
    static int counter = 1;
    static List<int> values = new List<int>();
    static void ReadNumber(int number, int end)
    {
        int previous = number;
        while (counter < 10)
        {
            counter++;
            int next = 0;
            try
            {
                Console.WriteLine("Enter a number {0}-100", previous + 1);
                next = int.Parse(Console.ReadLine());
            }
            catch (Exception fe)
            {
                Console.WriteLine("Invalid number, reason: {0}", fe);
                Console.WriteLine(new string('-', 40));
                counter--;
                continue;
            }
            if (next > end)
            {
                Console.WriteLine("Number must be < 100");
                Console.WriteLine(new string('-', 40));
                counter--;
                continue;
            }
            if (next <= previous)
            {
                Console.WriteLine("Next number must be bigger then previous({0})", previous);
                Console.WriteLine(new string('-', 40));
                counter--;
                continue;
            }
            if ((next < end) && (next > previous))
            {
                values.Add(next);
                previous = next;
            }
        }
    }
    static void Main()
    {
        Console.Write("Enter number= ");
        int number = int.Parse(Console.ReadLine());
        if ((number < 0) || (number > 100))
        {
            Console.WriteLine("Error! Number must be from 1 to 100");
            Main();
        }
        values.Add(number);
        ReadNumber(number, 100);
        foreach (var item in values)
        {
            Console.Write(item);
        }
    }
}
