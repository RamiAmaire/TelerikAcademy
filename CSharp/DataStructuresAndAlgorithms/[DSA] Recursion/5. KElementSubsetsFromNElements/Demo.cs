using System;

public class Demo
{
    private static void Generate(string[] set, string[] combinations, int startIndex)
    {
        if (startIndex == combinations.Length)
        {
            Print(combinations);
        }
        else
        {
            for (int i = 0; i < set.Length; i++)
            {
                combinations[startIndex] = set[i];
                Generate(set, combinations, startIndex + 1);
            }
        }
    }

    private static void Print(string[] combinations)
    {
        Console.WriteLine(string.Join(", ", combinations));
    }

    public static void Main()
    {
        string[] set = new string[] { "hi", "a", "b" };
        int len = 2;
        Generate(set, new string[len], 0);
    }
}

