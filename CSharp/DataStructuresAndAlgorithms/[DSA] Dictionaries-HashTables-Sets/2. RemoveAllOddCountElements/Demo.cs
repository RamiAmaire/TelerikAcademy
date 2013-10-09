using System;
using System.Collections.Generic;
using System.Linq;

public class Demo
{
    private static Dictionary<string, int> SaveWordsCount(string[] words)
    {
        Dictionary<string, int> wordsCountHolder = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (wordsCountHolder.ContainsKey(word))
            {
                wordsCountHolder[word]++;
            }
            else
            {
                wordsCountHolder[word] = 1;
            }
        }

        return wordsCountHolder;
    }

    private static List<string> GetAllOddCountWords(Dictionary<string, int> wordsCountHolder)
    {
        List<string> oddCountWords = new List<string>();
        Dictionary<string, int> oddWords = wordsCountHolder.Where(x => x.Value % 2 != 0).ToDictionary(x => x.Key, x => x.Value);
        oddCountWords = oddWords.Keys.ToList();
        return oddCountWords;
    }

    public static void Main()
    {
        string[] words = new string[] {"C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
        Dictionary<string, int> wordsCountHolder = SaveWordsCount(words);
        GetAllOddCountWords(wordsCountHolder);
        List<string> oddCountWords = GetAllOddCountWords(wordsCountHolder);
    }
}
