using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ExractSentences
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();
        Console.Write("Enter substring: ");
        string substring = Console.ReadLine();
        text = text.ToLower();
        string[] lineSeparator = { ".", "\n" };
        string[] lineSeparated = text.Split(lineSeparator, StringSplitOptions.RemoveEmptyEntries);
        string[] wordSeparator = { " " };
        string[] wordSeparated;
        int temp = 0;
        List<string> finalResult = new List<string>();
        for (int i = 0; i < lineSeparated.Length; i++)
        {
            wordSeparated = lineSeparated[i].Split(wordSeparator, StringSplitOptions.RemoveEmptyEntries);
            while (temp < wordSeparated.Length)
            {
                if (wordSeparated[temp] == substring)
                {
                    finalResult.Add(lineSeparated[i]);
                }
                temp++;
            }
            temp = 0;
        }
        foreach (var item in finalResult)
        {
            Console.WriteLine(item);
        }
    }
}
