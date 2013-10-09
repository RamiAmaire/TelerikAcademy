using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PrintingMatrix
{
    static int i = 1;
    static int indexRow = 0;
    static int indexCol = 0;
    static int tempindexRow = 0;
    static int tempindexCol = 0;
    static int br = 0;
    static void GenDown(int[,] arr, int n, int s, int indexRow, int indexCol)
    {
        if (br == n)
        {
            br = 0;
            tempindexRow = indexRow;
            tempindexCol = indexCol;
        }
        else
        {
            arr[indexRow, indexCol] = i;
            i += 1;
            br++;
            GenDown(arr, n, s, indexRow + 1, indexCol);
        }
    }
    static void GenRight(int[,] arr, int n, int s, int indexrow, int indexcol)
    {
        if (br == n)
        {
            br = 0;
            tempindexRow = indexrow;
            tempindexCol = indexcol;
        }
        else
        {
            arr[indexrow, indexcol] = i;
            i += 1;
            br++;
            GenRight(arr, n, s, indexrow, indexcol + 1);
        }

    }
    static void GenUp(int[,] arr, int n, int s, int indexrow, int indexcol)
    {
        if (br == n)
        {
            br = 0;
            tempindexRow = indexrow;
            tempindexCol = indexcol;
        }
        else
        {
            arr[indexrow, indexcol] = i;
            i += 1;
            br++;
            GenUp(arr, n, s, indexrow - 1, indexcol);
        }

    }
    static void GenLeft(int[,] arr, int n, int s, int indexrow, int indexcol)
    {
        if (br == n)
        {
            br = 0;
            indexRow = indexrow + 1;
            indexCol = indexcol + 1;
        }
        else
        {
            arr[indexrow, indexcol] = i;
            i += 1;
            br++;
            GenLeft(arr, n, s, indexrow, indexcol - 1);
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
        int s = n * n;
        int[,] arr = new int[n, n];
        while (n > 0)
        {
            GenDown(arr, n, s, indexRow, indexCol);
            n -= 1;
            if (n == 0)
            {
                break;
            }
            GenRight(arr, n, s, tempindexRow - 1, tempindexCol + 1);
            GenUp(arr, n, s, tempindexRow - 1, tempindexCol - 1);
            n -= 1;
            if (n == 0)
            {
                break;
            }
            GenLeft(arr, n, s, tempindexRow + 1, tempindexCol - 1);
        }
        Print(arr);

    }
}
