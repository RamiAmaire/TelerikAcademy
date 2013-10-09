using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class RemoveElemIncrOrder
{
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
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Console.WriteLine("Enter elements of array: ");
        ReadArray(arr);
        int[] length = new int[n];
        int[] position = new int[n];
        int maxLength = 0;
        int bestEnd = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            length[i] = 1;
            position[i] = -1;
            for (int j = i - 1; j >= 0; j--)
            {
                if ((length[j] + 1 > length[i]) && (arr[j] <= arr[i]))
                {
                    length[i] = length[j] + 1;
                    position[i] = j;
                }
            }
            if (length[i] > maxLength)
            {
                bestEnd = i;
                maxLength = length[i];
            }
        }
        int[] result = new int[maxLength];
        int y = maxLength - 1;
        while (bestEnd != -1)
        {
            result[y] = arr[bestEnd];
            bestEnd = position[bestEnd];
            y--;
        }
        Console.Write("Result: {");
        for (int i = 0; i < result.Length; i++)
        {
            if (i<result.Length-1)
            {
                Console.Write(result[i] + ",");
            }
            else
            {
                Console.Write(result[i]);
            }
        }
        Console.WriteLine();
    }
}
