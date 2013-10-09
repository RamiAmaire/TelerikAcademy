using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class ReplacingStartAndFinish
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"D:\newfile.txt");
            string[] result;
            using (reader)
            {
                string line = reader.ReadLine();
                string temp = "";
                while (line != null)
                {
                    temp += " " + line;
                    line = reader.ReadLine();
                }
                string[] separator = { " ", ",", ".", "\n", "!", "?", "@" };
                result = temp.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == "start")
                    {
                        result[i] = "finish";
                    }
                }
            }
            StreamWriter writer = new StreamWriter(File.Open(@"D:\newfile.txt", FileMode.Create));
            using (writer)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    writer.WriteLine(result[i]);
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
