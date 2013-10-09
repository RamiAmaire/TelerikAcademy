using System;

public class Demo
{
    private static void GenPermutations(int[] numbers, int currentIndex)
    {
        if (currentIndex == numbers.Length)
        {
            Print(numbers);
        }
        else
        {
            for (int i = currentIndex; i < numbers.Length; i++)
            {
                Swap(ref numbers[currentIndex], ref numbers[i]);
                GenPermutations(numbers, currentIndex + 1);
                Swap(ref numbers[currentIndex], ref numbers[i]);
            }
        }
    }

    private static void Swap(ref int first, ref int second)
    {
        int oldFirst = first;
        first = second;
        second = oldFirst;
    }

    private static void Print(int[] numbers)
    {
        Console.WriteLine(string.Join(", ", numbers));
    }

    private static int[] AddNumbers(int start, int end)
    {
        int[] numbers = new int[end - start + 1];
        int numbersIndex = 0;
        for (int i = start; i <= end; i++)
        {
            numbers[numbersIndex++] = i;
        }

        return numbers;
    }

    public static void Main()
    {
        int n = 3;
        int[] numbers = AddNumbers(1, n);
        GenPermutations(numbers, 0);
    }
}
