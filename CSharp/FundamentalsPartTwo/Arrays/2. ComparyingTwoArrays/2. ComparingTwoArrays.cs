using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ComparingTwoArrays
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
        Console.Write("Enter length for 1st Array: ");
        int lenOne = int.Parse(Console.ReadLine());
        Console.Write("Enter length for 2nd Array: ");
        int lenTwo = int.Parse(Console.ReadLine());
        int[] arrayOne = new int[lenOne];
        int[] arrayTwo = new int[lenTwo];
        if (lenOne > lenTwo)
        {
            Console.WriteLine("arrayOne!=arrayTwo");
            return;
        }
        if (lenTwo > lenOne)
        {
            Console.WriteLine("arrayOne!=arrayTwo");
            return;
        }
        if (lenOne == lenTwo)
        {
            int counter = 0;
            Console.WriteLine("Enter elements for first array: ");
            ReadArray(arrayOne);
            Console.WriteLine("Enter elements for second array: ");
            ReadArray(arrayTwo);
            for (int i = 0; i < arrayOne.Length; i++)
            {
                if (arrayOne[i] == arrayTwo[i])
                {
                    counter++;
                }
            }
            Console.WriteLine("Result: ");
            if (counter == arrayOne.Length)
            {
                Console.WriteLine("arrayOne=arrayTwo");
                return;
            }
            else
            {
                Console.WriteLine("arrayOne!=arrayTwo");
                return;
            }
        }
    }
}
