using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class HTMLReplace
{
    static void Main()
    {
        //Console.Write("Enter text: ");
        //string text = Console.ReadLine();
        string text = "<p>Please visit <a href=http://academy.telerik.com>our site</a> to choose a training course. Also visit <a href=www.devbg.org>our forum</a> to discuss the courses.</p>";
        int index = text.IndexOf("<a");
        int lastindex = text.IndexOf("</p>");
        string substring = text.Substring(index, 147);
        substring = substring.Replace("<a href", "[URL");
        substring = substring.Replace("</a>", "[/URL]");
        substring = substring.Replace(">", "] ");
        text = text.Remove(16, 151);
        text = text.Insert(16, substring) + "</p>";
        Console.WriteLine("Result: ");
        Console.WriteLine(text);
    }
}
