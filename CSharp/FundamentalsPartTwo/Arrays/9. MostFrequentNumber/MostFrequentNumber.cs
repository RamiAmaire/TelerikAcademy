using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class MostFrequentNumber
{
    static int bestLength = 0;
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ",i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void SortArray(int[] arr)
    {
        int min;
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
    static int FindingNumber(int[] arr)
    {
        int counter = 0;
        int number = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] == arr[i + 1])
            {
                counter++;
                if (counter > bestLength)
                {
                    bestLength = counter;
                    number = arr[i];
                }
            }
            else
            {
                counter = 0;
            }
        }
        return number;
    }
    static void Main()
    {
        Console.Write("Enter length of array: ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        ReadArray(array);
        SortArray(array);
        Console.WriteLine("Result: ");
        Console.WriteLine(FindingNumber(array) + " " + "({0} times)",bestLength+1);
    }
}
