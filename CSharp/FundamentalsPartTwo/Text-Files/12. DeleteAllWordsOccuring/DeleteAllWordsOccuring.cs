using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class DeleteAllWordsOccuring
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
            for (int i = 0; i < words.Count; i++)
            {
                for (int j = 0; j < text.Count; j++)
                {
                    if (words[i] == text[j])
                    {
                        text.Remove(words[i]);
                    }
                }
            }
            StreamWriter writer = new StreamWriter(File.Open(@"D:\text.txt", FileMode.Create));
            using (writer)
            {
                int i = 0;
                while (i < text.Count)
                {
                    writer.WriteLine(text[i]);
                    i++;
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
