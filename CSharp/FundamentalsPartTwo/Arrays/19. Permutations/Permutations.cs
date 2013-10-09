using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Permutations
{
    static void Perm(int[] array, int left, int right)
    {
        if (left == right)
        {
            Print(array);
        }
        else
        {
            for (int i = left; i <= right; i++)
            {
                Swap(ref array[left], ref array[i]);
                Perm(array, left + 1, right);
                Swap(ref array[left], ref array[i]);
            }
        }
    }
    static void Swap(ref int numberOne, ref int numberTwo)
    {
        int temp = numberOne;
        numberOne = numberTwo;
        numberTwo = temp;
    }
    static void Print(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
        }
        Console.WriteLine();
    }
    static void Read(int[] arr)
    {
        int index = -1;
        for (int i = 1; i <= arr.Length; i++)
        {
            index++;
            arr[index] = i;
        }
    }
    static void Main()
    {
        Console.Write("Enter N= ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Read(array);
        Perm(array, 0, array.Length - 1);
    }
}
