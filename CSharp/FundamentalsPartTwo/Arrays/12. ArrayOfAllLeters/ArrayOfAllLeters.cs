using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ArrayOfAllLeters
{
    static void Main()
    {
        string[] letters = new string[32];
        int index = -1;
        for (char i = 'A'; i <= 'Z'; i++)
        {
            index++;
            letters[index] = Convert.ToString(i);
        }
        Console.Write("Enter word: ");
        string word = Console.ReadLine();
        word = word.ToUpper();
        char suffix;
        int secondIndex;
        for (int i = 0; i < word.Length; i++)
        {
            suffix = word[i];
            for (secondIndex = 0; secondIndex <= index; secondIndex++)
            {
                if (suffix == Convert.ToChar(letters[secondIndex]))
                {
                    Console.Write(suffix);
                    break;
                }
            }
            Console.WriteLine(" - " + secondIndex);
        }
    }
}
