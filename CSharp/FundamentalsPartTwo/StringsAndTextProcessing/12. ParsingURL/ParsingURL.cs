using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ParsingURL
{
    static void Main()
    {
        Console.Write("Enter URL : ");
        string text = Console.ReadLine();
        string[] separator = { ":", "//" };
        string[] result = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        if (result.Length == 1)
        {
            if (result[0].Contains("/"))
            {
                string rest = result[0];
                int index = rest.IndexOf("/");
                string server = rest.Substring(0, index);
                string resources = rest.Substring(index, rest.Length - index);
                Console.WriteLine("Server - {0}", server);
                Console.WriteLine("Resources - {0}", resources);
            }
            else
            {
                string server = result[0];
                Console.WriteLine("Server - {0}", server);
            }
        }
        else
        {
            string protocol = result[0];
            string rest = result[1];
            int index = rest.IndexOf("/");
            if (index == -1)
            {
                string server = rest.Substring(0, rest.Length);
                Console.WriteLine("Protocol - {0}", protocol);
                Console.WriteLine("Server - {0}", server);
            }
            else
            {
                string server = rest.Substring(0, index);
                string resources = rest.Substring(index, rest.Length - index);
                Console.WriteLine("Protocol - {0}", protocol);
                Console.WriteLine("Server - {0}", server);
                Console.WriteLine("Resources - {0}", resources);
            }
        }
    }
}
