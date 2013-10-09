using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class CalcSum
{
    static void Main()
    {
        string str = "43 68 9 23 318";
        string[] values = new string[20];
        int sum = 0;
        for (int i = 0; i < str.Length; i++)
        {
            values = str.Split(' ');
        }
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] != "")
            {
                sum += Convert.ToInt32(values[i]);
            }
        }
        Console.WriteLine("Sum -> " + sum);
    }
}
