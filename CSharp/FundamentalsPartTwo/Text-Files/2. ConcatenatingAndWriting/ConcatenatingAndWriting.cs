using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class ConcatenatingAndWriting
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"D:\Telerik\Stuff\Stuff.txt");
            StreamWriter writer = new StreamWriter(File.Open(@"D:\newfile.txt", FileMode.Create));
            using (reader)
            {
                using (writer)
                {
                    writer.Write(reader.ReadToEnd());
                }
            }
            StreamReader newReader = new StreamReader(@"D:\Telerik\Stuff\Rami's Dictionary.txt");
            StreamWriter newWriter = new StreamWriter(File.Open(@"D:\newfile.txt", FileMode.Append));
            using (newReader)
            {
                using (newWriter)
                {
                    newWriter.Write(newReader.ReadToEnd());
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
