using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BiggerOr_1
{
    static void CompareElements(int[] arr)
    {
        for (int i = 1; i < arr.Length - 1; i++)
        {
            if ((arr[i] > arr[i + 1]) && (arr[i] > arr[i - 1]))
            {
                Console.WriteLine("Element ({0}) at position ({1})", arr[i], i);
                return;
            }
        }
        Console.WriteLine("-1");
    }
    static void ReadArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }
    static void Main()
    {
        Console.Write("Enter length of array: ");
        int len = int.Parse(Console.ReadLine());
        int[] arr = new int[len];
        ReadArray(arr);
        CompareElements(arr);
    }
}
