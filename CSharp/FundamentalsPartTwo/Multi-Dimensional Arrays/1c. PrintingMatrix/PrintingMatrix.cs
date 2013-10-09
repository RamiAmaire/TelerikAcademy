using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PrintingMatrix
{
    static int n = 4;
    static int i = 0;
    static int k = n - 1;
    static int x = n - 1;
    static int temp = n + 3;
    static int tempOne = n;
    static void GenEvenOne(int[,] arr, int n, int s, int indexRow, int indexCol)
    {
        if (indexRow == 0)
        {
            i = temp;
        }
        if (indexRow == n)
        {
            indexCol += 1;
            temp += tempOne;
            k += 2;
        }
        else
        {
            arr[indexRow, indexCol] = i;
            i -= k;
            k--;
            GenEvenOne(arr, n, s, indexRow + 1, indexCol);
        }
    }
    static void GenEvenTwo(int[,] arr, int n, int s, int indexRow, int indexCol)
    {
        if (indexRow == 0)
        {
            i = temp;
        }
        if (indexRow == n)
        {
            indexCol += 1;
            temp += tempOne;
            k -= 2;
        }
        else
        {
            arr[indexRow, indexCol] = i;
            i -= k;
            k++;
            GenEvenTwo(arr, n, s, indexRow + 1, indexCol);
        }
    }
    static void GenOddOne(int[,] arr, int n, int s, int indexRow, int indexCol)
    {
        if (indexRow == 0)
        {
            i = temp;
        }
        if (indexRow == n)
        {
            temp += tempOne;
        }
        else
        {
            arr[indexRow, indexCol] = i;
            if (indexRow == n - 2)
            {
                x--;
            }
            i -= x;
            GenOddOne(arr, n, s, indexRow + 1, indexCol);
        }

    }
    static void GenOddTwo(int[,] arr, int n, int s, int indexRow, int indexCol)
    {
        if (indexRow == 0)
        {
            i = temp;
        }
        if (indexRow == n)
        {
            temp += tempOne;
        }
        else
        {
            arr[indexRow, indexCol] = i;
            if (indexRow == 1)
            {
                x++;
            }
            i -= x;
            GenOddTwo(arr, n, s, indexRow + 1, indexCol);
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
        // n trqbva da se vuvede ru4no ot nai gore :D
        int s = n * n;
        int[,] arr = new int[n, n];
        int indexRow = 0;
        int indexCol = 0;
        int tempThree = n;
        int br = 0;
        while (tempThree > 0)
        {
            GenEvenOne(arr, n, s, indexRow, indexCol + br);
            tempOne--;
            tempThree--;
            br++;
            if (tempThree == 0)
            {
                break;
            }
            GenOddOne(arr, n, s, indexRow, indexCol + br);
            tempOne--;
            tempThree--;
            br++;
            if (tempThree == 0)
            {
                break;
            }
            GenOddTwo(arr, n, s, indexRow, indexCol + br);
            tempOne--;
            tempThree--;
            br++;
            if (tempThree == 0)
            {
                break;
            }
            GenEvenTwo(arr, n, s, indexRow, indexCol + br);
            tempOne--;
            tempThree--;
            br++;
        }
        Print(arr);
    }
}
