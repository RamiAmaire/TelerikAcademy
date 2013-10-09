using System;

public class Demo
{
    private static void GenerateVariations(int[] numbers, int currentIndex)
    {
        if (currentIndex == numbers.Length)
        {
            PrintResult(numbers);
            // Instead of return here, you can always use else.
        }
        else
        {
            for (int i = 1; i <= numbers.Length; i++)
            {
                numbers[currentIndex] = i;
                GenerateVariations(numbers, currentIndex + 1);
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
        int n = 3;
        GenerateVariations(new int[n], 0);
    }
}

