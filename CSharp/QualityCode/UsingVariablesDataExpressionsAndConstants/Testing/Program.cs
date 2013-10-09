using System;

public class Program
{
    /// <summary> 
    /// Gets rotated point.
    /// </summary>
    /// <param name="point">The Point.</param>
    /// <param name="angle">The angle.</param>
    /// <returns>The rotated point. </returns>
    public static Point GetRotatedPoint(Point point, double angle)
    {
        double rotatedWidth = (Math.Abs(Math.Cos(angle)) * point.Width) +
            (Math.Abs(Math.Sin(angle)) * point.Height);

        double rotatedHeight = (Math.Abs(Math.Sin(angle)) * point.Width) +
            (Math.Abs(Math.Cos(angle)) * point.Height);

        return new Point(rotatedWidth, rotatedHeight);
    }

    private static void Main()
    {
        Point xy = new Point(5, 7);

        Point rotatedXy = GetRotatedPoint(xy, 90);
        Console.WriteLine("Width : " + rotatedXy.Width);
        Console.WriteLine("Height : " + rotatedXy.Height);
    }
}
