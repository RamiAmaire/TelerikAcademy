using System;
using System.Collections.Generic;

public class CountHowManyTimesANumberIsContained
{
    private static int[] FillArrayWithZeros(int length)
    {
        int[] arr = new int[length];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = 0;
        }

        return arr;
    }

    private static void SetNumbersCount(int[] numbers, int[] arr)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            arr[numbers[i]]++;
        }
    }

    private static void PrintNumbersCount(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                Console.WriteLine("{0} -> {1}", i, arr[i]);
            }
        }
    }

    public static void Main()
    {
        int[] numbers = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
        int[] arr = FillArrayWithZeros(1001);

        SetNumbersCount(numbers, arr);
        PrintNumbersCount(arr);
    }
}
