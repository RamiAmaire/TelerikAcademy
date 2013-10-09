using System;
using System.Collections.Generic;

public class Demo
{
    private static void Swap(ref int first, ref int second)
    {
        int oldFirst = first;
        first = second;
        second = oldFirst;
    }

    private static void SavePermutations(int[] numbers, ref HashSet<int> permutations)
    {
        string number = string.Empty;
        for (int i = 0; i < numbers.Length; i++)
        {
            number += numbers[i].ToString();
            if (i == numbers.Length - 1)
            {
                permutations.Add(int.Parse(number));
            }
        }
    }

    private static void GeneratePermutations(int[] numbers, int currentIndex, ref HashSet<int> permutations)
    {
        if (currentIndex >= numbers.Length)
        {
            SavePermutations(numbers, ref permutations);
        }
        else
        {
            GeneratePermutations(numbers, currentIndex + 1, ref permutations);
            for (int i = currentIndex + 1; i < numbers.Length; i++)
            {
                Swap(ref numbers[currentIndex], ref numbers[i]);
                GeneratePermutations(numbers, currentIndex + 1, ref permutations);
                Swap(ref numbers[currentIndex], ref numbers[i]);
            }
        }
    }

    private static int[] SaveNumbers(int lines)
    {
        int[] numbers = new int[lines];
        for (int i = 0; i < lines; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        return numbers;
    }

    private static int GetTheNumberWithLeastDividers(HashSet<int> numbers)
    {
        int num = 0;
        int minDivider = int.MaxValue;

        foreach (var number in numbers)
        {
            int dividers = CountDividers(number);
            if (dividers < minDivider)
            {
                minDivider = dividers;
                num = number;
            }
        }

        return num;
    }

    private static int CountDividers(int number)
    {
        int counter = 0;
        for (int i = 1; i <= number; i++)
        {
            if (number % i == 0)
            {
                counter++;
            }
        }

        return counter;
    }

    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        int[] numbers = SaveNumbers(lines);

        if (numbers.Length == 1)
        {
            Console.WriteLine(numbers[0]);
        }
        else
        {
            HashSet<int> permutations = new HashSet<int>();
            GeneratePermutations(numbers, 0, ref permutations);
            int number = GetTheNumberWithLeastDividers(permutations);
            Console.WriteLine(number);
        }
    }
}

