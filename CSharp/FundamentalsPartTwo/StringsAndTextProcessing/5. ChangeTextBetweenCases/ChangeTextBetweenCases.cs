using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ChangeTextBetweenCases
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string str = Console.ReadLine();
        int indexStart = str.IndexOf("<upcase>");
        int indexEnd = str.IndexOf("</upcase>");
        int temp = indexEnd - indexStart - 8;
        while (indexStart != -1)
        {
            string substring = str.Substring(indexStart + 8, temp);
            str = str.Replace(substring, substring.ToUpper());
            str = str.Remove(indexStart, 8);
            str = str.Remove(indexEnd - 8, 9);
            indexStart = str.IndexOf("<upcase>", indexStart + 1);
            if (indexStart == -1)
            {
                break;
            }
            indexEnd = str.IndexOf("</upcase>", indexEnd + 1);
            temp = indexEnd - indexStart - 8;
        }
        Console.WriteLine(str);
    }
}
