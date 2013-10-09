using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ReverseWordsInSentence
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();
        string textResult = "";
        for (int i = text.Length - 1; i >= 0; i--)
        {
            textResult += text[i];
        }
        string[] separator = { " " };
        string[] words = textResult.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        string result = "";
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = words[i].Length - 1; j >= 0; j--)
            {
                result += words[i][j];
            }
            result += " ";
        }
        Console.WriteLine("Result: {0}", result);
    }
}
