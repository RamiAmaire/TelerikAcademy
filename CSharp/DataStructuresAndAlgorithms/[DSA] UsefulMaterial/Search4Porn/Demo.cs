using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Demo
{
    private static void TraverseDirectories(DirectoryInfo directory, string[] searchedWords)
    {
        try
        {
            FileInfo[] files = directory.GetFiles();
            PrintFiles(files, searchedWords);

            foreach (var dir in directory.GetDirectories())
            {
                TraverseDirectories(dir, searchedWords);
            }
        }

        catch (UnauthorizedAccessException)
        {
        }
    }

    private static void PrintFiles(FileInfo[] files, string[] searchedWords)
    {
        if (files.Length > 0)
        {
            StringBuilder result = new StringBuilder();
            foreach (var file in files)
            {
                if (CheckForPornFile(file, searchedWords))
                {
                    result.AppendLine(file.Name);
                }
            }

            string pornFile = result.ToString();
            if (pornFile != string.Empty)
            {
                Console.WriteLine(pornFile);
            }
        }
    }

    private static bool CheckForPornFile(FileInfo file, string[] searchedWords)
    {
        bool isPorn = false;
        string fileName = file.Name.ToLower();

        foreach (var word in searchedWords)
        {
            if (fileName.Contains(word))
            {
                isPorn = true;
            }
        }
        
        return isPorn;
    }

    public static void Main()
    {
        string[] searchedWords = new string[] { "porn", "xxx", "tits", "cock", "pussy" };
        string path = @"E:\";
        DirectoryInfo directory = new DirectoryInfo(path);
        TraverseDirectories(directory, searchedWords);
    }
}

