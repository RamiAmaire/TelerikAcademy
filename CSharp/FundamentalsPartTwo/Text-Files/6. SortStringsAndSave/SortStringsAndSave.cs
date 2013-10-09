using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class SortStringsAndSave
{
    static void Main()
    {
        try
        {
            List<string> names = new List<string>();
            StreamReader reader = new StreamReader(@"D:\newfile.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    names.Add(line);
                    line = reader.ReadLine();
                }
            }
            names.Sort();
            StreamWriter writer = new StreamWriter(File.Open(@"D:\Names.txt", FileMode.Create));
            using (writer)
            {
                int i = 0;
                while (i < names.Count)
                {
                    writer.WriteLine("{0}.{1}", i + 1, names[i]);
                    i++;
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
