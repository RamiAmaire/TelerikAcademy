using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Variations
{
    static void Gen(int start, int[] arr, int n, int k)
    {
        if (start == k)
        {
            Print(arr);
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                arr[start] = i;
                Gen(start + 1, arr, n, k);
            }
        }
    }
    static void Print(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Console.Write("Enter N= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K= ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[k];
        int start = 0;
        Gen(start, arr, n, k);
    }
}
