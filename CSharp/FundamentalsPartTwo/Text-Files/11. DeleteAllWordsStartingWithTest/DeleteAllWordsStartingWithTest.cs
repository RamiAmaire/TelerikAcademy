using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

class DeleteAllWordsStartingWithTest
{
    static void Main()
    {
        try
        {
            string format = @"^test[A-Za-z0-9]*";
            string result = "";
            StreamReader reader = new StreamReader(@"D:\newfile.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    result += line;
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                }
            }
            string[] separator = { " ", ",", ".", "\n", "?", "!", "@" };
            string[] resultArr = result.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < resultArr.Length; i++)
            {
                resultArr[i] = Regex.Replace(resultArr[i], format, "");
            }
            for (int i = 0; i < resultArr.Length; i++)
            {
                if (resultArr[i] != "")
                {
                    Console.WriteLine(resultArr[i]);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }     
    }
}
