using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class HelloMethod
{
    static void PrintName(string name)
    {
        Console.WriteLine("Hello {0}!", name);
    }
    static void Main()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        PrintName(name);
    }
}
