using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class DeletingAllOddFiles
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"D:\newfile.txt");
            string result = "";
            string[] resultArr;
            using (reader)
            {
                string line = reader.ReadLine();
                int lineNumber = 0;
                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 == 0)
                    {
                        result += line + "\n";
                    }
                    line = reader.ReadLine();
                }
                string[] separator = { " ", ".", ",", "!", "\n", "?", "@" };
                resultArr = result.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            }
            StreamWriter writer = new StreamWriter(File.Open(@"D:\newfile.txt", FileMode.Create));
            using (writer)
            {
                for (int i = 0; i < resultArr.Length; i++)
                {
                    writer.WriteLine(resultArr[i]);
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
