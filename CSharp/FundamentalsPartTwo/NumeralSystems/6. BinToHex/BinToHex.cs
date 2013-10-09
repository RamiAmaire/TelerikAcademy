using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BinToHex
{
    static void Gen(int number)
    {
        int[] arr = new int[100];
        int k = 0;
        while (number > 0)
        {
            arr[k] = number % 16;
            number = number / 16;
            k++;
        }
        for (int i = k - 1; i >= 0; i--)
        {
            if ((arr[i] > 9) && (arr[i] < 16))
            {
                if (arr[i] == 10)
                {
                    Console.Write('A');
                }
                if (arr[i] == 11)
                {
                    Console.Write('B');
                }
                if (arr[i] == 12)
                {
                    Console.Write('C');
                }
                if (arr[i] == 13)
                {
                    Console.Write('D');
                }
                if (arr[i] == 14)
                {
                    Console.Write('E');
                }
                if (arr[i] == 15)
                {
                    Console.Write('F');
                }
            }
            else
            {
                Console.Write(arr[i]);
            }
        }
    }
    static int Converter(string s)
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
        return sum;
    }
    static void Main()
    {
        Console.Write("Enter binary number= ");
        string number = Console.ReadLine();
        Converter(number);
        Gen(Converter(number));
    }
}