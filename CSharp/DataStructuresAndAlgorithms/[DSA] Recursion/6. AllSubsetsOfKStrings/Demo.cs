using System;

public class Demo
{
    private static void Generate(string[] words, string[] combinations, int startIndex, int start)
    {
        if (startIndex == combinations.Length)
        {
            Print(combinations);
        }
        else
        {
            for (int i = start; i < words.Length; i++)
            {
                combinations[startIndex] = words[i];
                Generate(words, combinations, startIndex + 1, i + 1);
            }
        }
    }

    private static void Print(string[] combinations)
    {
        Console.WriteLine(string.Join(", ", combinations));
    }

    public static void Main()
    {
        string[] words = new string[] { "test", "rock", "fun" };
        int len = 2;
        Generate(words, new string[len], 0, 0);
    }
}
