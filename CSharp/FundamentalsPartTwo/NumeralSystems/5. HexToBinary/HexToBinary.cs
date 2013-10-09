using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class HexToBinary
{
    static void Main()
    {
        Console.Write("Enter number= ");
        string number = Console.ReadLine();
        int temp = 0;
        int sum = 0;
        int sqr = 0;
        string result = "";
        for (int i = number.Length - 1; i >= 0; i--)
        {
            if ((number[i] >= 'A') && (number[i] <= 'F'))
            {
                if (number[i] == 'A')
                {
                    temp = 10;
                }
                if (number[i] == 'B')
                {
                    temp = 11;
                }
                if (number[i] == 'C')
                {
                    temp = 12;
                }
                if (number[i] == 'D')
                {
                    temp = 13;
                }
                if (number[i] == 'E')
                {
                    temp = 14;
                }
                if (number[i] == 'F')
                {
                    temp = 15;
                }
            }
            else
            {
                temp = Convert.ToInt32(number[i] - '0');
            }
            sum += temp * (int)Math.Pow(16, sqr);
            sqr++;
        }
        result += Convert.ToString(sum, 2);
        Console.WriteLine(result);
    }
}

