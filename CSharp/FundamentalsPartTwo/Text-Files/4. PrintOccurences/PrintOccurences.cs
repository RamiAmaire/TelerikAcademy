using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class PrintOccurences
{
    static void Main()
    {
        try
        {
            StreamReader readerOne = new StreamReader(@"D:\text.txt");
            StreamReader readerTwo = new StreamReader(@"D:\words.txt");
            using (readerOne)
            {
                using (readerTwo)
                {
                    string lineOne = readerOne.ReadLine();
                    string lineTwo = readerTwo.ReadLine();
                    Console.WriteLine("Same lines: ");
                    while ((lineOne != null) && (lineTwo != null))
                    {
                        if (lineOne == lineTwo)
                        {
                            Console.WriteLine(lineOne);
                        }
                        lineOne = readerOne.ReadLine();
                        lineTwo = readerTwo.ReadLine();
                        if (((lineOne == null) && (lineTwo != null)) || ((lineTwo == null) && (lineOne != null)))
                        {
                            Console.WriteLine(new string('-',40));
                            Console.WriteLine("Files don't have same number of lines");
                            return;
                        }
                    }
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
