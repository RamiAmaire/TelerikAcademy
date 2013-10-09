using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PrintWordsInAlphaOrder
{
    static void Main()
    {
        Console.Write("Enter words: ");
        string text = Console.ReadLine();
        string[] separator = { ",", " ", "." };
        string[] result = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        List<string> finalResult = new List<string>();
        foreach (var item in result)
        {
            finalResult.Add(item);
        }
        finalResult.Sort();
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Sorted: ");
        foreach (var item in finalResult)
        {
            Console.WriteLine("\t" + item);
        }
    }
}
