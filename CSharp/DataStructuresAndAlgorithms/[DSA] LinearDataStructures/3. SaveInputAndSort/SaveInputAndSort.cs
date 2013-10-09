using System;
using System.Collections.Generic;

public class SaveInputAndSort
{
    private static List<int> SaveInput()
    {
        List<int> numbers = new List<int>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == string.Empty)
            {
                break;
            }
            else
            {
                numbers.Add(int.Parse(input));
            }
        }

        return numbers;
    }

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
        List<int> numbers = SaveInput();
        PrintNumbers(numbers, "Unsorted : ");
        numbers.Sort();
        PrintNumbers(numbers, "Sorted : ");
    }
}

