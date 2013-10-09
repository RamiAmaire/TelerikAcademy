using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class QuickSort
{
    public static void Quicksort(IComparable[] elements, int left, int right)
    {
        int leftIndex = left, rightIndex = right;
        IComparable pivot = elements[(left + right) / 2];

        while (leftIndex <= rightIndex)
        {
            while (elements[leftIndex].CompareTo(pivot) < 0)
            {
                leftIndex++;
            }
            while (elements[rightIndex].CompareTo(pivot) > 0)
            {
                rightIndex--;
            }
            if (leftIndex <= rightIndex)
            {
                IComparable temp = elements[leftIndex];
                elements[leftIndex] = elements[rightIndex];
                elements[rightIndex] = temp;
                leftIndex++;
                rightIndex--;
            }
        }
        if (left < rightIndex)
        {
            Quicksort(elements, left, rightIndex);
        }

        if (leftIndex < right)
        {
            Quicksort(elements, leftIndex, right);
        }
    }
    static void PrintArray(string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(" " + arr[i]);
        }
        Console.WriteLine();
    }
    static void Main()
    {
        string[] arr = { "z","e","x","c","m","q","a"};
        Console.Write("Array unsorted: ");
        PrintArray(arr);
        Quicksort(arr, 0, arr.Length - 1);
        Console.Write("Array sorted: ");
        PrintArray(arr);
    }
 
}
