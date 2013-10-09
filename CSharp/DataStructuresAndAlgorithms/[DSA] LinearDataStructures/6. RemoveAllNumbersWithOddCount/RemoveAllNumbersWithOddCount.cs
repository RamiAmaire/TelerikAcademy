using System;
using System.Collections.Generic;

public class RemoveAllNumbersWithOddCount
{
    private static List<int> RemoveOddCountNumbers(List<int> numbers)
    {
        List<int> visited = new List<int>();

        int counter;
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            counter = 1;
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    counter++;
                }
            }

            int oddNumber = numbers[i];
            if (counter % 2 != 0 && !visited.Contains(oddNumber))
            {
                numbers.RemoveAll(x => x == oddNumber);
                i = -1;
            }
            else
            {
                visited.Add(oddNumber);
            }
        }

        return numbers;
    }

    private static void PrintNumbers(List<int> numbers)
    {
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
        List<int> numbers = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
        numbers = RemoveOddCountNumbers(numbers);
        PrintNumbers(numbers);
    }
}
