using System;
using System.Collections.Generic;
using System.Linq;

public class RemoveAllNegativeNumbers
{
    private static void PrintNumbers(List<int> numbers, string message)
    {
        Console.WriteLine(message);
        for (int i = 0; i < numbers.Count; i++)
        {
            if (i == numbers.Count - 1)
            {
                Console.WriteLine(numbers[i]);
            }
            else
            {
                Console.Write(numbers[i] + ", ");
            }
        }
    }

    public static void Main()
    {
        List<int> numbers = new List<int>() { 19, -10, 12, -6, -3, 34, -2, 5 };
        PrintNumbers(numbers, "All numbers : ");
        numbers.RemoveAll(x => x < 0);
        PrintNumbers(numbers, "Only positive numbers : ");
    }
}
