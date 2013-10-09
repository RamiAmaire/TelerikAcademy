using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

static class PathStorage
{
    static private List<Point3D> points = new List<Point3D>();
    public static List<Point3D> Points
    {
        get { return points; }
    }
    static public void GetPoints()
    {
        string path = @"c:\documents and settings\rami\my documents\visual studio 2010\Homework\ClassesHomeworkPartTwo\4.Point3D\Paths.txt";
        try
        {
            StreamReader reader = new StreamReader(path);
            using (reader)
            {
                string line = reader.ReadLine();
                ParsePoints(line);
                while (!string.IsNullOrEmpty(line))
                {
                    line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                    ParsePoints(line);
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    static private void ParsePoints(string line)
    {
        string[] separator = { "," };
        string[] result = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        SavePoints(result);
    }
    static private void SavePoints(string[] result)
    {
        Point3D point = new Point3D(Convert.ToInt32(result[0]), Convert.ToInt32(result[1]), Convert.ToInt32(result[2]));
        points.Add(point);
    }
}
