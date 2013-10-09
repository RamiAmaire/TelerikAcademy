using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SubsetSumOfKElements
{
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void Main()
    {
        Console.Write("Enter N= ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K= ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Enter S= ");
        int s = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        ReadArray(arr);
        int checkedNumbers = 0;
        List<int> subsetNumbers = new List<int>();
        int maxi = (int)Math.Pow(2, arr.Length) - 1;
        bool hasSubsetSum = false;
        for (int i = 1; i <= maxi; i++)
        {
            long currentSum = 0;
            for (int j = 1; j <= arr.Length; j++)
            {
                if (((i >> (j - 1)) & 1) == 1)
                {
                    currentSum += arr[j - 1];
                    checkedNumbers++;
                    subsetNumbers.Add(arr[j - 1]);
                }
            }
            if (checkedNumbers == k && currentSum == s)
            {
                hasSubsetSum = true;
                break;
            }
            else
            {
                checkedNumbers = 0;
                subsetNumbers.Clear();
            }
        }
        if (hasSubsetSum)
        {
            Console.Write("Result: {");
            for (int i = 0; i < subsetNumbers.Count; i++)
            {
                if (i<subsetNumbers.Count-1)
                {
                    Console.Write(subsetNumbers[i] + ",");
                }
                else
                {
                    Console.Write(subsetNumbers[i]);
                }
            }
            Console.WriteLine("}");
        }
        else
        {
            Console.Write("Result: ");
            Console.Write("Subset doesn't exist");
            Console.WriteLine();
        }
    }
}
