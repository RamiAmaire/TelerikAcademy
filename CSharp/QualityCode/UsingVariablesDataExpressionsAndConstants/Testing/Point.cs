using System;

/// <summary>
/// Makes an instance of an object called Size,
/// with width and height properties for measuring.
/// </summary>
public class Point
{
    // Fields
    private double width = 0;
    private double height = 0;

    // Constructors
    public Point(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    // Properties
    public double Width
    {
        get
        {
            return this.width;
        }

        set
        {
            if (value < 0 || value > double.MaxValue)
            {
                throw new ArgumentException(
                    "Width value is out of range");
            }

            this.width = value;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }

        set
        {
            if (value < 0 || value > double.MaxValue)
            {
                throw new ArgumentException(
                    "Height value is out of range");
            }

            this.height = value;
        }
    }
}
