using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SeqOfMaximalSum
{
    static void ReadArr(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ",i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void FindMaxSum(int[] arr)
    {
        int sum;
        int bestSum = 0;
        int bestStart = 0;
        int counter = 0;
        int bestLen = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            sum = arr[i];
            counter = 0;
            for (int j = i + 1; j < arr.Length; j++)
            {
                sum += arr[j];
                counter++;
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestStart = i;
                    bestLen = counter;
                }
            }
        }
        Console.Write("Result -> {");
        for (int i = bestStart; i <= bestStart + bestLen; i++)
        {
            if (i < bestStart + bestLen)
            {
                Console.Write(arr[i]+",");
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
        Console.Write("Enter length of array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter elements of array: ");
        ReadArr(arr);
        FindMaxSum(arr);
    }
}
