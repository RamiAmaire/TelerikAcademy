using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DecimalToHex
{
    static void Convert(int number)
    {
        int[] arr = new int[100];
        int index = 0;
        while (number > 0)
        {
            arr[index] = number % 16;
            number = number / 16;
            index++;
        }
        for (int i = index - 1; i >= 0; i--)
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
    static void Main()
    {
        Console.Write("Enter number= ");
        int decNumber = int.Parse(Console.ReadLine());
        Console.Write("Number in hex: ");
        Convert(decNumber);
        Console.WriteLine();
    }
}
