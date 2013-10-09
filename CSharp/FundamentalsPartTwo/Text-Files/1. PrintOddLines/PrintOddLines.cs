using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"D:\Telerik\Stuff\Stuff.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                int lineNumber = 0;
                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine("{0,3} {1}", lineNumber, line);
                    }
                    line = reader.ReadLine();
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
