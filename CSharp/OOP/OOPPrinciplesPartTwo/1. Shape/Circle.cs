using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Circle : Shape
{
    public new int Height
    {
        get { return this.height; }
        set { this.height = this.width; }
    }
    public Circle(int width, int height)
        :base(width,height)
    {
        this.width = width;
        this.height = this.width;
    }
    public override double CalculateSurface()
    {
        double value = Math.PI * this.width * this.width;
        return (double)value;
    }
}
