using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class KElementsOfMaximalSum
{
    static void ReadArr(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void FindMaxSum(int k, int[] arr)
    {
        int sum;
        int bestSum = 0;
        int bestStart = 0;
        for (int i = 0; i < arr.Length - k + 1; i++)
        {
            sum = 0;
            for (int j = i; j < k + i; j++)
            {
                sum += arr[j];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestStart = i;
                }
            }
        }
        Console.Write("Result -> {");
        for (int i = bestStart; i < bestStart + k; i++)
        {
            if (i < bestStart + k - 1)
            {
                Console.Write(arr[i] + ",");
            }
            else
            {
                Console.Write(arr[i]);
            }
        }
        Console.WriteLine("}");
    }
    static void Main()
    {
        Console.Write("Enter N= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K= ");
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        ReadArr(arr);
        FindMaxSum(k, arr);
    }
}
