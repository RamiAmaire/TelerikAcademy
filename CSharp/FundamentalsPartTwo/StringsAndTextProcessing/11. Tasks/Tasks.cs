using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Tasks
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Decimal: ");
        Console.WriteLine(n.ToString("D").PadLeft(15));
        Console.WriteLine("Hexadecimal: ");
        Console.WriteLine(n.ToString("X").PadLeft(15));
        Console.WriteLine("Percent: ");
        Console.WriteLine(n.ToString("P").PadLeft(15));
        Console.WriteLine("Currency: ");
        Console.WriteLine(n.ToString("C").PadLeft(15));
        Console.WriteLine("Exponential: ");
        Console.WriteLine(n.ToString("E").PadLeft(15));
    }
}
