using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ExtractHTMLTitleBody
{
    static void Main()
    {
        Console.WriteLine("Enter text: ");
        StringBuilder sb = new StringBuilder();
        while (true)
        {
            char ch = Convert.ToChar(Console.Read());
            sb.Append(ch);
            if (ch == '\n')
            {
                break;
            }
        }
        string text=sb.ToString();
        StringBuilder builder = new StringBuilder();
        int count = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (i == text.IndexOf("</body>"))
            {
                Console.WriteLine("Body : {0}", builder);
            }
            if (i == text.IndexOf("</title>"))
            {
                Console.WriteLine("Title : {0}", builder);
                int len = builder.Length;
                builder = builder.Remove(0, len);
            }
            if (text[i] == '<')
            {
                count++;
            }
            if (count == 0)
            {
                builder.Append(text[i]);
            }
            if (text[i] == '>')
            {
                count--;
            }
        }
    }
}
