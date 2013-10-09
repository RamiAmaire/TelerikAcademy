using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class XMLFiles
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
                    result += line + "\n";
                    line = reader.ReadLine();
                }
            }
            StringBuilder builder = new StringBuilder();
            int counter = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] == '<')
                {
                    counter++;
                }
                if (counter == 0)
                {
                    builder.Append(result[i]);
                }
                if (result[i] == '>')
                {
                    counter--;
                }
            }
            Console.WriteLine(builder);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
