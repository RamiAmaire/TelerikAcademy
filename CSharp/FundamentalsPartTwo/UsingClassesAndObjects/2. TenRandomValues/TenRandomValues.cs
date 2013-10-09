using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TenRandomValues
{
    static void Main()
    {
        Random numbers = new Random();
        for (int i = 1; i <= 10; i++)
        {
            int rndNumbers = numbers.Next(100, 201);
            Console.WriteLine("{0}. {1}", i, rndNumbers);
        }
    }
}
