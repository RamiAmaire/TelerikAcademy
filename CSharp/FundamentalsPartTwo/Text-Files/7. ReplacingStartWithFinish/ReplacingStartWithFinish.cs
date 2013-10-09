using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class ReplacingStartWithFinish
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"D:\newfile.txt");
            string result = "";
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    result += " " + line;
                    line = reader.ReadLine();
                }
                result = result.Replace("start", "finish");
            }
            StreamWriter writer = new StreamWriter(File.Open(@"D:\newfile.txt", FileMode.Create));
            using (writer)
            {
                writer.WriteLine(result);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
