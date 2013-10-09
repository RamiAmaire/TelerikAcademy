using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SequenceOfSumS
{
    static int s = int.Parse(Console.ReadLine());
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ",i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void FindingSum(int[] arr)
    {
        int sum;
        int start = 0;
        int length = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            sum = arr[i];
            for (int j = i + 1; j < arr.Length; j++)
            {
                sum += arr[j];
                if (sum == s)
                {
                    start = i;
                    length = j - i;
                    length += start;
                    Console.Write("S -> {0}", s + " " + "{");
                    for (int x = start; x <= length; x++)
                    {
                        if (x < length)
                        {
                            Console.Write(arr[x] + ",");
                        }
                        else
                        {
                            Console.Write(arr[x]);
                        }

                    }
                    Console.WriteLine("}");
                    return;
                }
            }
        }
    }
    static void Main()
    {
        Console.Write("Enter length of array: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Console.WriteLine("Enter elements of array: ");
        ReadArray(array);
        FindingSum(array);
    }
}
