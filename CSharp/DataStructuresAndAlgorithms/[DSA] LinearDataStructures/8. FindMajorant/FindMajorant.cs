using System;
using System.Collections.Generic;

public class FindMajorant
{
    private static void PrintMajorant(List<int> numbers)
    {
        int counter;
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            counter = 1;
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[i] == numbers[j])
                {
                    counter++;
                    if (counter > numbers.Count / 2)
                    {
                        Console.WriteLine("The majorant is : {0}", numbers[i]);
                        return;
                    }
                }
            }
        }

        Console.WriteLine("The majorant does not exists !");
    }

    public static void Main()
    {
        List<int> numbers = new List<int>() { 3, 2, 3, 1, 2, 3, 2, 3, 3 };
        PrintMajorant(numbers);
    }
}
