using System;
using System.Collections.Generic;

public class Demo
{
    private static void PrintOccurences(Dictionary<double, int> numbersOccurencesHolder)
    {
        foreach (var keyValue in numbersOccurencesHolder)
        {
            Console.WriteLine("Key {0} -> {1} occurences.", keyValue.Key, keyValue.Value);
        }
    }

    private static Dictionary<double, int> SaveOccurences(double[] arr)
    {
        Dictionary<double, int> numbersOccurencesHolder = new Dictionary<double, int>();

        foreach (var number in arr)
        {
            if (numbersOccurencesHolder.ContainsKey(number))
            {
                numbersOccurencesHolder[number]++;
            }
            else
            {
                numbersOccurencesHolder[number] = 1;
            }
        }

        return numbersOccurencesHolder;
    }

    public static void Main()
    {
        double[] numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

        Dictionary<double, int> numbersOccurencesHolder = SaveOccurences(numbers);
        PrintOccurences(numbersOccurencesHolder);
    }
}

