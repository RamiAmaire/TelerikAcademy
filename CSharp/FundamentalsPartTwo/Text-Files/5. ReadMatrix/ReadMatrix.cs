using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class ReadMatrix
{
    static void Main()
    {
        try
        {
            StreamReader reader = new StreamReader(@"D:\newfile.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                int n = Convert.ToInt32(line);
                string[] number = new string[n * n];
                int i = 0;
                while (line != null)
                {
                    line = reader.ReadLine();
                    number[i] = line;
                    i++;
                }
                string[] separator = { " " };
                string temp = "";
                for (int j = 0; j < number.Length; j++)
                {
                    temp += number[j] + " ";
                }
                string[] res = (temp.Split(separator, StringSplitOptions.RemoveEmptyEntries));
                int[,] matrix = new int[n, n];
                int k = 0;
                for (int x = 0; x < n; x++)
                {
                    for (int y = 0; y < n; y++)
                    {
                        matrix[x, y] = Convert.ToInt32(res[k++]);
                    }
                }
                int sum = 0;
                int bestsum = int.MinValue;
                for (int row = 0; row < n - 1; row++)
                {
                    for (int col = 0; col < n - 1; col++)
                    {
                        sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                        if (sum > bestsum)
                        {
                            bestsum = sum;
                        }
                    }
                }
                StreamWriter writer = new StreamWriter(File.Open(@"D:\bestsum.txt", FileMode.Create));
                using (writer)
                {
                    writer.Write("Bestsum= {0}", bestsum);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
