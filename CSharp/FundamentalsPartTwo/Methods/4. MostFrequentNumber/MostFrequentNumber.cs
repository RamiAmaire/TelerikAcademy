using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MostFrequentNumber
{
    static int[] SortArray(int[] arr)
    {
        int min = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            min = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }
            int temp = arr[i];
            arr[i] = arr[min];
            arr[min] = temp;
        }
        return arr;
    }
    static int MostFrequentNum(int[] arr, int number)
    {
        int times = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == number)
            {
                times++;
            }
        }
        return times;
    }
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void Main()
    {
        Console.Write("Enter number= ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Enter length of array: ");
        int len = int.Parse(Console.ReadLine());
        int[] arr = new int[len];
        Console.WriteLine("Enter elements of array: ");
        ReadArray(arr);
        SortArray(arr);
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(" " + arr[i]);
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', 40));
        MostFrequentNum(arr, number);
        if (MostFrequentNum(arr, number) == 1)
        {
            Console.WriteLine("Number ({1}) is in the array ({0}) time", MostFrequentNum(arr, number), number);
        }
        else
        {
            Console.WriteLine("Number ({1}) is in the array ({0}) times", MostFrequentNum(arr, number), number);
        }
    }
}
