using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PrintAllWords
{
    static void Main()
    {
        Console.Write("Enter text : ");
        string text = Console.ReadLine();
        text = text.ToLower();
        string[] separator = { " ", ",", ".", "-", "?", "!", "\n" };
        string[] result = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> word = new Dictionary<string, int>();
        foreach (var item in result)
        {
            if (word.ContainsKey(item))
            {
                word[item]++;
            }
            else
            {
                word[item] = 1;
            }
        }
        var list = word.Keys.ToList();
        list.Sort();
        foreach (var key in list)
        {
            Console.WriteLine("{0}-> {1} times", key, word[key]);
        }
    }
}
