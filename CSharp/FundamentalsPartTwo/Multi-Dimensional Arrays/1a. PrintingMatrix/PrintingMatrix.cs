using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PrintingMatrix
{
    static void PrintMatrices(int[][] arr)
    {
        for (int i = 1; i <= arr.Length; i++)
        {
            for (int j = i; j <= i + 12; j = j + 4)
            {
                Console.Write(" " + j);
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        Console.Write("Enter N= ");
        int n = int.Parse(Console.ReadLine());
        int[][] array = new int[n][];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = new int[n];
        }
        PrintMatrices(array);
    }
}
