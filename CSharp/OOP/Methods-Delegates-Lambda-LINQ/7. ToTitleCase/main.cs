using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class main
{
    static void Main()
    {
        string paragraph = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas egestas venenatis rhoncus.";
        paragraph = paragraph.ToTitleCase();
        Console.WriteLine(paragraph);
    }
}
