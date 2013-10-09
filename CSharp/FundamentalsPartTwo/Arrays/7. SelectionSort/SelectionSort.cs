using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SelectionSort
{
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void PrintArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(" " + arr[i]);
        }
        Console.WriteLine();
    }
    static void Sort(int[] arr)
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
    }
    static void Main()
    {
        Console.Write("Enter length of array= ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Console.WriteLine("Enter elements of array: ");
        ReadArray(array);
        Console.Write("Array -> ");
        PrintArray(array);
        Console.Write("Array sorted -> ");
        Sort(array);
        PrintArray(array);
    }
}
