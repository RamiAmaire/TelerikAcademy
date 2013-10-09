using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MaxSumOfRecMatrix
{
    static int bestRow = 0;
    static int bestCol = 0;
    static void ReadMatrix(int n, int m, int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = new int[m];
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i][j] = int.Parse(Console.ReadLine());
            }
        }
    }
    static void PrintMatrix(int n, int m, int[][] matrix)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(" " + matrix[i][j]);
            }
            Console.WriteLine();
        }
    }
    static void Sum(int n, int m, int[][] matrix)
    {
        int sum;
        int bestSum = 0;

        for (int row = 0; row < n - 2; row++)
        {
            sum = 0;
            for (int col = 0; col < m - 2; col++)
            {
                sum = matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] + matrix[row + 1][col] + matrix[row + 1][col + 1]
                    + matrix[row + 1][col + 2] + matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }
        for (int row = bestRow; row <= bestRow + 2; row++)
        {
            for (int col = bestCol; col <= bestCol + 2; col++)
            {
                Console.Write(" " + matrix[row][col]);
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        Console.Write("First side= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Second side= ");
        int m = int.Parse(Console.ReadLine());
        if (n > m)
        {
            Console.WriteLine("Error, second side must always be bigger !");
            return;
        }
        int[][] matrix = new int[n][];
        ReadMatrix(n, m, matrix);
        Console.WriteLine("Enter elements of matrix: ");
        PrintMatrix(n, m, matrix);
        Sum(n, m, matrix);
    }
}
