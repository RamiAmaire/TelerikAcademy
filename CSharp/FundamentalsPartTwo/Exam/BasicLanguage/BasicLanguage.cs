using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BasicLanguage
{
    static StringBuilder sb = new StringBuilder();
    static int count = 1;
    static bool GetCommands(string line)
    {
        if (line == "EXIT")
        {
            return true;
        }
        int index = line.IndexOf('(');
        string command = line.Substring(0, index);
        command = command.Trim();
        if (command == "PRINT")
        {
            string content = line.Substring(index + 1);
            for (int i = 0; i < count; i++)
            {
                sb.Append(content);
            }
            count = 1;
        }
        if (command == "FOR")
        {
            string content = line.Substring(index + 1);
            if (string.IsNullOrWhiteSpace(content))
            {
                return false;
            }
            if (content.Contains(","))
            {
                string[] result = content.Split(',');
                int a = int.Parse(result[0]);
                int b = int.Parse(result[1]);
                if (count != 1)
                {
                    count *= b - a + 1;
                }
                else
                {
                    count = b - a + 1;
                }
            }
            else
            {
                if (count != 1)
                {
                    count *= int.Parse(content);
                }
                else
                {
                    count = int.Parse(content);
                }
            }
        }
        return false;
    }
    static bool SecondSplit(string line)
    {
        string[] result = line.Split(')');
        for (int l = 0; l < result.Length; l++)
        {
            result[l].TrimStart();
            line = result[l];
            if (!string.IsNullOrWhiteSpace(line))
            {
                if (GetCommands(line))
                {
                    return true;
                }
            }
        }
        return false;
    }
    static void Main()
    {
        StringBuilder bodyBuilder = new StringBuilder();
        bool isInBrackets = false;
        string line = string.Empty;
        while (true)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    isInBrackets = true;
                }
                if (input[i] == ')')
                {
                    isInBrackets = false;
                }
                if (!isInBrackets)
                {
                    if (input[i] == ';')
                    {
                        continue;
                    }
                }
                if (!isInBrackets)
                {
                    if (input[i] == ' ')
                    {
                        continue;
                    }
                }
                bodyBuilder.Append(input[i]);
            }
            if (isInBrackets)
            {
                line += bodyBuilder.ToString();
                bodyBuilder.Clear();
                continue;
            }
            else
            {
                line += bodyBuilder.ToString();
                if (SecondSplit(line))
                {
                    string result = sb.ToString();
                    Console.WriteLine(result);
                    break;
                }
            }
            line = string.Empty;
            bodyBuilder.Clear();
        }
    }
}

