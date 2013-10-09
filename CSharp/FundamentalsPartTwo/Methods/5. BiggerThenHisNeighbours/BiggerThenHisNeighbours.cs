using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BiggerThenHisNeighbours
{
    static void CompareElement(int[] arr, int position)
    {
        if ((arr[position] > arr[position + 1]) && (arr[position] > arr[position - 1]))
        {
            Console.WriteLine("Element ({1}) at position ({0}) is bigger then his neighbours", position, arr[position]);
        }
        else
        {
            Console.WriteLine("Element ({1}) at position ({0}) is smaller then his neighbours", position, arr[position]);
        }
    }
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ",i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void Main()
    {
        Console.Write("Enter position= ");
        int position = int.Parse(Console.ReadLine());
        Console.Write("Enter length of array: ");
        int len = int.Parse(Console.ReadLine());
        int[] arr = new int [len];
        ReadArray(arr);
        CompareElement(arr, position);
    }
}
