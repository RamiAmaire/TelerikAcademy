using System;

/// <summary>
///     I make this class for more appropriate use of the method 
///     "CalcDistanceBetweenTwoPoints" in the Method.cs file.
/// </summary>
public class Point
{
    private double x = 0;
    private double y = 0;

    public Point(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public double X 
    {
        get
        {
            return this.x;
        }

        set
        {
            if (value < double.MinValue || value > double.MaxValue)
            {
                throw new ArgumentException("Variable x is out of the appropriate range");
            }

            this.x = value;
        }
    }

    public double Y 
    {
        get
        {
            return this.y;
        }

        set
        {
            if (value < double.MinValue || value > double.MaxValue)
            {
                throw new ArgumentException("Variable y is out of the appropriate range");
            }

            this.y = value;
        }
    }
}
