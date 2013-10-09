using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ArrayOf20Integers
{
    static void AssignArray(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            arr[i] = i * 5;
        }
    }
    static void WriteArray(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            Console.WriteLine("arr[{0}]= " + arr[i], i);
        }
    }
    static void Main()
    {
        int[] array = new int[21];
        AssignArray(array);
        WriteArray(array);
    }
}
