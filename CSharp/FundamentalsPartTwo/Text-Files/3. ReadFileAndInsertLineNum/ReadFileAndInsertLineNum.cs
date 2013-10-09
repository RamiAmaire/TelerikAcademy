using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class ReadFileAndInsertLineNum
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"D:\newfile.txt");
            List<string> newText = new List<string>();
            using (reader)
            {
                string line = reader.ReadLine();
                int lineNumber = 0;
                while (line != null)
                {
                    lineNumber++;
                    newText.Add(lineNumber.ToString() + ". " + line);
                    line = reader.ReadLine();
                }
            }
            StreamWriter writer = new StreamWriter(File.Open(@"D:\ResultIs.txt",FileMode.Create));
            using (writer)
            {
                for (int i = 0; i < newText.Count; i++)
                {
                    writer.WriteLine(newText[i]);
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
