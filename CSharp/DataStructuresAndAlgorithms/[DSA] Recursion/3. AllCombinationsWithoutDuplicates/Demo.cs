using System;

public class Demo
{
    private static void Generate(int[] numbers, int currentIndex, int start, int end)
    {
        if (currentIndex == numbers.Length)
        {
            PrintResult(numbers);
        }
        else
        {
            for (int i = start; i <= end; i++)
            {
                numbers[currentIndex] = i;
                Generate(numbers, currentIndex + 1, i + 1, end);
            }
        }
    }

    private static void PrintResult(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }

        Console.WriteLine();
    }

    public static void Main()
    {
        int end = 4;
        int start = 1;
        int len = 2;
        Generate(new int[len], 0, start, end);
    }
}
