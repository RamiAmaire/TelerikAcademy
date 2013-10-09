using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void BiggestNumber(int[] arr, int index)
    {
        int max = 0;
        max = arr[index];
        for (int i = index + 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        Console.WriteLine(max);
    }
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void Sort(int[] arr,int index)
    {
        int min = 0;
        for (int i = index; i < arr.Length - 1; i++)
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
        for (int i = index; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
    static void Main()
    {
        Console.Write("Enter length of array= ");
        int len = int.Parse(Console.ReadLine());
        int[] arr = new int[len];
        Console.WriteLine("Enter elements of array: ");
        ReadArray(arr);
        Console.Write("Enter index= ");
        int index = int.Parse(Console.ReadLine());
        if (index < 0)
        {
            Console.WriteLine("Error !");
            return;
        }
        Console.Write("Array sorted startin from index {0}: ",index);
        Sort(arr, index);
        Console.WriteLine();
        Console.Write("Biggest number = ");
        BiggestNumber(arr, index);
    }
}
