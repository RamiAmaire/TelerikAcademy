using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ReplaceIdenticalLettersWithOnlyOne
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();
        StringBuilder bodyBuilder = new StringBuilder();
        bodyBuilder.Append(text[0]);
        for (int i = 0; i < text.Length - 1; i++)
        {
            if (text[i] != text[i + 1])
            {
                bodyBuilder.Append(text[i + 1]);
            }
        }
        Console.WriteLine("Result -> {0}", bodyBuilder);
    }
}
