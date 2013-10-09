using System;
using System.Collections.Generic;
using System.Linq;

public class Demo
{
    private static string[] GetWordsCaseInsensitive(string text)
    {
        text = text.ToLower();
        string[] words = text.Split(
            new string[]{" ", ",", ".", "?", "!", "-"},
            StringSplitOptions.RemoveEmptyEntries);
        return words;
    }

    private static Dictionary<string, int> SaveOccurences(string[] arr)
    {
        Dictionary<string, int> occurencesHolder = new Dictionary<string, int>();

        foreach (var item in arr)
        {
            if (occurencesHolder.ContainsKey(item))
            {
                occurencesHolder[item]++;
            }
            else
            {
                occurencesHolder[item] = 1;
            }
        }

        return occurencesHolder;
    }

    private static Dictionary<string, int> OrderByOccurences(Dictionary<string, int> wordOccurences)
    {
        var ordered = wordOccurences.OrderByDescending(x => x.Value);
        Dictionary<string, int> orderedByValue = ordered.ToDictionary(x => x.Key, x => x.Value);
        return orderedByValue;
    }

    private static void Print(Dictionary<string, int> dic)
    {
        foreach (var keyValue in dic)
        {
            Console.WriteLine("{0} -> {1}", keyValue.Key, keyValue.Value);
        }
    }

    public static void Main()
    {
        string text = "This is the TEXT. Text, text, text - THIS TEXT! Is this the text?";
        string[] words = GetWordsCaseInsensitive(text);
        Dictionary<string, int> wordOccurences = SaveOccurences(words);
        Dictionary<string, int> orderedByOcc = OrderByOccurences(wordOccurences);
        Print(orderedByOcc);
    }
}
