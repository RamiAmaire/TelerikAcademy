using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class WordsTestResult
{
    static void Main()
    {
        try
        {
            StreamReader readerWords = new StreamReader(@"D:\words.txt");
            string[] resultWords;
            string[] resultText;
            string[] separator = { " ", ".", ",", "\n" };
            using (readerWords)
            {
                string result = "";
                string line = readerWords.ReadLine();
                while (line != null)
                {
                    result += " " + line;
                    line = readerWords.ReadLine();
                }
                resultWords = result.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            }
            StreamReader readerText = new StreamReader(@"D:\text.txt");
            using (readerText)
            {
                string result = "";
                string line = readerText.ReadLine();
                while (line != null)
                {
                    result += " " + line;
                    line = readerText.ReadLine();
                }
                resultText = result.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            }
            List<string> words = new List<string>();
            List<string> text = new List<string>();
            words = resultWords.ToList();
            text = resultText.ToList();
            var dictionary = new Dictionary<string, int>();
            int value;
            for (int i = 0; i < words.Count; i++)
            {
                dictionary.Add(words[i], 0);
            }
            for (int i = 0; i < text.Count; i++)
            {
                if (dictionary.TryGetValue(text[i], out value))
                {
                    dictionary[text[i]] = value + 1;
                }
            }
            var items = from pair in dictionary
                        orderby pair.Value descending
                        select pair;
            StreamWriter writer = new StreamWriter(File.Open(@"D:\result.txt", FileMode.Create));
            using (writer)
            {
                foreach (KeyValuePair<string, int> pair in items)
                {
                    writer.WriteLine("{0}: {1}", pair.Key, pair.Value);
                }
            }
        }
        catch (FieldAccessException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (PathTooLongException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (IOException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
