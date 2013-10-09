using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SieveOfEratosthenes
{
    static void Main()
    {
        int[] arr = new int[5000001];
        arr[0] = 0;
        for (int i = 1, j = 1; i < 5000001; i++, j += 2)
        {
            arr[i] = j;
        }
        Console.Write(arr[1] + " ");
        for (int i = 2; i <= 1582; i++)                         
        {
            if (arr[i] != 0)                                              
            {
                for (int j = i + 1; j < 5000001; j++)
                {
                    if (arr[j] % arr[i] == 0)
                    {
                        arr[j] = 0;
                    }
                }
                Console.Write(arr[i] + " ");
            }
        }
        for (int i = 1582; i < 5000001; i++)
        {
            if (arr[i] != 0)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
