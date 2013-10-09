using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class StringInUnicode
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();
        string[] s = { " " };
        string[] temp = text.Split(s, StringSplitOptions.RemoveEmptyEntries);
        string unicodeFormat = "u{0:x4}";
        string tempOne = "";
        for (int i = 0; i < temp.Length; i++)
        {
            tempOne = temp[i];
        }
        List<string> result = new List<string>();
        for (int i = 0; i < tempOne.Length; i++)
        {
            int a = Convert.ToInt32(tempOne[i]);
            result.Add(string.Format(unicodeFormat, a));
        }
        Console.Write("In Unicode: ");
        for (int i = 0; i < result.Count; i++)
        {
            if (i < result.Count - 1)
            {
                Console.Write(result[i] + "\\");
            }
            else
            {
                Console.Write(result[i]);
            }
        }
        Console.WriteLine();
    }
}
