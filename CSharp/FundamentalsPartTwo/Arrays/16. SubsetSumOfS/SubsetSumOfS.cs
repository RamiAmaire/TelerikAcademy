using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SubsetSumOfS
{
    static void Gen(int[] originalArray, int n, int[] tempArr, int k, int index, int s, int i)
    {
        int sum = 0;
        if (index == k)
        {
            for (int j = 0; j < tempArr.Length; j++)
            {
                sum += tempArr[j];
                if (sum > s)
                {
                    break;
                }
            }
            if (sum == s)
            {
                Print(tempArr, s);
            }
        }
        else
        {
            for (; i < n; i++)
            {
                tempArr[index] = originalArray[i];
                Gen(originalArray, n, tempArr, k, index + 1, s, i + 1);
            }
        }
    }
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ",i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void Print(int[] arr, int s)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (i<arr.Length-1)
            {
                Console.Write(arr[i] + "+");
            }
            else
            {
                Console.Write(arr[i]);
            }
            sum += arr[i];
            if (sum == s)
            {
                break;
            }
        }
        Console.WriteLine("= " + s);
    }
    static void Main()
    {
        Console.Write("Enter N= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter S= ");
        int s = int.Parse(Console.ReadLine());
        int[] originalArray = new int[n];
        Console.WriteLine("Enter elements of array: ");
        ReadArray(originalArray);
        int k = 1;
        int[] tempArr = new int[k];
        int start = 0;
        while (k < n - 1)
        {
            Gen(originalArray, n, tempArr, k, start, s, 0);
            k++;
            tempArr = new int[k];
        }
    }
}
