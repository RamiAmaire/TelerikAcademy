using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ExtractPalindromes
{
    static void Main()
    {
        Console.Write("Enter text : ");
        string text = Console.ReadLine();
        text = text.ToLower();
        string[] separator = { " ", ",", ".", "\n", ":", "-" };
        string[] result = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < result.Length; i++)
        {
            int index = result[i].Length - 1;
            int count = 0;
            Console.WriteLine("Palindromes (in lowercase): ");
            for (int j = 0; j < result[i].Length; j++)
            {
                if (result[i][j] == result[i][index])
                {
                    count++;
                    if (count == result[i].Length)
                    {
                        Console.WriteLine(result[i]);
                    }
                }
                else
                {
                    count = 0;
                }
                index--;
            }
        }
    }
}
