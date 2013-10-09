using System;
using System.Collections.Generic;

public class FindLongestSequanceOfEqualElements
{
    private static List<int> GetLongestEqualSequence(List<int> numbers)
    {
        List<int> sequence = new List<int>();
        int counter = 0;
        int maxCounter = 0;

        for (int i = 0; i < numbers.Count - 1; i++)
        {
            if (numbers[i] == numbers[i + 1])
            {
                counter++;
                if (counter > maxCounter)
                {
                    maxCounter = counter;
                    sequence = SaveSequence(numbers, i - maxCounter, i);
                }
            }
            else
            {
                counter = 0;
            }
        }

        return sequence;
    }

    private static List<int> SaveSequence(List<int> numbers, int start, int end)
    {
        List<int> sequence = new List<int>();
        for (int i = start + 1; i <= end + 1; i++)
        {
            sequence.Add(numbers[i]);
        }

        return sequence;
    }

    public static void Main()
    {
        List<int> numbers = new List<int> { 1, 3, 5, 5, 5, 5, 5, 7, 8, 8, 8, 8, 9, 9, 19 };
        List<int> longestSequence = GetLongestEqualSequence(numbers);
    }
}
