using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Shape
{
    protected int width = 0;
    protected int height = 0;
    public int Width
    {
        get { return this.width; }
        set { this.width = value; }
    }
    public int Height
    {
        get { return this.height; }
        set { this.height = value; }
    }
    public Shape(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
    public abstract double CalculateSurface();
}
