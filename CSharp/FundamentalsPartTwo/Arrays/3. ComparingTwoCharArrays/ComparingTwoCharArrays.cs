using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class ComparingTwoCharArrays
{
    static void ReadArray(char[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("arr[{0}]= ", i);
            arr[i] = char.Parse(Console.ReadLine());
        }
    }
    static void ComparingArrays(int lengthMax, char[] arrOne, char[] arrTwo)
    {
        int counter = 0;
        for (int i = 0; i < lengthMax; i++)
        {
            if (arrOne.Length < lengthMax)
            {
                Console.WriteLine("arrayOne is shorter");
                return;
            }
            if (arrTwo.Length < lengthMax)
            {
                Console.WriteLine("arrayTwo is shorter");
                return;
            }
            if (arrOne[i] != arrTwo[i])
            {
                if ((int)arrOne[i] < (int)arrTwo[i])
                {
                    Console.WriteLine("arrayOne is shorter");
                    return;
                }
                else
                {
                    Console.WriteLine("arrayTwo is shorter");
                    return;
                }
            }
            if (arrOne[i] == arrTwo[i])
            {
                counter++;
                if (counter == arrOne.Length)
                {
                    if ((int)arrOne[i] < (int)arrTwo[i])
                    {
                        Console.WriteLine("arrayOne is shorter");
                        return;
                    }
                    if ((int)arrOne[i] > (int)arrTwo[i])
                    {
                        Console.WriteLine("arrayTwo is shorter");
                        return;
                    }
                    if ((int)arrOne[i] == (int)arrTwo[i])
                    {
                        Console.WriteLine("arrayOne = arrayTwo");
                        return;
                    }
                }
            }
        }
    }
    static void Main()
    {
        Console.Write("Enter length for arrayOne: ");
        int lenOne = int.Parse(Console.ReadLine());
        Console.Write("Enter length for arrayTwo: ");
        int lenTwo = int.Parse(Console.ReadLine());
        char[] arrayOne = new char[lenOne];
        char[] arrayTwo = new char[lenTwo];
        int lengthMax = Math.Max(lenOne, lenTwo);
        Console.WriteLine("Enter elements for first array: ");
        ReadArray(arrayOne);
        Console.WriteLine("Enter elements for second array: ");
        ReadArray(arrayTwo);
        Console.WriteLine("Result: ");
        ComparingArrays(lengthMax, arrayOne, arrayTwo);
    }
}
