using System;
using System.Collections.Generic;

public class Demo
{
    private static void SaveAllNonRepeatingCombinations(int[] combination, List<int[]> allCombinations,
        int from, int to, int currentIndex)
    {
        if (currentIndex == combination.Length)
        {
            var currentCombination = new int[combination.Length]; 
            combination.CopyTo(currentCombination, 0);
            allCombinations.Add(currentCombination);
        }
        else
        {
            for (int i = from; i <= to; i++)
            {
                combination[currentIndex] = i;
                SaveAllNonRepeatingCombinations(combination, allCombinations, i + 1, to, currentIndex + 1);
            }
        }
    }

    private static void PrintAllCombinations(List<int[]> allCombinations)
    {
        foreach (var combination in allCombinations)
        {
            foreach (var number in combination)
            {
                Console.Write(number);
            }

            Console.WriteLine();
        }
    }

    public static void Main()
    {
        int combinationsLen = 3;
        int from = 4;
        int to = 8;
        List<int[]> allNonRepeatingCombinations = new List<int[]>();
        SaveAllNonRepeatingCombinations(new int[combinationsLen], allNonRepeatingCombinations, from, to, 0);
        PrintAllCombinations(allNonRepeatingCombinations);
    }
}

