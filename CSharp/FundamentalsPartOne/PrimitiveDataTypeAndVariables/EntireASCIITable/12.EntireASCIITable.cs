using System;
class EntireASCIITable
{
    static void Main()
    {
        int i;
        for (i = 0; i <= 255; i++)
        {
            Console.WriteLine(i + "." + (char)i);
        }
    }
}
