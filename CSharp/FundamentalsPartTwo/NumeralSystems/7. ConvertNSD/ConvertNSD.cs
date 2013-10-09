using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ConvertNSD
{
    static int ToDecimal(string number, int s)
    {
        int sum = 0;
        int k = 0;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            sum += (number[i] - '0') * (int)Math.Pow(s, k);
            k++;
        }
        return sum;
    }
    static int ToSecond(int dec, int d)
    {
        int sum = 0;
        while (dec > 0)
        {
            sum += dec % d;
            dec /= d;
        }
        return sum;
    }
    static void Main()
    {
        Console.Write("Enter number= ");
        string n = Console.ReadLine();
        Console.Write("Enter s= ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Enter d= ");
        int d = int.Parse(Console.ReadLine());
        int dec = 0;
        ToDecimal(n, s);
        dec = ToDecimal(n, s);
        int result = ToSecond(dec, d);
        Console.WriteLine(n + "({0})" + "= " + result + "({1})", s, d);
    }
}
