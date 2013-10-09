using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TimesSubstring
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string str = Console.ReadLine();
        str = str.ToLower();
        Console.Write("Enter substring: ");
        string substring = Console.ReadLine();
        substring = substring.ToLower();
        int counter = 0;
        int index = str.IndexOf(substring);
        while (index != -1)
        {
            counter++;
            index = str.IndexOf(substring, index + 1);
        }
        if (counter == 1)
        {
            Console.WriteLine("{0} is contained {1} time", substring, counter);
        }
        if (counter == 0)
        {
            Console.WriteLine("{0} is not contained", substring);
        }
        if (counter > 1)
        {
            Console.WriteLine("{0} is contained {1} times", substring, counter);
        }
    }
}
