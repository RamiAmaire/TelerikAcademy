using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class SBExtensions
{
    public static string Substring(this StringBuilder sb, int index, int length)
    {
        if (index < 0)
        {
            Console.WriteLine("Start index must 0 or greater");
            throw new ArgumentOutOfRangeException("Start index must 0 or greater");
        }
        if (length <= 0)
        {
            Console.WriteLine("Length must be bigger then 0");
            throw new Exception("Length must be bigger then 0");
        }
        string str = sb.ToString();
        string[] separator = new string[] { "\n", "\r" };
        string[] result = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        string res = result[0];
        return res.Substring(index, length);
    }
}
