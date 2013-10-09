using System;
using System.Collections.Generic;
using System.Linq;

public class GetSumAndAverage
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

    public static void Main()
    {
        List<int> numbers = SaveInput();
        Console.WriteLine("Sum = {0}", numbers.Sum());
        Console.WriteLine("Average = {0}", numbers.Average());
    }
}
