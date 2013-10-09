using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DecimalToBinary
{
    static void Converter(int num)
    {
        string[] arr = new string[10000];
        int temp;
        int k = -1;
        while (num > 0)
        {
            k++;
            temp = num % 2;
            arr[k] = Convert.ToString(temp);
            num /= 2;
        }
        while (k >= 0)
        {
            Console.Write(arr[k]);
            k--;
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Console.Write("Enter number= ");
        int n = int.Parse(Console.ReadLine());
        Converter(n);
    }
}
