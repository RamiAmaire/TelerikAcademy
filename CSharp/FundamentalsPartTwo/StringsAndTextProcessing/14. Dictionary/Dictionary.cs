using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Dictionary
{
    static void Main()
    {
        Console.WriteLine("Enter text (for new lines use (\\n) without spacing, example : \\ntext )");
        string text = Console.ReadLine();
        text = text.ToLower();
        string[] lineSeparator = {"\n"};
        string[] separatedLines = text.Split(lineSeparator, StringSplitOptions.RemoveEmptyEntries);
        string[] wordSeparator = {"^"};
        string[] separatedWords;
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string temp = "";
        for (int i = 0; i < separatedLines.Length; i++)
        {
            temp = separatedLines[i].Replace("-","^");
            separatedWords = temp.Split(wordSeparator,StringSplitOptions.None);
            dictionary.Add(separatedWords[0], separatedWords[1]);
        }
        string result = "";
        for (int i = 0; i < dictionary.Count; i++)
        {
            Console.Write("Enter word in lower case: ");
            string word = Console.ReadLine();
            if (dictionary.ContainsKey(word + " "))
            {
                dictionary.TryGetValue(word + " ", out result);
                Console.WriteLine("{0} - {1}", word, result);
            }
        }
    }
}
