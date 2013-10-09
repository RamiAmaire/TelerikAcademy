using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class CleanCode
{
    static void Main()
    {
        int lineCount = int.Parse(Console.ReadLine());
        StringBuilder code = new StringBuilder();
        bool inMultiLineComment = false;
        bool IsString = false;
        bool inMultilineString = false;
        bool inSingleQuotedString = false;
        for (int i = 1; i <= 9; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < line.Length; j++)
            {
                //string
                if (inMultilineString)
                {
                    if (line[j] == '"' && j + 1 < line.Length && line[j + 1] == '"')
                    {
                        code.Append("\"\"");
                        j++;
                        continue;
                    }
                }
                if (IsString)
                {
                    if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\"')
                    {
                        code.Append("\\\"");
                        j++;
                        continue;
                    }
                    if (line[j] == '\\' && j + 1 < line.Length && line[j + 1] == '\'')
                    {
                        code.Append("\\\'");
                        j++;
                        continue;
                    }
                    if (line[j] == '\"' && !inSingleQuotedString)
                    {
                        IsString = false;
                        inMultilineString = false;
                        code.Append('\"');
                        continue;
                    }
                    if (line[j] == '\'' && inSingleQuotedString)
                    {
                        IsString = false;
                        inSingleQuotedString = false;
                        code.Append('\'');
                        continue;
                    }
                    code.Append(line[j]);
                    continue;
                }
                // multiline comment
                if (!inMultiLineComment && j + 1 < line.Length && line[j] == '/' && line[j + 1] == '*')
                {
                    inMultiLineComment = true;
                    j++;
                    continue;
                }
                if (inMultiLineComment && j + 1 < line.Length && line[j] == '*' && line[j + 1] == '/')
                {
                    inMultiLineComment = false;
                    j++;
                    continue;
                }
                if (inMultiLineComment)
                {
                    continue;
                }
                // one line comment
                if (j + 1 < line.Length && line[j] == '/' && line[j + 1] == '/')
                {
                    break;
                }
                // string 
                if (line[j] == '@' && j + 1 < line.Length && line[j + 1] == '"')
                {
                    IsString = true;
                    inMultilineString = true;
                    j++;
                    code.Append("@\"");
                    continue;
                }
                if (line[j] == '"')
                {
                    IsString = true;
                }
                if (line[j] == '\'')
                {
                    IsString = true;
                    inSingleQuotedString = true;
                }
                code.Append(line[j]);
            }
            if (!inMultiLineComment)
            {
                code.AppendLine();
            }
        }
        string str = code.ToString();
        string[] separator = { "\n", "\r" };
        string[] result = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < result.Length; i++)
        {
            string temp = result[i];
            if (!string.IsNullOrWhiteSpace(temp))
            {
                Console.WriteLine(temp);
            }

        }
    }
}
