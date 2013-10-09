using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BinaryToDecimal
{
    static void Converter(string s)
    {
        int sum = 0;
        int n = 2;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (i == s.Length - 1)
            {
                sum += Convert.ToChar(s[i] - '0') * 1;
            }
            else
            {
                sum += Convert.ToChar(s[i] - '0') * n;
                n *= 2;
            }
        }
        Console.WriteLine(s + "(bin)" + "= " + sum + "(dec)");
    }
    static void Main()
    {
        Console.Write("Enter binary number= ");
        string s = Console.ReadLine();
        Converter(s);
    }
}
