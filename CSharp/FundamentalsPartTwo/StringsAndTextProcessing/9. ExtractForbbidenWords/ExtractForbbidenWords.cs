using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ExtractForbbidenWords
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();
        Console.WriteLine(new string('-', 40));
        Console.Write("Enter forbidden words: ");
        string forbiddenWords = Console.ReadLine();
        string[] saparator = { ",", ".", " " };
        string[] forbiddenWordsResult = forbiddenWords.Split(saparator, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < forbiddenWordsResult.Length; i++)
        {
            int len = forbiddenWordsResult[i].Length;
            text = text.Replace(forbiddenWordsResult[i], new string('*', len));
        }
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Result: ");
        foreach (var item in text)
        {
            Console.Write(item);
        }
    }
}
