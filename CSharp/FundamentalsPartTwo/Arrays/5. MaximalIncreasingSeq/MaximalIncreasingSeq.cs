using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MaximalIncreasingSeq
{
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void FindingBestLength(int[] arr)
    {
        int len = 0;
        int bestLen = 0;
        int bestStart = 0; ;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] < arr[i + 1])
            {
                len++;
                if (len > bestLen)
                {
                    bestLen = len;
                    bestStart = i - bestLen + 1;
                }
            }
            else
            {
                len = 0;
            }
        }
        bestLen += 1;
        Console.Write("Result -> {");
        for (int i = bestStart; i <= bestLen; i++)
        {
            if (i<bestLen)
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
        Console.Write("Enter length of Array: ");
        int len = int.Parse(Console.ReadLine());
        int[] array = new int[len];
        ReadArray(array);
        FindingBestLength(array);
    }
}
