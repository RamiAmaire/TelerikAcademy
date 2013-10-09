using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PrintingMatrix
{
    static int i = 1;
    static int tempindexRow = 0;
    static int tempindexCol = 0;
    static void GenOdd(int[,] arr, int n, int s, int indexRow, int indexCol)
    {
        if (indexRow==n)
        {
            tempindexCol = indexCol += 1;
            i += 3;
            tempindexRow = indexRow = 0;
        }
        else
        {
            arr[indexRow, indexCol] = i;
            i += 1;
            GenOdd(arr, n, s, indexRow + 1, indexCol);
        } 
    }
    static void GenEven(int[,] arr, int n, int s, int indexRow, int indexCol)
    {
        if (indexRow == n)
        {
            tempindexCol = indexCol += 1;
            i += 5;
            tempindexRow = indexRow = 0;
        }
        else
        {
            arr[indexRow, indexCol] = i;
            i -= 1;
            GenEven(arr, n, s, indexRow + 1, indexCol);
        }
    }
    static void Print(int[,] arr)
    {
        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                Console.Write(" " + arr[row, col]);
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        Console.Write("Enter N= ");
        int n = int.Parse(Console.ReadLine());
        int s=n*n;
        int[,]arr=new int[n,n];
        int k = n;
        while (k>0)
        {
            if (tempindexCol % 2 == 0)
            {
                GenOdd(arr, n, s, tempindexRow, tempindexCol);
                k--;
                if (k==0)
                {
                    break;
                }
            }
            if (tempindexCol % 2 == 1)
            {
                GenEven(arr, n, s, tempindexRow, tempindexCol);
                k--;
                if (k == 0)
                {
                    break;
                }
            }
        }
        Print(arr);
    }
}
