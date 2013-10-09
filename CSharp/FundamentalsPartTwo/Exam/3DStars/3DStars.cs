using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Stars3D
{
    static string[] separator = { " " };
    static int starsCount = 0;
    static int width, height, depth;
    static Dictionary<char, int> stars = new Dictionary<char, int>();
    static char[, ,] ReadCube(int width, int height, int depth)
    {

        char[, ,] cuboid = new char[width, height, depth];
        for (int h = 0; h < height; h++)
        {
            string[] lines = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < depth; d++)
            {
                string row = lines[d];
                for (int w = 0; w < width; w++)
                {
                    cuboid[w, h, d] = row[w];
                }
            }
        }
        return cuboid;
    }
    static void FindStar(char[, ,] cube, int w, int h, int d)
    {
        bool isStart = true;
        char currChar = cube[w, h, d];
        if ((cube[w + 1, h, d] == currChar) && (cube[w - 1, h, d] == currChar) && (cube[w, h + 1, d] == currChar)
            && (cube[w, h - 1, d] == currChar) && (cube[w, h, d + 1] == currChar) && (cube[w, h, d - 1] == currChar))
        {
            isStart = true;
            starsCount++;
        }
        if (isStart)
        {
            if (stars.ContainsKey(currChar))
            {
                stars[currChar]++;
            }
            else
            {
                stars.Add(currChar, 1);
            }
        }
    }
    static void Main()
    {
        string input = Console.ReadLine();
        string[] result = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        width = int.Parse(result[0]);
        height = int.Parse(result[1]);
        depth = int.Parse(result[2]);
        char[, ,] cube = ReadCube(width, height, depth);
        for (int w = 1; w < width - 1; w++)
        {
            for (int h = 1; h < height - 1; h++)
            {
                for (int d = 1; d < depth - 1; d++)
                {
                    FindStar(cube, w, h, d);
                }
            }
        }
        Console.WriteLine(starsCount);
        var sortStars = stars.OrderBy(x => x.Key);
        foreach (var star in sortStars)
        {
            Console.WriteLine("{0} {1}", star.Key, star.Value);
        }
    }
}
