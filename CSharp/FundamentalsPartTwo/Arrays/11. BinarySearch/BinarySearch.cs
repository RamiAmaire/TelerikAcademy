using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BinarySearch
{
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void BinSearch(int[] arr)
    {
        Console.Write("Enter number wanted to be found: ");
        int number = int.Parse(Console.ReadLine());
        int index = -1; 
        int firstElement = 0; 
        int lastElement = arr.Length - 1; 
        int mid = 0;
        int current;
        int counter = 0;
        while (firstElement <= lastElement)
        {
            counter++;
            mid = (firstElement + lastElement + 1) / 2;
            current = arr[mid];
            if (current == number)
            {
                index = mid;
                Console.WriteLine("{0} found in array for {1} rounds at position {2}",number,counter,index);
                break;
            }
            else if (current < number)
            {
                firstElement = mid + 1;
            }
            else
            {
                lastElement = mid - 1;
            }
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
    static void Main()
    {
        Console.Write("Enter length of array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter elements of array: ");
        ReadArray(arr);
        SortArray(arr);
        BinSearch(arr);
    } 
}
