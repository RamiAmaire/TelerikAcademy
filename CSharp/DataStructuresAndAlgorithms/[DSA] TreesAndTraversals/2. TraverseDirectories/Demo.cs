using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Demo
{
    public static void TraverseDirectories(DirectoryInfo directory)
    {
        try
        {
            FileInfo[] files = directory.GetFiles();
            PrintFiles(files);

            foreach (var dir in directory.GetDirectories())
            {
                TraverseDirectories(dir);
            }
        }

        catch (UnauthorizedAccessException)
        {
        }
    }

    public static void PrintFiles(FileInfo[] files)
    {
        StringBuilder result = new StringBuilder();
        foreach (var file in files)
        {
            if (CheckForExeFile(file))
            {
                result.AppendLine(file.Name);
            }
        }

        string exeFiles = result.ToString();
        if (exeFiles != string.Empty)
        {
            Console.WriteLine(exeFiles);
        }
    }

    private static bool CheckForExeFile(FileInfo file)
    {
        bool isExe = false;
        string name = file.Name;
        if (name.Length > 4)
        {
            string extension = name.Substring(name.Length - 4);
            extension = extension.Trim();
            isExe = extension == ".exe";
        }

        return isExe;
    }

    public static void Main()
    {
        string path = @"C:\WINDOWS";
        DirectoryInfo directory = new DirectoryInfo(path);
        TraverseDirectories(directory);
    }
}

