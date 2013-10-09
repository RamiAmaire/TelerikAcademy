using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LargestAreaOfEqualMembers
{
    static int maxLen = 0;
    static int bestTemp = 0;
    static int len = 0;
    static void Read(int[][] arr, int row, int col)
    {
        for (int i = 0; i < col; i++)
        {
            arr[row] = new int[col];
        }
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                arr[i][j] = int.Parse(Console.ReadLine());
            }
        }
    }
    static void Gen(int[][] arr, int row, int col)
    {
        int temp = arr[row][col];
        if (row < arr.Length - 1)
        {
            if ((arr[row][col] == arr[row + 1][col]) && (arr[row + 1][col] != -1))
            {
                len++;
                arr[row][col] = -1;
                Gen(arr, row + 1, col);
                arr[row][col] = temp;
            }
        }
        if (row > 0)
        {
            if (arr[row][col] == arr[row - 1][col] && (arr[row - 1][col] != -1))
            {
                len++;
                arr[row][col] = -1;
                Gen(arr, row - 1, col);
                arr[row][col] = temp;
            }
        }
        if (col < arr[row].Length - 1)
        {
            if (arr[row][col] == arr[row][col + 1] && (arr[row][col + 1] != -1))
            {
                len++;
                arr[row][col] = -1;
                Gen(arr, row, col + 1);
                arr[row][col] = temp;
            }
        }
        if (col > 0)
        {
            if (arr[row][col] == arr[row][col - 1] && (arr[row][col - 1] != -1))
            {
                len++;
                arr[row][col] = -1;
                Gen(arr, row, col - 1);
                arr[row][col] = temp;
            }
        }
        if (maxLen < len)
        {
            maxLen = len + 1;
            bestTemp = temp;
        }
    }
    static void Main()
    {
        //Console.Write("Enter N= ");
        //int n = int.Parse(Console.ReadLine());
        //Console.Write("Enter M= ");
        //int m = int.Parse(Console.ReadLine());
        int[][] myJaggedArray = 
        {
            new int[] {1, 3, 2, 2, 2, 4},
            new int[] {3, 3, 3, 2, 4, 4},
            new int[] {4, 3, 1, 2, 3, 3},
            new int[] {4, 3, 1, 3, 3, 1},
            new int[] {4, 3, 3, 3, 1, 1}
        };
        for (int i = 0; i < myJaggedArray.Length; i++)
        {
            for (int j = 0; j < myJaggedArray[i].Length; j++)
            {
                len = 0;
                Gen(myJaggedArray, i, j);
            }
        }
        Console.WriteLine("Number= " + bestTemp);
        Console.WriteLine("Length= " + maxLen);
    }
}
