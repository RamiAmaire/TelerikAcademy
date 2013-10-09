using System;
using System.Collections.Generic;

public class FindingShortestSequence
{
    private static void CheckForEnd(
        List<int> container, int[] sequence, int sum, int len, int containerIndex, int sequenceIndex)
    {
        if (sequenceIndex == len)
        {
            if (CheckForSum(sequence, sum))
            {
                PrintSequence(sequence, sum);
                foundNumber = true;
            }
        }
        else
        {
            for (; containerIndex < container.Count; containerIndex++)
            {
                sequence[sequenceIndex] = container[containerIndex];
                CheckForEnd(container, sequence, sum, len, containerIndex + 1, sequenceIndex + 1);
            }
        }
    }

    private static void PrintSequence(int[] sequence, int sum)
    {
        for (int i = 0; i < sequence.Length; i++)
        {
            if (i == sequence.Length - 1)
            {
                Console.WriteLine(sequence[i] + " = " + sum);
            }
            else
            {
                Console.Write(sequence[i] + " -> ");

            }
        }
    }

    private static bool CheckForSum(int[] sequence, int sum)
    {
        int s = 0;
        for (int i = 0; i < sequence.Length; i++)
        {
            s += sequence[i];
        }

        return s == sum;
    }

    static bool foundNumber = false;
    public static void Main()
    {
        int startingNumber = 5;
        Queue<int> numbers = new Queue<int>();
        numbers.Enqueue(startingNumber);

        List<int> container = new List<int>();
        int searchedNumber = 16;
        while (numbers.Count > 0)
        {
            int sequenceLen = 1;
            int currentNumber = numbers.Dequeue();
            container.Add(currentNumber);

            numbers.Enqueue(currentNumber + 1);
            numbers.Enqueue(currentNumber + 2);
            numbers.Enqueue(currentNumber * 2);

            while (sequenceLen <= container.Count)
            {
                CheckForEnd(container, new int[sequenceLen], searchedNumber, sequenceLen, 0, 0);
                if (foundNumber)
                {
                    break;
                }

                sequenceLen++;
            }

            if (foundNumber)
            {
                break;
            }
        }
    }
}

