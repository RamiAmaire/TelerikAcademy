using System;

public class Demo
{
    static void PermuteRep(int[] numbers, int start, int n)
    {
        Print(numbers);

        for (int left = n - 2; left >= start; left--)
        {
            for (int right = left + 1; right < n; right++)
            {
                if (numbers[left] != numbers[right])
                {
                    Swap(ref numbers[left], ref numbers[right]);
                    PermuteRep(numbers, left + 1, n);
                }
            }

            // Undo all modifications done by the
            // previous recursive calls and swaps
            var firstElement = numbers[left];
            for (int i = left; i < n - 1; i++)
            {
                numbers[i] = numbers[i + 1];
            }

            numbers[n - 1] = firstElement;
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

    public static void Main()
    {
        int[] numbers = new int[] { 1, 3, 5, 5 };
        PermuteRep(numbers, 0, numbers.Length);
    }
}

